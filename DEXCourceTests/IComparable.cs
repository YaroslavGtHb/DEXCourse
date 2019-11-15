using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DEXCource
{
    class IComparable
    {
        [Test]
        public void IComparableTest()
        {
            var geometricFigures = GeometricFigureGenerate(10);
            Array.Sort(geometricFigures, new GeometricFigureComparer());
            int testSquare = 0;
            foreach(var figure in geometricFigures)
            {
                Console.WriteLine(figure.square);
                Assert.That(figure.square >= testSquare);
                testSquare = figure.square;
            }
        }
        public GeometricFigure[] GeometricFigureGenerate(int GeometricFigureCount)
        {
            string[] geometricFigureTypes = new string[8]
            {
                "Многоугольник", "Шестнадцатиугольник", "Восьмиугольник", "Тропеция", "Ромб", "Прямоугольник", "Квадрат", "Круг"
            };
            var random = new Random();

            GeometricFigure[] geometricFigures = new GeometricFigure[GeometricFigureCount];
            for (int i = 0; i < GeometricFigureCount; i++)
            {
                geometricFigures[i] = new GeometricFigure(i, geometricFigureTypes[random.Next(0, 7)], random.Next(1, 999));
            }
            return geometricFigures;
        }
    }
    class GeometricFigure : IComparable<GeometricFigure>
    {
        public GeometricFigure(int id, string type, int square)
        {
            this.id = id;
            this.type = type;
            this.square = square;
        }
        public int id { get; }
        public string type { get; set; }
        public int square { get; set; }
        public int CompareTo(GeometricFigure figure)
        {
            return square.CompareTo(figure.square);
        }
    }
    class GeometricFigureComparer : IComparer<GeometricFigure>
    {
        public int Compare(GeometricFigure firstFigure, GeometricFigure secondFigure)
        {
            //Поменял местами, для обратной сортивровки.
            if (firstFigure.square < secondFigure.square)
                return 1;
            else if (firstFigure.square > secondFigure.square)
                return -1;
            else
                return 0;
        }
    }
}
