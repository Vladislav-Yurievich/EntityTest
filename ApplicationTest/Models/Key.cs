using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Models
{
    public class Key // Ключ
    {
        public int ID { get; set; }
        public int Data { get; set; }
        public int DimensionID { get; set; }
        public int ModelID { get; set; }
        public Dimension Dimension { get; set; }
        public Model Model { get; set; }
        public int ValueID { get; set; }
        public Value Value { get; set; }
    }
}
