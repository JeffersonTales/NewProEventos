using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProEventos.API.Data;

namespace ProEventos.API.Back.src.ProEventos.API {

    public class Startup {

        #region construtor
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        #endregion

        #region propriedades
        public IConfiguration Configuration { get; }
        #endregion

        /*A ASP.NET Core implementa a injeção de dependência por padrão. 
         * Os serviços (como o contexto de banco de dados do EF) são registrados com injeção de dependência durante a inicialização do aplicativo. 
         * Componentes que requerem esses serviços (como controladores MVC) fornecem esses serviços através de parâmetros do construtor.*/
        public void ConfigureServices(IServiceCollection services) {

            /*O nome da string de conexão é passada para o contexto pela chamada do método no objeto DbContextOptionsBuilder. 
             * Para o desenvolvimento local a ASP .NET Core obtém a string de conexão do arquivo appsettings.json.*/
            services.AddDbContext<DataContext>(optionsAction: context => context.UseSqlite(Configuration.GetConnectionString("Default")));

            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(setupAction: c => c.SwaggerDoc(name: "v1",
                                                                  info: new OpenApiInfo {
                                                                      Title = "ProEventos.API",
                                                                      Version = "v1"
                                                                  }
                                                                  ));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
