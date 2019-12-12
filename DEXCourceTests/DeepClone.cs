using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace DEXCource
{
    internal class DeepClone
    {
        [Test]
        public void DeepCloneTest()
        {
            var cloning = new ClonableClass(8, 88, true, "HelloWorld!");
            var cloned = cloning.Clone();
            Assert.AreEqual(cloning.intValue, cloned.intValue);
        }
    }

    public class ClonableClass
    {
        public ClonableClass(int intValue, double DoubleValue, bool BoolValue, string StringValue)
        {
            this.intValue = intValue;
            doubleValue = doubleValue;
            boolValue = boolValue;
            stringValue = stringValue;
        }
        public int intValue { get; set; }
        public double doubleValue { get; set; }
        public bool boolValue { get; set; }
        public string stringValue { get; set; }

        public ClonableClass Clone()
        {
            var clonedClass = new ClonableClass(intValue, doubleValue, boolValue, stringValue);
            return clonedClass;
        }
    }

    public static class ObjectCopier
    {
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable) throw new ArgumentException();
            if (ReferenceEquals(source, null)) return default;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(stream);
            }
        }
    }
}