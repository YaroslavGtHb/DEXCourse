using NUnit.Framework;
using System.Collections.Generic;

namespace DEXCource
{
    class GenericTypeGenericMember
    {
        [Test]
        public void GenericTypeGenericMemberTest()
        {
            UniqueCollection<string> uniquecollection = new UniqueCollection<string>();
            uniquecollection.AddUnique("Значение");
            uniquecollection.AddUnique("Значение");
            Assert.IsTrue(uniquecollection.Count == 1);
        }
    public class UniqueCollection<T> : List<T>
    {
        public void AddUnique(T item)
        {
                if(!this.Contains(item))
                {
                    this.Add(item);
                }
        }
    }
}
}
