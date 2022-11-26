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

            var items = raceDb.Races.ToArray();
            ;
        }
    }
}
