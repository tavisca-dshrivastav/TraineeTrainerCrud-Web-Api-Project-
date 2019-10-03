using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Interfaces;
using TraineeTrainerModel.DTO;

namespace TraineeTrainerModel.DB
{
    public class InMemoryDBService : IDBServices
    {
        public List<EmployeeDTO> employees { get; set; }
        public List<TraineeDTO> Trainee { get; set; }
        public List<TrainerDTO> Trainer { get; set; }

        public InMemoryDBService()
        {
            employees = new List<EmployeeDTO>
            {
                new EmployeeDTO
                {
                    ID = "C297",
                    Name= "Deepak",
                    Designation="Fresher",
                    Email="xyz",
                    Phone="9650268873"
                },
                new EmployeeDTO
                {
                    ID = "C298",
                    Name= "Tushar",
                    Designation="Fresher",
                    Email="xyz",
                    Phone="9650268873"
                },
            };
            Trainee = new List<TraineeDTO>
            {
                new TraineeDTO
                {
                    EmployeeID = employees[0].ID,
                    BatchNo = 1,
                }
            };
            Trainer = new List<TrainerDTO>
            {
                new TrainerDTO
                {
                    EmployeeId = employees[1].ID,
                    Specialization = "Java",
                    TribeName = "GCE"
                }
            };
        }
    }
}
