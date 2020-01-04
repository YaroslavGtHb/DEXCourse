using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace DEXCource
{
    internal class Reflection
    {
        [Test]
        public void ReflectionTest()
        {
            var privateClass = new PrivateClass();
            var privateClassType = privateClass.GetType();
            var privateClassInstance = Activator.CreateInstance(privateClassType);
            var prvateClassConstructors = privateClassType.GetConstructors(BindingFlags.DeclaredOnly
                                                                           | BindingFlags.Instance |
                                                                           BindingFlags.NonPublic |
                                                                           BindingFlags.Public);
            var privateConstructor = prvateClassConstructors.First(m => m.IsPrivate);
            var privateConstructorResult = privateConstructor.Invoke(privateClassInstance,
                new object[] { "ПриватноеПоле!", "ПриватноеСвойство!" });
            var privateClassFields = privateClassType.GetFields(BindingFlags.DeclaredOnly
                                                                | BindingFlags.Instance | BindingFlags.NonPublic |
                                                                BindingFlags.Public);
            var privateField = privateClassFields.First(m => m.Name == "PrivateField");
            var privateClassPropetries = privateClassType.GetProperties(BindingFlags.DeclaredOnly
                                                                        | BindingFlags.Instance |
                                                                        BindingFlags.NonPublic | BindingFlags.Public);
            var privatePropetry = privateClassPropetries.First(m => m.Name == "PrivateProperty");
            var privateClassMethods = privateClassType.GetMethods(BindingFlags.DeclaredOnly
                                                                  | BindingFlags.Instance | BindingFlags.NonPublic |
                                                                  BindingFlags.Public);
            var privateMethod = privateClassMethods.First(m => m.Name == "PrivateMethod");
            var privateMethodResult = privateMethod.Invoke(privateClassInstance, new object[] { "Привет", "Мир!" });
            Assert.AreEqual(privateField.GetValue(privateClassInstance), "ПриватноеПоле!");
            Assert.AreEqual(privatePropetry.GetValue(privateClassInstance), "ПриватноеСвойство!");
            Assert.AreEqual(privateMethodResult, "ПриветМир!");
        }

        private class PrivateClass
        {
            private string PrivateField = "ЗакрытоеПриватноеПоле!";

            public PrivateClass()
            {
            }

            private PrivateClass(string Field, string Propetry)
            {
                PrivateField = Field;
                PrivateProperty = Propetry;
            }

            private string PrivateProperty { get; } = "ЗакрытоеПриватноеСвойство!";

            private string PrivateMethod(string firstString, string secondString)
            {
                return firstString + secondString;
            }
        }
    }
}