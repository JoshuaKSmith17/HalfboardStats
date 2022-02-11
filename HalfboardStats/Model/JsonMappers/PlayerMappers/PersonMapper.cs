using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.JsonMappers
{
    public class PersonMapper
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Link { get; set; }
        public TeamMapper currentTeam { get; set; }
    }
}
