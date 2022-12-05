using Microsoft.AspNetCore.Mvc;
using QLYUSG_HFT_2022231.Logic;
using QLYUSG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLYUSG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        ITeamLogic logic;

        public TeamController(ITeamLogic logic)
        {
            this.logic = logic;
        }


        // GET: api/<TeamController>
        [HttpGet]
        public IEnumerable<Team> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public Team Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<TeamController>
        [HttpPost]
        public void Create([FromBody] Team value)
        {
            this.logic.Create(value);
        }

        // PUT api/<TeamController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Team value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
