using System;
using System.Collections.Generic;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
        {
            public BinarySearchTree()
            {
            }

            public BinarySearchTree(BinaryTreeNode<T> root)
                : base(root)
            {
            }

            public void Insert(T item)
            {
                var itemNode = new BinaryTreeNode<T>(item);

                if (Root == null)
                    Root = itemNode;
                else
                    InsertItem(itemNode, Root);

            }

            private static void InsertItem(BinaryTreeNode<T> nodeToInsert, BinaryTreeNode<T> subTreeRoot)
            {
                if (subTreeRoot.Value.CompareTo(nodeToInsert.Value) >= 0)
                {
                    if (subTreeRoot.Left == null)
                    {
                        subTreeRoot.Left = nodeToInsert;
                        nodeToInsert.parent = subTreeRoot;
                    }
                    else
                        InsertItem(nodeToInsert, subTreeRoot.Left);
                }
                else
                {
                    if (subTreeRoot.Right == null)
                    {
                        subTreeRoot.Right = nodeToInsert;
                        nodeToInsert.parent = subTreeRoot;
                    }
                    else
                        InsertItem(nodeToInsert, subTreeRoot.Right);
                }
            }

            public bool Search(T item)
            {
                return FindItem(item, Root) != null;
            }

            public T Successor(T item)
            {
                BinaryTreeNode<T> itemNode = FindItem(item, Root);

                if (itemNode != null)
                {
                    var successor = FindSuccessorNode(itemNode);
                    if (successor != null)
                        return successor.Value;
                    else
                        throw new ItemNotFoundException("No successor present for " + item.ToString());
                }
                throw new ItemNotFoundException(item);
            }

            private BinaryTreeNode<T> FindSuccessorNode(BinaryTreeNode<T> node)
            {
                if (node.Right != null)
                    return SubTreeMinimumNode(node.Right);

                var parent = node.Parent;
                while (parent != null && node == parent.Right) //&& parent != Root)
                {
                    node = parent;
                    parent = node.Parent;
                }
                return parent;
            }

            private BinaryTreeNode<T> SubTreeMinimumNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                    throw new ArgumentNullException("node");

                while (node.Left != null)
                    node = node.Left;
                return node;
            }

            private BinaryTreeNode<T> SubTreeMaximumNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                    throw new ArgumentNullException("node");

                while (node.Right != null)
                    node = node.Right;
                return node;
            }

            public void Delete(T item)
            {
                if (Root == null)
                    throw new ItemNotFoundException(item);

                var itemNode = FindItem(item, Root);
                if (itemNode == null)
                    throw new ItemNotFoundException(item);

                if (itemNode.Right == null || itemNode.Left == null)
                {
                    var childNode = itemNode.Right == null ? itemNode.Left : itemNode.Right;
                    if (itemNode == Root)
                        Root = childNode;
                    else
                    {
                        if (itemNode.Parent.Right == itemNode)
                            itemNode.Parent.Right = childNode;
                        else
                            itemNode.Parent.Left = childNode;

                        //null check dude!
                        if (childNode != null) childNode.parent = itemNode.Parent;
                    }
                }
                else
                {
                    var successorNode = FindSuccessorNode(itemNode);

                    if (successorNode.Parent.Right == successorNode)
                        successorNode.Parent.Right = successorNode.Right;
                    else
                        successorNode.Parent.Left = successorNode.Right;

                    if (successorNode.Right != null)
                        successorNode.Right.parent = successorNode.Parent;

                    itemNode.item = successorNode.Value;
                }
            }

            public IEnumerable<T> InOrderTraversal()
            {
                if (Root != null)
                    foreach (var item in InOrder(Root))
                        yield return item;
            }

            private IEnumerable<T> InOrder(BinaryTreeNode<T> node)
            {
                if (node.Left != null)
                    foreach (var value in InOrder(node.Left))
                        yield return value;
                yield return node.Value;
                if (node.Right != null)
                    foreach (var value in InOrder(node.Right))
                        yield return value;
            }

            public IEnumerable<T> PreOrderTraversal()
            {
                if (Root != null)
                    foreach (var item in PreOrder(Root))
                        yield return item;
            }

            private IEnumerable<T> PreOrder(BinaryTreeNode<T> node)
            {
                yield return node.Value;

                if (node.Left != null)
                    foreach (var value in PreOrder(node.Left))
                        yield return value;
                if (node.Right != null)
                    foreach (var value in PreOrder(node.Right))
                        yield return value;
            }

            public IEnumerable<T> PostOrderTraversal()
            {
                if (Root != null)
                    foreach (var item in PostOrder(Root))
                        yield return item;
            }

            private IEnumerable<T> PostOrder(BinaryTreeNode<T> node)
            {
                if (node.Left != null)
                    foreach (var value in PostOrder(node.Left))
                        yield return value;
                if (node.Right != null)
                    foreach (var value in PostOrder(node.Right))
                        yield return value;
                yield return node.Value;
            }

            private static BinaryTreeNode<T> FindItem(T item, BinaryTreeNode<T> subTreeRoot)
            {
                if (subTreeRoot == null)
                    return null;

                if (subTreeRoot.Value.CompareTo(item) == 0)
                    return subTreeRoot;

                if (subTreeRoot.Value.CompareTo(item) >= 0)
                    return FindItem(item, subTreeRoot.Left);

                return FindItem(item, subTreeRoot.Right);

            }

            public IEnumerable<T> InOrderTraversalNonRecursive()
            {
                if (Root != null)
                {
                    var stack = new Stack<BinaryTreeNode<T>>();

                    var node = Root;
                    while (stack.Count > 0 || node != null)
                    {
                        if (node != null)
                        {
                            stack.Push(node);
                            node = node.Left;
                        }
                        else
                        {
                            node = stack.Pop();
                            yield return node.Value;
                            node = node.Right;
                        }
                    }
                }
            }
        }
    }
}
