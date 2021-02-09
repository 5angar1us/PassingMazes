using solution.Graph.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace solution
{
    public abstract class PathResultFormater <TEdge> where TEdge : DataEdge
    {
        protected readonly Action<StringBuilder, TEdge> func;

        protected PathResultFormater(Action<StringBuilder, TEdge> func)
        {
            this.func = func;
        }

        public string Format(IEnumerable<TEdge> path)
        {
            var sb = new StringBuilder();

            foreach (var edge in path)
                func(sb, edge);

            return sb.ToString();
        }
    }
}
