using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    class Tree
    {
        private TreeNode root;

        public Tree() { root = null; }

        public TreeNode getRoot()
        { return root; }

        // Agacın preOrder Dolasılması
        public void preOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                Console.WriteLine(localRoot.data.Alan_Adı);
                preOrder(localRoot.leftChild);
                preOrder(localRoot.rightChild);
            }
        }

        // Agacın InOrderla bilgilerinin yazdırılması
        public void inOrderPrint(TreeNode localRoot)
        {
            
            if (localRoot != null)
            {
                inOrderPrint(localRoot.leftChild);
                
                localRoot.displayNode();
                inOrderPrint(localRoot.rightChild);
                
            }
            
        }
        // Agacın postOrder Dolasılması
        public void postOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                postOrder(localRoot.leftChild);
                postOrder(localRoot.rightChild);
                localRoot.displayNode();
            }
        }


        // Düzey düzey ekleme yapan metot

        public void AddLevelOrder(TreeNode newdata)
        {
            TreeNode newNode = new TreeNode();
            newNode = newdata;
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    TreeNode temp = queue.Dequeue();

                    if (temp.leftChild == null)
                    {
                        temp.leftChild = newNode;
                        break;
                    }
                    else
                    {
                        queue.Enqueue(temp.leftChild);
                    }

                    if (temp.rightChild == null)
                    {
                        temp.rightChild = newNode;
                        break;
                    }
                    else
                    {
                        queue.Enqueue(temp.rightChild);
                    }
                }
            }

        }

        // UM Alanı bilgilerini ağacın uygun yerine ekleyen metot
        public void InsertUmAlanı(UM_Alanı newdata)
        {
            TreeNode newNode = new TreeNode();
            newNode.data = newdata;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (newdata.Alan_Adı.CompareTo(parent.data.Alan_Adı) < 0)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                } 
            } 
        } 

        // Agacın derinligini bulan metot
        public int TreeDepht(TreeNode Root, int depht, ref int maxDepth)
        {

            if (Root == null) return depht;
            if (depht > maxDepth)
            {
                maxDepth = depht;
            }

            TreeDepht(Root.leftChild, (depht + 1),  ref maxDepth);
            TreeDepht(Root.rightChild, (depht + 1),  ref maxDepth);
            return maxDepth;
        }

        // Ağacın düğüm sayısını bulan metot
        public int CountNode(TreeNode Node)
        {
            if (Node == null) return 0;
            return 1 + CountNode(Node.leftChild) + CountNode(Node.rightChild);

        }
    } 
}
