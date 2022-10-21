﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeamId { get; set; }
        public int DivisionId { get; set; }
        public int FranchiseId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Abbreviation { get; set; }
        public string TeamName { get; set; }
        public string LocationName { get; set; }
        public int FirstYearOfPlay { get; set; }
        public string ShortName { get; set; }
        public string OfficialSiteUrl { get; set; }        
        public bool IsActive { get; set; }
        public List<TeamSeason> TeamSeasons { get; set; }

    }
}
