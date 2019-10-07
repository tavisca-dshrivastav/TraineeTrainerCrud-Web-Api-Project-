using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Dto;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.Translator
{
    public class CredentialTranslator
    {
        public UserCredentialDto Translate(UserCredential credential)
        {
            return new UserCredentialDto
            {
                Email = credential.Email,
                PasswordHash = credential.PasswordHash,
                SecurityStamp = credential.SecurityStamp,
                Role = credential.Role
            };
        }
        public UserCredential Translate(UserCredentialDto credential)
        {
            return new UserCredential
            {
                Email = credential.Email,
                PasswordHash = credential.PasswordHash,
                SecurityStamp = credential.SecurityStamp,
                Role = credential.Role
            };
        }
    }
}
