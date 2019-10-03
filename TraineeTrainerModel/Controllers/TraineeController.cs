using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeTrainerModel.DAL;
using TraineeTrainerModel.Interfaces;
using TraineeTrainerModel.Models;
using TraineeTrainerModel.Services;

namespace TraineeTrainerModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private TraineeService _service;

        public TraineeController(IDBServices database)
        {
            _service = new TraineeService(new TraineeDAL(database));
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Trainee>> Get()
        {
            return _service.Get() ?? (ActionResult<IEnumerable<Trainee>>)StatusCode(404);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {
            return _service.Get(id) ?? (ActionResult<Employee>)StatusCode(404);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Trainee value)
        {
            if (_service.Create(value))
                return StatusCode(201);
            return StatusCode(403);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Trainee value)
        {

            if (_service.Update(id, value))
                return StatusCode(200);
            return StatusCode(405);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (_service.Delete(id))
                return StatusCode(200);
            return StatusCode(405);
        }
    }
}