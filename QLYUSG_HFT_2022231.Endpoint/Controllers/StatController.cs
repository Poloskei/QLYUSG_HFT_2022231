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

        public StatController(IRaceLogic raceLogic, ITeamLogic teamLogic)
        {
            this.raceLogic = raceLogic;
            this.teamLogic = teamLogic;
        }

        [HttpGet("{raceId}")]
        public int WinnerOfRace(int raceId)
        {
            return this.raceLogic.WinningTeam(raceId);
        }

        [HttpGet]
        public int ChampionshipWinners()
        {
            return this.raceLogic.Champions();
        }

        [HttpGet]
        public IEnumerable<TeamStatistics> TeamStats()
        {
            return this.teamLogic.TeamStats();
        }

        
    }
}
