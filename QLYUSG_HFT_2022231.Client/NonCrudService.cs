using QLYUSG_HFT_2022231.Models;
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

        public void GetTeamStats()
        {
            //var items = rest.Get<BrandStatistic>("Stat/ReadBrandStats");
            var items = rest.Get<TeamStatistics>("Stat/TeamStats");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void ChampionshipWinners()
        {
            var v = rest.GetSingle<int>("Stat/ChampionshipWinners");
            Console.WriteLine($"Champion team id: {v}");
            Console.ReadLine();
        }
        public void WinnerOfRace()
        {
            Console.WriteLine("which race?(id)");
            int raceId = int.Parse(Console.ReadLine());
            var item =  rest.GetSingle<int>($"Stat/WinnerOfRace/{raceId}");
            Console.WriteLine(item);
            Console.ReadLine();
        }
    }
}
