using System;
using System.Security.Cryptography;
using System.Text;
using NUnit.Framework;

namespace DEXCource
{
    internal class EqualsGetHashCode
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

    internal class PersonInfo
    {
        public PersonInfo(string Fio, string BirthDate, string BirthPlace, int PassportId)
        {
            this.Fio = Fio;
            this.BirthDate = BirthDate;
            this.BirthPlace = BirthPlace;
            this.PassportId = PassportId;
        }

        private string Fio { get; }
        private string BirthDate { get; }
        private string BirthPlace { get; }
        private int PassportId { get; }

        public override int GetHashCode()
        {
            byte[] bytehash;
            using (var md5 = MD5.Create())
            {
                var instring = Fio + BirthDate + BirthPlace + PassportId;
                md5.Initialize();
                md5.ComputeHash(Encoding.UTF8.GetBytes(instring));
                bytehash = md5.Hash;
            }

            var outhash = BitConverter.ToInt32(bytehash, 0);
            return outhash;
        }

        public override bool Equals(object testedPerson)
        {
            PersonInfo person;
            try
            {
                person = (PersonInfo) testedPerson;
            }
            catch (InvalidCastException)
            {
                return false;
            }

            if (person != null && Fio == person.Fio && BirthDate == person.BirthDate &&
                BirthPlace == person.BirthPlace && PassportId == person.PassportId)
                return true;
            return false;
        }
    }
}