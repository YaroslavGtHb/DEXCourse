using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DEXCource
{
    class LinkedList
    {
        [Test]
        public void LinkedListTest()
        {
            var linkedList = new LinkedListRealization<int>();
            linkedList.Add(2);
            linkedList.Add(4);
            linkedList.Add(8);
            linkedList.Add(16);
            linkedList.
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
        Element<T> head;
        Element<T> tail;
        int count;
        public void Add(T data)
        {
            Element<T> node = new Element<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }

            tail = node;
            count++;
        }

        public void AddFirst(T data)
        {
            Element<T> node = new Element<T>(data);
            Element<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        public bool Remove(T data)
        {
            Element<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }

                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                count--;
                return true;
            }

            return false;
        }

        public int Count
        {
            get { return count; }
        }
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T data)
        {
            Element<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Element<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerable<T> BackEnumerator()
        {
            Element<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}