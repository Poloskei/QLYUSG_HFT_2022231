using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Car { get; set; }
        [NotMapped]
        public virtual ICollection<Driver> Drivers { get; set; }
        [NotMapped][JsonIgnore]
        public virtual ICollection<Race> Races { get; set; }
        [NotMapped][JsonIgnore]
        public virtual ICollection<Position> Positions { get; set; }
        public Team()
        {
            Drivers = new HashSet<Driver>();
        }
    }

    public class TeamStatistics
    {
        public string Name { get; set; }
        public double AverageAge { get; set; }
        public int PointsEarned { get; set; }
        public override string ToString()
        {
            return $"Team name : {Name}, Average driver age: {Math.Round(AverageAge, 2)}, Points earned: {PointsEarned} ";
        }
    }
}
