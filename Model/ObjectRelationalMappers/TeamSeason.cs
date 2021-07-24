using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class TeamSeason
    {
        /* 
         * The goal of this class is to contain the data for the win loss record of a team and every other team stastic.
         * The NHL API appears to have all this information obtainable from one get request of the teams/ID/stats endpoint.
         * This class should eventually make our Standings classes unneccessary.  We may choose to keep Standings for efficient
         * use of the smaller data set.
         */
        public int Id { get; set; }
        public int Year { get; set; }
        public Team Team { get; set; }

    }
}
