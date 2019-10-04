using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TraineeTrainerModel.Interfaces;
using TraineeTrainerModel.DB;
using TraineeTrainerModel.Services.Interface;
using TraineeTrainerModel.Models;
using TraineeTrainerModel.Services;
using TraineeTrainerModel.Dal;
using TraineeTrainerModel.Generics;

namespace TraineeTrainerModel
{

    public class Startup
    {

        private IDBServices _database = new InMemoryDBService();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.
                AddMvc(o => o.Conventions.Add(
                    new GenericControllerRouteConvention()
                )).
                ConfigureApplicationPartManager(m =>
                m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider()
            ));
            services.AddSingleton<IService<Employee>>(new EmloyeeService(new EmployeeDAL(_database)));
            services.AddSingleton<IService<Trainer>>(new TrainerService(new TrainerDAL(_database)));
            services.AddSingleton<IService<Trainee>>(new TraineeService(new TraineeDAL(_database)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
