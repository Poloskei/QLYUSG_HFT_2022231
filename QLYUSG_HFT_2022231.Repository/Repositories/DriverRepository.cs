using QLYUSG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Repository
{
    public class DriverRepository : Repository<Driver>
    {
        public DriverRepository(RaceDbContext rdc) : base(rdc)
        {

        }
        public override Driver Read(int id)
        {
            return rdc.Drivers.FirstOrDefault(d => d.Id == id);
        }

        public override void Update(Driver item)
        {
            var old = item.Id;
            foreach (var property in item.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(item));
            }
            rdc.SaveChanges();
        }
    }
}
