using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.DAL.Interfaces;
using TraineeTrainerModel.Models;
using TraineeTrainerModel.Services.Interface;

namespace TraineeTrainerModel.Services
{
    public class TrainerService : IService<Trainer>
    {
        private IDAL<Trainer> _trainerDAL;

        public TrainerService(IDAL<Trainer> trainerDAL)
        {
            _trainerDAL = trainerDAL;
        }

        public Trainer Get(string id)
        {
            return _trainerDAL.Get(id);
        }

        public List<Trainer> Get()
        {
            return _trainerDAL.Get();
        }
        public bool Create(Trainer employee)
        {
            if (_trainerDAL.Exist(employee))
                return false;
            _trainerDAL.Create(employee);
            return true;
        }
        public bool DeleteById(string id)
        {
            if (!_trainerDAL.Exist(_trainerDAL.Get(id)))
                return false;
            _trainerDAL.Remove(id);
            return true;
        }

        public bool Update(string id, Trainer employee)
        {
            if (!_trainerDAL.Exist(employee))
                return false;
            _trainerDAL.Update(id, employee);
            return true;
        }
    }
}
