using System;
using System.Collections.Generic;
using System.Linq;

namespace ParticleInaBox
{
    namespace DataStructures
    {
        public class Graph<T>
        {
            List<GraphNode<T>> _vertices = new List<GraphNode<T>>();

            bool IsDirected { get; set; }

            public void Add(T item)
            {
                _vertices.Add(new GraphNode<T>(item));
            }

            private GraphNode<T> GetVertex(T item)
            {
                return _vertices.Where(node => node.item.Equals(item)).FirstOrDefault();
            }

            public void AddEdge(T uItem, T vItem, Int32 weight = 0)
            {
                var uVertex = GetVertex(uItem);
                var vVertex = GetVertex(vItem);

                if (uVertex != null && vVertex != null)
                    uVertex.AddEdge(vVertex, weight);
                else
                    throw new ItemNotFoundException(string.Format("Vertex not found : {0} {1}", uVertex == null ? uItem.ToString() : "", vVertex == null ? vItem.ToString() : ""));

                if (!IsDirected)
                    vVertex.AddEdge(uVertex, weight);
            }

            public void AddVertexWithEdge(T uItem, T vItem, Int32 weight = 0)
            {
                if (GetVertex(vItem) == null)
                    Add(vItem);
                AddEdge(uItem, vItem, weight);
            }

            public Int32 EdgeCount
            {
                get
                {
                    return _vertices.Sum(_vertex => _vertex.Neighbours.Count);
                }
            }

            public Int32 NVertices
            {
                get
                {
                    return _vertices.Count;
                }
            }

            private void ResetMetaData()
            {
                _vertices.ForEach(v => v.MetaData = "");
            }

            public IEnumerable<T> BreadthFirstTraversal(T item)
            {
                var node = GetVertex(item);
                if (node != null)
                {
                    ResetMetaData();

                    var _q = new Queue<GraphNode<T>>();
                    _q.Enqueue(node);

                    while (_q.Count > 0)
                    {
                        var currentNode = _q.Dequeue();
                        yield return currentNode.item;
                        foreach (var _neighbour in currentNode.Neighbours.Where(n => n.MetaData == ""))
                            _q.Enqueue(_neighbour);
                    }
                    ResetMetaData();
                }
            }

            public void BreadthFirstTraversal(T item, Action<T> action)
            {
                var node = GetVertex(item);
                if (node != null)
                {
                    ResetMetaData();

                    var _q = new Queue<GraphNode<T>>();
                    _q.Enqueue(node);

                    while (_q.Count > 0)
                    {
                        var currentNode = _q.Dequeue();
                        action(currentNode.item);
                        foreach (var _neighbour in currentNode.Neighbours.Where(n => n.MetaData == ""))
                        {
                            _neighbour.MetaData = "D";
                            _q.Enqueue(_neighbour);
                        }
                        currentNode.MetaData = "P";
                    }
                    ResetMetaData();
                }
            }
        }
    }
}