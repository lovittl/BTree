using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btree
{
    class BTree
    {
        private int val;
        public BTree (int val)
        {
            this.val = val;
        }
        

        BTree left = null;
        BTree right = null;

        public void Add(int val)
        {
            if (val > this.val)
            {
                if (right == null)
                {
                    right = new BTree(val);
                }
                else
                {
                    right.Add(val);
                }
            }
            else if (val < this.val)
            {
                if(left == null)
                {
                    left = new BTree(val);
                }
                else
                {
                    left.Add(val);
                }
            }
            else
            {
                throw new Exception("Can't have equal vals");
            }
        }

        public List<int> Flatten()
        {
            var l = new List<int>();

            if (left != null)
            {
                l.AddRange(left.Flatten());
            }

            l.Add(this.val);

            if (right != null)
            {
                l.AddRange(right.Flatten());
            }

            return l;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                BTree tree = new BTree(22);

                tree.Add(6);
                tree.Add(1);
                tree.Add(7);
                tree.Add(22);
                tree.Add(17);

                //try { tree.Add(17); }

                foreach (var i in tree.Flatten())
                    Console.WriteLine(i);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
    }
}
