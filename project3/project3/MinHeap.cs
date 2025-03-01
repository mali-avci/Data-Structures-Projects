using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    class MinHeap
    {
        private List<UM_Alanı> umAlanlari;

        public MinHeap()
        {
            umAlanlari = new List<UM_Alanı>();
        }

        public void Insert(UM_Alanı uM_Alanı)
        {
            umAlanlari.Add(uM_Alanı);
            HeapifyUp();
        }

        private void HeapifyUp()
        {
            int currentIndex = umAlanlari.Count - 1;

            while (currentIndex > 0)
            {
                int parentIndex = (currentIndex - 1) / 2;

                if (string.Compare(umAlanlari[currentIndex].Alan_Adı, umAlanlari[parentIndex].Alan_Adı) < 0)
                {
                    Swap(currentIndex, parentIndex);
                    currentIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int index1, int index2)
        {
            UM_Alanı temp = umAlanlari[index1];
            umAlanlari[index1] = umAlanlari[index2];
            umAlanlari[index2] = temp;
        }

        public UM_Alanı ExtractMin()
        {
            if (umAlanlari.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            UM_Alanı root = umAlanlari[0];
            int lastindex = umAlanlari.Count - 1;

            umAlanlari[0] = umAlanlari[lastindex];
            umAlanlari.RemoveAt(lastindex);

            HeapifyDown();

            return root;
        }

        private void HeapifyDown()
        {
            int currentIndex = 0;
            int leftChildIndex;
            int rightChildIndex;

            while (true)
            {
                leftChildIndex = 2 * currentIndex + 1;
                rightChildIndex = 2 * currentIndex + 2;

                int smallestChildIndex = -1;

                if (leftChildIndex < umAlanlari.Count)
                {
                    smallestChildIndex = leftChildIndex;

                    if (rightChildIndex < umAlanlari.Count &&
                        string.Compare(umAlanlari[rightChildIndex].Alan_Adı, umAlanlari[leftChildIndex].Alan_Adı) < 0)
                    {
                        smallestChildIndex = rightChildIndex;
                    }

                    if (string.Compare(umAlanlari[smallestChildIndex].Alan_Adı, umAlanlari[currentIndex].Alan_Adı) < 0)
                    {
                        Swap(smallestChildIndex, currentIndex);
                        currentIndex = smallestChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}