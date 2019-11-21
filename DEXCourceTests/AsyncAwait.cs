using NUnit.Framework;
using System;
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
        class JobExecutor
        {
            private List<Task> Tasks = new List<Task>();
            private List<Task> RunningTasks = new List<Task>();
            public int Amount()
            {
                return Tasks.Count;
            }
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
