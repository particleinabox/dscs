using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        public class GraphNode<T> : Node<T>
        {
            public GraphNode(T item)
                : base(item)
            {

            }

            internal string MetaData { get; set; }

            public new Collection<GraphNode<T>> Neighbours
            {
                get
                {
                    return new Collection<GraphNode<T>>((from _edge in _edges select _edge.To).ToList());
                }
            }

            private List<Edge<T>> _edges;
            protected List<Edge<T>> Edges
            {
                get
                {
                    if (_edges == null)
                        _edges = new List<Edge<T>>();
                    return _edges;
                }
            }

            public void AddEdge(GraphNode<T> node, Int32 weight = 0)
            {
                this.Edges.Add(new Edge<T>(node, weight));
            }
        }
    }
}
