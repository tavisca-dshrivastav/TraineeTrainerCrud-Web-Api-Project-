using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TraineeTrainerModel.Services;
using TraineeTrainerModel.Interfaces;
using TraineeTrainerModel.Dal;
using TraineeTrainerModel.Models;
using System;
using TraineeTrainerModel.Services.Interface;


namespace TraineeTrainerModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController<T> : ControllerBase where T : class
    {
        
        private IService<T> _service;

        public EmployeeController(IService<T> service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<T>> Get()
        {
            try
            {
                return _service.Get();
            }
            catch
            {
                return (ActionResult<IEnumerable<T>>)StatusCode(404);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<T> Get(string id)
        {
            try
            {
                return (ActionResult<T>)_service.Get(id);
            }
            catch
            {
                return (ActionResult<T>)StatusCode(404);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] T value)
        {
            if (_service.Create(value))
                return StatusCode(201);
            return StatusCode(403);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] T value)
        {

            if (_service.Update(id, value))
                return StatusCode(200);
            return StatusCode(405);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (_service.DeleteById(id))
                return StatusCode(200);
            return StatusCode(405);
        }
    }

    
}
