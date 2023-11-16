using SQLite;

namespace PlantsBook.Models
{
    [Table("Schedule")]
    public class Schedule
    {
        [PrimaryKey, AutoIncrement]
        public int ScheduleId { get; set; }
        public int PlantId { get; set; }
        public string StartDate { get; set; }
        public string Periodicity { get; set; }
        public string Times { get; set; }
        public string Name { get; set; }
        public string NameImg { get; set; }
    }
}
