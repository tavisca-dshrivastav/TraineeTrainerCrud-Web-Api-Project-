﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraineeTrainerModel.Generics;

namespace TraineeTrainerModel.Models
{
    [GeneratedControllerAttribute("api/user/employee")]
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    [GeneratedControllerAttribute("api/user/trainee")]
    public class Trainee : Employee
    {
        public int BatchNo { get; set; }
    }

    [GeneratedControllerAttribute("api/user/trainer")]
    public class Trainer : Employee
    {
        public string Specialization { get; set; }
        public string TribeName { get; set; }
    }
}
