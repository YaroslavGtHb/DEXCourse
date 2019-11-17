using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DEXCource
{
    class ListDictionary
    {
        [Test]
        public void ListDictionaryTest()
        {
            PersonArchive archive = new PersonArchive();
            archive.Add(new PersonInformation("ПерсоновПерсонПерсонович", "1988", "1", 8888), "ПерсонГаллера");
            string searchedWorkPlace = archive.Search(new PersonInformation("ПерсоновПерсонПерсонович", "1988", "1", 8888));
            Assert.AreEqual("ПерсонГаллера", searchedWorkPlace);
        }
    }
    public class PersonArchive
    {
        private Dictionary<PersonInformation, string> _personDatabase = new Dictionary<PersonInformation, string>();
        public void Add(PersonInformation Person, string WorkPlace)
        {
            _personDatabase.Add(Person, WorkPlace);
        }
        public string Search(PersonInformation SearchedPerson)
        {
            var Answer = _personDatabase.First(t => t.Key.FIO == SearchedPerson.FIO && t.Key.BirthDay == SearchedPerson.BirthDay && t.Key.BirthPlace == SearchedPerson.BirthPlace && t.Key.PassportId == SearchedPerson.PassportId);
            return Answer.Value;
            
        }
    }
    public class PersonInformation
    {
        public PersonInformation(string FIO, string BirthDay, string BirthPlace, int PassportId)
        {
            this.FIO = FIO;
            this.BirthDay = BirthDay;
            this.BirthPlace = BirthPlace;
            this.PassportId = PassportId;
        }
        public string FIO { get; set; }
        public string BirthDay { get; set; }
        public string BirthPlace { get; set; }
        public int PassportId { get; set; }
    }
}
