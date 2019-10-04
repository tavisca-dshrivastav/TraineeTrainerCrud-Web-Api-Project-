using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Dto;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.Translator
{
    public class EmployeeTranslator
    {
        public EmployeeDto Translate(Employee employee)
        {
            var emp = new EmployeeDto
            {
                ID = employee.ID,
                Name = employee.Name,
                Designation = employee.Designation,
                Email = employee.Designation,
                Phone = employee.Phone
            };
            return emp;
        }
        public Employee Translate(EmployeeDto employee)
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
        public EmployeeDto Get(Trainer trainer)
        {
            var t = new EmployeeDto
            {
                ID = trainer.ID,
                Designation = trainer.Designation,
                Email = trainer.Email,
                Name = trainer.Name,
                Phone = trainer.Phone
            };
            return t;
        }
        public EmployeeDto Get(Trainee trainee)
        {
            var t = new EmployeeDto
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
