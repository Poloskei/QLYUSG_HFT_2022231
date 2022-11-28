using QLYUSG_HFT_2022231.Repository;
using QLYUSG_HFT_2022231.Logic;
using System;
using System.Linq;
using QLYUSG_HFT_2022231.Repository.Repositories;

namespace QLYUSG_HFT_2022231.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            RaceDbContext raceDb = new RaceDbContext();

            RaceRepository rr = new RaceRepository(raceDb);
            PositionRepository pr = new PositionRepository(raceDb);
            RaceLogic rl = new RaceLogic(rr,pr);
            Console.WriteLine(rl.WinningTeam(2));
            rl.Champions();
            ;
        }
    }
}
