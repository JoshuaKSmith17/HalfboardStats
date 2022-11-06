using System;

namespace HalfboardStats.Core
{
    public class SeasonYear : ISeasonYear
    {
        public string Year { get; set; }
        public string BaseYear { get; set; }
        public string FirstYear => "19171918";
        public IDateTimeProvider TimeProvider { get; set; }
        public SeasonYear(IDateTimeProvider timeProvider)
        {
            TimeProvider = timeProvider;
            if (timeProvider.CurrentMonth >= 7)
            {
                Year = TimeProvider.CurrentYear.ToString() + (TimeProvider.CurrentYear + 1).ToString();
                BaseYear = Year;
            }
            else
            {
                Year = (TimeProvider.CurrentYear - 1).ToString() + TimeProvider.CurrentYear;
                BaseYear = Year;
            }
        }

        public void IncrementSeason()
        {
            if (Year != BaseYear)
            {
                Year = Year.Substring(4, 4);
                Year += (int.Parse(Year) + 1).ToString();
            }
        }

        public void DecrementSeason()
        {
            if (Year != FirstYear)
            {
                Year = (int.Parse(Year.Substring(0, 4)) - 1).ToString();
                Year += (int.Parse(Year) + 1).ToString();
            }
        }
    }
}
