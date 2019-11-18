using System;
using System.Collections.Generic;
using System.Text;

namespace DEXCource
{
    class Extentions
    {
    }
    public class IntTimeSpanExtentions
    {
        public static TimeSpan ToMilliseconds(int number)
        {
            return new TimeSpan(0, 0, 0, 0, number);
        }
        public static TimeSpan ToSeconds(int number)
        {
            return new TimeSpan(0, 0, 0, number, 0);
        }
        public static TimeSpan ToMinutes(int number)
        {
            return new TimeSpan(0, 0, number, 0, 0);
        }
        public static TimeSpan ToHours(int number)
        {
            return new TimeSpan(0, number, 0, 0, 0);
        }
        public static TimeSpan ToDays(int number)
        {
            return new TimeSpan(number, 0, 0, 0, 0);
        }
    }
}
