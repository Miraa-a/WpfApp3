using System.Collections.Generic;
using HelixToolkit.SharpDX.Core;

namespace WpfApp3
{
    class Face
    {
        public IntCollection Indices { get; } = new IntCollection();
        public List<Edge> Edges { get; } = new List<Edge>();
    }
}
