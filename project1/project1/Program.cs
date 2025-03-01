using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ilAdList = new string[81];
            int[][] uzaklik = new int[81][];
            int ilSayisi = 81;
            for (int i = 0; i < ilSayisi; i++)
            {
                uzaklik[i] = new int[81];
            }
            uzaklik = matrisOlustur(uzaklik, ilSayisi);
            ilAdList = plakaOlustur(ilAdList, ilSayisi);
            string cevap= "e";
            while (cevap == "e"|| cevap == "E")
            {
                int istekNo = menu();
                if (istekNo == 1)
                {
                    ilMesafeListele(uzaklik, ilAdList);
                }
                if(istekNo == 2)
                {
                    enMesafeİller(uzaklik, ilAdList);
                }
                if (istekNo == 3)
                {
                    enCokSehir(uzaklik, ilAdList);
                }
                if(istekNo == 4)
                {
                    rastgele5(uzaklik, ilAdList);
                }
                if(istekNo == 5)
                {
                    break;
                }
                Console.Write("başka bir işlem yapmak istiyor musunuz?(E/e/H/h)");
                cevap = Console.ReadLine();
            }
        }
        static int menu() 
        {
            
            Console.WriteLine("(1) Verilen ilden belli bir uzaklığa kadar olan illerin ve uzaklıklarının listelenmesi!");
            Console.WriteLine("(2) Türkiye’deki birbirine en yakın iki ilin ve en uzak iki ilin bulunması!");
            Console.WriteLine("(3) Verilen ilden verilen mesafe kullanılarak en fazla kaç il dolaşılabildiğinin bulunması!");
            Console.WriteLine("(4) Rastgele (random) 5 farklı sayı attırarak bu plaka numaralı iller arasındaki uzaklıkları " +
                "matris şeklinde illerin adlarıyla birlikte ekrana listele !");
            Console.WriteLine("(5) çıkış");
            Console.Write("Yapmak istediğiniz işlemin numarasını giriniz: ");
            int istekNo = Convert.ToInt32(Console.ReadLine());
            return istekNo;
        }
    static int[][] matrisOlustur(int[][] uzaklik, int ilSayisi)
    {
        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook excelWorkbook = excelApp.Workbooks.Open("C:\\Users\\baran\\Downloads\\project1\\project1\\ilmesafe.xlsx");
        Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[1]; // İlk sayfa

        for (int i = 0; i < ilSayisi; i++)
        {
            for (int j = 0; j < ilSayisi; j++)
            {
                uzaklik[i][j] = Convert.ToInt32(excelWorksheet.Cells[i + 3, j + 3].Value2);

            }
        }
        excelWorkbook.Close();
        excelApp.Quit();

        return uzaklik;
    }

    static string[] plakaOlustur(string[] ilAdList, int ilSayisi)
    {
        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook excelWorkbook = excelApp.Workbooks.Open("C:\\Users\\baran\\Downloads\\project1\\project1\\ilmesafe.xlsx");
        Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[1]; // İlk sayfa

        for (int k = 0; k < ilSayisi; k++)
        {
            ilAdList[k] = excelWorksheet.Cells[2, k + 3].Value2;
        }
        excelWorkbook.Close();
        excelApp.Quit();

        return ilAdList;
    }

    static void ilMesafeListele(int[][] uzaklik, string[] ilAdList)
    {
        Console.Write("Diğer illere uzaklığını öğrenmek istediğiniz ilin ismini ya da plaka kodunu giriniz: ");
        string sehirİsmi = Console.ReadLine();
        Console.Write("Aratmak istediğiniz uzaklığı giriniz: ");
        int mesafe = Convert.ToInt32(Console.ReadLine());
        int index = indexUret(sehirİsmi, ilAdList);
        Console.WriteLine(mesafe + "km mesafedeki iller:");
        for (int j = 0; j < ilAdList.Length; j++)
        {
            if (uzaklik[index][j] <= mesafe && uzaklik[index][j] != 0)
            {
                
                Console.WriteLine(ilAdList[j] + " ile arasındaki mesafe " + uzaklik[index][j] + " km'dir");
            }
        }
    }

    static void enMesafeİller(int[][] uzaklik, string[] ilAdList)
    {
        int maxUzaklik = int.MinValue;
        int minUzaklik = int.MaxValue;
        string sehirUzak1 = null;
        string sehirUzak2 = null;
        string sehirYakin1 = null;
        string sehirYakin2 = null;

        for (int i = 0; i < ilAdList.Length; i++)
        {
            for (int j = 0; j < ilAdList.Length; j++)
            {
                if (uzaklik[i][j] > maxUzaklik)
                {
                    maxUzaklik = uzaklik[i][j];
                    sehirUzak1 = ilAdList[i];
                    sehirUzak2 = ilAdList[j];
                }

                if (uzaklik[i][j] < minUzaklik && uzaklik[i][j] != 0)
                {
                    minUzaklik = uzaklik[i][j];
                    sehirYakin1 = ilAdList[i];
                    sehirYakin2 = ilAdList[j];
                }
            }
        }
        Console.WriteLine("En uzak iki il: " + sehirUzak1 + " - " + sehirUzak2 + " Arası uzaklık: " + maxUzaklik);
        Console.WriteLine("En yakın iki il: " + sehirYakin1 + " - " + sehirYakin2 + " Arası uzaklık: " + minUzaklik);
    }

    static void rastgele5(int[][] uzaklik, string[] ilAdList) // Tabloyu Düzenle
    {
            int[] rastgelesayilar = new int[5];
            string [] rastgelesehirler = new string[5];
            Random rnd = new Random();

           
         
        for (int i =0; i<5; i++)
        {       
                rastgelesayilar[i] = rnd.Next(0, 80);
                rastgelesehirler[i] = ilAdList[rastgelesayilar[i]]; 
        }
            var cities = String.Format("{0,30}{1,20}{2,20}{3,20}{4,20}\n", rastgelesehirler[0], 
            rastgelesehirler[1], rastgelesehirler[2], rastgelesehirler[3], rastgelesehirler[4]);
            Console.Write(cities);
            Console.WriteLine();
        int[] mesafeler = new int[5];
        for (int i = 0; i < 5; i++)
        {
            Console.Write(String.Format("{0,-16}", rastgelesehirler[i]));
            for (int j = 0; j < 5; j++)
            {
                    
                mesafeler[j] = uzaklik[rastgelesayilar[i]][rastgelesayilar[j]];
                 
            }
            Console.Write(String.Format("{0,14}{1,16}{2,17}{3,19}{4,23}\n", mesafeler[0],
                    mesafeler[1], mesafeler[2], mesafeler[3], mesafeler[4]));

            Console.WriteLine();

            }
        }
        static int indexUret(string input, string[] ilAdList)
        {
            int index = -1;

            if (int.TryParse(input, out int ilkodu))
            {
                index = Convert.ToInt32(input) - 1;
            }
            else
            {
                for (int i = 0; i < ilAdList.Length; i++)
                {
                    if (string.Equals(input, ilAdList[i].ToLower(), StringComparison.OrdinalIgnoreCase)) //SADECE BÜYÜK HARFİ KABUL EDİYO
                    {

                        index = i; break;
                    }
                }
            }

            return index;

        }
        static void enCokSehir(int[][] uzaklik, string[] ilAdList)
        {
            Console.Write("Başlangıç şehrini giriniz: ");
            string girdi = Console.ReadLine();
            int index = indexUret(girdi, ilAdList);
            Console.Write("Menzili belirtiniz: ");
            int menzil = Convert.ToInt32(Console.ReadLine());
            List<string> sehirler = new List<string>();
            int sayac = 0;
            int tmp = -1;

            sehirler.Add(ilAdList[index]);
            while(sayac <= menzil) 
            {
                int sehirlerArasiMesafe = int.MaxValue;
                for (int i = 0;i < ilAdList.Length;i++)
                {

                    if (uzaklik[index][i] < sehirlerArasiMesafe && index != i && !sehirler.Contains(ilAdList[i]))
                    {
                        sehirlerArasiMesafe = uzaklik[index][i];
                        tmp = i;
                    }
                }

                sehirler.Add(ilAdList[tmp]);
                sayac += uzaklik[index][tmp];
                Console.WriteLine(ilAdList[index] + "-" + ilAdList[tmp] + " Arası uzaklık: " + uzaklik[index][tmp]);
                index = tmp;
            }
            Console.WriteLine();
            Console.WriteLine("Totalde " + sehirler.Count + " İl Gezilebilmektedir.");




        }
    }


        
}
