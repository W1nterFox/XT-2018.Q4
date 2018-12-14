using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.CustomSort
{
    public class CustomSortDemonstration
    {
        public void CustomSortDemonstrate()
        {
            Car[] cars =
            {
                new Car("Renault", 2009),
                new Car("Nissan", 2012),
                new Car("Lada", 2003),
                new Car("Ford Galaxie", 1968)
            };

            Console.WriteLine("Initial array of cars: ");
            this.PrintCarsArray(cars);
            Console.WriteLine();

            this.CustomSort<Car>(cars, this.CompareByCarBrand);
            Console.WriteLine("Array of cars after sorting by its brand: ");
            this.PrintCarsArray(cars);
            Console.WriteLine();

            this.CustomSort<Car>(cars, this.CompareByYearOfCreation);
            Console.WriteLine("Array of cars after sorting by its year of creation: ");
            this.PrintCarsArray(cars);
        }
        
        public int CompareByYearOfCreation(Car first, Car second)
        {
            if (ReferenceEquals(first, second))
            {
                return 0;
            }

            if (first == null)
            {
                return -1;
            }

            if (second == null)
            {
                return 1;
            }

            if (first.YearOfCreation < second.YearOfCreation)
            {
                return -1;
            }
            else if (first.YearOfCreation > second.YearOfCreation)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //// Коммантарий для Виктора или Михаила: в интернете увидел такой порядок 
        //// сравнения объектов. Если что-то забыл, то напишите что именно, пожалуйста
        public int CompareByCarBrand(Car first, Car second)
        {
            if (ReferenceEquals(first, second))
            {
                return 0;
            }

            if (first == null)
            {
                return -1;
            }

            if (second == null)
            {
                return 1;
            }

            int minLengthOfCarBrand;

            if (first.CarBrand.Length < second.CarBrand.Length)
            {
                minLengthOfCarBrand = first.CarBrand.Length;
            }
            else
            {
                minLengthOfCarBrand = second.CarBrand.Length;
            }

            for (int i = 0; i < minLengthOfCarBrand; i++)
            {
                if (first.CarBrand[i] < second.CarBrand[i])
                {
                    return -1;
                }

                if (first.CarBrand[i] > second.CarBrand[i])
                {
                    return 1;
                }
            }

            if (first.CarBrand.Length > second.CarBrand.Length)
            {
                return 1;
            }
            else if (first.CarBrand.Length < second.CarBrand.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private void PrintCarsArray(Car[] array)
        {
            foreach (var car in array)
            {
                Console.WriteLine(car);
            }
        }

        private void CustomSort<T>(T[] array, Func<T, T, int> methodCompare)
        {
            ////Shell sorting
            int step = array.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < array.Length; i++)
                {
                    T value = array[i];
                    for (j = i - step; (j >= 0) && (methodCompare(array[j], value) == 1); j -= step)
                    {
                        array[j + step] = array[j];
                    }

                    array[j + step] = value;
                }

                step /= 2;
            }
        }
    }
}
