

using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ApplicationTest.Models
{
    public class Task // Задание
    {
        public int ID { get; set; }
        public int ModelID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public Model Model { get; set; }
        public ICollection<ParametrValues> ParametrValues { get; set; }
    }
}
