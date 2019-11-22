using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DEXCource
{
    class AsyncAwait
    {
        [Test]
        public void AsyncAwaitTest()
        {
            int[] elements = { 1, 2, 3, 4, 5, 6, 7, 8};
            var arithmeticAverage = new ArithmeticAverage();

            var watchParrallel = System.Diagnostics.Stopwatch.StartNew();
            arithmeticAverage.GetParrallel(elements);
            watchParrallel.Stop();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            arithmeticAverage.Get(elements);
            watch.Stop();

            Assert.IsTrue(watchParrallel.ElapsedMilliseconds != watch.ElapsedMilliseconds);
        }
    }
    class ArithmeticAverage
    {
        public double Get(int[] Elements)
        {
            int summ = 0;
            for (int i = 0; i < Elements.Length; i++)
            {
                summ += Elements[i];
            }
            return summ / 2;
        }
        public double GetParrallel(int[] Elements)
        {
            return Elements.AsParallel().Aggregate((x, y) => x + y) / 2;
        }

        private class JobExecutor
        {
            private readonly List<Task> Tasks = new List<Task>();
            private List<Task> RunningTasks = new List<Task>();

            public void Start(int maxConcurrent)
            {
                var semaphore = new SemaphoreSlim(maxConcurrent);
                semaphore.Release();
                for(int i = 0; i < Tasks.Count; i++)
                {
                    Tasks[i].Start();
                    RunningTasks.Add(Tasks[i]);
                    Tasks.RemoveAt(i);
                }
            }
            public void Stop()
            {
                foreach(Task task in RunningTasks)
                {
                    task.Dispose();
                }
            }
            public void Clear()
            {
                Tasks.Clear();
            }
        }
    }
}
