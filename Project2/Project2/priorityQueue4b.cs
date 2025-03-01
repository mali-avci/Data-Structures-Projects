using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class PriorityQueue4b
    {
        private List<int> numbers; // Generic List

        public PriorityQueue4b()
        {
            numbers = new List<int>();
        }

        public void Enqueue(int number)
        {
            if (numbers.Count == 0)
            {
                // Kuyruk boşsa direkt ekle
                numbers.Add(number);
            }
            else
            {
                int index = 0;
                while (index < numbers.Count && number > numbers[index])
                {
                    index++;
                }
                
                // Elemanı uygun konuma ekleyerek sırayı koru.
                numbers.Insert(index, number);
            }
        }

        public int Dequeue()
        {
            if (numbers.Count == 0)
            {
                
                throw new Exception("Öncelikli kuyruk boş!");
            }

            int front = numbers[0];
            numbers.RemoveAt(0);

            
            return front;
        }

        public bool IsEmpty()
        {
            return numbers.Count == 0;
        }
    }
}
