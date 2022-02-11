using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalfboardStats.Model.ObjectRelationalMappers
{
    public class Division
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DivisionId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

    }
}
