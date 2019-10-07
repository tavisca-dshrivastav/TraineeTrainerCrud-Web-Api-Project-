using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraineeTrainerModel.Models
{
    public class UserCredential : IdentityUser
    {
        public string Role { get; set; }
    }
    public enum UserRole
    {
        TrainingManager,
        Admin,
        Trainer,
        Trainee
    }
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
