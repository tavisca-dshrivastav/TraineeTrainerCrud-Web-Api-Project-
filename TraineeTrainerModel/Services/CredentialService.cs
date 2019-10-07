using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Services;
using TraineeTrainerModel.Dal;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.Services
{
    public class CredentialService
    {
        private UserCredentialsDal _credentialsDal;

        public CredentialService(UserCredentialsDal credentialsDal)
        {
            _credentialsDal = credentialsDal;
        }
        public UserCredential Authenticate(string username, string password)
        {
            var credential = _credentialsDal.Get(username);
            if (credential.PasswordHash.Equals(password))
                return credential;
            return null;
        }
        
        public bool Exist(string username) => !_credentialsDal.Exist(username);


       
    }
}
