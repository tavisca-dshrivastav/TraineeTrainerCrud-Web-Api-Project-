using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Dal.Interfaces;
using TraineeTrainerModel.Models;
using TraineeTrainerModel.Services.Interface;

namespace TraineeTrainerModel.Services
{
    public class EmloyeeService : IService<Employee>
    {
        private IBaseDal<Employee> _employeeDAL;

        public EmloyeeService(IBaseDal<Employee> employeeDAL)
        {
           _employeeDAL = employeeDAL;
        }

        public Employee Get(string id)
        {
            return _employeeDAL.Get(id);
        }

        public List<Employee> Get()
        {
            return _employeeDAL.Get();
        }
        public bool Create(Employee employee)
        {
            if (_employeeDAL.Exist(employee))
                return false;
            _employeeDAL.Create(employee);
            return true;
        }
        public bool DeleteById(string id)
        {
            if (!_employeeDAL.Exist(_employeeDAL.Get(id)))
                return false;
            _employeeDAL.Remove(id);
            return true;
        }

        public bool Update(string id, Employee employee)
        {
            if (!_employeeDAL.Exist(employee))
                return false;
            _employeeDAL.Update(id, employee);
            return true;
        }
    }
}
