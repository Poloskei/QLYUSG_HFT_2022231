﻿using QLYUSG_HFT_2022231.Models;
using QLYUSG_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Logic
{
    public class TeamLogic : ITeamLogic
    {
        IRepository<Team> team;

        public TeamLogic(IRepository<Team> team)
        {
            this.team = team;
        }
        //non cruds
        public double AvgAge(int tid)
        {
            Team t = team.ReadAll().FirstOrDefault(t => t.Id == tid);
            return t.Drivers.Average(d => d.Age);
        }
        public int PointsEarned(int tid)
        {
            Team t = team.ReadAll().FirstOrDefault(t => t.Id == tid);
            return t.Positions.Sum(p => p.Points);
        }
        public IEnumerable<TeamStatistics> TeamStats()
        {
            return team.ReadAll()
                       .Select(t => new TeamStatistics
                       {
                           Name = t.Name,
                           AverageAge = t.Drivers.Average(d => d.Age),
                           PointsEarned = PointsEarned(t.Id)
                       });
        }

        public Team OldestTeam()
        {
            return team.ReadAll().FirstOrDefault(t => AvgAge(t.Id) == team.ReadAll().Min(m => AvgAge(m.Id)));
        }







        //cruds

        public void Create(Team item)
        {
            if (item.Name == "")
            {
                throw new ArgumentException("Cannot create: Name empty");
            }
            team.Create(item);
        }

        public void Delete(int id)
        {
            if (!team.ReadAll().Any(t => t.Id == id))
            {
                throw new ArgumentException("this item doesn't exist or already deleted");
            }
            else team.Delete(id);
        }

        public IQueryable<Team> ReadAll()
        {
            return team.ReadAll();
        }

        public Team Read(int id)
        {
            return team.Read(id);
        }
        public void Update(Team item)
        {
            team.Update(item);
        }
    }
    
}
