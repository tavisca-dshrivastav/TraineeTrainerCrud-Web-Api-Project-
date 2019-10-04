using TraineeTrainerModel.Dto;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.Translator
{
    public class TrainerTranslator
    {
        public TrainerDto Translate(Trainer trainer)
        {
            var t = new TrainerDto
            {
                EmployeeId = trainer.ID,
                Specialization = trainer.Specialization,
                TribeName = trainer.TribeName
            };
            return t;
        }
        public Trainer Translate(TrainerDto trainerDTO, EmployeeDto employeeDTO)
        {
            var trainee = new Trainer
            {
                ID = employeeDTO.ID,
                Name = employeeDTO.Name,
                Email = employeeDTO.Email,
                Designation = employeeDTO.Email,
                Phone = employeeDTO.Phone,
                Specialization = trainerDTO.Specialization,
                TribeName = trainerDTO.TribeName
            };
            return trainee;
        }
    }
}
