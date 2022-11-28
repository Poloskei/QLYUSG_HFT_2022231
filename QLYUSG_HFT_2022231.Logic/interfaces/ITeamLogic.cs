using QLYUSG_HFT_2022231.Models;
using System.Linq;

namespace QLYUSG_HFT_2022231.Logic
{
    public interface ITeamLogic
    {
        double AvgFinishingPos(Team t);
        void Create(Team item);
        void Delete(int id);
        int PointsEarned(Team t);
        int RacesFinished(Team t);
        Team Read(int id);
        IQueryable<Team> ReadAll();
        void Update(Team item);
    }
}