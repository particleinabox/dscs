using System;
using System.Collections.Generic;
using System.Linq;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        public class Heap<T> where T : IComparable
        {
            public T ExtractFirst()
            {
                if (_items == null || _items.Count() <= 0)
                    throw new Exception("HeapEmpty");

                var first = _items[0];
                var last = _items[_items.Count - 1];
                _items.Remove(last);
                if (_items.Count != 0)
                {
                    _items[0] = last;
                    BubbleDown(0);
                }
                return first;
            }

            public void Insert(T item)
            {
                if (_items == null)
                    _items = new List<T>();

                _items.Add(item);
                int index = _items.IndexOf(item);
                BubbleUp(index);
            }

            private void BubbleUp(int index)
            {
                if (index == 0)
                    return;

                int parentIndex;
                if (index % 2 == 0)
                    parentIndex = (index - 1) / 2;
                else
                    parentIndex = index / 2;
                if (_items[parentIndex].CompareTo(_items[index]) < 0)
                {
                    var temp = _items[index];
                    _items[index] = _items[parentIndex];
                    _items[parentIndex] = temp;

                    BubbleUp(parentIndex);
                }
            }

            public Heap(ICollection<T> collection)
            {
                if (collection != null && collection.Count() > 0)
                {
                    _items = new List<T>(collection);
                    for (int i = _items.Count() / 2 - 1; i >= 0; i--)
                        BubbleDown(i);
                }
            }

            private IList<T> _items = new List<T>();

            private void BubbleDown(int i)
            {
                int minIndex;
                if (_items == null || _items.Count <= 0)
                    throw new Exception("HeapEmpty");

                if (i >= _items.Count() / 2)
                    return;

                minIndex = _items[i].CompareTo(_items[2 * i + 1]) > 0 ? i : 2 * i + 1;
                if (2 * i + 2 < _items.Count())
                    minIndex = _items[minIndex].CompareTo(_items[2 * i + 2]) > 0 ? minIndex : 2 * i + 2;
                if (minIndex != i)
                {
                    var temp = _items[i];
                    _items[i] = _items[minIndex];
                    _items[minIndex] = temp;

                    BubbleDown(minIndex);
                }
            }
        }
    }
}