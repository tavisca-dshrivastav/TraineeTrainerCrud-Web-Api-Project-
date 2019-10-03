﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.DAL.Interfaces;
using TraineeTrainerModel.DTO;
using TraineeTrainerModel.Interfaces;
using TraineeTrainerModel.Models;
using TraineeTrainerModel.Translator;

namespace TraineeTrainerModel.DAL
{
    public class TraineeDAL : IDAL<Trainee>
    {
        private IDBServices _dbService;
        private EmployeeTranslator _employeeTranslator = new EmployeeTranslator();
        private TraineeTranslator _traineeTranslator = new TraineeTranslator();
        
        public TraineeDAL(IDBServices dbService)
        {
            _dbService = dbService;
        }

        public void Create(Trainee trainee)
        {
            EmployeeDTO employeeDTO = _employeeTranslator.Get(trainee);

            _dbService.employees.Add(employeeDTO);

            TraineeDTO traineeDTO = _traineeTranslator.Translate(trainee);
            _dbService.Trainee.Add(traineeDTO);
        }

        public bool Exist(Trainee trainee)
        {
            return _dbService.Trainee.Where(x => x.EmployeeID == trainee.ID) != null ? true : false;
        }

        public Trainee Get(string id)
        {
            var traineeDTO = _dbService.Trainee.Where(x => x.EmployeeID == id).SingleOrDefault();
            var employeeDTO = _dbService.employees.Where(x => x.ID == id).SingleOrDefault();
            var trainee = _traineeTranslator.Translate(traineeDTO, employeeDTO);
            return trainee;
        }

        public List<Trainee> Get()
        {
            var traineeDTOs = _dbService.Trainee;
            var trainee = GetTraineeFromTraineeDTOs(traineeDTOs);
            return trainee;
        }

        private List<Trainee> GetTraineeFromTraineeDTOs(List<TraineeDTO> traineeDTOs)
        {
            var trainees = new List<Trainee>();
            foreach(var trainee in traineeDTOs)
            {
                trainees.Add(_traineeTranslator.
                    Translate(trainee, _dbService.employees.
                        Where(x => x.ID.Equals(trainee.EmployeeID)).SingleOrDefault()));
            }
            return trainees;
        }

        public void Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public bool Update(string id, Trainee employee)
        {
            throw new NotImplementedException();
        }
    }
}
