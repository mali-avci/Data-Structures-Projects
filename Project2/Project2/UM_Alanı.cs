using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class UM_Alanı 
    {
        public string Alan_Adı { get; set; }
        public List<string> İl_Adları { get; set; }
        public int İlan_Yılı { get; set; }
        public UM_Alanı() { }

        public UM_Alanı(string alanAdı, List<string> ilAdları, int ilanYılı) // Constructor (Yapıcı) metot
        {
            Alan_Adı = alanAdı;
            İl_Adları = ilAdları;
            İlan_Yılı = ilanYılı;
        }

    }
}
