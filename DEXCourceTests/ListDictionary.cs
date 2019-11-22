using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DEXCource
{
    internal class ListDictionary
    {
        [Test]
        public void ListDictionaryTest()
        {
            var archive = new PersonArchive();
            archive.Add(new PersonInformation("ПерсоновПерсонПерсонович", "1988", "1", 8888), "ПерсонГаллера");
            var searchedWorkPlace =
                archive.Search(new PersonInformation("ПерсоновПерсонПерсонович", "1988", "1", 8888));
            Assert.AreEqual("ПерсонГаллера", searchedWorkPlace);
        }
    }

    public class PersonArchive
    {
        private readonly Dictionary<PersonInformation, string> _personDatabase =
            new Dictionary<PersonInformation, string>();

        public void Add(PersonInformation Person, string WorkPlace)
        {
            _personDatabase.Add(Person, WorkPlace);
        }

        public string Search(PersonInformation SearchedPerson)
        {
            var answer = _personDatabase.First(t =>
                t.Key.Fio == SearchedPerson.Fio && t.Key.BirthDay == SearchedPerson.BirthDay &&
                t.Key.BirthPlace == SearchedPerson.BirthPlace && t.Key.PassportId == SearchedPerson.PassportId);
            return answer.Value;
        }
    }

    public class PersonInformation
    {
        public PersonInformation(string Fio, string BirthDay, string BirthPlace, int PassportId)
        {
            this.Fio = Fio;
            this.BirthDay = BirthDay;
            this.BirthPlace = BirthPlace;
            this.PassportId = PassportId;
        }

        public string Fio { get; set; }
        public string BirthDay { get; set; }
        public string BirthPlace { get; set; }
        public int PassportId { get; set; }
    }
}