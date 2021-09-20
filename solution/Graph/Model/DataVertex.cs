using GraphX.Common.Models;
using System;

namespace solution.Graph.Model
{
    public class DataVertex : VertexBase, IEquatable<DataVertex>
    {
        public string Name { get; set; }
        public char Symbol { get; set; }

        public DataVertex() : this(' ', string.Empty)
        {
        }

        public DataVertex(char symbol, string text = "")
        {
            Symbol = symbol;
            Name = text;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DataVertex);
        }

        public bool Equals(DataVertex other)
        {
            return other != null &&
                   Angle == other.Angle &&
                   GroupId == other.GroupId &&
                   SkipProcessing == other.SkipProcessing &&
                   ID == other.ID &&
                   Name == other.Name &&
                   Symbol == other.Symbol;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Angle, GroupId, SkipProcessing, ID, Name, Symbol);
        }
    }
}
