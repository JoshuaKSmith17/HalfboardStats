using HalfboardStats.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfboardStats.Tests.Mockups
{
    internal class DateTimeProviderMockup : IDateTimeProvider
    {
        public int CurrentYear => 2022;

        public int CurrentMonth => 8;
    }
}
