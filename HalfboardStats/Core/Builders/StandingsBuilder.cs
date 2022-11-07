using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using HalfboardStats.Core.JsonMappers.StandingsMappers;
using HalfboardStats.Infrastructure.ServiceAgents;

namespace HalfboardStats.Core.Builders
{
    public class StandingsBuilder : IStandingsBuilder
    {
        IServiceProvider ServiceProvider;
        public IStandings Standings { get; set; }
        public IStandingsMapper StandingsMapper { get; set; }
        public IStandingsAgent Repository { get; set; }

        public StandingsBuilder(IServiceProvider serviceProvider, IStandings standings, IStandingsMapper mapper, IStandingsAgent repository)
        {
            ServiceProvider = serviceProvider;
            Standings = standings;
            StandingsMapper = mapper;
            Repository = repository;
        }
        public async Task<IDictionary<string, IEnumerable<ITeamRecord>>> BuildStandings()
        {
            /*
             * Method that takes the raw data we get from the JSON file and organizes it in a way that is easier for our front end to work with.
             * Since there is a lot of logic needed to perform the transfer, this logic is separated out from the class it creates.  It also
             * serves as a way to separate some logic from classes that will serve as the model for our database.
             */

            var standingsDictionary = new Dictionary<string, IEnumerable<ITeamRecord>>();

            StandingsMapper = await Repository.GetStandings();

            for (int i = 0; i < StandingsMapper.Records.Count; i++)
            {
                for (int j = 0; j < StandingsMapper.Records[i].TeamRecords.Count; j++)
                {
                    // TODO: Need a factory to replace this service locator.
                    ITeamRecord record = (ITeamRecord)ServiceProvider.GetService(typeof(ITeamRecord));
                    record.TeamRecordId = StandingsMapper.Records[i].TeamRecords[j].Team.Id;
                    record.TeamName = StandingsMapper.Records[i].TeamRecords[j].Team.Name;
                    record.Conference = StandingsMapper.Records[i].Conference.Name;
                    record.Division = StandingsMapper.Records[i].Division.Name;


                    record.Wins = StandingsMapper.Records[i].TeamRecords[j].LeagueRecord.Wins;
                    record.Losses = StandingsMapper.Records[i].TeamRecords[j].LeagueRecord.Losses;
                    record.OvertimeLosses = StandingsMapper.Records[i].TeamRecords[j].LeagueRecord.Ot;

                    record.Points = StandingsMapper.Records[i].TeamRecords[j].Points;

                    record.PointsPercentage = record.Points / ((double)(record.Wins + record.Losses + record.OvertimeLosses) * 2);

                    this.Standings.TeamRecords.Add(record);
                }
            }

            standingsDictionary.Add("LeagueStandings", Standings.TeamRecords);

            IEnumerable<ITeamRecord> westDivision =
                from teamRecord in Standings.TeamRecords
                where teamRecord.Division.Contains("Metropolitan")
                select teamRecord;

            westDivision = westDivision.OrderByDescending(team => team.Points);

            standingsDictionary.Add("Metropolitan", westDivision);

            IEnumerable<ITeamRecord> northDivision =
                from teamRecord in Standings.TeamRecords
                where teamRecord.Division.Contains("Atlantic")
                select teamRecord;

            northDivision = northDivision.OrderByDescending(team => team.Points);

            standingsDictionary.Add("Atlantic", northDivision);

            IEnumerable<ITeamRecord> centralDivision =
                from teamRecord in Standings.TeamRecords
                where teamRecord.Division.Contains("Central")
                select teamRecord;

            centralDivision = centralDivision.OrderByDescending(team => team.Points);

            standingsDictionary.Add("CentralDivision", centralDivision);

            IEnumerable<ITeamRecord> eastDivision =
                from teamRecord in Standings.TeamRecords
                where teamRecord.Division.Contains("Pacific")
                select teamRecord;

            eastDivision = eastDivision.OrderByDescending(team => team.Points);

            standingsDictionary.Add("Pacific", eastDivision);

            return standingsDictionary;

        }
    }
}
