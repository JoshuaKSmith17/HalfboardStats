﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class StandingsMapper
    {
        public string Copyright { get; set; }
        public List<DivisionStandingsMapper> Records { get; set; }
    }
}
