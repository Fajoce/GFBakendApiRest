using BLL.GF.Interfaces.BranchOffices;
using BLL.GF.Interfaces.Items;
using BLL.GF.Interfaces.Remissions;
using BLL.GF.Interfaces.Technicals;
using BLL.GF.Repositories;
using BLL.GF.Repositories.Items;
using DAL.GF.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using DAL.GF.Utils;

namespace GFAPI
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
            services.AddControllers().AddNewtonsoftJson(); ;
            services.AddDbContext<GFDbContext>(
            options => options.UseSqlServer("name=ConnectionStrings:myConection"));
            services.AddScoped<ITechnicals, TechnicalRepository>();
            services.AddScoped<IItems, ItemsRepository>();
            services.AddScoped<IBranchOffices, BranchOfficesRepository>();
            services.AddScoped<IRemissions, RemissionsRepository>();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TechnicalValidations>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RemissionValidations>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
