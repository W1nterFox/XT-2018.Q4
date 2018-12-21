using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.SortingUnit
{
    public class SortingUnitEndOfSortEvent : EventArgs
    {
        public SortingUnitEndOfSortEvent(string message, double timeTotal)
        {
            this.Message = message;
            this.TimeTotal = timeTotal;
        }

        public string Message { get; }

        public double TimeTotal { get; }
    }
}
