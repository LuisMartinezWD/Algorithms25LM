using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3tree
{
    public class TwoThreeTree
    {
        private TwoThreeNode root = new TwoThreeNode();

        public void Insert(int key)
        {
            var newRoot = Insert(root, key);
            if (newRoot != null)
                root = newRoot;
        }

        private TwoThreeNode Insert(TwoThreeNode node, int key)
        {
            if (node.IsLeaf)
            {
                node.Keys.Add(key);
                node.Keys.Sort();

                if (node.Keys.Count == 3)
                    return Split(node);
                return null;
            }
            else
            {
                
                int i = 0;
                while (i < node.Keys.Count && key > node.Keys[i]) i++;

                var child = node.Children[i];
                var newChild = Insert(child, key);

                if (newChild != null)
                {
                   
                    node.Keys.Insert(i, newChild.Keys[0]);
                    node.Children[i] = newChild.Children[0];
                    node.Children.Insert(i + 1, newChild.Children[1]);
                }

                if (node.Keys.Count == 3)
                    return Split(node);
                return null;
            }
        }

        private TwoThreeNode Split(TwoThreeNode node)
        {
            var newNode = new TwoThreeNode();
            newNode.Keys.Add(node.Keys[1]);

            var left = new TwoThreeNode();
            left.Keys.Add(node.Keys[0]);

            var right = new TwoThreeNode();
            right.Keys.Add(node.Keys[2]);

            if (!node.IsLeaf)
            {
                left.Children.Add(node.Children[0]);
                left.Children.Add(node.Children[1]);

                right.Children.Add(node.Children[2]);
                right.Children.Add(node.Children[3]);
            }

            newNode.Children.Add(left);
            newNode.Children.Add(right);

            return newNode;
        }

        public void InOrderTraversal()
        {
            InOrder(root);
        }

        private void InOrder(TwoThreeNode node)
        {
            if (node.IsLeaf)
            {
                foreach (var key in node.Keys)
                    Console.WriteLine(key);
            }
            else
            {
                for (int i = 0; i < node.Keys.Count; i++)
                {
                    InOrder(node.Children[i]);
                    Console.WriteLine(node.Keys[i]);
                }
                InOrder(node.Children[node.Keys.Count]);
            }
        }


    }
}
