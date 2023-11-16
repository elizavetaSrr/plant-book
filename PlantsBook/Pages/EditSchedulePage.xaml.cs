using PlantsBook.Data;
using PlantsBook.Models;
using PlantsBook.Push;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantsBook.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditSchedulePage : ContentPage
    {
        public static PlantRepository repository = new PlantRepository();
        public int idSchedule;
        public string dateStart;
        public string period;
        public string times;
        public int idPlant;
        public double pushPeriod;
        public string namePlant;
        public EditSchedulePage(int id, string date, string period, string time, string name, int plant)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            namePlant = name;
            Title = "Полив " + name;
            idSchedule = id;
            idPlant = plant;
            dateStart = date;
            pickerDate.Date = DateTime.Parse(date);
            picker.SelectedItem = period;
            pushPeriod = Calculation.CalculationPeriodicity(picker.Items[picker.SelectedIndex], picker.Items);
            timePicker.Time = TimeSpan.Parse(time);

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            dateStart = e.NewDate.ToString("yyyy-MM-dd");
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            period = picker.Items[picker.SelectedIndex].ToString();
            pushPeriod = Calculation.CalculationPeriodicity(picker.Items[picker.SelectedIndex], picker.Items);
        }

        private void TimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            times = timePicker.Time.ToString();
        }
        private async void Edit_Clicked(object sender, EventArgs e)
        {
            Schedule schedule = new Schedule()
            {
                ScheduleId = idSchedule,
                PlantId = idPlant,
                StartDate = dateStart,
                Periodicity = period,
                Times = times
            };
            repository.UpdateSchedule(schedule);
            

            string date = dateStart + " " + times;
            PushNotificate.UpdateNotification(idSchedule, pushPeriod, DateTime.Parse(date), namePlant);

            await Navigation.PopAsync();

        }
    }
}