using GraphX.Common;
using QuickGraph;
using QuickGraph.Algorithms.Search;
using solution.Graph.Model;
using solution.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace solution
{
    class Program
    {


        static void Main(string[] args)
        {
            var textMap = "";
            using (var sr = new StreamReader(@"C:\Users\Admin\source\repos\solution\solution\Properties\TextFile1.txt"))
            {
                textMap = sr.ReadToEnd();
            }

            var parser = new MapParser();
            MyMap map = parser.Parse(textMap);




            MapConverter graphCreator = new MapConverter();
            var graph = graphCreator.ToGraph(map);

            GraphOptimazer graphOptimazer = new GraphOptimazer();
            var optimazedGraph = graphOptimazer.Optimazi(graph);

            


            var optimazedPathFinder = new PathFinder<OptimazedDataGraph, OptimazedDataEdge>(optimazedGraph);
            (string optimazedCommands, string optimazedEdgeOrder) = FindPath(optimazedPathFinder, new OptimazedCommadFormater(), new EdgeInfoFormater<OptimazedDataEdge>());

            var pathFinder = new PathFinder<DataGraph, DataEdge>(graph);
            (string commands, string edgeOrder) = FindPath(pathFinder, new DataCommandFormater(), new EdgeInfoFormater<DataEdge>());


           
            WriteSeparator();
            WriteSymbols(map);

            WriteSeparator();
            WriteName(map);

            //WriteSeparator();
            //foreach (var x in optimazedGraph.Vertices)
            //{
            //    Console.Write(x.Name + " ");
            //}
            //Console.WriteLine();

            //WriteSeparator();
            //foreach (var x in optimazedGraph.Edges)
            //{
            //    Console.Write(x.Text + " ");
            //}
            //Console.WriteLine();

            if (optimazedCommands.Equals(commands))
            {
                
                Write("The commands are equals", commands);
                Write(nameof(edgeOrder), edgeOrder);
                Write(nameof(optimazedEdgeOrder), optimazedEdgeOrder);
            }
            else
            {
                Write(nameof(commands), commands);
                Write(nameof(edgeOrder), edgeOrder);

                Write(nameof(optimazedCommands), optimazedCommands);
                Write(nameof(optimazedEdgeOrder), optimazedEdgeOrder);

            }




            WriteSeparator();
        }

        private static void Write(string title, string commands)
        {
            WriteSeparator();
            Console.WriteLine($"{title} : {commands}");
        }

        private static (string, string) FindPath<TGraph, TEdge>
            (
                PathFinder<TGraph, TEdge> pathFinder,
                CommandFormater<TEdge> pathCommandFormater,
                EdgeInfoFormater<TEdge> edgeInfoFormater
            )
            where TGraph : BidirectionalGraph<DataVertex, TEdge>
            where TEdge : DataEdge
        {
            string commands = "";
            string edgeOrder = "";
            if (pathFinder.TryFindPath(out IEnumerable<TEdge> path))
            {
                commands = pathCommandFormater.Format(path);
                edgeOrder = edgeInfoFormater.Format(path);
            }
            else
            {
                var errorText = "Path is not find";
                commands = errorText;
                edgeOrder = errorText;
            }
            return (commands, edgeOrder);
        }

        private static void WriteSymbols(MyMap map)
        {
            for (int r = 0; r < map.Height; r++)
            {
                for (int c = 0; c < map.Width; c++)
                {
                    Console.Write(map[r, c].Symbol + " ");
                }
                Console.WriteLine();
            }
        }

        private static void WriteName(MyMap map)
        {
            for (int r = 0; r < map.Height; r++)
            {
                for (int c = 0; c < map.Width; c++)
                {
                    Console.Write("{0,4}", $"{ map[r, c].Name }");
                }
                Console.WriteLine();
            }
        }

        private static void WriteSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("===== ===== =====");
            Console.WriteLine();
        }
    }
}
