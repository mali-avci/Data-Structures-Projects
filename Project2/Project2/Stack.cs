using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class MyStack<T>
    {
        private List<T> items;
        private int top = -1; // Üstteki elemanın dizideki indeksi
        public MyStack()
        {
            items = new List<T>();// bellekte liste için alan aç
        }


        public void Push(T item)
        {
            top++;
            items.Add(item);
        }

        public T Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack boş. Eleman çıkarılamaz.");
                return default(T); // Stack boşsa varsayılan değeri döndür
            }
            else
            {
                T poppedItem = items[top];
                top--;
                return poppedItem;
            }
        }

        public T Peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack boş. Üstteki elemana bakılamaz.");
                return default(T);
            }
            else
            {
                return items[top];
            }
        }

        public bool IsEmpty()
        {
            if (top == -1)
            {
                return true;
            }
            else { return false; }

        }

        public int Count()
        {
            return top + 1;
        }
    }
}

