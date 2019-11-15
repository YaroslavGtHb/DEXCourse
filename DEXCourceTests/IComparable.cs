using System;
using System.Collections.Generic;
using System.Text;

namespace DEXCource
{
    class IComparable
    {
    }

    class GeometricFigure : IComparable
    {
        public int Id;
        public string Type { get; set; }
        public int Square { get; set; }
        public int CompareTo(object o)
        {
            GeometricFigure figure = o as GeometricFigure;
            if (figure != null)
            {
                return Square.CompareTo(figure.Square);
            }
            else
            {
                throw new Exception("Невозможно сравнить два объекта");
            }
        }
    }
}
