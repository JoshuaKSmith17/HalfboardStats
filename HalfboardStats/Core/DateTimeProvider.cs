using System;

namespace HalfboardStats.Core
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public int CurrentYear => DateTime.Now.Year;
        public int CurrentMonth => DateTime.Now.Month;
    }
}
