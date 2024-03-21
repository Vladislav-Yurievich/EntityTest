

namespace ApplicationTest.Models
{
    public class ConnectionDimensionIndex // Связь_Размерность_Показатель
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ModelID { get; set; }

        public Model Model { get; set; }
        public ICollection<Dimension> Dimensions { get; set; }
        public ICollection<Index> Indices { get; set; }
    }
}
