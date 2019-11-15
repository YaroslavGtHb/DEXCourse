using System;
using System.Collections.Generic;
using System.Text;

namespace DEXCource
{
    class Casting
    {
        public void CastingTest()
        {
            var Pupkin = new Person("Иван", "Пупкин");
            string PupkinString = "Петр Петров";
            _ = (Person)PupkinString;
            _ = PupkinString.GetType();
        }
    }
    public class Person
    {
        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        string FirstName { get; set; }
        string LastName { get; set; }

        public static explicit operator Person(string v)
        {
            throw new NotImplementedException();
        }
    }
}
