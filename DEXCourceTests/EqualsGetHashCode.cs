using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DEXCource
{
    class EqualsGetHashCode
    {
        [Test]
        public void EqualsGetHashCodeTest()
        {
            var firstPerson = new PersonInfo("ПерсонажевПерсонажПерсонажович", "1988", "Персонляндия", 8888);
            var secondPerson = new PersonInfo("ВыдуманныйВыдумВыдумович", "1988", "Выдумляндия", 88888888);
            Assert.AreNotEqual(firstPerson.GetHashCode(), secondPerson.GetHashCode());
            Assert.IsFalse(firstPerson.Equals(secondPerson));
        }
    }
    class PersonInfo
    {
        public PersonInfo(string FIO, string BirthDate, string BirthPlace, int PassportId)
        {
            this.FIO = FIO;
            this.BirthDate = BirthDate;
            this.BirthPlace = BirthPlace;
            this.PassportId = PassportId;
        }
        string FIO { get; set; }
        string BirthDate { get; set; }
        string BirthPlace { get; set; }
        int PassportId { get; set; }
        public override int GetHashCode()
        {
            byte[] bytehash;
            using (MD5 md5 = MD5.Create())
            {
                string instring = FIO + BirthDate + BirthPlace + PassportId;
                md5.Initialize();
                md5.ComputeHash(Encoding.UTF8.GetBytes(instring));
                bytehash = md5.Hash;
            }
            int outhash = BitConverter.ToInt32(bytehash, 0);
            return outhash;
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
