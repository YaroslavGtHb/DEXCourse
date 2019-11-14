using System;
using System.Collections;
using System.Collections.Generic;

namespace DEXCource
{
    class IEnumerableIEnumerator
    {
    }

    public class ZOO
    {
        string[] Animals = { "Lion", "Mokney" };
        public IEnumerator<string> GetEnumerator()
        {
            return new ZOOEnumerator(Animals);
        }
        public class ZOOEnumerator : IEnumerator<string>
        {
            string[] Animals;
            public int Position { get; set; }
            public ZOOEnumerator(string[] days)
            {
                Animals = Animals;
            }
            public string Current
            {
                get
                {
                    if (Position == -1 || Position >= Animals.Length)
                        throw new InvalidOperationException();
                    return Animals[Position];
                }
            }
            object IEnumerator.Current => throw new NotImplementedException();
            public bool MoveNext()
            {
                if (Position < Animals.Length - 1)
                {
                    Position++;
                    return true;
                }
                else
                    return false;
            }
            public void Reset()
            {
                Position = -1;
            }
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
