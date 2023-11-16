using PlantsBook.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace PlantsBook.Data
{
    public class PlantRepository
    {
        private readonly SQLiteConnection _database;
        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plants.db");
        public PlantRepository()
        {
            _database = new SQLiteConnection(DbPath);
            
            _database.CreateTables<Plants, Images>();
            _database.CreateTable<Schedule>();
        }
        public List<Plants> ListPlant()
        {
            return _database.Table<Plants>().ToList();
            
        }
        public List<Plants> ListPlantOne()
        {
            return _database.Query<Plants>($"SELECT * FROM Plants WHERE CategoryId = 1").ToList();

        }
        public List<Plants> ListPlantTwo()
        {
            return _database.Query<Plants>($"SELECT * FROM Plants WHERE CategoryId = 2").ToList();

        }
        public List<Plants> ListPlantThree()
        {
            return _database.Query<Plants>($"SELECT * FROM Plants WHERE CategoryId = 3").ToList();

        }
        public List<Plants> ListPlantFour()
        {
            return _database.Query<Plants>($"SELECT * FROM Plants WHERE CategoryId = 4").ToList();

        }
        public string GetNameImgById(int id)
        {
            var img = _database.Query<Images>($"SELECT * FROM Images WHERE ImageId = {id}");
            return img[0].NameImg;
        }
        public List<Plants> NameSearch(string result)
        {
            return _database.Query<Plants>($"SELECT * FROM Plants WHERE Name LIKE '%{result}%'").ToList();
        }
        
        public int PlantBoormarker(int id)
        {
            var book = _database.Get<Plants>(id).Bookmarker;
            return book;
        }
        
        public int InsertSchedule(Schedule schedule)
        {
            _database.Insert(schedule);
            return schedule.ScheduleId;
            
        }
        public List<Schedule> ScheduleList()
        {
            return _database.Table<Schedule>().ToList();

        }
        public string GetNameById(int id)
        {
            var name = _database.Query<Plants>($"SELECT * FROM Plants WHERE PlantId = {id}");
            return name[0].Name;
        }
        public void DeleteSchedule(int id)
        {
            _database.Query<Schedule>($"DELETE FROM Schedule WHERE ScheduleId = {id}");
        }
        public void UpdateSchedule(Schedule schedule) 
        { 
            _database.Update(schedule); 
        }
        public void UpdateTruePlants(int id)
        {
            _database.Query<Plants>($"UPDATE Plants SET Bookmarker = 1 WHERE PlantId = {id}");
        }
        public void UpdateFalsePlants(int id)
        {
            _database.Query<Plants>($"UPDATE Plants SET Bookmarker = 0 WHERE PlantId = {id}");
        }
        public List<Plants> ListBookmark()
        {
            return _database.Query<Plants>($"SELECT * FROM Plants WHERE Bookmarker = 1");
        }
        
        






    }
}
