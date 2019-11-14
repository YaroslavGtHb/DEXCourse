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
    }
}
