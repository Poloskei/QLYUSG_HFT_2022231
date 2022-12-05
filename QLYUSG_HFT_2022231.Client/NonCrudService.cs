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
            var v = rest.GetSingle<Team>("Stat/ChampionshipWinners");
            Console.WriteLine($"Champion team: {v.Name} with {v.Car}");
            Console.ReadLine();
        }
        public void ListChampionDrivers()
        {
            var v = rest.GetSingle<Team>("Stat/ChampionshipWinners");
            foreach (var item in v.Drivers)
            {
                Console.WriteLine($"\t {item.Name}");
            }
            Console.ReadLine();

        }
        public void WinnerOfRace()
        {
            Console.WriteLine("which race?(id)");
            int raceId = int.Parse(Console.ReadLine());
            var item =  rest.GetSingle<Team>($"Stat/WinnerOfRace/{raceId}");
            Console.WriteLine(item.Name);
            Console.ReadLine();
        }
        public void YoungestDriver()
        {
            var driver = rest.GetSingle<Driver>($"Stat/YoungestDriver");
            Console.WriteLine(driver.Name+": "+driver.Age+" years old");
            Console.ReadLine();
        }
        public void OldestTeam()
        {
            var team = rest.GetSingle<Driver>($"Stat/OldestTeam");
            Console.WriteLine("Oldest team: "+team.Name);
            Console.ReadLine();
        }
    }
}
