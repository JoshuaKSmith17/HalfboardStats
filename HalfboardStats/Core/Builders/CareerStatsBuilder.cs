using HalfboardStats.Core.JsonMappers.StatsMappers;
using HalfboardStats.Core.ObjectRelationalMappers;
using HalfboardStats.Infrastructure.ServiceAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.Builders
{
    public class CareerStatsBuilder : ICareerStatsBuilder
    {
        public IServiceProvider ServiceProvider { get; set; }
        public CareerStatsBuilder(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public List<RegularSeasonStats> BuildCareerStatsAsync(int Id, YearByYearMapper playerStats)
        {
            // var agent = (IYearByYearStatsAgent)ServiceProvider.GetService(typeof(IYearByYearStatsAgent));
            // var playerStats = await agent.GetCareerStats(Id);
            List<RegularSeasonStats> regularSeasonStats = new List<RegularSeasonStats>();

            foreach(var splits in playerStats.Stats[0].Splits)
            {
                // Checks if the league is the NHL
                if(splits.League.Id == 133)
                {
                    // Commented lines are not available in this GET request
                    RegularSeasonStats playerSeason = new RegularSeasonStats();
                    playerSeason.PlayerId = Id;
                    playerSeason.TeamId = splits.Team.Id;

                    playerSeason.Assists = splits.Stat.Assists;
                    playerSeason.EvenStrengthTimeOnIce = splits.Stat.EvenStrengthTimeOnIce;
                    playerSeason.EvenTimeOnIcePerGame = splits.Stat.EvenTimeOnIcePerGame;
                    playerSeason.FaceOffPct = splits.Stat.FaceOffPct;
                    playerSeason.Games = splits.Stat.Games;
                    playerSeason.GameWinningGoals = splits.Stat.GameWinningGoals;
                    playerSeason.Goals = splits.Stat.Goals;
                    playerSeason.Hits = splits.Stat.Hits;
                    playerSeason.OverTimeGoals = splits.Stat.OverTimeGoals;
                    playerSeason.PenaltyMinutes = splits.Stat.PenaltyMinutes;
                    playerSeason.PlusMinus = splits.Stat.PlusMinus;
                    playerSeason.Points = splits.Stat.Points;
                    playerSeason.PowerPlayGoals = splits.Stat.PowerPlayGoals;
                    playerSeason.PowerPlayPoints = splits.Stat.PowerPlayPoints;
                    playerSeason.PowerPlayTimeOnIce = splits.Stat.PowerPlayTimeOnIce;
                    // playerSeason.PowerPlayTimeOnIcePerGame = splits.Stat.PowerPlayTimeOnIcePerGame;
                    playerSeason.Shifts = splits.Stat.Shifts;
                    playerSeason.ShortHandedGoals = splits.Stat.ShortHandedGoals;
                    playerSeason.ShortHandedPoints = splits.Stat.ShortHandedPoints;
                    playerSeason.ShortHandedTimeOnIce = splits.Stat.ShortHandedTimeOnIce;
                    // playerSeason.ShortHandedTimeOnIcePerGame = splits.Stat.ShortHandedTimeOnIcePerGame;
                    playerSeason.ShotPct = splits.Stat.ShotPct;
                    playerSeason.Shots = splits.Stat.Shots;
                    playerSeason.ShotsBlocked = splits.Stat.Blocked;
                    // playerSeason.TimeOnIcePerGame = splits.Stat.TimeOnIcePerGame;
                    playerSeason.Year = splits.Season;

                    regularSeasonStats.Add(playerSeason);
                }

            }

            return regularSeasonStats;
            
        }
    }
}
