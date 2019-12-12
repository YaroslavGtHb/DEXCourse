using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using NUnit.Framework;

namespace DEXCource
{
    class DeepClone
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
            this.doubleValue = doubleValue;
            this.boolValue = boolValue;
            this.stringValue = stringValue;
        }
        public int intValue { get; set; }
        public double doubleValue { get; set; }
        public bool boolValue { get; set; }
        public string stringValue { get; set; }

        public ClonableClass Clone()
        {
            ClonableClass clonedClass = new ClonableClass(intValue, doubleValue, boolValue, stringValue);
            return clonedClass;
        }
    }
    public static class ObjectCopier
    {
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException();
            }
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}