﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Interfaces;
using TraineeTrainerModel.Dto;

namespace TraineeTrainerModel.DB
{
    public class InMemoryDBService : IDBServices
    {
        public List<EmployeeDto> employees { get; set; }
        public List<TraineeDto> Trainee { get; set; }
        public List<TrainerDto> Trainer { get; set; }
        public List<UserCredentialDto> UserCredentials { get; set; }
        public InMemoryDBService()
        {
            employees = new List<EmployeeDto>
            {
                new EmployeeDto
                {
                    ID = "C297",
                    Name= "Deepak",
                    Designation="Fresher",
                    Email="d@gmail.com",
                    Phone="9650268873"
                },
                new EmployeeDto
                {
                    ID = "C298",
                    Name= "Tushar",
                    Designation="Fresher",
                    Email="t@gmail.com",
                    Phone="9650268873"
                },
            };
            Trainee = new List<TraineeDto>
            {
                new TraineeDto
                {
                    EmployeeID = employees[0].ID,
                    BatchNo = 1,
                }
            };
            Trainer = new List<TrainerDto>
            {
                new TrainerDto
                {
                    EmployeeId = employees[1].ID,
                    Specialization = "Java",
                    TribeName = "GCE"
                }
            };
            UserCredentials = new List<UserCredentialDto>
            {
                new UserCredentialDto
                {
                    Email = employees[0].Email,
                    PasswordHash = "123",
                    Role = "trainee"
                },
                new UserCredentialDto
                {
                    Email = employees[1].Email,
                    PasswordHash = "123",
                    Role = "admin"
                },
            };
        }
    }
}
