using System.Diagnostics;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        [DebuggerDisplay("{Value}")]
        public class LinkedListNode<T>
        {
            internal LinkedListNode<T> next;
            public LinkedListNode<T> Next
            {
                get { return next; }
            }

            internal LinkedListNode<T> previous;
            public LinkedListNode<T> Previous
            {
                get { return previous; }
            }

            internal T item;
            public T Value
            {
                get { return item; }
            }

            //internal LinkedListNode(T data, LinkedListNode<T> next = null)
            //{
            //    item = data;
            //    this.next = next;
            //}

            internal LinkedListNode(T data, LinkedListNode<T> next = null, LinkedListNode<T> prev = null)
            {
                item = data;
                this.next = next;
                this.previous = prev;
            }
        }
    }
}
