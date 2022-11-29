using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Client
{
    class NonCrudService
    {
        private RestService rest;

        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }

        public void ReadTeamStats()
        {
            //var items = rest.Get<BrandStatistic>("Stat/ReadBrandStats");
            
        }
    }
}
