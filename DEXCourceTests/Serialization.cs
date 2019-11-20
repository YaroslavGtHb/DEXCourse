using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEXCource
{
    class Serialization
    {
        [Test]
        public void SerializationTest()
        {
            var SerializableInstance = new SerializationClass("Сериализатор", "Сериализаторов", 42, 88);
            string SerializableString = JsonConvert.SerializeObject(SerializableInstance);
            SerializationClass DeserializableInstance = JsonConvert.DeserializeObject<SerializationClass>(SerializableString);
            Assert.AreEqual(SerializableInstance.firstName, DeserializableInstance.firstName);
            Assert.AreEqual(SerializableInstance.lastName, DeserializableInstance.lastName);
            Assert.AreEqual(SerializableInstance.ID, DeserializableInstance.ID);
            Assert.AreEqual(SerializableInstance.Level, DeserializableInstance.Level);
        }
    }
    public class SerializationClass
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int ID { get; set; }
        public int Level { get; set; }
        public SerializationClass()
        {

        }
        public SerializationClass(string firstName, string lastName, int ID, int Level)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.ID = ID;
            this.Level = Level;
        }
    }
}
