using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    class TreeNode
    {
        public UM_Alanı data;
        public TreeNode leftChild;
        public TreeNode rightChild;
        public void displayNode() 
        {
            Console.WriteLine();
            Console.Write(" " + data.Alan_Adı + " ");
            Console.Write(" " + data.İl_Adları);
            Console.Write(" " + data.İlan_Yılı);
            Console.WriteLine();
            Console.WriteLine("Bilgi Paragrafı:");
            for (var i = 0; i < data.bilgiler.Count; i++)
            {
               
                Console.Write(" " + data.bilgiler[i]);
            }
            Console.WriteLine();

        }
    }
}
