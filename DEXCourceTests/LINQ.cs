using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DEXCource
{
    class LINQ
    {
        [Test]
        public void LINQTest()
        {
            var cats = BirdsGenerate(100);
            var old = cats.Where(t => t.age > 30);
            var orderByAge = cats.OrderBy(t => t.age);
            var groupByName = cats.GroupBy(t => t.name);
            var onlyGarfield = cats.Where(t => t.name == "Гарфилд");
            var totalWeight = cats.Sum(t => t.weight);
            Assert.That(old.All(t => t.age > 30));
            Assert.That(onlyGarfield.All(t => t.name == "Гарфилд"));
            Assert.That(totalWeight >= 100);
        }
        public Collection<Cat> BirdsGenerate(int BirdsCount)
        {
            string[] birdNames = new string[8]
            {
                "Матроскин", "Гарфилд", "Рыжий", "Мурзик", "Снежок", "Полосатый", "Мемасик", "Том"
            };
            var random = new Random();

            var generatedCats = new Collection<Cat>();
            for (int i = 0; i < BirdsCount; i++)
            {
                generatedCats.Add(new Cat(generatedCats.Count, birdNames[random.Next(0, 7)], random.Next(1, 48), random.Next(100) < 50 ? true : false, random.Next(1, 88)));
            }
            return generatedCats;
        }
    }
    public class Cat
    {
        public Cat(int id, string name, int age, bool isMale, double weight)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.isMale = isMale;
            this.weight = weight;
        }
        public int id { get; }
        public string name { get; set; }
        public int age { get; set; }
        public bool isMale { get; }
        public double weight { get; set; }
    }
}
