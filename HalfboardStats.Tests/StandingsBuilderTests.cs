using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using NUnit.Framework;
using HalfboardStats.Tests.Mockups;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Core.JsonMappers.StandingsMappers;
using HalfboardStats.Core.Builders;
using HalfboardStats.Infrastructure.ServiceAgents;

namespace HalfboardStats.Tests
{
    public class Tests
    {
        private IServiceCollection _serviceCollection;
        private IServiceProvider _serviceProvider;
        private StandingsBuilder _builder;
        private int _teamId;

        [SetUp]
        public void Setup()
        {
            var standingsMock = new StandingsMapperMock();
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton<IStandingsMapper>(standingsMock);
            _serviceCollection.AddScoped<IStandingsRepository, StandingsRepositoryMockup>();
            _serviceCollection.AddScoped<IStandings, Standings>();
            _serviceCollection.AddScoped<ITeamRecord, TeamRecord>();

            _serviceProvider = _serviceCollection.BuildServiceProvider();


            _builder = new StandingsBuilder(_serviceProvider);

        }

        [Test]
        public async Task NonEmptyStandings()
        {
            var standings = await _builder.BuildStandings();
            

            foreach (var team in standings["Metropolitan"])
            {
                _teamId = team.TeamRecordId;
            }

            var result = _teamId == 1;
            Assert.IsTrue(result, "The value doesn't match");
        }
    }
}