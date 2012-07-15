using System;
using System.Text;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        public class LinkedList<T> where T : IComparable
        {
            private LinkedListNode<T> _head = null;
            public LinkedListNode<T> Head
            {
                get
                {
                    return _head;
                }
            }

            public Int32 Length
            {
                get
                {
                    var _iterator = _head;
                    var count = 0;
                    while (_iterator != null)
                    {
                        count++;
                        _iterator = _iterator.Next;
                    }
                    return count;
                }
            }

            public void Insert(T item)
            {
                if (_head == null)
                    _head = new LinkedListNode<T>(item);
                else
                {
                    _head = new LinkedListNode<T>(item, _head);
                    _head.Next.previous = _head;
                }
            }

            public void InsertAfter(T item1, T item2)
            {
                var insertAfterNode = SearchNodes(item1);
                if (insertAfterNode == null)
                    throw new ItemNotFoundException(item1);

                var node = new LinkedListNode<T>(item2, insertAfterNode.Next, insertAfterNode);
                insertAfterNode.Next.previous = node;
                insertAfterNode.next = node;

            }

            public void Remove(T item)
            {
                LinkedListNode<T> node = SearchNodes(item);

                if (node == null)
                    throw new ItemNotFoundException(item);
                else
                {
                    if (node == _head)
                    {
                        _head = node.Next;
                        if (_head != null)
                            _head.previous = null;
                    }

                    else
                    {
                        node.Previous.next = node.Next;
                        if (node.Next != null)
                            node.Next.previous = node.Previous;
                    }
                }

            }

            public bool Contains(T item)
            {
                return SearchNodes(item) != null ? true : false;
            }

            private LinkedListNode<T> SearchNodes(T item)
            {
                var iterator = _head;
                while (iterator != null)
                    if (iterator.Value.CompareTo(item) == 0)
                        return iterator;
                    else
                        iterator = iterator.Next;
                return iterator;
            }

            public void Reverse()
            {
                var node = _head;
                var prev = node.previous;
                while (node != null)
                {
                    var next = node.Next;

                    node.next = prev;
                    node.previous = next;

                    prev = node;
                    node = next;
                }
                _head = prev;
            }

            public void ReverseRecursiveWay()
            {
                if (_head != null)
                    ReverseRecursive(_head);
            }

            private void ReverseRecursive(LinkedListNode<T> _node)
            {
                if (_node != null)
                {
                    _head = _node;
                    ReverseRecursive(_node.Next);
                    if (_node.Next != null)
                        _node.Next.next = _node;
                    _node.previous = _node.Next;
                    _node.next = null;
                }
            }

            public override string ToString()
            {
                if (_head != null)
                {
                    var start = _head;
                    var stackString = new StringBuilder();
                    stackString.Append(_head.Value);
                    while ((start = start.Next) != null)
                    {
                        stackString.AppendFormat(" -> {0} ", start.Value);
                    }

                    return stackString.ToString();
                }
                return null;
            }

        }
    }
}