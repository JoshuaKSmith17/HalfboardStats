using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class Conference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConferenceId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

    }
}
