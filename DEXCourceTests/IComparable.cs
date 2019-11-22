using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DEXCource
{
    internal class IComparable
    {
        [Test]
        public void IComparableTest()
        {
            var geometricFigures = GeometricFigureGenerate(10);
            Array.Sort(geometricFigures, new GeometricFigureComparer());
            var testSquare = 999;
            foreach (var figure in geometricFigures)
            {
                Console.WriteLine(figure.Square);
                Assert.That(figure.Square <= testSquare);
                testSquare = figure.Square;
            }
        }

        public GeometricFigure[] GeometricFigureGenerate(int GeometricFigureCount)
        {
            var geometricFigureTypes = new[]
            {
                "Многоугольник", "Шестнадцатиугольник", "Восьмиугольник", "Тропеция", "Ромб", "Прямоугольник",
                "Квадрат", "Круг"
            };
            var random = new Random();

            var geometricFigures = new GeometricFigure[GeometricFigureCount];
            for (var i = 0; i < GeometricFigureCount; i++)
                geometricFigures[i] =
                    new GeometricFigure(i, geometricFigureTypes[random.Next(0, 7)], random.Next(1, 999));
            return geometricFigures;
        }
    }

    internal class GeometricFigure : IComparable<GeometricFigure>
    {
        public GeometricFigure(int id, string type, int square)
        {
            Id = id;
            Type = type;
            Square = square;
        }

        public int Id { get; }
        public string Type { get; set; }
        public int Square { get; set; }

        public int CompareTo(GeometricFigure figure)
        {
            return Square.CompareTo(figure.Square);
        }
    }

    internal class GeometricFigureComparer : IComparer<GeometricFigure>
    {
        public int Compare(GeometricFigure firstFigure, GeometricFigure secondFigure)
        {
            //Поменял местами, для обратной сортивровки.
            if (secondFigure != null && (firstFigure != null && firstFigure.Square < secondFigure.Square))
                return 1;
            return secondFigure != null && (firstFigure != null && firstFigure.Square > secondFigure.Square) ? -1 : 0;
        }
    }
}