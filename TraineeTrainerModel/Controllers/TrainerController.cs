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
    public class TrainerController : ControllerBase
    {
        private TrainerService _service;

        public TrainerController(IDBServices database)
        {
            _service = new TrainerService(new TrainerDAL(database));
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Trainer>> Get()
        {
            return _service.Get() ?? (ActionResult<IEnumerable<Trainer>>)StatusCode(404);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Trainer> Get(string id)
        {
            return _service.Get(id) ?? (ActionResult<Trainer>)StatusCode(404);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Trainer value)
        {
            if (_service.Create(value))
                return StatusCode(201);
            return StatusCode(403);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Trainer value)
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