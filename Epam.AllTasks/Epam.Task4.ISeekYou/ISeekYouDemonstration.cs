using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.ISeekYou
{
    public class ISeekYouDemonstration
    {
        private readonly Random r = new Random();

        private Stopwatch sw = new Stopwatch();

        private List<int> listForTests = new List<int>();

        private List<long> listOfResultsTicks = new List<long>();

        private int RandomMaxValue { get; } = 100000;

        private int RandomMinValue { get; } = -100000;
        
        private int CountOfElement { get; } = 10000;

        private int CountOfTests { get; } = 10000;
        
        public void ISeekYouDemonstrate()
        {
            Predicate<int> myPredicate = this.IsPositive;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose menu element:");
                Console.WriteLine("1 - Use simple method");
                Console.WriteLine("2 - Use method with instance of delegate");
                Console.WriteLine("3 - Use method with delegate by anonymous method");
                Console.WriteLine("4 - Use method with lambda");
                Console.WriteLine("5 - Use method with LINQ");
                Console.WriteLine();
                Console.WriteLine("0 - Exit");

                int pickedElemMenu;
                while (!int.TryParse(Console.ReadLine(), out pickedElemMenu))
                {
                    Console.WriteLine("Incorrect value: valid values are 0 - 4");
                }

                if (pickedElemMenu != 0)
                {
                    Console.WriteLine("Please wait: calculation is in progress...");
                }
                
                this.FillRandomValues(this.listForTests);
                this.listOfResultsTicks.Clear();
                
                switch (pickedElemMenu)
                {
                    case 0:
                    {
                        Environment.Exit(0);
                        break;
                    }

                    case 1:
                    {
                        for (int i = 0; i < this.CountOfTests; i++)
                        {
                            this.sw.Restart();
                            this.GetPositiveFirst(this.listForTests);
                            this.sw.Stop();
                            this.listOfResultsTicks.Add(this.sw.ElapsedTicks);
                        }

                        this.PrintMediana(this.listOfResultsTicks);
                        break;
                    }

                    case 2:
                    {
                        for (int i = 0; i < this.CountOfTests; i++)
                        {
                            this.sw.Restart();
                            this.GetPositiveByPredicate(this.listForTests, myPredicate);
                            this.sw.Stop();
                            this.listOfResultsTicks.Add(this.sw.ElapsedTicks);
                        }

                        this.PrintMediana(this.listOfResultsTicks);
                        break;
                    }

                    case 3:
                    {
                        for (int i = 0; i < this.CountOfTests; i++)
                        {
                            this.sw.Restart();
                            this.GetPositiveByPredicate(this.listForTests, delegate(int x) { return x >= 0; });
                            this.sw.Stop();
                            this.listOfResultsTicks.Add(this.sw.ElapsedTicks);
                        }

                        this.PrintMediana(this.listOfResultsTicks);
                        break;
                    }

                    case 4:
                    {
                        for (int i = 0; i < this.CountOfTests; i++)
                        {
                            this.sw.Restart();
                            this.GetPositiveByPredicate(this.listForTests, x => x >= 0);
                            this.sw.Stop();
                            this.listOfResultsTicks.Add(this.sw.ElapsedTicks);
                        }

                        this.PrintMediana(this.listOfResultsTicks);
                        break;
                    }

                    case 5:
                    {
                        for (int i = 0; i < this.CountOfTests; i++)
                        {
                            this.sw.Restart();
                            var resultList = this.listForTests.Where(elem => elem >= 0).ToList();
                            this.sw.Stop();
                            this.listOfResultsTicks.Add(this.sw.ElapsedTicks);
                        }

                        this.PrintMediana(this.listOfResultsTicks);
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("Incorrect value: valid values are 0, 1 and 2");
                        break;
                    }
                }

                Console.ReadKey();
            }
        }

        public void PrintMediana(List<long> list)
        {
            list.Sort();
            int positionMedium;
            long mediumValue;
            if (list.Count % 2 == 1)
            {
                positionMedium = list.Count / 2;
                mediumValue = list[positionMedium];
            }
            else
            {
                positionMedium = (list.Count / 2) - 1;
                mediumValue = (list[positionMedium] + list[positionMedium + 1]) / 2;
            }

            Console.WriteLine("Medium value: {0}", mediumValue);
        }

        public void FillRandomValues(List<int> collection)
        {
            collection.Clear();
            for (int i = 0; i < this.CountOfElement; i++)
            {
                 collection.Add(this.r.Next(this.RandomMinValue, this.RandomMaxValue));
            }
        }       

        public List<int> GetPositiveFirst(IEnumerable<int> collection)
        {
            var resultCollection = new List<int>();
            foreach (var elem in collection)
            {
                if (elem >= 0)
                {
                    resultCollection.Add(elem);
                }
            }

            return resultCollection;
        }

        public List<int> GetPositiveByPredicate(IEnumerable<int> collection, Predicate<int> predicate)
        {
            var resultCollection = new List<int>();
            foreach (var elem in collection)
            {
                if (predicate.Invoke(elem))
                {
                    resultCollection.Add(elem);
                }
            }

            return resultCollection;
        }

        private bool IsPositive(int x)
        {
            return x >= 0;
        }
    }
}
