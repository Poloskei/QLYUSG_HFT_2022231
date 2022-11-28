using QLYUSG_HFT_2022231.Models;
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

        public int PointsEarned(Team t)
        {
            return t.Positions.Sum(p => p.Points); ;
        }
        public int RacesFinished(Team t)
        {
            return t.Positions.Count;
        }
        public double AvgFinishingPos(Team t)
        {
            return t.Positions.Average(p => p.Result);
        }
        //public Team Champions()
        //{
        //    return team.ReadAll().
        //}











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
            if (Read(id) == null)
            {
                throw new ArgumentException("this item doesn't exist");
            }
            team.Delete(id);
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
