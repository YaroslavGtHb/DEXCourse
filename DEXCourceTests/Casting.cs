using System;
using NUnit.Framework;

namespace DEXCource
{
    internal class Casting
    {
        [Test]
        public void CastingTest()
        {
            var FullName = "Иван Иванов";
            var people = (Person) FullName;
            Assert.AreEqual("Иван", people.FirstName);
            Assert.AreEqual("Иванов", people.LastName);
        }
    }

    public class Person
    {
        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static explicit operator Person(string FullName)
        {
            var words = FullName.Split(new[] {' '});
            try
            {
                return new Person(words[0], words[1]);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
    }
}