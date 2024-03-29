﻿using System.Collections.Generic;
using System.Text;
using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters.Abstract;
using PassingMazesAlgorithm.Core.Graph.Model;

namespace PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters
{
    public class ForeachFormater<TEdge> where TEdge : DataEdge
    {
        protected readonly AbstractFormater<TEdge> _commandFormater;

        public ForeachFormater(AbstractFormater<TEdge> commandFormater)
        {
            _commandFormater = commandFormater;
        }

        public string Format(IEnumerable<TEdge> path)
        {
            var sb = new StringBuilder();

            foreach (TEdge edge in path)
                _commandFormater.Format(sb, edge);

            return sb.ToString();
        }
    }
}
