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
        public CareerStatsBuilder()
        {
        }

        public List<RegularSeasonStats> BuildCareerStatsAsync(int Id, YearByYearMapper playerStats)
        {
            List<RegularSeasonStats> regularSeasonStats = new List<RegularSeasonStats>();

            foreach(var splits in playerStats.Stats[0].Splits)
            {
                // Checks if the league is the NHL
                if(splits.League.Id == 133)
                {
                    RegularSeasonStats playerSeason = MapStats(Id, splits);
                    regularSeasonStats.Add(playerSeason);
                }
            }
            return regularSeasonStats;            
        }

        public List<RegularSeasonStats> BuildSeasonStatsAsync(int Id, YearByYearMapper playerStats)
        {
            List<RegularSeasonStats> regularSeasonStats = new List<RegularSeasonStats>();

            foreach (var splits in playerStats.Stats[0].Splits)
            {     
                RegularSeasonStats playerSeason = MapStats(Id, splits);
                regularSeasonStats.Add(playerSeason);            

            }
            return regularSeasonStats;
        }

        private RegularSeasonStats MapStats(int Id, YearByYearStatLineItem statLineItem)
        {
            RegularSeasonStats playerSeason = new RegularSeasonStats();
            playerSeason.PlayerId = Id;
            playerSeason.TeamId = statLineItem.Team.Id;

            playerSeason.Assists = statLineItem.Stat.Assists;
            playerSeason.EvenStrengthTimeOnIce = statLineItem.Stat.EvenStrengthTimeOnIce;
            playerSeason.EvenTimeOnIcePerGame = statLineItem.Stat.EvenTimeOnIcePerGame;
            playerSeason.FaceOffPct = statLineItem.Stat.FaceOffPct;
            playerSeason.Games = statLineItem.Stat.Games;
            playerSeason.GameWinningGoals = statLineItem.Stat.GameWinningGoals;
            playerSeason.Goals = statLineItem.Stat.Goals;
            playerSeason.Hits = statLineItem.Stat.Hits;
            playerSeason.OverTimeGoals = statLineItem.Stat.OverTimeGoals;
            playerSeason.PenaltyMinutes = statLineItem.Stat.PenaltyMinutes;
            playerSeason.PlusMinus = statLineItem.Stat.PlusMinus;
            playerSeason.Points = statLineItem.Stat.Points;
            playerSeason.PowerPlayGoals = statLineItem.Stat.PowerPlayGoals;
            playerSeason.PowerPlayPoints = statLineItem.Stat.PowerPlayPoints;
            playerSeason.PowerPlayTimeOnIce = statLineItem.Stat.PowerPlayTimeOnIce;
            // playerSeason.PowerPlayTimeOnIcePerGame = splits.Stat.PowerPlayTimeOnIcePerGame;
            playerSeason.Shifts = statLineItem.Stat.Shifts;
            playerSeason.ShortHandedGoals = statLineItem.Stat.ShortHandedGoals;
            playerSeason.ShortHandedPoints = statLineItem.Stat.ShortHandedPoints;
            playerSeason.ShortHandedTimeOnIce = statLineItem.Stat.ShortHandedTimeOnIce;
            // playerSeason.ShortHandedTimeOnIcePerGame = splits.Stat.ShortHandedTimeOnIcePerGame;
            playerSeason.ShotPct = statLineItem.Stat.ShotPct;
            playerSeason.Shots = statLineItem.Stat.Shots;
            playerSeason.ShotsBlocked = statLineItem.Stat.Blocked;
            // playerSeason.TimeOnIcePerGame = splits.Stat.TimeOnIcePerGame;
            playerSeason.Year = statLineItem.Season;

            return playerSeason;
        }
    }
}
