using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace DEXCource
{
    internal class IEnumerableIEnumerator
    {
        [Test]
        public void IEnumerableIEnumeratorTest()
        {
            var zoo = new ZooArray();
            zoo.Add("Лев");
            zoo.Add("Гепард");
            zoo.Add("Барс");
            zoo.Add("Алкаш");

            foreach (var animal in zoo)
            {
                Console.WriteLine("В нашем зоопарке есть:");
                Console.WriteLine(animal);
            }

            Console.WriteLine("Перечень животных:");
            var pointer = 0;
            while (pointer < zoo.GetLenght())
            {
                Console.WriteLine(pointer + "." + zoo.GetItemName(pointer));
                pointer += 1;
            }
        }
    }

    public class ZooArray
    {
        private string[] animals = new string[0];

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
            return new ZooEnumerator(animals);
        }

        public class ZooEnumerator : IEnumerator<string>
        {
            private readonly string[] animals;

            public ZooEnumerator(string[] animals)
            {
                this.animals = animals;
            }

            public int Position { get; set; } = -1;

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