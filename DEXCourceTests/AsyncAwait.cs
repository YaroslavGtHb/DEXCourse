using NUnit.Framework;
using System.Linq;

namespace DEXCource
{
    class AsyncAwait
    {
        [Test]
        public void AsyncAwaitTest()
        {
            int[] Elements = { 1, 2, 3, 4, 5, 6, 7, 8};
            var arithmeticAverage = new ArithmeticAverage();

            var watchParrallel = System.Diagnostics.Stopwatch.StartNew();
            arithmeticAverage.GetParrallel(Elements);
            watchParrallel.Stop();

            var Watch = System.Diagnostics.Stopwatch.StartNew();
            arithmeticAverage.Get(Elements);
            Watch.Stop();

            Assert.IsTrue(watchParrallel.ElapsedMilliseconds < Watch.ElapsedMilliseconds);
        }
    }
    class ArithmeticAverage
    {
        public double Get(int[] Elements)
        {
            int Summ = 0;
            for (int i = 0; i < Elements.Length; i++)
            {
                Summ += Elements[i];
            }
            return Summ / 2;
        }
        public double GetParrallel(int[] Elements)
        {
            return Elements.AsParallel().Aggregate((x, y) => x + y) / 2;
        }
        //public double Get(int[] Elements)
        //{
        //    int Summ = 0;
        //    for (int i = 0; i < Elements.Length; i++)
        //    {
        //        Summ += Elements[i];
        //    }
        //    return Summ / 2;
        //}
        //public async Task<double> GetAsync(int[] Elements)
        //{
        //    return await Task.Run(() => Get(Elements));
        //}
    }
}
