using System;
using System.Collections.Generic;
using System.Text;

namespace DEXCource
{
    class IComparable
    {
    }

    class GeometricFigure : IComparable<GeometricFigure>
    {
        public int Id;
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
