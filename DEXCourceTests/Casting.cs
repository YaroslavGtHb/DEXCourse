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
            this.SetFirstName(FirstName);
            this.SetLastName(LastName);
        }

        private string firstName;

        private string GetFirstName()
        {
            return firstName;
        }

        private void SetFirstName(string value)
        {
            firstName = value;
        }

        private string lastName;

        private string GetLastName()
        {
            return lastName;
        }

        private void SetLastName(string value)
        {
            lastName = value;
        }

        public static explicit operator Person(string v)
        {
            throw new NotImplementedException();
        }
    }
}
