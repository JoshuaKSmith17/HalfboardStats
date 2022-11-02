using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalfboardStats.Core.ObjectRelationalMappers
{
    public class Player : IEntity, IPlayer
    {
        /*
         * This class is mainly mapped to PeopleMapper.cs.  PeopleMapper is the main area of the API that we are pulling
         * player data from.  Another difference is that season statistics for a player will have a relation in this class.
         */

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public virtual Team CurrentTeam { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryNumber { get; set; }
        public string BirthDate { get; set; }
        public int CurrentAge { get; set; }
        public string BirthCity { get; set; }
        public string BirthStateProvince { get; set; }
        public string BirthCountry { get; set; }
        public string Nationality { get; set; }
        public string Height { get; set; }
        public int Weight { get; set; }
        public bool IsActive { get; set; }
        public bool IsAlternateCaptain { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsRookie { get; set; }
        public string ShootsCatches { get; set; }
        public string RosterStatus { get; set; }
        public Position PlayingPosition { get; set; }
        public List<RegularSeasonStats> RegularSeasonStats { get; set; }
    }
}
