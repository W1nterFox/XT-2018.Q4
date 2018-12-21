using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.DynamicArray;

namespace Epam.Task3.DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        private int capacity = 0;

        public DynamicArray()
        {
            this.Array = new T[8];
            this.Capacity = 8;
        }

        public DynamicArray(int capacity)
        {
            this.Array = new T[capacity];
            this.Capacity = capacity;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            this.Array = new T[collection.Count()];
            int index = 0;
            foreach (var elem in collection)
            {
                this[index] = elem;
                index++;
            }

            this.Capacity = collection.Count();
            this.Length = collection.Count();
        }
        
        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (value >= this.Length)
                {
                    this.capacity = value;
                }
                else
                {
                    T[] tempArray = new T[value];
                    for (int i = 0; i < value; i++)
                    {
                        tempArray[i] = this.Array[i];
                    }

                    this.Array = tempArray;
                    this.Length = value;
                    this.capacity = value;
                }
            }
        }

        public int Length { get; private set; } = 0;

        private T[] Array { get; set; }
        
        public T this[int pos]
        {
            get
            {
                if (pos >= this.Length || pos < -this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (pos < 0)
                {
                    return this.Array[this.Length + pos];
                }
                else
                {
                    return this.Array[pos];
                }
            }

            set
            {
                this.Array[pos] = value;
            }
        }
        
        public void Add(T elem)
        {
            if (this.Length == this.Capacity)
            {
                this.IncreaseCapacityDoubleSize();
            }

            this[this.Length] = elem;
            this.Length++;
        }
        
        public void AddRange(IEnumerable<T> collection)
        {
            int countOfFreeCell = this.Capacity - this.Length;
            if (countOfFreeCell < collection.Count())
            {
                int newCapacity = (int)((this.Length + collection.Count()) * 1.5);
                T[] tempArray = new T[newCapacity];
                for (int i = 0; i < this.Length; i++)
                {
                    tempArray[i] = this[i];
                }

                this.Array = tempArray;
                this.Capacity = newCapacity;
            }

            foreach (var elem in collection)
            {
                this.Add(elem);
            }
        }

        public bool Remove(T elem)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i].Equals(elem))
                {
                    this.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index must be positive number");
            }

            if (index >= this.Length)
            {
                throw new ArgumentOutOfRangeException("Index must be more than Length of DynamicArray");
            }

            int countElemForShift = this.Length - index - 1;
            int curElem;
            int nextElem;

            try
            {
                for (int i = 0; i < countElemForShift; i++)
                {
                    curElem = i + index;
                    nextElem = curElem + 1;
                    this[curElem] = this[nextElem];
                }

                this[this.Length - 1] = default(T);
                this.Length--;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }
        }

        public bool Insert(T elem, int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index must be positive number");
            }

            if (index > this.Capacity)
            {
                throw new ArgumentOutOfRangeException("Index must be more than Capacity of DynamicArray");
            }

            if (this.Length == this.Capacity)
            {
                this.IncreaseCapacityDoubleSize();
            }

            int countElemForShift = this.Length - index;
            int curElem;
            int prevElem;

            try
            {
                for (int k = countElemForShift; k > 0; k--)
                {
                    curElem = k + index;
                    prevElem = k + index - 1;
                    this[curElem] = this[prevElem];
                }

                this[index] = elem;
                this.Length++;
                return true;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }

            return false;
        }
        
        public T[] ToArray()
        {
            T[] res = new T[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                res[i] = this[i];
            }

            return res;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Length; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
        public object Clone()
        {
            return new DynamicArray<T>(this);
        }

        private void IncreaseCapacityDoubleSize()
        {
            int newCapacity = this.Capacity * 2;
            T[] tempArray = new T[newCapacity];
            for (int i = 0; i < this.Length; i++)
            {
                tempArray[i] = this[i];
            }

            this.Capacity = newCapacity;
            this.Array = tempArray;
        }
    }
}
