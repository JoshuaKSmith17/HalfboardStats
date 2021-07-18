using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HalfboardStats.Model.Repositories;
using HalfboardStats.Model.ObjectRelationalMappers;
using HalfboardStats.Model.JsonMappers;

namespace HalfboardStats.Model.Builders
{
    public class StandingsBuilder
    {
        public async Task<Dictionary<string, IEnumerable<TeamRecord>>> BuildStandings()
        {
            /*
             * Method that takes the raw data we get from the JSON file and organizes it in a way that is easier for our front end to work with.
             * Since there is a lot of logic needed to perform the transfer, this logic is separated out from the class it creates.  It also
             * serves as a way to separate some logic from classes that will serve as the model for our database.
             */
            Standings standings = new Standings();
            StandingsMapper mapper = new StandingsMapper();
            StandingsRepository repo = new StandingsRepository();

            Dictionary<string, IEnumerable<TeamRecord>> standingsDictionary = new Dictionary<string, IEnumerable<TeamRecord>>();

            mapper = await repo.GetStandings();

            for (int i = 0; i < mapper.Records.Count; i++)
            {
                for (int j = 0; j < mapper.Records[i].TeamRecords.Count; j++)
                {
                    TeamRecord record = new TeamRecord();
                    record.TeamName = mapper.Records[i].TeamRecords[j].Team.Name;
                    record.Conference = mapper.Records[i].Conference.Name;
                    record.Division = mapper.Records[i].Division.Name;


                    record.Wins = mapper.Records[i].TeamRecords[j].LeagueRecord.Wins;
                    record.Losses = mapper.Records[i].TeamRecords[j].LeagueRecord.Losses;
                    record.OvertimeLosses = mapper.Records[i].TeamRecords[j].LeagueRecord.Ot;

                    record.Points = mapper.Records[i].TeamRecords[j].Points;

                    record.PointsPercentage = (double)record.Points / ((double)(record.Wins + record.Losses + record.OvertimeLosses) * 2);

                    standings.TeamRecords.Add(record);
                }
            }

            standingsDictionary.Add("LeagueStandings", standings.TeamRecords);

            IEnumerable<TeamRecord> westDivision =
                from teamRecord in standings.TeamRecords
                where teamRecord.Division.Contains("West")
                select teamRecord;

            standingsDictionary.Add("WestDivision", westDivision);

            standingsDictionary.Add("LeagueStandings", standings.TeamRecords);

            IEnumerable<TeamRecord> northDivision =
                from teamRecord in standings.TeamRecords
                where teamRecord.Division.Contains("North")
                select teamRecord;

            standingsDictionary.Add("WestDivision", westDivision);

            standingsDictionary.Add("LeagueStandings", standings.TeamRecords);

            IEnumerable<TeamRecord> centralDivision =
                from teamRecord in standings.TeamRecords
                where teamRecord.Division.Contains("Central")
                select teamRecord;

            standingsDictionary.Add("WestDivision", westDivision);

            standingsDictionary.Add("LeagueStandings", standings.TeamRecords);

            IEnumerable<TeamRecord> eastDivision =
                from teamRecord in standings.TeamRecords
                where teamRecord.Division.Contains("East")
                select teamRecord;

            standingsDictionary.Add("WestDivision", westDivision);

            return standingsDictionary;
            
        }
    }
}
