using PlantsBook.Data;
using System.Collections.Generic;

namespace PlantsBook.Models
{
    public static class CreateItems
    {
        public static PlantRepository repository = new PlantRepository();
        public static List<Plants> Plants = new List<Plants>();
        public static List<Schedule> Schedule = new List<Schedule>();

        public static List<Plants> CreatListCommon()
        {
            Plants = repository.ListPlant();
            foreach (var plant in Plants)
            {
                plant.NameImg = repository.GetNameImgById(plant.PlantId);
            }
            return Plants;
        }
        public static List<Plants> CreatListOne()
        {
            Plants = repository.ListPlantOne();
            foreach (var plant in Plants)
            {
                plant.NameImg = repository.GetNameImgById(plant.PlantId);
            }
            return Plants;
        }
        public static List<Plants> CreatListTwo()
        {
            Plants = repository.ListPlantTwo();
            foreach (var plant in Plants)
            {
                plant.NameImg = repository.GetNameImgById(plant.PlantId);
            }
            return Plants;
        }
        public static List<Plants> CreatListThree()
        {
            Plants = repository.ListPlantThree();
            foreach (var plant in Plants)
            {
                plant.NameImg = repository.GetNameImgById(plant.PlantId);
            }
            return Plants;
        }
        public static List<Plants> CreatListFour()
        {
            Plants = repository.ListPlantFour();
            foreach (var plant in Plants)
            {
                plant.NameImg = repository.GetNameImgById(plant.PlantId);
            }
            return Plants;
        }
        public static List<Plants> GetSearchResults(string result)
        {
            Plants = repository.NameSearch(result);
            foreach (var plant in Plants)
            {
                plant.NameImg = repository.GetNameImgById(plant.PlantId);
            }
            return Plants;
        }
        public static List<Schedule> CreateListSchedule()
        {
            Schedule = repository.ScheduleList();
            foreach(var schedule in Schedule)
            {
                schedule.Name = repository.GetNameById(schedule.PlantId);
                schedule.NameImg = repository.GetNameImgById(schedule.PlantId);

            }
            return Schedule;
        }
        public static List<Plants> CreateBookmarker()
        {
            Plants = repository.ListBookmark();
            foreach(var plant in Plants)
            {
                plant.NameImg = repository.GetNameImgById(plant.PlantId);

            }
            return Plants;
        }
    }
}
