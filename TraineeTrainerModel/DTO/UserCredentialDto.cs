using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraineeTrainerModel.Dto
{
    public class UserCredentialDto : IdentityUser
    {
        public string Role { get; set; }
    }
    public enum UserRoleDto
    {
        TrainingManager,
        Admin,
        Trainer,
        Trainee
    }
}
