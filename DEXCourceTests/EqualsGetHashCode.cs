using System;
using System.Collections.Generic;
using System.Text;

namespace DEXCource
{
    class EqualsGetHashCode
    {
    }
    class PersonInfo
    {
        public PersonInfo(string FIO, string BirthDate, string BirthPlace, string PassportId)
        {
            this.FIO = FIO;
            this.BirthDate = BirthDate;
            this.BirthPlace = BirthPlace;
            this.PassportId = PassportId;
        }
        string FIO { get; set; }
        string BirthDate { get; set; }
        string BirthPlace { get; set; }
        string PassportId { get; set; }
        public override int GetHashCode()
        {
            return Int32.Parse(FIO) + Int32.Parse(BirthDate) + Int32.Parse(BirthPlace) + Int32.Parse(PassportId);
        }
        public override bool Equals(object testedPerson)
        {
            PersonInfo person;
            try
            {
                person = (PersonInfo)testedPerson;
            }
            catch(InvalidCastException)
            {
                return false;
            }

            if (FIO == person.FIO && BirthDate == person.BirthDate && BirthPlace == person.BirthPlace && PassportId == person.PassportId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
