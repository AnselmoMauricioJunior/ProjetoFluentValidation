using ApiProjetoFluentValidation.Core.Interfaces.Infra.Repository;
using ApiProjetoFluentValidation.Core.Interfaces.Services;
using ApiProjetoFluentValidation.Core.Interfaces.Validations;
using ApiProjetoFluentValidation.Core.Services;
using ApiProjetoFluentValidation.Core.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoFluentValidation.Data.Config;
using ProjetoFluentValidation.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Threading.Tasks;

namespace ProjetoFluentValidation.Api
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
            services.AddControllers();

            #region Swagger
            services.AddSwaggerGen(s =>
            {
                s.EnableAnnotations();
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ProjetoFluentValidation",
                    Description = "Api responsável por mostrar uma arquitetura utilizando o Fluent Validation",
                });

            });

            #endregion

            #region HealtCheck
            services.AddHealthChecks()
               .AddSqlServer(Configuration["ConnectionStrings:BancoDados"], name: "DB projeto");
            #endregion

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "Versao 1.0");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.None);
            });
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();

                endpoints.MapGet("/", context =>
                {
                    return Task.Run(() => context.Response.Redirect("/Readme"));
                });
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            #region [Configs]
            services.Configure<DatabaseConfig>(Configuration.GetSection("ConnectionStrings"));
            #endregion

            #region [Repository]           
            services.AddSingleton<IPlantaRepository, PlantaRepository>();
            #endregion

            #region [Services]           
            services.AddTransient<IPlantaServices, PlantaServices>();
            #endregion

            #region [Validators]
            services.AddTransient<IPlantaValidation, PlantaValidation>();
            #endregion

        }
    }
}
