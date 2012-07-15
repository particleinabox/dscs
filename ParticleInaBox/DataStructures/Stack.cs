using System;
using System.Text;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        public class Stack<T>
        {
            private LinkedListNode<T> _head;

            private int _count;
            public Int32 Count { get { return _count; } }
            public String Id { get; set; }

            public void Push(T item)
            {
                _head = new LinkedListNode<T>(item, _head);
                _count++;
            }

            public T Pop()
            {
                if (_head == null)
                    throw new StackUnderflowException();

                var item = _head.Value;
                _head = _head.Next;

                _count--;
                return item;
            }

            public T Peek()
            {
                if (_head == null)
                    throw new StackUnderflowException();
                return _head.Value;
            }

            public override string ToString()
            {
                if (_head != null)
                {
                    var start = _head;
                    var stackString = new StringBuilder(Count);
                    stackString.Append(_head.Value);
                    while ((start = start.Next) != null)
                    {
                        stackString.AppendFormat(" -> {0} ", start.Value);
                    }

                    return stackString.ToString();
                }
                return "";
            }
        }
    }
}
