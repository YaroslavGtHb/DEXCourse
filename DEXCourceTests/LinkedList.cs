using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DEXCource
{
    internal class LinkedList
    {
        [Test]
        public void LinkedListTest()
        {
            var linkedList = new LinkedListRealization<int>();
            linkedList.Add(2);
            linkedList.Add(4);
            linkedList.Add(8);
            linkedList.Add(16);
            var testitem = linkedList.ElementAt(3);
            foreach (var item in linkedList.BackEnumerator()) testitem = item;
            Assert.AreEqual(testitem, linkedList.First());
        }
    }

    public class Element<T>
    {
        public Element(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public Element<T> Previous { get; set; }
        public Element<T> Next { get; set; }
    }

    public class LinkedListRealization<T> : IEnumerable<T>
    {
        private Element<T> head;
        private Element<T> tail;

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Add(T data)
        {
            var node = new Element<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }

            tail = node;
            Count++;
        }

        public void AddFirst(T data)
        {
            var node = new Element<T>(data);
            var temp = head;
            node.Next = temp;
            head = node;
            if (Count == 0)
                tail = head;
            else
                temp.Previous = node;
            Count++;
        }

        public bool Remove(T data)
        {
            var current = head;
            while (current != null)
            {
                if (current.Data.Equals(data)) break;

                current = current.Next;
            }

            if (current != null)
            {
                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;
                Count--;
                return true;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public bool Contains(T data)
        {
            var current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }

            return false;
        }

        public IEnumerable<T> BackEnumerator()
        {
            var current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}