using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.Services.Interface
{
    public interface IService<T>
    {
        T Get(string id);
        List<T> Get();
        bool Create(T employee);
        bool DeleteById(string id);
        bool Update(string id, T employee);
    }
}
