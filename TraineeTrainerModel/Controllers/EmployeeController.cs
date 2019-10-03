using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TraineeTrainerModel.Services;
using TraineeTrainerModel.Interfaces;
using TraineeTrainerModel.DAL;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmloyeeService _service;

        public EmployeeController(IDBServices database)
        {
            _service = new EmloyeeService(new EmployeeDAL(database));
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _service.Get() ?? (ActionResult<IEnumerable<Employee>>)StatusCode(404);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {
            return _service.Get(id) ?? (ActionResult<Employee>)StatusCode(404);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Employee value)
        {
            if (_service.Create(value))
                return StatusCode(201);
            return StatusCode(403);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Employee value)
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
