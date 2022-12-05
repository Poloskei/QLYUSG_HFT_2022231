using Microsoft.AspNetCore.Mvc;
using QLYUSG_HFT_2022231.Logic;
using QLYUSG_HFT_2022231.Models;
using System.Collections.Generic;

namespace QLYUSG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IRaceLogic raceLogic;
        ITeamLogic teamLogic;
        IDriverLogic driverLogic;

        public StatController(IRaceLogic raceLogic, ITeamLogic teamLogic, IDriverLogic driverLogic)
        {
            this.raceLogic = raceLogic;
            this.teamLogic = teamLogic;
            this.driverLogic = driverLogic;
        }

        [HttpGet]
        public Driver YoungestDriver()
        {
            return this.driverLogic.YoungestDriver();
        }
        [HttpGet]
        public Team OldestTeam()
        {
            return this.teamLogic.OldestTeam();
        }

        [HttpGet("{raceId}")]
        public Team WinnerOfRace(int raceId)
        {
            return this.teamLogic.Read(this.raceLogic.WinningTeam(raceId));
        }

        [HttpGet]
        public Team ChampionshipWinners()
        {
            return this.teamLogic.Read(this.raceLogic.Champions());
            
        }

        [HttpGet]
        public IEnumerable<TeamStatistics> TeamStats()
        {
            return this.teamLogic.TeamStats();
        }

        
    }
}
