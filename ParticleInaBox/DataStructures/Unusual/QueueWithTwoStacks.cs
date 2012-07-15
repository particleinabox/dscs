using System;

namespace ParticleInaBox
{
    namespace DataStructures.Unusual
    {
        public class QueueWithTwoStacks<T>
        {
            private readonly Stack<T> _inStack = new Stack<T>();
            private readonly Stack<T> _outStack = new Stack<T>();

            public Int32 Count
            {
                get { return _inStack.Count + _outStack.Count; }
            }

            public void Enqueue(T item)
            {
                _inStack.Push(item);
            }

            public T Dequeue()
            {
                if (Count == 0)
                    throw new QueueEmptyException();

                if (_outStack.Count == 0)
                    while (_inStack.Count > 0)
                        _outStack.Push(_inStack.Pop());

                return _outStack.Pop();
            }

            public T Peek()
            {
                if (Count == 0)
                    throw new QueueEmptyException();

                if (_outStack.Count == 0)
                    while (_inStack.Count > 0)
                        _outStack.Push(_inStack.Pop());

                return _outStack.Peek();
            }
        }
    }
}
