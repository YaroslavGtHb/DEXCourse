using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace DEXCource
{
    class Reflection
    {
        [Test]
        public void ReflectionTest()
        {
            PrivateClass privateClass = new PrivateClass();
            Type privateClassType = privateClass.GetType();
            object privateClassInstance = Activator.CreateInstance(privateClassType);
            MethodInfo[] privateClassMethods = privateClassType.GetMethods(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            MethodInfo privateMethod = privateClassMethods.First(m => m.Name == "PrivateMethod");
            var privateMethodResult = privateMethod.Invoke(privateClassInstance, new object[] { "Привет", "Мир!" });
            Assert.AreEqual(privateMethodResult, "ПриветМир!");
        }
    }
    class PrivateClass
    {
        private string PrivateMethod(string firstString, string secondString)
        {
            return firstString + secondString;
        }
    }
}
