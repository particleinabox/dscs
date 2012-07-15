using System;

namespace ParticleInaBox
{
    namespace DataStructures.Unusual
    {
        public class TwoStacksInOneArray<T>
        {
            private T[] _array;
            private const Int32 DefaultCapacity = 16;
            private Int32 _top1 = -1;
            private Int32 _top2 = DefaultCapacity;

            public TwoStacksInOneArray(Int32 capacity)
            {
                _array = new T[capacity];
                _top2 = capacity;

            }
            public TwoStacksInOneArray()
                : this(16)
            {
            }


            public void PushToStack1(T item)
            {
                if (item.Equals(default(T)))
                    throw new ArgumentException("item");

                if (_top1 + 1 == _top2)
                    throw new StackOverflowException();
                _array[++_top1] = item;
            }

            public void PushToStack2(T item)
            {
                if (item.Equals(default(T)))
                    throw new ArgumentException("item");

                if (_top1 + 1 == _top2)
                    throw new StackOverflowException();
                _array[--_top2] = item;
            }

            public T PopFromStack1()
            {
                if (_top1 == -1)
                    throw new StackUnderflowException();
                return (_array[_top1--]);
            }

            public T PopFromStack2()
            {
                if (_top2 == _array.Length)
                    throw new StackUnderflowException();
                return (_array[_top2++]);
            }
        }
    }
}

