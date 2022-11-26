using QLYUSG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Repository
{
    class RaceRepository : Repository<Race>
    {
        public RaceRepository(RaceDbContext rdc) : base(rdc)
        {

        }

        public override Race Read(int id)
        {
            return rdc.Races.FirstOrDefault(r => r.RaceId == id);
        }

        public override void Update(Race item)
        {
            var old = item.RaceId;
            foreach (var property in item.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(item));
            }
            rdc.SaveChanges();
        }
    }
}
