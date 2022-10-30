using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Core.JsonMappers.StandingsMappers;
using HalfboardStats.Core.Builders;
using HalfboardStats.Infrastructure.ServiceAgents;
using HalfboardStats.Infrastructure.Repositories;
using HalfboardStats.Application;

namespace HalfboardStats
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // services is used as the DI container.  Register using services.AddScoped<IMyDependency, MyDependency>();
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddScoped<IStandingsMapper, StandingsMapper>();
            services.AddScoped<IStandings, Standings>();
            services.AddScoped<IStandingsRepository, StandingsRepository>();
            services.AddTransient<ITeamRecord, TeamRecord>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerbaseBuilder, PlayerbaseBuilder>();
            services.AddScoped<IActivePlayerLocalRepository, ActivePlayerLocalRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamBuilder, TeamBuilder>();
            services.AddScoped<ITeamLocalRepository, TeamLocalRepository>();
            services.AddScoped<IPlayerFacade, PlayerFacade>();

            services.AddRazorPages();
            services.AddMvc().AddRazorPagesOptions(opt => {
                opt.RootDirectory = "/Presentation/Pages" ; 
                });

            services.AddDbContext<HalfboardContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HalfboardContext")));

            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
