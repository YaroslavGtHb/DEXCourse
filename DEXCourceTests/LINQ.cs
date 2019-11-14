using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DEXCource
{
    class LINQ
    {
        public void LINQTest()
        {
            var cats = BirdsGenerate(100);
        }
        public Collection<Cat> BirdsGenerate(int BirdsCount)
        {
            string[] birdNames = new string[8]
            {
                "Матроскин", "Гарфилд", "Рыжий", "Мурзик", "Снежок", "Полосатый", "Мемасик", "Том"
            };
            var random = new Random();

            var generatedCats = new Collection<Cat>();
            for (int i = 0; i < 100; i++)
            {
                generatedCats.Add(new Cat(generatedCats.Count, birdNames[random.Next(0, 7)], random.Next(1, 48), random.Next(100) < 50 ? true : false, random.NextDouble()));
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
