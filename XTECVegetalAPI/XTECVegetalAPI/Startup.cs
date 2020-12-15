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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace XTECVegetalAPI
{
    public class Startup
    {

        //Para hacer la conexion a la base de datos en el Nuget Console
        //Scaffold-DBContext "Server=localhost; Database=TareaCorta1; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

        //Para hacer update a la base de datos, cuando se cambia una opcion en Sql
        //Scaffold-DbContext -Connection "Server=localhost; Database=TareaCorta1; Trusted_Connection=True;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -context TareaCorta1Context -force

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddControllers();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

        }
    }
}
