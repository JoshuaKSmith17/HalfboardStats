using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HalfboardStats.Model.JsonMappers;

namespace HalfboardStats.Tests.Mockups
{
    public class StandingsMapperMock : IStandingsMapper
    {
        public string Copyright { get; set; }
        public List<DivisionStandingsMapper> Records { get; set; }

        public StandingsMapperMock()
        {
            var divisionStandingsMapper = new DivisionStandingsMapper();
            var teamRecords = new TeamRecordsMapper();
            teamRecords.Team = new TeamMapper();
            teamRecords.Team.Id = 1;
            teamRecords.Team.Name = "TestName";



            var leagueRecordMapper = new LeagueRecordMapper();
            leagueRecordMapper.Wins = 1;
            leagueRecordMapper.Losses = 5;
            leagueRecordMapper.Ot = 3;

            teamRecords.LeagueRecord = leagueRecordMapper;
            divisionStandingsMapper.Division = new DivisionMapper();
            divisionStandingsMapper.Division.Name = "Metropolitan";

            divisionStandingsMapper.Conference = new ConferenceMapper();
            divisionStandingsMapper.Conference.Name = "Western";
            divisionStandingsMapper.League = new LeagueMapper();

            divisionStandingsMapper.TeamRecords = new List<TeamRecordsMapper>();
            divisionStandingsMapper.TeamRecords.Add(teamRecords);

            Records = new List<DivisionStandingsMapper>();
            Records.Add(divisionStandingsMapper);

        }
    }
}
