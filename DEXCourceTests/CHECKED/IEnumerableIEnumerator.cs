using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

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
        private string[] _animals = new string[0];

        public void Add(string Animal)
        {
            Array.Resize(ref _animals, _animals.Length + 1);
            _animals[^1] = Animal;
        }

        public int GetLenght()
        {
            return _animals.Length;
        }

        public string GetItemName(int index)
        {
            return _animals[index];
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new ZooEnumerator(_animals);
        }

        public class ZooEnumerator : IEnumerator<string>
        {
            private readonly string[] _animals;

            public ZooEnumerator(string[] animals)
            {
                this._animals = animals;
            }

            public int Position { get; set; } = -1;

            public string Current
            {
                get
                {
                    if (Position == -1 || Position >= _animals.Length)
                        throw new InvalidOperationException();
                    return _animals[Position];
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                if (Position < _animals.Length - 1)
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