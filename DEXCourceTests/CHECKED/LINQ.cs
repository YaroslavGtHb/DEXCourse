using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DEXCource
{
    internal class LINQ
    {
        [Test]
        public void LINQTest()
        {
            var cats = BirdsGenerate(100);
            var old = cats.Where(t => t.Age > 30);
            var orderByAge = cats.OrderBy(t => t.Age);
            var groupByName = cats.GroupBy(t => t.Name);
            var onlyGarfield = cats.Where(t => t.Name == "Гарфилд");
            var totalWeight = cats.Sum(t => t.Weight);
            Assert.That(old.All(t => t.Age > 30));
            var testItem = 0;
            foreach (var item in orderByAge)
            {
                Assert.That(item.Age >= testItem);
                testItem = item.Age;
            }

            Assert.That(onlyGarfield.All(t => t.Name == "Гарфилд"));
            Assert.That(totalWeight >= 100);
        }

        public Collection<Cat> BirdsGenerate(int BirdsCount)
        {
            string[] birdNames =
            {
                "Матроскин", "Гарфилд", "Рыжий", "Мурзик", "Снежок", "Полосатый", "Мемасик", "Том"
            };
            var random = new Random();

            var generatedCats = new Collection<Cat>();
            for (var i = 0; i < BirdsCount; i++)
                generatedCats.Add(new Cat(generatedCats.Count, birdNames[random.Next(0, 7)], random.Next(1, 48),
                    random.Next(100) < 50, random.Next(1, 88)));
            return generatedCats;
        }
    }

    public class Cat
    {
        public Cat(int id, string name, int age, bool isMale, double weight)
        {
            Id = id;
            Name = name;
            Age = age;
            IsMale = isMale;
            Weight = weight;
        }

        public int Id { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; }
        public double Weight { get; set; }
    }
}