using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEXCource
{
    class Extentions
    {
        [Test]
        public void ExtentionsTest()
        {
            var time = new TimeSpan();
            int Milliseconds = 88;
            int Seconds = 88;
            int Minutes = 88;
            int Hours = 88;
            int Days = 88;
            time += Milliseconds.ToMilliseconds();
            time += Seconds.ToSeconds();
            time += Minutes.ToMinutes();
            time += Hours.ToHours();
            time += Days.ToDays();
            Assert.AreEqual(time.TotalMilliseconds, 7925368088);
        }
    }
    public static class IntTimeSpanExtentions
    {
        public static TimeSpan ToMilliseconds(this int number)
        {
            return new TimeSpan(0, 0, 0, 0, number);
        }
        public static TimeSpan ToSeconds(this int number)
        {
            return new TimeSpan(0, 0, 0, number, 0);
        }
        public static TimeSpan ToMinutes(this int number)
        {
            return new TimeSpan(0, 0, number, 0, 0);
        }
        public static TimeSpan ToHours(this int number)
        {
            return new TimeSpan(0, number, 0, 0, 0);
        }
        public static TimeSpan ToDays(this int number)
        {
            return new TimeSpan(number, 0, 0, 0, 0);
        }
    }
}
