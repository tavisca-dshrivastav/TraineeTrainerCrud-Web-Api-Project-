using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Interfaces;
using TraineeTrainerModel.Models;
using TraineeTrainerModel.Translator;
namespace TraineeTrainerModel.Dal
{
    public class UserCredentialsDal
    {
        IDBServices _dbService;
        CredentialTranslator translator = new CredentialTranslator();
        public UserCredentialsDal(IDBServices dbService)
        {
            _dbService = dbService;
        }

        public bool Exist(string username)
        {
            if (_dbService.UserCredentials.Where(x => x.Email.Equals(username)).SingleOrDefault() == null)
                return false;
            return true;
        }

        public UserCredential Get(string username)
        {
            return translator.Translate(_dbService.UserCredentials.Where(x => x.Email.Equals(username)).SingleOrDefault());
        }
        

        public bool Update(string id, UserCredential employee)
        {
            throw new NotImplementedException();
        }
    }
}
