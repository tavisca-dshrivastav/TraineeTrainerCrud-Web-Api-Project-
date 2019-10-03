using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.DAL.Interfaces;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.Services
{
    public class TraineeService
    {
        private IDAL<Trainee> _traineeDAL;

        public TraineeService(IDAL<Trainee> traineeDAL)
        {
            _traineeDAL = traineeDAL;
        }

        public Trainee Get(string id)
        {
            return _traineeDAL.Get(id);
        }

        public List<Trainee> Get()
        {
            return _traineeDAL.Get();
        }
        public bool Create(Trainee employee)
        {
            if (_traineeDAL.Exist(employee))
                return false;
            _traineeDAL.Create(employee);
            return true;
        }
        public bool Delete(string id)
        {
            if (!_traineeDAL.Exist(_traineeDAL.Get(id)))
                return false;
            _traineeDAL.Remove(id);
            return true;
        }

        public bool Update(string id, Trainee employee)
        {
            if (!_traineeDAL.Exist(employee))
                return false;
            _traineeDAL.Update(id, employee);
            return true;
        }
    }
}
