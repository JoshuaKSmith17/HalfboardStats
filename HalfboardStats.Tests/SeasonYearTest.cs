using HalfboardStats.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalfboardStats.Tests.Mockups;

namespace HalfboardStats.Tests
{
    internal class SeasonYearTest
    {
        private IServiceCollection _serviceCollection;
        private IServiceProvider _serviceProvider;
        private ISeasonYear _seasonYear;
        private string _currentYear;
        private string _previousYear;
        private string _firstYear;

        [SetUp]
        public void Setup()
        {
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddTransient<ISeasonYear, SeasonYear>();
            _serviceCollection.AddScoped<IDateTimeProvider, DateTimeProviderMockup>();

            _serviceProvider = _serviceCollection.BuildServiceProvider();

            // _currentYear and _previousYear values match what the mockup contains.
            _currentYear = "20222023";
            _previousYear = "20212022";
            
            _firstYear = "19171918";

        }

        [Test]
        public void CurrentSeason()
        {
            _seasonYear = (ISeasonYear)_serviceProvider.GetService(typeof(ISeasonYear));

            Assert.IsTrue(_seasonYear.Year == _currentYear);
        }

        [Test]
        public void DecrementSeasonTest()
        {
            _seasonYear = (ISeasonYear)_serviceProvider.GetService(typeof(ISeasonYear));

            _seasonYear.DecrementSeason();
            Assert.IsTrue(_seasonYear.Year == _previousYear);
        }

        [Test]
        public void IncrementSeasonTest()
        {
            _seasonYear = (ISeasonYear)_serviceProvider.GetService(typeof(ISeasonYear));

            _seasonYear.DecrementSeason();
            Assert.IsTrue(_seasonYear.Year == _previousYear);

            _seasonYear.IncrementSeason();
            Assert.IsTrue(_seasonYear.Year == _currentYear);
        }

        [Test]
        public void IncrementTestSeasonLimit()
        {
            _seasonYear = (ISeasonYear)_serviceProvider.GetService(typeof(ISeasonYear));

            for (int i = 0; i < 10; i++)
            {
                _seasonYear.IncrementSeason();
            }

            Assert.IsTrue(_seasonYear.Year == _currentYear);
        }
        [Test]
        public void DecrementTestSeasonLimit()
        {
            _seasonYear = (ISeasonYear)_serviceProvider.GetService(typeof(ISeasonYear));

            for (int i = 0; i < 120; i++)
            {
                _seasonYear.DecrementSeason();
            }

            Assert.IsTrue(_seasonYear.Year == _firstYear);
        }
    }
}
