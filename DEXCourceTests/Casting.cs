using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEXCource
{
    class Casting
    {
        [Test]
        public void CastingTest()
        {
            string FullName = "Иван Иванов";
            Person People = (Person)FullName;
            Assert.AreEqual("Иван", People.FirstName);
            Assert.AreEqual("Иванов", People.LastName);
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
            string[] Words = FullName.Split(new char[] { ' ' });
            try
            {
                return new Person(Words[0], Words[1]);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
    }
}
