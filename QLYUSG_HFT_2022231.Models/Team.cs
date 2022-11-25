using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Models
{
    class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Car { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
