using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Lost
{
    public static class LinkedListExtension
    {
        public static void RemoveByIndex<T>(this LinkedList<T> list, int index)
        {
            LinkedListNode<T> currentNode = list.FindByIndex<T>(index);
            list.Remove(currentNode);
        }

        public static LinkedListNode<T> FindByIndex<T>(this LinkedList<T> list, int index)
        {
            LinkedListNode<T> currentNode = list.First;
            for (int i = 0; i <= index && currentNode != null; i++)
            {
                if (i != index)
                {
                    currentNode = currentNode.Next;
                    continue;
                }

                return currentNode;
            }

            throw new IndexOutOfRangeException();
        }
    }
}
