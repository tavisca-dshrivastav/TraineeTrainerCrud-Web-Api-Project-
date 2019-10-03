using TraineeTrainerModel.DTO;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.Translator
{
    public class TraineeTranslator
    {
        public TraineeDTO Translate(Trainee trainee)
        {
            var t = new TraineeDTO
            {
                BatchNo = trainee.BatchNo,
                EmployeeID = trainee.ID
            };
            return t;
        }
        public Trainee Translate(TraineeDTO traineeDTO, EmployeeDTO employeeDTO)
        {
            var trainee = new Trainee
            {
                ID = employeeDTO.ID,
                Name = employeeDTO.Name,
                Email = employeeDTO.Email,
                Designation = employeeDTO.Email,
                Phone = employeeDTO.Phone,
                BatchNo = traineeDTO.BatchNo
            };
            return trainee;
        }
    }
}
