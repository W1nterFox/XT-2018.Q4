using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task4.CustomSort;

namespace Epam.Task4.SortingUnit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Car[] cars =
            {
                new Car("Renault", 2009),
                new Car("Nissan", 2012),
                new Car("Lada", 2003),
                new Car("Ford Galaxie", 1968)
            };
            CustomSortDemonstration.PrintCarsArray(cars);
            Console.WriteLine();
            
            var demonstrateSortingUnit = new DemonstrateSortingUnit();
            demonstrateSortingUnit.EndOfSortEvent += PrintSortingEvent;

            demonstrateSortingUnit.Demonstrate(cars, CustomSortDemonstration.CompareByCarBrand, "First thread");
            demonstrateSortingUnit.SortThread.Join();

            CustomSortDemonstration.PrintCarsArray(cars);
            Console.WriteLine();

            demonstrateSortingUnit.Demonstrate(cars, CustomSortDemonstration.CompareByYearOfCreation, "Second thread");
            demonstrateSortingUnit.SortThread.Join();

            CustomSortDemonstration.PrintCarsArray(cars);
        }

        private static void PrintSortingEvent(object sender, SortingUnitEndOfSortEvent e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Total time: {0}", e.TimeTotal);
            Console.WriteLine();
        }
    }
}
