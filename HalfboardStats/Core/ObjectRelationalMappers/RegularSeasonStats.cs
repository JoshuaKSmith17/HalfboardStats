using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.ObjectRelationalMappers
{
    public class RegularSeasonStats
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public string Year { get; set; }
        public int Assists { get; set; }
        public int Goals { get; set; }
        // Redundant with PenaltyMinutes
        // public int Pim { get; set; }
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
        public int ShotsBlocked { get; set; }
        public int PlusMinus { get; set; }
        public int Points { get; set; }
        public int Shifts { get; set; }
        public string TimeOnIcePerGame { get; set; }
        public string EvenTimeOnIcePerGame { get; set; }
        public string ShortHandedTimeOnIcePerGame { get; set; }
        public string PowerPlayTimeOnIcePerGame { get; set; }

    }
}
