

using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ApplicationTest.Models
{
    public class Dimension // Размерность
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ModelID { get; set; }
        public Model Model { get; set; }
        public ICollection<ParametrValues> ParametrValues { get; set; }
        public ICollection<Key> Keys { get; set; }
        public ICollection<ConnectionDimensionIndex> ConnectionDimensionIndexes { get; set; }
    }
}
