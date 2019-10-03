﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Models;

namespace TraineeTrainerModel.DAL.Interfaces
{
    public interface IDAL<T>
    {
        void Create(T employee);

        bool Exist(T employee);

        T Get(string id);

        List<T> Get();

        void Remove(string ID);

        bool Update(string id, T employee);
    }


}
