using PlantsBook.Data;
using PlantsBook.Models;
using PlantsBook.Push;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantsBook.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleSettingPage : ContentPage
    {
        public static PlantRepository repository = new PlantRepository();
        public int idPlant;
        public string namePlant;
        public string dateStart = DateTime.Now.ToString("yyyy-MM-dd");
        public string period = null;
        public string time;
        public double pushPeriod;
        public ScheduleSettingPage(int id, string name)
        {
            InitializeComponent();
            idPlant = id;
            namePlant = name;
            saveBut.IsEnabled = false;
        }
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
           dateStart = e.NewDate.ToString("yyyy-MM-dd");
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            period = picker.Items[picker.SelectedIndex].ToString();
            saveBut.IsEnabled = true;
            pushPeriod = Calculation.CalculationPeriodicity(picker.Items[picker.SelectedIndex], picker.Items);
            
        }

        private void TimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            time = timePicker.Time.ToString();
        }
        private async void Save_Clicked(object sender, EventArgs e)
        {
            Schedule schedule = new Schedule()
            {
                PlantId = idPlant,
                StartDate = dateStart,
                Periodicity = period,
                Times = time
            };

            int idPush = repository.InsertSchedule(schedule);
            string date = dateStart + " " + time;
            PushNotificate.CreateNotification(idPush, namePlant, DateTime.Parse(date), pushPeriod);

            await Navigation.PopAsync();

        }
    }
}