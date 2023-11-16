using SQLite;

namespace PlantsBook.Models
{
    [Table("Images")]
    public class Images
    {
        [PrimaryKey, AutoIncrement]
        public int ImageId { get; set; }
        public string NameImg { get; set; }
        public int PlantId { get; set; }
        
    }
}
