using GraphX.Common.Models;
using System;

namespace solution.Graph.Model
{
    public class DataVertex : VertexBase, IEquatable<DataVertex>
    {
        /// <summary>
        /// Some string property for example purposes
        /// </summary>
        public string Name { get; set; }
        public char Symbol { get; set; }

        #region Calculated or static props

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

        #endregion

        /// <summary>
        /// Default parameterless constructor for this class
        /// (required for YAXLib serialization)
        /// </summary>
        public DataVertex() : this(' ',string.Empty)
        {
        }

        public DataVertex(char symbol, string text = "")
        {
            Symbol = symbol;
            Name = text;
        }
    }
}
