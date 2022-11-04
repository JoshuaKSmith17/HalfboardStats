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
using HalfboardStats.Core.Controllers;
using HalfboardStats.Core.Schedulers;
using Quartz;
using Quartz.Impl;
using Microsoft.AspNetCore.Mvc;

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
            services.AddScoped<IStandingsBuilder, StandingsBuilder>();
            services.AddScoped<IStandingsAgent, StandingNhlApiAgent>();
            services.AddScoped<IStandingsFacade, StandingsFacade>();
            services.AddTransient<ITeamRecord, TeamRecord>();
            services.AddScoped<IPlayerAgent, PlayerNhlApiAgent>();
            services.AddScoped<IPlayerbaseBuilder, PlayerbaseBuilder>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamAgent, TeamNhlApiAgent>();
            services.AddScoped<ITeamBuilder, TeamBuilder>();
            services.AddScoped<Infrastructure.Repositories.ITeamRepository, TeamRepository>();
            services.AddScoped<IPlayerFacade, PlayerFacade>();
            services.AddScoped<IStatsAgent, StatsNhlApiAgent>();
            services.AddScoped<ICareerStatsBuilder, CareerStatsBuilder>();
            services.AddScoped<IStatsRepository, StatsRepository>();
            services.AddScoped<IPlayerStatScraperController, PlayerStatScraperController>();
            services.AddScoped<IStatsFacade, StatsFacade>();
            services.AddScoped<IPlayerController, PlayerController>();
            services.AddScoped<ITeamController, TeamController>();

            services.Configure<QuartzOptions>(Configuration.GetSection("Quartz"));

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
                q.ScheduleJob<PlayerJob>(trigger => trigger
                .WithIdentity("Main Trigger")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInHours(6)
                .RepeatForever()));
            });

            services.AddQuartzHostedService();


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
