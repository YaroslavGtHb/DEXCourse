using Newtonsoft.Json;
using NUnit.Framework;

namespace DEXCource
{
    internal class Serialization
    {
        [Test]
        public void SerializationTest()
        {
            var serializableInstance = new SerializationClass("Сериализатор", "Сериализаторов", 42, 88);
            var serializableString = JsonConvert.SerializeObject(serializableInstance);
            var deserializableInstance = JsonConvert.DeserializeObject<SerializationClass>(serializableString);
            Assert.AreEqual(serializableInstance.FirstName, deserializableInstance.FirstName);
            Assert.AreEqual(serializableInstance.LastName, deserializableInstance.LastName);
            Assert.AreEqual(serializableInstance.Id, deserializableInstance.Id);
            Assert.AreEqual(serializableInstance.Level, deserializableInstance.Level);
        }
    }

    public class SerializationClass
    {
        public SerializationClass()
        {
        }

        public SerializationClass(string firstName, string lastName, int Id, int Level)
        {
            FirstName = firstName;
            LastName = lastName;
            this.Id = Id;
            this.Level = Level;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public int Level { get; set; }
    }
}