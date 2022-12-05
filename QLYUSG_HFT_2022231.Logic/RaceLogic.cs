using QLYUSG_HFT_2022231.Models;
using QLYUSG_HFT_2022231.Repository;
using QLYUSG_HFT_2022231.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Logic
{
    public class RaceLogic : IRaceLogic
    {
        IRepository<Race> race;
        IPositionRepository positions;

        public RaceLogic(IRepository<Race> race, IPositionRepository positions)
        {
            this.race = race;
            this.positions = positions;
        }


        //non cruds
        public int WinningTeam(int raceId)
        {
            return positions.ReadAll().FirstOrDefault(p => p.RaceId == raceId && p.Result == 1).TeamId;
        }
        public int Champions()
        {
            var v = positions.ReadAll()
                             .GroupBy(p => p.TeamId).Select(s => new
                             {
                                 teamId = s.Key,
                                 pointsEarned = s.Sum(i => i.Points)
                             });
            return v.FirstOrDefault(p => p.pointsEarned == v.Max(i => i.pointsEarned)).teamId;
        }







        //cruds
        public void Create(Race item)
        {
            if (item.Name == "" || item.Id < 1)
            {
                throw new ArgumentException("cannot create: bad data");
            }
            race.Create(item);
        }

        public void Delete(int id)
        {
            if (Read(id) == null)
            {
                throw new ArgumentException("this item doesn't exist");
            }
            race.Delete(id);
        }

        public IQueryable<Race> ReadAll()
        {
            return race.ReadAll();
        }

        public Race Read(int id)
        {
            return race.Read(id);
        }
        public void Update(Race item)
        {
            race.Update(item);
        }

    }
}
