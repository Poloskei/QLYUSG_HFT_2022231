using Microsoft.EntityFrameworkCore;
using QLYUSG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Repository
{
    public class RaceDbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Position> Positions { get; set; }

        public RaceDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("wec");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(e =>
            {
                e.HasOne(driver => driver.Team)
                .WithMany(team => team.Drivers)
                .HasForeignKey(driver => driver.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            //multiple teams compete on multiple races
            modelBuilder.Entity<Team>().HasMany(t => t.Races)
                .WithMany(r => r.Teams)
                .UsingEntity<Position>(
                    x => x.HasOne(x => x.Race).WithMany().HasForeignKey(x => x.RaceId).OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne(x => x.Team).WithMany().HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.Cascade)
                );

#region dbseed
            modelBuilder.Entity<Driver>().HasData(
                new Driver() { Age = 30, Name = "André Negrão",         Id = 1,TeamId=4},
                new Driver() { Age = 38, Name = "Nicolas Lapierre",     Id = 2,TeamId=4},
                new Driver() { Age = 27, Name = "Matthieu Vaxiviere",   Id = 3,TeamId=4},
                new Driver() { Age = 41, Name = "Olivier Pla",          Id = 4,TeamId=3},
                new Driver() { Age = 44, Name = "Romain Dumas",         Id = 5,TeamId=3},
                new Driver() { Age = 41, Name = "Ryan Briscoe",         Id = 6,TeamId=3},
                new Driver() { Age = 29, Name = "Luis Felipe Derani",   Id = 7,TeamId=3},
                new Driver() { Age = 36, Name = "Paul Di Resta",        Id = 8,TeamId=2},
                new Driver() { Age = 27, Name = "Mikkel Jensen",        Id = 9,TeamId=2},
                new Driver() { Age = 32, Name = "Jean-Eric Vergne",     Id = 10,TeamId=2},
                new Driver() { Age = 39, Name = "Mike Conway",          Id = 11,TeamId=1},
                new Driver() { Age = 36, Name = "Kamui Kobayashi",      Id = 12,TeamId=1},
                new Driver() { Age = 39, Name = "Jose Maria Lopez",     Id = 13,TeamId=1}
                );


            modelBuilder.Entity<Team>().HasData(
                new Team() { Id = 1, Name = "Toyota Gazoo Racing", Car = "GR010 Hybrid" },
                new Team() { Id = 2, Name = "Peugeot Totalenergies", Car = "9X8" },
                new Team() { Id = 3, Name = "Glickenhaus Racing", Car = "SCG0007" },
                new Team() { Id = 4, Name = "Alpine Elf Team", Car = "A480" }
                );


            modelBuilder.Entity<Race>().HasData(
                new Race() { Country="USA", Name="1000 miles of Sebring",       Id = 1},
                new Race() { Country="Belgium", Name="6 hours of Spa-Francorchamps", Id = 2},
                new Race() { Country="France", Name="24 hours of Le Mans",      Id = 3},
                new Race() { Country="Italy", Name="6 hours of Monza",          Id = 4},
                new Race() { Country="Japan", Name="6 hours of Fuji",          Id = 5},
                new Race() { Country="Bahrain", Name="8 hours of Bahrain",          Id = 6}
                );

            modelBuilder.Entity<Position>().HasData(
                //serbring
                new Position() { RaceId = 1, TeamId = 4, Result = 1, Points = 38 },
                new Position() { RaceId = 1, TeamId = 1, Result = 2, Points = 27 },
                new Position() { RaceId = 1, TeamId = 3, Result = 3, Points = 23 },
                
                //spa
                new Position() { RaceId = 1, TeamId = 1, Result = 1, Points = 25 },
                new Position() { RaceId = 1, TeamId = 4, Result = 2, Points = 18 },
                new Position() { RaceId = 1, TeamId = 3, Result = 9, Points = 15 },
               
                //lemans
                new Position() { RaceId = 3, TeamId = 1, Result = 1, Points = 50 },
                new Position() { RaceId = 3, TeamId = 3, Result = 3, Points = 30 },
                new Position() { RaceId = 3, TeamId = 4, Result = 23, Points = 24 },
              
                //monza
                new Position() { RaceId = 4, TeamId = 4, Result = 1, Points = 25 },
                new Position() { RaceId = 4, TeamId = 1, Result = 2, Points = 18 },
                new Position() { RaceId = 4, TeamId = 2, Result = 33, Points = 12 },
                new Position() { RaceId = 4, TeamId = 3, Result = 36, Points = 0 },
            
                //fuji
                new Position() { RaceId = 5, TeamId = 1, Result = 1, Points = 25 },
                new Position() { RaceId = 5, TeamId = 4, Result = 3, Points = 15 },
                new Position() { RaceId = 5, TeamId = 2, Result = 7, Points = 12 },
           
                //bahrain
                new Position() { RaceId = 6, TeamId = 1, Result = 1, Points = 38 },
                new Position() { RaceId = 6, TeamId = 4, Result = 3, Points = 23 },
                new Position() { RaceId = 6, TeamId = 2, Result = 4, Points = 18 }
                );
#endregion
        }

    }
}
