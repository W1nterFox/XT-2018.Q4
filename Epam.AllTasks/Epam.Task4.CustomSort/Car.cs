using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.CustomSort
{
    public class Car
    {
        public Car(string carBrand, int yearOfCreation)
        {
            this.CarBrand = carBrand;
            this.YearOfCreation = yearOfCreation;
        }

        public string CarBrand { get; }

        public int YearOfCreation { get; }

        public override string ToString()
        {
            return this.CarBrand + " " + this.YearOfCreation;
        }
    }
}
