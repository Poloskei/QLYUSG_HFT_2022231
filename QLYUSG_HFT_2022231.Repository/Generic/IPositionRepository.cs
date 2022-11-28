using QLYUSG_HFT_2022231.Models;
using System.Linq;

namespace QLYUSG_HFT_2022231.Repository.Repositories
{
    public interface IPositionRepository
    {
        void Create(Position item);
        void Delete(int raceId, int teamId);
        Position Read(int raceId, int teamId);
        IQueryable<Position> ReadAll();
        void Update(Position item);
    }
}