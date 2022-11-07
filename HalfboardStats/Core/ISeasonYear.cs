namespace HalfboardStats.Core
{
    public interface ISeasonYear
    {
        string Year { get; set; }
        string FirstYear { get; }
        string BaseYear { get; set; }
        IDateTimeProvider TimeProvider { get; set; }

        void DecrementSeason();
        void IncrementSeason();
    }
}