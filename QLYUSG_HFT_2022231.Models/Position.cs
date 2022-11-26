using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Models
{
    public class Position
    {
        public int RaceId { get; set; }
        public int TeamId { get; set; }
        public int Result { get; set; }
        public int Points { get; set; }
        
        public virtual Race Race { get; set; }
        public virtual Team Team { get; set; }

    }
}
