using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DEXCource
{
    class IEnumerableIEnumerator
    {
        [Test]
        public void IEnumerableIEnumeratorTest()
        {
            var zoo = new ZOOArray();
            zoo.Add("Лев");
            zoo.Add("Гепард");
            zoo.Add("Барс");
            zoo.Add("Алкаш");

            foreach(string animal in zoo)
            {
                Console.WriteLine("В нашем зоопарке есть:");
                Console.WriteLine(animal);
            }
            Console.WriteLine("Перечень животных:");
            int pointer = 0;
            while(pointer <= zoo.GetLenght())
            {
                Console.WriteLine(pointer + "." + zoo.GetItemName(pointer));
                pointer += 1;
            }
        }
    }
    public class ZOOArray
    {
        string[] animals = new string[0];
        public void Add(string Animal)
        {
            Array.Resize(ref animals, animals.Length + 1);
            animals[^1] = Animal;
        }
        public int GetLenght()
        {
            return animals.Length;
        }
        public string GetItemName(int index)
        {
            return animals[index];
        }
        public IEnumerator<string> GetEnumerator()
        {
            return new ZOOEnumerator(animals);
        }
        public class ZOOEnumerator : IEnumerator<string>
        {
            string[] animals;
            public int Position { get; set; } = -1;
            public ZOOEnumerator(string[] animals)
            {
                this.animals = animals;
            }
            public string Current
            {
                get
                {
                    if (Position == -1 || Position >= animals.Length)
                        throw new InvalidOperationException();
                    return animals[Position];
                }
            }
            object IEnumerator.Current => throw new NotImplementedException();
            public bool MoveNext()
            {
                if (Position < animals.Length - 1)
                {
                    Position++;
                    return true;
                }
                else
                    return false;
            }
            public void Reset()
            {
                Position = -1;
            }
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
