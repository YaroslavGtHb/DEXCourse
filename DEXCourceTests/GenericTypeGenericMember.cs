using System.Collections.Generic;
using NUnit.Framework;

namespace DEXCource
{
    internal class GenericTypeGenericMember
    {
        [Test]
        public void GenericTypeGenericMemberTest()
        {
            var uniquecollection = new UniqueCollection<string>();
            uniquecollection.AddUnique("Значение");
            uniquecollection.AddUnique("Значение");
            Assert.IsTrue(uniquecollection.Count == 1);
        }

        public class UniqueCollection<T> : List<T>
        {
            public void AddUnique(T item)
            {
                if (!Contains(item)) Add(item);
            }
        }
    }
}