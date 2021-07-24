using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalfboardStats.Model.JsonMappers
{
    public class PeopleMapper
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Link { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryNumber { get; set; }

        // TODO Birthdate property is currently coming in as a string.  Need to convert to DateTime at some point.
        public string BirthDate { get; set; }
        public int CurrentAge { get; set; }
        public string BirthCity { get; set; }
        public string BirthStateProvince { get; set; }
        public string BirthCountry { get; set; }
        public string Nationality { get; set; }

        // TODO Height comes in as a string with a character break.  We need to ensure this data is captured properly.
        public string Height { get; set; }
        public int Weight { get; set; }
        public bool Active { get; set; }
        public bool AlternateCaptain { get; set; }
        public bool Captain { get; set; }
        public bool Rookie { get; set; }
        public string ShootsCatches { get; set; }
        public string RosterStatus { get; set; }
        public TeamMapper teamMapper { get; set; }
        public PositionMapper PrimaryPosition { get; set; }

    }
}
