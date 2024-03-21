

namespace ApplicationTest.Models
{
    public class ParametrValues // Значения параметра
    {
        public int ID { get; set; }
        public int TaskID { get; set; }
        public int DimensionID { get; set; }
        public string Data { get; set; } = string.Empty;

        public Task Task { get; set; }
        public Dimension Dimension { get; set; }
    }
}
