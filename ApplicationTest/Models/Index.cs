
namespace ApplicationTest.Models
{
    public class Index // показатель
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelID { get; set; }

        public Model Model { get; set; }
        public ICollection<Value> Values { get; set; }
        public ICollection<ConnectionCalculationIndex> ConnectionCalculationIndices { get; set; }
    }
}
