using HelixToolkit.SharpDX.Core;
using System.Collections.Generic;

namespace WpfApp3
{
    abstract class ModelBase
    {
        public Vector3Collection Positions { get; } = new Vector3Collection();
        public IntCollection Indices { get; }= new IntCollection();
        public Vector3Collection Normals { get; } = new Vector3Collection();
        public List<Face> Faces { get; } = new List<Face>();
        public List<Edge> Edges { get; } = new List<Edge>();

        public abstract void Update();
    }
}
