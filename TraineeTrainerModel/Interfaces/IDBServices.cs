using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Dto;

namespace TraineeTrainerModel.Interfaces
{
    public interface IDBServices
    {
        List<EmployeeDto> employees { get; set; }
        List<TraineeDto> Trainee { get; set; }
        List<TrainerDto> Trainer { get; set; }
    }
}
