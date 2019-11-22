using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DEXCource
{
    internal class AsyncAwait
    {
        [Test]
        public void AsyncAwaitTest()
        {
            int[] elements = {1, 2, 3, 4, 5, 6, 7, 8};
            var arithmeticAverage = new ArithmeticAverage();

            var watchParrallel = Stopwatch.StartNew();
            arithmeticAverage.GetParrallel(elements);
            watchParrallel.Stop();

            var watch = Stopwatch.StartNew();
            arithmeticAverage.Get(elements);
            watch.Stop();

            Assert.IsTrue(watchParrallel.ElapsedMilliseconds != watch.ElapsedMilliseconds);

            var jobExecutor = new MyJobExecutor();
            for (int i = 0; i < 8; i++)
            {
                jobExecutor.Add(() => { Console.WriteLine(Task.CurrentId); });
            }
            Assert.AreEqual(jobExecutor.Amount, 8);
            jobExecutor.Start(8);
            Assert.AreEqual(jobExecutor.Amount, 0);
        }
    }

    internal class ArithmeticAverage
    {
        public double Get(int[] Elements)
        {
            var summ = 0;
            for (var i = 0; i < Elements.Length; i++) summ += Elements[i];
            return summ / 2;
        }

        public double GetParrallel(int[] Elements)
        {
            return Elements.AsParallel().Aggregate((x, y) => x + y) / 2;
        }
    }

    public interface IJobExecutor
    {
        int Amount { get; }
        void Start(int maxConcurrent);
        void Stop();
        void Add(Action action);
        void Clear();
    }

    public class MyJobExecutor : IJobExecutor
    {
        private BlockingCollection<Action> _actions;
        private volatile bool _jobIsStarted;
        private volatile bool _shouldStop;

        public MyJobExecutor()
        {
            _actions = new BlockingCollection<Action>();
        }

        public int Amount => _actions.Count;

        public void Start(int maxConcurrent)
        {
            if (maxConcurrent <= 0) throw new ArgumentOutOfRangeException(nameof(maxConcurrent));

            if (_jobIsStarted) return;

            _jobIsStarted = true;


            var tasks = new List<Task>();
            using var semaphoreSlim = new SemaphoreSlim(Environment.ProcessorCount, maxConcurrent);


            while (!_shouldStop)
            {
                if (_actions.Count < 1) return;

                semaphoreSlim.Wait();
                tasks.Add(Task.Run(() =>
                {
                    try
                    {
                        _actions.Take().Invoke();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        semaphoreSlim.Release();
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            _jobIsStarted = false;
        }

        public void Stop()
        {
            _shouldStop = true;
        }

        public void Add(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            _actions.Add(action);
        }

        public void Clear()
        {
            _actions = new BlockingCollection<Action>();
        }
    }
}