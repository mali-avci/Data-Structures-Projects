using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class PriorityQueue
    {
        private List<UM_Alanı> uM_Alanları; // Generic List

        public PriorityQueue()
        {
            uM_Alanları = new List<UM_Alanı>();
        }

        public void Enqueue(UM_Alanı umAlan)
        {
            uM_Alanları.Add(umAlan); // liste sonuna ekleme
        }

        public void Dequeue()
        {
            if (uM_Alanları.Count == 0)
            {
                Console.WriteLine("Öncelikli kuyruk boş!");
                return;
            }

            //alfabetik sıraya göre silme
            UM_Alanı mostPriority = uM_Alanları[0];
            for (int i = 1; i < uM_Alanları.Count; i++)
            {
                if (uM_Alanları[i].Alan_Adı.CompareTo(mostPriority.Alan_Adı) < 0)
                {
                    mostPriority = uM_Alanları[i];
                }
            }

            uM_Alanları.Remove(mostPriority);
            Console.WriteLine($"'{mostPriority.Alan_Adı}'    Silindi.");
        }

        public bool IsEmpty()
        {
            return uM_Alanları.Count == 0;
        }
    }
}
