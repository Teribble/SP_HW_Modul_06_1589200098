using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureArea
{
    public static class FigureArea
    {
        public static double Square(double a)
        {
            return a * a;
        }

        public static double Rectangle(double a, double b)
        {
            return a * b;
        }

        public static double Triangle(double a, double b)
        {
            return (a * b) / 2;
        }
    }
}
