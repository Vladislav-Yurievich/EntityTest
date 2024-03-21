

namespace ApplicationTest.Models
{
    public class Calculation // Расчёт
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Script { get; set; } = string.Empty;
        public int ModelID { get; set; }
        public int Priority { get; set; }

        public Model Model { get; set; }
        public ICollection<ConnectionCalculationIndex> ConnectionCalculationIndices { get; set; }
    }
}
