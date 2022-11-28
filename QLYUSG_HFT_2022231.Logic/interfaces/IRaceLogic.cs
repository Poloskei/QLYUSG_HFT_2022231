using QLYUSG_HFT_2022231.Models;
using System.Linq;

namespace QLYUSG_HFT_2022231.Logic
{
    public interface IRaceLogic
    {
        void Create(Race item);
        void Delete(int id);
        Race Read(int id);
        IQueryable<Race> ReadAll();
        void Update(Race item);
        Team WinningTeam(Race r);
    }
}