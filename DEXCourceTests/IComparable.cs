using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DEXCource
{
    class IComparable
    {

        public Collection<GeometricFigure> GeometricFigureGenerate(int GeometricFigureCount)
        {
            string[] geometricFigureTypes = new string[8]
            {
                "Многоугольник", "", "Шестнадцатиугольник", "Восьмиугольник", "Тропеция", "Прямоугольник", "Квадрат", "Круг"
            };
            var random = new Random();

            var generatedGeometricFigures = new Collection<GeometricFigure>();
            for (int i = 0; i < GeometricFigureCount; i++)
            {
                generatedGeometricFigures.Add(new GeometricFigure(generatedGeometricFigures.Count, geometricFigureTypes[random.Next(0, 7)], random.Next(0, 999)));
            }
            return generatedGeometricFigures;
        }
    }
    class GeometricFigure : IComparable<GeometricFigure>
    {
        public GeometricFigure(int Id, string Type, int Square)
        {
            this.Id = Id;
            this.Type = Type;
            this.Square = Square;
        }
        public int Id { get; }
        public string Type { get; set; }
        public int Square { get; set; }
        public int CompareTo(GeometricFigure figure)
        {
            return Square.CompareTo(figure.Square);
        }
    }
    class GeometricFigureComparer : IComparer<GeometricFigure>
    {
        public int Compare(GeometricFigure firstFigure, GeometricFigure secondFigure)
        {
            if (firstFigure.Square > secondFigure.Square)
                return 1;
            else if (firstFigure.Square < secondFigure.Square)
                return -1;
            else
                return 0;
        }
    }
}
