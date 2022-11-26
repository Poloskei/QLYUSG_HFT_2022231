using QLYUSG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Repository
{
    class TeamRepository : Repository<Team>
    {
        public TeamRepository(RaceDbContext rdc) : base(rdc)
        {

        }

        public override Team Read(int id)
        {
            return rdc.Teams.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Team item)
        {
            var old = Read(item.Id);
            foreach (var property in item.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(item));
            }
            rdc.SaveChanges();
        }
    }
}
