﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.JsonMappers
{
    public class SeasonTypeMapper
    {
        public string DisplayName { get; set; }
        public GameTypeMapper Type { get; set; }

    }
}
