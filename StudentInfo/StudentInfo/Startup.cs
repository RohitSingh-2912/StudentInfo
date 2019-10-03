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
using MongoDB.Driver;
using StudentInfo.Models;
using StudentInfo.Controllers;
using StudentInfo.Services;

namespace StudentInfo
{

    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStudentDatabaseSettings>(p => new StudentDatabaseSettings
            {
                ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING"),
                DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME"),
                StudentsCollectionName = nameof(Student)
            });

            services.AddTransient<StudentService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}