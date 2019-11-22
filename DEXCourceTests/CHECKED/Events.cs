using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DEXCource
{
    internal class Events
    {
        [Test]
        public void EventsTest()
        {
            var quere = new Queue<int>();
            var maxWasCalled = false;
            var nullWasCalled = false;
            quere.MaxElementsNotify += delegate { maxWasCalled = true; };
            quere.ZeroElementsNotify += delegate { nullWasCalled = true; };
            for (var i = 0; i < 28; i++) quere.Enqueue(i);
            for (var i = 0; i < 28; i++) quere.Dequeue();
            quere.MaxElementsNotify += delegate { maxWasCalled = true; };
            quere.ZeroElementsNotify -= delegate { nullWasCalled = true; };
            Assert.IsTrue(maxWasCalled);
            Assert.IsTrue(nullWasCalled);
        }
    }

    public class Queue<T>
    {
        public delegate void ElementsCountHandler();

        private readonly List<T> _items = new List<T>();
        public int MaxElements = 8;
        public int Count => _items.Count;

        public event ElementsCountHandler MaxElementsNotify;
        public event ElementsCountHandler ZeroElementsNotify;

        public void Enqueue(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (Count == MaxElements)
                if (MaxElementsNotify != null)
                    MaxElementsNotify();
            if (Count == 0)
                if (ZeroElementsNotify != null)
                    ZeroElementsNotify();
            _items.Add(item);
        }

        public T Dequeue()
        {
            var item = GetItem();
            _items.Remove(item);
            if (Count == MaxElements)
                if (MaxElementsNotify != null)
                    MaxElementsNotify();
            if (Count == 0)
                if (ZeroElementsNotify != null)
                    ZeroElementsNotify();
            return item;
        }

        public T Peek()
        {
            var item = GetItem();
            return item;
        }

        private T GetItem()
        {
            var item = _items.FirstOrDefault();
            if (item == null) throw new NullReferenceException("Очередь пуста. Нет элементов для получения.");
            return item;
        }
    }
}