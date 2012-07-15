using System;
using System.Text;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        public class Queue<T>
        {
            private LinkedListNode<T> _head;
            private LinkedListNode<T> _tail;

            private int _count;
            public Int32 Count { get { return _count; } }

            public void Enqueue(T item)
            {
                if (null == _tail && null == _head)
                    _head = _tail = new LinkedListNode<T>(item);
                else
                {
                    _tail.next = new LinkedListNode<T>(item);
                    _tail = _tail.Next;
                }

                _count++;
            }

            public T Dequeue()
            {
                if (null == _head)
                    throw new QueueEmptyException();

                var item = _head.Value;
                _head = _head.Next;

                if (_head == null)
                    _tail = null;

                _count--;

                return item;

            }

            public T Peek()
            {
                if (null == _head)
                    throw new QueueEmptyException();

                return _head.Value;
            }

            public override string ToString()
            {
                if (_head != null)
                {
                    var start = _head;
                    var queueString = new StringBuilder(Count);
                    queueString.Append(_head.Value);
                    while ((start = start.Next) != null)
                    {
                        queueString.AppendFormat(" -> {0} ", start.Value);
                    }

                    return queueString.ToString();
                }
                return null;
            }
        }

        [Serializable]
        public class QueueEmptyException : System.Exception
        { }
    }
}
