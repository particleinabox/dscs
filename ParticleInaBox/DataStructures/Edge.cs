using System;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        public class Edge<T>
        {
            public GraphNode<T> To { get; set; }
            Int32 Weight { get; set; }

            public Edge(GraphNode<T> to, Int32 weight = 0)
            {
                To = to;
                Weight = weight;
            }
        }
    }
}
