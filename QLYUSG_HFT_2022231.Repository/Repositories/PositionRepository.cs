using QLYUSG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Repository.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        RaceDbContext rdc;
        public PositionRepository(RaceDbContext rdc)
        {
            this.rdc = rdc;
        }


        public Position Read(int raceId, int teamId)
        {
            return rdc.Positions.FirstOrDefault(p => p.RaceId == raceId && p.TeamId == teamId);
        }


        public void Update(Position item)
        {
            var oldRace = item.RaceId;
            var oldTeam = item.TeamId;
            var oldPos = rdc.Positions.Find(item.RaceId, item.TeamId);
            foreach (var pos in item.GetType().GetProperties())
            {
                pos.SetValue(oldPos, pos.GetValue(item));
            }
            throw new NotImplementedException();
        }

        public void Create(Position item)
        {
            rdc.Set<Position>().Add(item);
            rdc.SaveChanges();
        }

        public void Delete(int raceId, int teamId)
        {
            rdc.Set<Position>().Remove(Read(raceId, teamId));
            rdc.SaveChanges();
        }

        public IQueryable<Position> ReadAll()
        {
            return rdc.Set<Position>();
        }

    }
}
