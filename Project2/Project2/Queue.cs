using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{

    public class MyQueue<T>
    {
        private List<T> items = new List<T>();

        // Kuyruğa eleman eklemek (enqueue)
        public void Enqueue(T item)
        {
            items.Add(item);
        }

        // Kuyruğun başındaki elemanı çıkarmak (dequeue)
        public T Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Kuyruk boş. Eleman çıkarılamaz.");
                return default(T); // Kuyruk boşsa varsayılan değeri döndür
            }

            T frontItem = items[0];
            items.RemoveAt(0);
            return frontItem;
        }

        // Kuyruğun başındaki elemana bakmak (peek)
        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Kuyruk boş. Elemana bakılamaz.");
                return default(T);
            }

            return items[0];
        }

        // Kuyruğun boş olup olmadığını kontrol etmek
        public bool IsEmpty()
        {
            return items.Count == 0;
        }

        // Kuyruktaki eleman sayısını almak
        public int Count()
        {
            return items.Count;
        }
    }



}
