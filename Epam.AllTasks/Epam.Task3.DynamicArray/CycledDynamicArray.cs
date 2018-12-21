using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.DynamicArray
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable, IEnumerable<T>
    {
        public override IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                for (int i = 0; i < this.Length; i++)
                {
                    yield return this[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
