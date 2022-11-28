using QLYUSG_HFT_2022231.Models;
using QLYUSG_HFT_2022231.Repository;
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

        public RaceLogic(IRepository<Race> race)
        {
            this.race = race;
        }

        public Team WinningTeam(Race r)
        {
            return r.Positions.FirstOrDefault(p => p.Result == 1).Team;
        }









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
