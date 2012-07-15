using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        [DebuggerDisplay("[{item}] -> [{(Left == null) ? default(T) : Left.item }] [{(Right == null) ? default(T) : Right.item }]")]
        public class BinaryTreeNode<T> : Node<T> where T : IComparable
        {
            public BinaryTreeNode(T item, BinaryTreeNode<T> left, BinaryTreeNode<T> right, BinaryTreeNode<T> parent)
                : base(item, new Collection<Node<T>> { left, right })
            {
                this.parent = parent;
            }

            public BinaryTreeNode(T item, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
                : base(item, new Collection<Node<T>> { left, right })
            {
            }

            public BinaryTreeNode(T item, BinaryTreeNode<T> parent)
                : base(item)
            {
                this.parent = parent;
            }

            public BinaryTreeNode(T item)
                : base(item)
            {
            }

            public BinaryTreeNode<T> Left
            {
                get
                {
                    if (Neighbours == null || Neighbours.Count == 0)
                        return null;

                    return (BinaryTreeNode<T>)Neighbours[0];
                }
                set
                {
                    if (Neighbours == null)
                        neighbours = new Collection<Node<T>> { value, null };
                    else
                        Neighbours[0] = value;
                }
            }

            public BinaryTreeNode<T> Right
            {
                get
                {
                    if (Neighbours == null || Neighbours.Count <= 1)
                        return null;

                    return (BinaryTreeNode<T>)Neighbours[1];
                }
                set
                {
                    if (Neighbours == null)
                        base.neighbours = new Collection<Node<T>> { null, value };
                    else
                        Neighbours[1] = value;
                }
            }

            internal BinaryTreeNode<T> parent;
            public BinaryTreeNode<T> Parent
            {
                get { return parent; }
            }

            public override string ToString()
            {
                return Value.ToString();
            }

            public string ToStringAsTreeNode()
            {
                return string.Format("[{0}{1}{2}]", Left == null ? "" : Left.ToStringAsTreeNode(), Value.ToString(), Right == null ? "" : Right.ToStringAsTreeNode());
            }
        }
    }
}
