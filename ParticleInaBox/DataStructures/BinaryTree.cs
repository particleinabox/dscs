using System;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        public class BinaryTree<T> where T : IComparable
        {
            public BinaryTreeNode<T> Root
            {
                get;
                set;
            }

            public BinaryTree(BinaryTreeNode<T> root)
            {
                Root = root;
            }

            public BinaryTree()
            {

            }

            public Int32 Height
            {
                get
                {
                    return ComputeHeight(Root);
                }
            }

            public Int32 Diameter
            {
                get
                {
                    return ComputeDiameter(Root);
                }
            }

            private int ComputeDiameter(BinaryTreeNode<T> node)
            {
                if (node == null)
                    return 0;

                return Math.Max(ComputeDiameter(node.Left),
                                Math.Max(ComputeDiameter(node.Right),
                                         ComputeHeight(node.Left) + ComputeHeight(node.Right) + 1));
            }

            private int ComputeHeight(BinaryTreeNode<T> node)
            {
                if (node == null)
                    return 0;

                return Math.Max(ComputeHeight(node.Left), ComputeHeight(node.Right)) + 1;
            }
        }
    }
}
