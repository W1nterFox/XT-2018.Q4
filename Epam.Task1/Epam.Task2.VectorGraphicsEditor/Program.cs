using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.VectorGraphicsEditor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Point p1 = new Point(5, 5);
            Point p2 = new Point(10, 10);
            List<Figure> listFigures = new List<Figure> { };
            listFigures.Add(new Line(p1, p2));
            listFigures.Add(new Circle(p1, 5));
            listFigures.Add(new Round(p2, 7));
            listFigures.Add(new Ring(2, 7, p1));
            listFigures.Add(new Rectangle(p1, p2));

            foreach (var elem in listFigures)
            {
                elem.Draw();
                elem.PrintInfo();
                Console.WriteLine();
            }
        }
    }
}
