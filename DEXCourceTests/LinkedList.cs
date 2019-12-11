using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DEXCource
{
    class LinkedList
    {

    }
    public class Item<T>
    {
        public T Data { get; set; }
        public Item<T> Next { get; set; }
        public Item(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Data = data;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
    public class LinkedListRealization<T> : IEnumerable<T>
    {
        private Item<T> _head = null;
        private Item<T> _tail = null;
        private int _count = 0;
        public int Count
        {
            get => _count;
        }
        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            var item = new Item<T>(data);
            if (_head == null)
            {
                _head = item;
            }
            else
            {
                _tail.Next = item;
            }
            _tail = item;
            _count++;
        }
        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            var current = _head;
            Item<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        _head = _head.Next;
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    _count--;
                    break;
                }
                previous = current;
                current = current.Next;
            }
        }
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
