using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    internal class UM_Alanı 
    {
        public string Alan_Adı { get; set; }
        public string İl_Adları { get; set; }
        public int İlan_Yılı { get; set; }

        public List<string> bilgiler {  get; set; }
        public UM_Alanı() { }

        public UM_Alanı(string alanAdı,string ilAdları, int ilanYılı, List<string> bilgileri) // Constructor (Yapıcı) metot
        {
            Alan_Adı = alanAdı;
            bilgiler = bilgileri;
            İlan_Yılı = ilanYılı;
            İl_Adları = ilAdları;
        }
       




    }
    
}
