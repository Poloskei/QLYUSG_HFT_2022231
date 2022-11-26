using QLYUSG_HFT_2022231.Repository;
using QLYUSG_HFT_2022231.Logic;
using System;
using System.Linq;

namespace QLYUSG_HFT_2022231.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            RaceDbContext raceDb = new RaceDbContext();

            //var items = raceDb.Races.ToArray();
            //;
            //foreach (var race in raceDb.Races)
            //{
            //    Console.WriteLine(race.Name);
            //    foreach (var team in race.Teams)
            //    {
            //        Console.WriteLine("\t"+team.Positions.FirstOrDefault(i => i.RaceId == race.Id).Result+" "+team.Name);
            //    }
            //}
            RaceRepository rr = new RaceRepository(raceDb);
            RaceLogic rl = new RaceLogic(rr);
            TeamRepository tr = new TeamRepository(raceDb);
            TeamLogic tl = new TeamLogic(tr);
            foreach (var item in raceDb.Teams)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine("\tpoints earned: " +tl.PointsEarned(item));
            }
            Console.WriteLine("Champions: "+tl.Champions().Name);
            
            
            
            ;
        }
    }
}
