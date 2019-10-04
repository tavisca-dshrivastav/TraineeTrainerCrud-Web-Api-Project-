using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Dal.Interfaces;
using TraineeTrainerModel.Dto;
using TraineeTrainerModel.Interfaces;
using TraineeTrainerModel.Models;
using TraineeTrainerModel.Translator;

namespace TraineeTrainerModel.Dal
{
    public class TrainerDal : IBaseDal<Trainer>
    {
        private IDBServices _dbService;
        private EmployeeTranslator _employeeTranslator = new EmployeeTranslator();
        private TrainerTranslator _trainerTranslator = new TrainerTranslator();

        public TrainerDal(IDBServices dbService)
        {
            _dbService = dbService;
        }

        public void Create(Trainer trainer)
        {
            EmployeeDto employeeDTO = _employeeTranslator.Get(trainer);

            _dbService.employees.Add(employeeDTO);

            TrainerDto trainerDTO = _trainerTranslator.Translate(trainer);
            _dbService.Trainer.Add(trainerDTO);
        }

        public bool Exist(Trainer trainer)
        {
            return _dbService.Trainee.Where(x => x.EmployeeID == trainer.ID) != null ? true : false;
        }

        public Trainer Get(string id)
        {
            var trainerDTO = _dbService.Trainer.Where(x => x.EmployeeId == id).SingleOrDefault();
            var employeeDTO = _dbService.employees.Where(x => x.ID == id).SingleOrDefault();
            var trainee = _trainerTranslator.Translate(trainerDTO, employeeDTO);
            return trainee;
        }

        public List<Trainer> Get()
            
        {
            var trainerDTOs = _dbService.Trainer;
            var trainer = GetTraineeFromTraineeDTOs(trainerDTOs);
            return trainer;
        }

        private List<Trainer> GetTraineeFromTraineeDTOs(List<TrainerDto> trainerDTOs)
        {
            var trainers = new List<Trainer>();
            foreach (var trainer in trainerDTOs)
            {
                trainers.Add(_trainerTranslator.
                    Translate(trainer, _dbService.employees.
                        Where(x => x.ID.Equals(trainer.EmployeeId)).SingleOrDefault()));
            }
            return trainers;
        }

        public void Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public bool Update(string id, Trainer employee)
        {
            throw new NotImplementedException();
        }
    }
}
