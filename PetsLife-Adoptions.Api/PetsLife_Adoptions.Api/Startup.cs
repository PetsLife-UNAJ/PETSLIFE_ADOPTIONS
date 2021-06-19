using AccessData.Commad;
using AccessData.Commad.Repository;
using AccessData.Queries;
using AccessData.Queries.Repository;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PetsLife_Adoptions.AccessData;
using SqlKata.Compilers;
using System;
using System.Data;
using System.Text;
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

            //AUTH CONFIG
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.FromMinutes(0)
                };
            });
            //FIN AUTH CONFIG

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
            services.AddTransient<IMascotaService, MascotaService>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
        }
    }
}