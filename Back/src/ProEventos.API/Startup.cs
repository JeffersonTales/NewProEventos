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

        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<DataContext>(optionsAction: context => context.UseSqlite(Configuration.GetConnectionString("Default")));
            services.AddControllers();
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

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
