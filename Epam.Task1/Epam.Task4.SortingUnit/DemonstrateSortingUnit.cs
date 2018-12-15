using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task4.SortingUnit
{
    public class DemonstrateSortingUnit
    {
        private readonly object locker = new object();

        private Stopwatch sw = new Stopwatch();

        public event EventHandler<SortingUnitEndOfSortEvent> EndOfSortEvent;

        public double TotalTime { get; private set; }
        
        public Thread SortThread { get; private set; }
        
        public void Demonstrate<T>(T[] array, Func<T, T, int> methodCompare, string nameOfThread)
        {
            this.SortThread = new Thread(() => this.StartCustomSort(array, methodCompare));
            this.SortThread.Name = nameOfThread;
            this.SortThread.Start();
        }

        private void StartCustomSort<T>(T[] array, Func<T, T, int> methodCompare)
        {
            lock (this.locker)
            {
                this.sw.Start();
                this.CustomSort(array, methodCompare);
                this.sw.Stop();
                this.TotalTime = this.sw.ElapsedTicks;
                this.EndOfSortEvent?.Invoke(this, new SortingUnitEndOfSortEvent("End of sorting in " + this.SortThread.Name, this.TotalTime));
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
