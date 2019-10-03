using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.DTO;

namespace TraineeTrainerModel.Interfaces
{
    public interface IDBServices
    {
        List<EmployeeDTO> employees { get; set; }
        List<TraineeDTO> Trainee { get; set; }
        List<TrainerDTO> Trainer { get; set; }
    }
}
