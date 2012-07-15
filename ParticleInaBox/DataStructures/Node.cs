using System.Collections.ObjectModel;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        public class Node<T>
        {
            internal T item;
            public T Value { get { return item; } }

            internal System.Collections.IList neighbours;
            protected System.Collections.IList Neighbours { get { return neighbours; } }

            public Node(T item, Collection<Node<T>> neighbours = null)
            {
                this.item = item;
                this.neighbours = neighbours;
            }
        }
    }
}
