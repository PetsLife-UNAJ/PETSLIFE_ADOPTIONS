using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using PetsLife_Adoptions.AccessData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Application.Services;
using AccessData.Commad.Repository;
using AccessData.Commad;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System.Data;
using Microsoft.Data.SqlClient;
using AccessData.Queries.Repository;
using AccessData.Queries;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace PetsLife_Adoptions.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuracion Sql ConnectionString
            services.AddControllers();
            var connectionString = Configuration.GetSection("connectionString").Value;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //Configuracion Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetsLife", Version = "v1" });
            });

            //Configuracion Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AnyAllow", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            //Injecciones de dependencias
            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<IMascotaService , MascotaService>();
            services.AddTransient<IMascotaQuery, MascotaQuery>();
           
            services.AddTransient<IAdoptanteMascotaQuery, AdoptanteMascotaQuery>();
            services.AddTransient<IAdoptanteMascotaService, AdoptanteMascotaService>();

            services.AddTransient<IAdoptanteService, AdoptanteService>();
            services.AddTransient<IAdoptanteQuery, AdoptanteQuery>();

            services.AddTransient<ITipoMascotaService, TipoMascotaService>();
            services.AddTransient<ITipoMascotaQuery, TipoMascotaQuery>();

            

           
            //Configuracion SqlKata
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetsLife v1"));
            }
            app.UseCors("AnyAllow");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
