using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Project2.Program;


namespace Project2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string dosya_yolu = "C:\\Users\\mehme\\source\\repos\\Project2\\UM_Alani.txt";
            string[] alanBilgileri;
            UM_Alanı uM_Alanı = null;
            // Şehirleri bölgelere ayırmak için 7 satırlık jagged array oluştur
            string[][] bölgeler = new string[7][];
            bölgeler[0] = new string[] { "Antalya", "Burdur", "Isparta", "Mersin", "Adana", "Hatay", "Osmaniye", "Kahramanmaraş" };
            bölgeler[1] = new string[] { "Malatya", "Erzincan", "Elazığ", "Tunceli", "Bingöl", "Erzurum", "Muş", "Bitlis", "Şırnak", "Kars", "Ağrı", "Ardahan", "Van", "Iğdır", "Hakkari" };
            bölgeler[2] = new string[] { "İzmir", "Aydın", "Muğla", "Manisa", "Denizli", "Uşak", "Kütahya", "Afyon" };
            bölgeler[3] = new string[] { "Gaziantep", "Kilis", "Adıyaman", "Şanlıurfa", "Diyarbakır", "Mardin", "Batman", "Siirt" };
            bölgeler[4] = new string[] { "Eskişehir", "Konya", "Ankara", "Çankırı", "Aksaray", "Kırıkkale", "Kırşehir", "Yozgat", "Niğde", "Nevşehir", "Kayseri", "Karaman", "Sivas" };
            bölgeler[5] = new string[] { "Bolu", "Düzce", "Zonguldak", "Karabük", "Bartın", "Kastamonu", "Çorum", "Sinop", "Samsun", "Amasya", "Tokat", "Ordu", "Giresun", "Gümüşhane",
                "Trabzon", "Bayburt", "Rize","Artvin" };
            bölgeler[6] = new string[] { "Çanakkale", "Balıkesir", "Edirne", "Tekirdağ", "Kırklareli", "İstanbul", "Bursa", "Yalova", "Kocaeli", "Bilecik", "Sakarya" };


            //7 elemanlı bir Generic List dizisi oluştur
            List<UM_Alanı>[] GenericList = new List<UM_Alanı>[7];

            // Her elemanı UM_Alanı olan Generic List oluştur
            for (int i = 0; i < 7; i++)
            {
                GenericList[i] = new List<UM_Alanı>();
            }

            try
            {
                // Dosyayı aç
                using (StreamReader sr = new StreamReader(dosya_yolu))
                {
                    // Dosyanın sonuna kadar satır satır oku
                    while (!sr.EndOfStream)
                    {
                        // Satırı oku
                        string satir = sr.ReadLine();
                        alanBilgileri = satir.Split(',');
                        string[] sehir = alanBilgileri[1].Split('-'); //Birden çok il adı için liste
                        int ilanYil = int.Parse(alanBilgileri[2]);

                        foreach (var item in sehir)
                        {
                            // İl adını tutmak için generic list oluştur ve il adını bu listeye ekle
                            List<string> ilAdList = new List<string>();
                            ilAdList.Add(item);

                            // UM Alanı nesnesi oluştur
                            uM_Alanı = new UM_Alanı(alanBilgileri[0], ilAdList, ilanYil);

                            // İlin hangi bölgenin indeksinde olduğunu bul ve Generic Liste ekle
                            for (int i = 0; i < bölgeler.Length; i++)
                            {
                                for (int j = 0; j < bölgeler[i].Length; j++)
                                {
                                    if (item == bölgeler[i][j])
                                    {
                                        GenericList[i].Add(uM_Alanı);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Dosya okuma hatası: " + e.Message);
            }


            string cevap = "e";
            while (cevap == "e" || cevap == "E")
            {
                int istekNo = menu();
                if (istekNo == 1)
                {
                    Console.WriteLine("UNESCO Dünya Mirası Listesi seçildi:");
                    Console.WriteLine();
                    ekranaYazdir(GenericList);
                }
                else if (istekNo == 2)
                {
                    Console.WriteLine("Stackle yazılan:");
                    stackleYazdir(GenericList);
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Queue ile yazılan:");
                    kuyruklaYazdir(GenericList);
                    
                }
                else if (istekNo == 3)
                {
                    öncelikliKuyruklaYazdir(GenericList);
                }
                else if (istekNo == 4)
                {
                    Console.WriteLine("Kuyruk kullanarak hesaplanınca: ");
                    marketIslemSuresi();
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Öncelikli Kuyruk kullanarak hesaplanınca: ");
                    öncelikliMarketIslemSuresi();
                }
                else
                {
                    break;
                }

                Console.Write("başka bir işlem yapmak istiyor musunuz?(E/e/H/h)");
                cevap = Console.ReadLine();
            }
        }

        static int menu()
        {

            Console.WriteLine("(1) UNESCO Dünya Mirası Listesi!");
            Console.WriteLine("(2) YIĞIT ve KUYRUK yapılarıyla UNESCO Dünya Miras alanlarını yaz");
            Console.WriteLine("(3) ÖNCELİKLİ KUYRUK yapısıyla alfabetik sırada UNESCO Dünya Miras alanlarını yaz");
            Console.WriteLine("(4) KUYRUK ve ÖNCELİKLİ KUYRUK yapılarını kullanarak market kasası işlem süresi ve ortalama süreyi yaz ");
            Console.WriteLine("(5) çıkış");
            Console.Write("Yapmak istediğiniz işlemin numarasını giriniz: ");
            int istekNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return istekNo;
        }
        static void ekranaYazdir(List<UM_Alanı>[] GenericList)
        {
            string[] bölgeler = { "Akdeniz", "Doğu Anadolu", "Ege", "Güney Doğu Anadolu", "İç Anadolu", "Karadeniz", "Marmara" };

            for (int i = 0; i < GenericList.Length; i++)
            {
                Console.WriteLine($"{bölgeler[i]} Bölgesindeki UNESCO Dünya Mirası Alanları {GenericList[i].Count} adettir ve şunlardır:");


                for (int j = 0; j < GenericList[i].Count; j++)
                {

                    Console.Write(" " + (j + 1) + ")" + GenericList[i][j].Alan_Adı + " " + GenericList[i][j].İlan_Yılı + " ");


                    foreach (var item in GenericList[i][j].İl_Adları)
                    {
                        Console.WriteLine(item);
                    }
                }
                Console.WriteLine();
            }
        }
        static void stackleYazdir(List<UM_Alanı>[] GenericList)
        {
            MyStack<UM_Alanı> myStack = new MyStack<UM_Alanı>();
            for (int i = 0; i < GenericList.Length; i++)
            {
                for (int j = 0; j < GenericList[i].Count; j++)
                {
                    myStack.Push(GenericList[i][j]);
                }

            }
            while (!myStack.IsEmpty())
            {
                UM_Alanı uM_Alanı = myStack.Pop();
                Console.Write(uM_Alanı.Alan_Adı + " " + uM_Alanı.İlan_Yılı);

                foreach (var item in uM_Alanı.İl_Adları) { Console.WriteLine(" " + item); }



            }
            
        }
        static void kuyruklaYazdir(List<UM_Alanı>[] GenericList)
        {
            MyQueue<UM_Alanı> myQueue = new MyQueue<UM_Alanı>();
            for (int i = 0; i < GenericList.Length; i++)
            {
                for (int j = 0; j < GenericList[i].Count; j++)
                {
                    myQueue.Enqueue(GenericList[i][j]);
                }

            }
            while (!myQueue.IsEmpty())
            {
                UM_Alanı uM_Alanı = myQueue.Dequeue();
                Console.Write(uM_Alanı.Alan_Adı + " " + uM_Alanı.İlan_Yılı);

                foreach (var item in uM_Alanı.İl_Adları) { Console.WriteLine(" " + item); }



            }
          
        }
        static void öncelikliKuyruklaYazdir(List<UM_Alanı>[] GenericList)
        {
            PriorityQueue priorityQueue = new PriorityQueue();
            for (int i = 0; i < GenericList.Length; i++)
            {
                for (int j = 0; j < GenericList[i].Count; j++)
                {
                    priorityQueue.Enqueue(GenericList[i][j]);
                }

            }
            while (!priorityQueue.IsEmpty())
            {
                priorityQueue.Dequeue();
            }
            
        }

        static void marketIslemSuresi()
        {
            MyQueue<int> queue = new MyQueue<int>();
            int[] urunSayisi = { 10, 4, 8, 6, 7, 1, 15, 9, 3, 2 };
            
            for (int i = 0; i < urunSayisi.Length; i++)
            {
                queue.Enqueue(urunSayisi[i]);
            }
            int j = 0;
            double total = 0;
            double islemSureleri = 0;
            while (!queue.IsEmpty())
            {
                double islemSureKatsayisi = 2.5;
                int urunSayi = queue.Dequeue();
                double islemSuresi = urunSayi * islemSureKatsayisi;
                Console.WriteLine($"{j + 1}. müşterinin işlem süresi: {islemSuresi}");
                islemSureleri += islemSuresi;
                total += islemSureleri;
                j++;
            }
            double ortIslemSuresi = total / urunSayisi.Length;
            Console.WriteLine($"Ortalama işlem süresi: {ortIslemSuresi}");
        }
        static void öncelikliMarketIslemSuresi()
        {
            PriorityQueue4b priorityQueue = new PriorityQueue4b();
            int[] urunSayisi = { 10, 4, 8, 6, 7, 1, 15, 9, 3, 2 };
            
            double islemSureKatsayisi = 2.5;
            for( int i = 0;i < urunSayisi.Length; i++)
            {
                priorityQueue.Enqueue(urunSayisi[i]);   
            }
            int j = 0;
            double total = 0;
            double islemSureleri = 0;
            while (!priorityQueue.IsEmpty())
            {
                
                double islemSuresi = priorityQueue.Dequeue() * islemSureKatsayisi;
                Console.WriteLine($"{j + 1}. müşterinin işlem süresi: {islemSuresi}");
                islemSureleri += islemSuresi;
                total += islemSureleri;
                j++;
            }
            double ortIslemSuresi = total / urunSayisi.Length;
            Console.WriteLine($"Ortalama işlem süresi: {ortIslemSuresi}");
        }
    }
}