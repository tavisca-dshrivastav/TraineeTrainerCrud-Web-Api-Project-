using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Dal.Interfaces;
using TraineeTrainerModel.Models;
using TraineeTrainerModel.Services.Interface;

namespace TraineeTrainerModel.Services
{
    public class TraineeService : IService<Trainee>
    {
        private IBaseDal<Trainee> _traineeDal;

        public TraineeService(IBaseDal<Trainee> traineeDal)
        {
            _traineeDal = traineeDal;
        }

        public Trainee Get(string id)
        {
            return _traineeDal.Get(id);
        }

        public List<Trainee> Get()
        {
            return _traineeDal.Get();
        }
        public bool Create(Trainee employee)
        {
            if (_traineeDal.Exist(employee))
                return false;
            _traineeDal.Create(employee);
            return true;
        }
        public bool DeleteById(string id)
        {
            if (!_traineeDal.Exist(_traineeDal.Get(id)))
                return false;
            _traineeDal.Remove(id);
            return true;
        }

        public bool Update(string id, Trainee employee)
        {
            if (!_traineeDal.Exist(employee))
                return false;
            _traineeDal.Update(id, employee);
            return true;
        }
    }
}
