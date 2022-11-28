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
    public class RaceController : ControllerBase
    {
        IRaceLogic logic;




public RaceController(IRaceLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<RaceController>
        [HttpGet]
        public IEnumerable<Race> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<RaceController>/5
        [HttpGet("{id}")]
        public Race Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<RaceController>
        [HttpPost]
        public void Create([FromBody] Race value)
        {
            this.logic.Create(value);
        }

        // PUT api/<RaceController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Race value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<RaceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
