using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DEXCource
{
    class Reflection
    {
        [Test]
        public void ReflectionTest()
        {
            //OOP OOPInstaince = (OOP)Activator.CreateInstance("MyAssembly", "OOP");
            //OOPInstaince.OOPTest();

            PrivateClass privateClass = new PrivateClass();
            Type privateClassType = privateClass.GetType();
            MethodInfo[] privateClassMethods = privateClassType.GetMethods(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            Assert.AreEqual(privateClassMethods.Length, 1);
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
