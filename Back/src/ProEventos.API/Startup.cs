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

        /*A ASP.NET Core implementa a inje��o de depend�ncia por padr�o. 
         * Os servi�os (como o contexto de banco de dados do EF) s�o registrados com inje��o de depend�ncia durante a inicializa��o do aplicativo. 
         * Componentes que requerem esses servi�os (como controladores MVC) fornecem esses servi�os atrav�s de par�metros do construtor.*/
        public void ConfigureServices(IServiceCollection services) {

            /*O nome da string de conex�o � passada para o contexto pela chamada do m�todo no objeto DbContextOptionsBuilder. 
             * Para o desenvolvimento local a ASP .NET Core obt�m a string de conex�o do arquivo appsettings.json.*/
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
