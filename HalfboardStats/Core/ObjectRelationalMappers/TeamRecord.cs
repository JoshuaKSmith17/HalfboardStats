using HalfboardStats.Core.ObjectRelationalMappers.OrmInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Core.ObjectRelationalMappers
{
    public class TeamRecord : ITeamRecord
    {
        public int TeamRecordId { get; set; }
        public string TeamName { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int OvertimeLosses { get; set; }
        public int Points { get; set; }
        public double PointsPercentage { get; set; }

    }
}
