using solution.Graph.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace solution
{
    public class EdgeInfoFormater<TEdge> : PathResultFormater<TEdge>
        where TEdge : DataEdge
    {

        public EdgeInfoFormater() : base((sb, edge) => sb.Append($"{edge.Text }"))
        {

        }
    }
}
