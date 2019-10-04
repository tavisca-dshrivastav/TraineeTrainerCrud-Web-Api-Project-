using TraineeTrainerModel.Dto;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.Translator
{
    public class TraineeTranslator
    {
        public TraineeDto Translate(Trainee trainee)
        {
            var t = new TraineeDto
            {
                BatchNo = trainee.BatchNo,
                EmployeeID = trainee.ID
            };
            return t;
        }
        public Trainee Translate(TraineeDto traineeDTO, EmployeeDto employeeDTO)
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
