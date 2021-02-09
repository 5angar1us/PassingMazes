using GraphX.Common;
using solution.Graph.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace solution
{
    class TurnNeighborSide
    {
        readonly Dictionary<ENeighborSide, ENeighborSide> TurnPairs = new Dictionary<ENeighborSide, ENeighborSide>();
        readonly Dictionary<ENeighborSide, ENeighborSide> OppositePairs = new Dictionary<ENeighborSide, ENeighborSide>();

        public TurnNeighborSide()
        {
            TurnPairs.Add(ENeighborSide.Left, ENeighborSide.Top);
            TurnPairs.Add(ENeighborSide.Top, ENeighborSide.Right);
            TurnPairs.Add(ENeighborSide.Right, ENeighborSide.Bottom);
            TurnPairs.Add(ENeighborSide.Bottom, ENeighborSide.Left);

            CreateOppositePairs();

        }

        private void CreateOppositePairs()
        {
            OppositePairs.Add(ENeighborSide.Left, ENeighborSide.Right);
            OppositePairs.Add(ENeighborSide.Top, ENeighborSide.Bottom);

            var list = new List<(ENeighborSide first, ENeighborSide second)>();
            foreach (var x in OppositePairs.Keys)
            {
                list.Add((x, OppositePairs[x]));
            }
            foreach (var x in list)
            {
                OppositePairs.Add(x.second, x.first);
            }
        }

        public bool IsTurn(IGrouping<DataVertex, DataEdge> x)
        {
            if (x.Count() != 2)
                throw new ArgumentException();

            var list = x.ToList();

            var firstNeighborSide = list[0].NeighborSide;
            var secondNeighborSide = list[1].NeighborSide;

            return TurnPairs[firstNeighborSide] == secondNeighborSide
                || TurnPairs[secondNeighborSide] == firstNeighborSide;

        }

        public ENeighborSide Turn(ENeighborSide eNeighborSide)
        {
            return OppositePairs[eNeighborSide];
        }

    }
}
