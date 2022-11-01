using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.JsonMappers.PlayerMappers
{
    public class PlayerSeasonSplitStatMapper
    {
        public string TimeOnIce { get; set; }
        public int Assists { get; set; }
        public int Goals { get; set; }
        public int Pim { get; set; }
        public int Shots { get; set; }
        public int Games { get; set; }
        public int Hits { get; set; }
        public int PowerPlayGoals { get; set; }
        public int PowerPlayPoints { get; set; }
        public string PowerPlayTimeOnIce { get; set; }
        public string EvenStrengthTimeOnIce { get; set; }
        public string PenaltyMinutes { get; set; }
        public double FaceOffPct { get; set; }
        public double ShotPct { get; set; }
        public int GameWinningGoals { get; set; }
        public int OverTimeGoals { get; set; }
        public int ShortHandedGoals { get; set; }
        public int ShortHandedPoints { get; set; }
        public string ShortHandedTimeOnIce { get; set; }

        // I assume that Blocked is blocked shots.
        public int Blocked { get; set; }
        public int PlusMinus { get; set; }
        public int Points { get; set; }
        public int Shifts { get; set; }
        public string TimeOnIcePerGame { get; set; }
        public string EvenTimeOnIcePerGame { get; set; }
        public string ShortHandedTimeOnIcePerGame { get; set; }
        public string PowerPlayTimeOnIcePerGame { get; set; }

    }
}
