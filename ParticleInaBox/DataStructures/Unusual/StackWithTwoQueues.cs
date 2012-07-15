using System;

namespace ParticleInaBox
{
    namespace DataStructures.Unusual
    {
        public class StackWithTwoQueues<T>
        {
            private Queue<T> _queue1 = new Queue<T>();
            private Queue<T> _queue2 = new Queue<T>();

            public Int32 Count { get { return _queue1.Count + _queue2.Count; } }

            public void Push(T item)
            {
                _queue2.Enqueue(item);

                while (_queue1.Count > 0)
                    _queue2.Enqueue(_queue1.Dequeue());

                Swap(ref _queue1, ref _queue2);
            }

            public T Pop()
            {
                if (0 == Count)
                    throw new StackUnderflowException();

                return _queue1.Dequeue();
            }

            public T Peek()
            {
                if (0 == Count)
                    throw new StackUnderflowException();

                return _queue1.Peek();
            }

            private void Swap<TObject>(ref TObject o1, ref TObject o2)
            {
                var temp = o1;
                o1 = o2;
                o2 = temp;
            }
        }
    }
}
