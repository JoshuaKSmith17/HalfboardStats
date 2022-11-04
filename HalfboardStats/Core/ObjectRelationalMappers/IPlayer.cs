using System.Collections.Generic;

namespace HalfboardStats.Core.ObjectRelationalMappers
{
    public interface IPlayer
    {
        string BirthCity { get; set; }
        string BirthCountry { get; set; }
        string BirthDate { get; set; }
        string BirthStateProvince { get; set; }
        int CurrentAge { get; set; }
        Team CurrentTeam { get; set; }
        string FirstName { get; set; }
        string Height { get; set; }
        int Id { get; set; }
        bool IsActive { get; set; }
        bool IsAlternateCaptain { get; set; }
        bool IsCaptain { get; set; }
        bool IsRookie { get; set; }
        string LastName { get; set; }
        string Nationality { get; set; }
        Position PlayingPosition { get; set; }
        string PrimaryNumber { get; set; }
        List<RegularSeasonStats> RegularSeasonStats { get; set; }
        string RosterStatus { get; set; }
        string ShootsCatches { get; set; }
        int TeamId { get; set; }
        int Weight { get; set; }
    }
}