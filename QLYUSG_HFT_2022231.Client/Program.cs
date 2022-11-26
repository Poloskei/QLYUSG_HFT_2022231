using QLYUSG_HFT_2022231.Repository;
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

            //ar items = raceDb.Races.ToArray();

            foreach (var race in raceDb.Races)
            {
                Console.WriteLine(race.Name);
                foreach (var team in race.Teams)
                {
                    Console.WriteLine("\t"+team.Positions.FirstOrDefault(i => i.RaceId == race.Id).Result+" "+team.Name);
                }
            }
            
            
            
            
            ;
        }
    }
}
