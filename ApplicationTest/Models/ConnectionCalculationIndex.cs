
namespace ApplicationTest.Models
{
    public class ConnectionCalculationIndex // Связь_Расчёт_Показатель
    {
        public int ID { get; set; }
        public int IndexID { get; set; }
        public int CalculationID { get; set; }
        public string TypeIndex { get; set; }
        public Index Index { get; set; }
        public Calculation Calculation { get; set; }
    }
}
