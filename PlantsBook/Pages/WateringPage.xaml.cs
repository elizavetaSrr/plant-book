using PlantsBook.Data;
using PlantsBook.Models;
using PlantsBook.Push;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantsBook.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WateringPage : ContentPage
    {
        public List<Schedule> Schedule { get; set; } = CreateItems.Schedule;
        public static PlantRepository repository = new PlantRepository();
        public WateringPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }
        protected override void OnAppearing()
        {
            
            Schedule = CreateItems.CreateListSchedule();
            CollSchedule.ItemsSource = Schedule;
            
            BindingContext = this;
            base.OnAppearing();

        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.ImageButton imageBut = (Xamarin.Forms.ImageButton)sender;
            var item = (Schedule)imageBut.BindingContext;
            int id = item.ScheduleId;
            repository.DeleteSchedule(item.ScheduleId);
            CollSchedule.ItemsSource = CreateItems.CreateListSchedule();
            int[] push = {id};
            PushNotificate.DeleteNotification(push);
        }

        private async void AddPlant_Clicked(object sender, EventArgs e)
        {
            CreateItems.CreatListCommon();
            await Navigation.PushAsync(new SearchPage());
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.Button button = (Xamarin.Forms.Button)sender;
            var item = (Schedule)button.BindingContext;
            int id = item.ScheduleId;
            string dateStart = item.StartDate;
            string period = item.Periodicity;
            string time = item.Times;
            string name = item.Name;
            int idPlant = item.PlantId;
            await Navigation.PushAsync(new EditSchedulePage(id, dateStart, period, time, name, idPlant));

        }
    }
}