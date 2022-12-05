using QLYUSG_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace QLYUSG_HFT_2022231.Logic
{
    public interface ITeamLogic
    {
        public Team OldestTeam();
        double AvgAge(int tid);
        void Create(Team item);
        void Delete(int id);
        int PointsEarned(int tid);
        Team Read(int id);
        IQueryable<Team> ReadAll();
        IEnumerable<TeamStatistics> TeamStats();
        void Update(Team item);
    }
}