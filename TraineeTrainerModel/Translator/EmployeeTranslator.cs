using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.DTO;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.Translator
{
    public class EmployeeTranslator
    {
        public EmployeeDTO Translate(Employee employee)
        {
            var emp = new EmployeeDTO
            {
                ID = employee.ID,
                Name = employee.Name,
                Designation = employee.Designation,
                Email = employee.Designation,
                Phone = employee.Phone
            };
            return emp;
        }
        public Employee Translate(EmployeeDTO employee)
        {
            var emp = new Employee
            {
                ID = employee.ID,
                Name = employee.Name,
                Designation = employee.Designation,
                Email = employee.Designation,
                Phone = employee.Phone
            };
            return emp;
        }
        public EmployeeDTO Get(Trainer trainer)
        {
            var t = new EmployeeDTO
            {
                ID = trainer.ID,
                Designation = trainer.Designation,
                Email = trainer.Email,
                Name = trainer.Name,
                Phone = trainer.Phone
            };
            return t;
        }
        public EmployeeDTO Get(Trainee trainee)
        {
            var t = new EmployeeDTO
            {
                ID = trainee.ID,
                Designation = trainee.Designation,
                Email = trainee.Email,
                Name = trainee.Name,
                Phone = trainee.Phone
            };
            return t;
        }
    }
}
