

namespace ApplicationTest.Models
{
    public class Value // Значение
    {
        public int ID { get; set; }
        public int ModelID { get; set; }
        public int IndexID { get; set; }
        public string Data { get; set; }

        public Model Model { get; set; }
        public Index Index { get; set; }
    }
}
