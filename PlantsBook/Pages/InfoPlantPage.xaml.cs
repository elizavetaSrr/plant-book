using PlantsBook.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantsBook.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPlantPage : ContentPage
    {
        public int idPlant;
        public string namePlant;
        public static PlantRepository repository = new PlantRepository();
        public int bookmark;
        public InfoPlantPage(string name, string img, string light, string water, string soil, string fertilizer, string transfer, int id, int bookmarker)
        {
            InitializeComponent();
            bookmark = bookmarker;
            nameLabel.Text = name;
            plantImage.Source = img;
            lightLabel.Text = light;
            waterLabel.Text = water;
            soilLabel.Text = soil;
            fertilizerLabel.Text = fertilizer;
            transferLabel.Text = transfer;
            idPlant = id;
            namePlant = name;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (bookmark == 0)
            {
                Star.Source = "starUn.png";
            }
            else if (bookmark != 0)
            {
                Star.Source = "starSel.png";
            }

            
        }
        private async void SettingSchedule_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScheduleSettingPage(idPlant, namePlant));
        }

        private void Bookmarker_Clicked(object sender, EventArgs e)
        {
            if (bookmark == 0)
            {
                repository.UpdateTruePlants(idPlant);
                Star.Source = "starSel.png";
                bookmark = 1;
            }
            else if (bookmark == 1)
            {
                repository.UpdateFalsePlants(idPlant);
                Star.Source = "starUn.png";
                bookmark = 0;
            }
            
        }
    }
}