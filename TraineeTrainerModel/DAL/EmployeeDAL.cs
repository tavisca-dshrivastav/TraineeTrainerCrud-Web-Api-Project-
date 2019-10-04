using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Dal.Interfaces;
using TraineeTrainerModel.Interfaces;
using TraineeTrainerModel.Models;
using TraineeTrainerModel.Translator;

namespace TraineeTrainerModel.Dal
{
    public class EmployeeDal : IBaseDal<Employee>
    {
        IDBServices _database;
        EmployeeTranslator translator = new EmployeeTranslator();
        public EmployeeDal(IDBServices database)
        {
            _database = database;
        }
        public void Create(Employee employee)
        {
            var emp = translator.Translate(employee);
            _database.employees.Add(emp);
        }
        public bool Exist(Employee employee)
        {
            var emp = Get(employee.ID);
            if (emp == null)
                return false;
            return true;
        }
        public Employee Get(string id)
        {
            return _database.employees.Where(x => x.ID == id).Select(x=>translator.Translate(x)).SingleOrDefault();
        }
        public List<Employee> Get()
        {
            return _database.employees.Select(x => translator.Translate(x)).ToList();
        }
        public void Remove(string ID)
        {
            _database.employees.RemoveAt(_database.employees.IndexOf(_database.employees.Where(x=>x.ID == ID).SingleOrDefault()));
        }
       public bool Update(string id, Employee employee)
       {
            var emp = _database.employees.Where(x=>x.ID==id).SingleOrDefault();
            if (emp == null)
                return false;
            emp.ID = employee.ID;
            emp.Name = employee.Name;
            emp.Phone = employee.Phone;
            emp.Designation = employee.Designation;
            emp.Email = employee.Email;
            return true;
       }
    }
}
