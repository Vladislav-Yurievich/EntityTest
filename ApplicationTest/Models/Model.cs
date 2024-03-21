

using System.ComponentModel.DataAnnotations;

namespace ApplicationTest.Models
{
    public class Model // Модель
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Task> Tasks { get; set; }
        public ICollection<Dimension> Dimensions { get; set; }
        public ICollection<Key> Keys { get; set; }
        public ICollection<Value> Values { get; set; }
        public ICollection<Index> Indices { get; set; }
        public ICollection<Calculation> Calculations { get; set; }
    }
}
