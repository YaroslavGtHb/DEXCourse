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
            ConstructorInfo[] prvateClassConstructors = privateClassType.GetConstructors(BindingFlags.DeclaredOnly
                | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            ConstructorInfo privateConstructor = prvateClassConstructors.First(m => m.IsPrivate);
            var privateConstructorResult = privateConstructor.Invoke(privateClassInstance, new object[] { "ПриватноеПоле!", "ПриватноеСвойство!" });
            FieldInfo[] privateClassFields = privateClassType.GetFields(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            FieldInfo privateField = privateClassFields.First(m => m.Name == "PrivateField");
            PropertyInfo[] privateClassPropetries = privateClassType.GetProperties(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            PropertyInfo privatePropetry = privateClassPropetries.First(m => m.Name == "PrivateProperty");
            MethodInfo[] privateClassMethods = privateClassType.GetMethods(BindingFlags.DeclaredOnly
           | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            MethodInfo privateMethod = privateClassMethods.First(m => m.Name == "PrivateMethod");
            var privateMethodResult = privateMethod.Invoke(privateClassInstance, new object[] { "Привет", "Мир!" });
            Assert.AreEqual(privateField.GetValue(privateClassInstance), "ПриватноеПоле!");
            Assert.AreEqual(privatePropetry.GetValue(privateClassInstance), "ПриватноеСвойство!");
            Assert.AreEqual(privateMethodResult, "ПриветМир!");
        }
    class PrivateClass
    {
        public PrivateClass()
        {

        }
        private PrivateClass( string Field, string Propetry)
        {
            PrivateField = Field;
            PrivateProperty = Propetry;
        }
        private string PrivateField = "ЗакрытоеПриватноеПоле!";
        private string PrivateProperty { get; set; } = "ЗакрытоеПриватноеСвойство!";
        private string PrivateMethod(string firstString, string secondString)
            {
            return firstString + secondString;
            }
        }
    }
}