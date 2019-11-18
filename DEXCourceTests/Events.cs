using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DEXCource
{
    class Events
    {
        [Test]
        public void EventsTest()
        {
            var quere = new Queue<int>();
            var MaxWasCalled = false;
            var NullWasCalled = false;
            quere.MaxElementsNotify += delegate () { MaxWasCalled = true; };
            quere.ZeroElementsNotify += delegate () { NullWasCalled = true; };
            for (int i = 0; i < 28; i++)
            {
                quere.Enqueue(i);
            }
            for (int i = 0; i < 28; i++)
            {
                quere.Dequeue();
            }
            quere.MaxElementsNotify += delegate () { MaxWasCalled = true; };
            quere.ZeroElementsNotify -= delegate () { NullWasCalled = true; };
            Assert.IsTrue(MaxWasCalled);
            Assert.IsTrue(NullWasCalled);
        }
    }
    public class Queue<T>
    {
        private List<T> _items = new List<T>();
        public int Count => _items.Count;
        public int MaxElements = 8;
        public  delegate void ElementsCountHandler();

        public event ElementsCountHandler MaxElementsNotify;
        public event ElementsCountHandler ZeroElementsNotify;
        public void Enqueue(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if(Count == MaxElements)
            {
                MaxElementsNotify();
            }
            if(Count == 0)
            {
                ZeroElementsNotify();
            }
            _items.Add(item);
        }
        public T Dequeue()
        {
            var item = GetItem();
            _items.Remove(item);
            if (Count == MaxElements)
            {
                MaxElementsNotify();
            }
            if (Count == 0)
            {
                ZeroElementsNotify();
            }
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
            if (item == null)
            {
                throw new NullReferenceException("Очередь пуста. Нет элементов для получения.");
            }
            return item;
        }
    }
}

