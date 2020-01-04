using NUnit.Framework;
using System;

namespace DEXCource
{
    internal class Extentions
    {
        [Test]
        public void ExtentionsTest()
        {
            var time = new TimeSpan();
            var Milliseconds = 88;
            var Seconds = 88;
            var Minutes = 88;
            var Hours = 88;
            var Days = 88;
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