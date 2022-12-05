using ConsoleTools;
using QLYUSG_HFT_2022231.Models;
using System;
using System.Linq;

namespace QLYUSG_HFT_2022231.Client
{
    class Program
    {
        static RestService rest;
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            rest = new RestService("http://localhost:62624/","race");
            CrudService crud = new CrudService(rest);
            NonCrudService nc = new NonCrudService(rest);

            var raceSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Race>())
                .Add("Create", () => crud.Create<Race>())
                .Add("Delete", () => crud.Delete<Race>())
                .Add("Update", () => crud.Update<Race>())
                .Add("Winner of race", () => nc.WinnerOfRace())
                .Add("Exit", ConsoleMenu.Close);


            var teamSubMenu = new ConsoleMenu(args, level: 1)
            .Add("List", () => crud.List<Team>())
            .Add("Create", () => crud.Create<Team>())
            .Add("Delete", () => crud.Delete<Team>())
            .Add("Update", () => crud.Update<Team>())
            .Add("Team stats", nc.GetTeamStats)
            .Add("Champions", () => nc.ChampionshipWinners())
            .Add("Oldest Team", () => nc.OldestTeam())
            .Add("Exit", ConsoleMenu.Close);
            var driverSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Driver>())
                .Add("Create", () => crud.Create<Driver>())
                .Add("Delete", () => crud.Delete<Driver>())
                .Add("Update", () => crud.Update<Driver>())
                .Add("Youngest Driver", () => nc.YoungestDriver())
                .Add("List championship winners",() => nc.ListChampionDrivers())
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Races", () => raceSubMenu.Show())
                .Add("Team", () => teamSubMenu.Show())
                .Add("Drivers", () => driverSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
            ;
        }
    }
}
