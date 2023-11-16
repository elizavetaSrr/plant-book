using SQLite;


namespace PlantsBook.Models
{
    [Table("Plants")]
    public class Plants
    {
        [PrimaryKey, AutoIncrement]
        public int PlantId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Light { get; set; }
        public string Watering { get; set; }
        public string Soil { get; set; }
        public string Fertilizer { get; set; }
        public string Transfer { get; set; }
        public string NameImg { get; set; }
        public int Bookmarker { get; set; }
    }
}
