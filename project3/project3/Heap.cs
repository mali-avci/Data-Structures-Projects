using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    public class Heap
    {
        private List<int> heap;

        public Heap()
        {
            heap = new List<int>();
        }

        public void Insert(int value)
        {
            heap.Add(value);
            HeapifyUp(heap.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (heap[index] < heap[parentIndex])
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public int ExtractMin()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            int minValue = heap[0];
            int lastIndex = heap.Count - 1;

            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);

            HeapifyDown(0);

            return minValue;
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex, rightChildIndex, smallestChildIndex;

            while (true)
            {
                leftChildIndex = 2 * index + 1;
                rightChildIndex = 2 * index + 2;
                smallestChildIndex = index;

                if (leftChildIndex < heap.Count && heap[leftChildIndex] < heap[smallestChildIndex])
                {
                    smallestChildIndex = leftChildIndex;
                }

                if (rightChildIndex < heap.Count && heap[rightChildIndex] < heap[smallestChildIndex])
                {
                    smallestChildIndex = rightChildIndex;
                }

                if (smallestChildIndex == index)
                {
                    break;
                }

                Swap(index, smallestChildIndex);
                index = smallestChildIndex;
            }
        }

        private void Swap(int index1, int index2)
        {
            int temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }

        public void PrintHeap()
        {
            Console.WriteLine(string.Join(" ", heap));
        }
    }

}
