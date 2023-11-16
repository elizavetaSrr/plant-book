using PlantsBook.Data;
using PlantsBook.Models;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantsBook.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookmarkerPage : ContentPage
	{
        public static PlantRepository repository = new PlantRepository();
        public List<Plants> Bookmarker { get; set; } = CreateItems.Plants;
        public int bookmark;
        public BookmarkerPage()
		{

			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            Bookmarker = CreateItems.CreateBookmarker();
            CollBookmarker.ItemsSource = Bookmarker;
            BindingContext = this;
            base.OnAppearing();

        }

        private void CollBookmarker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CollBookmarker.SelectedItem != null)
            {
                CollBookmarker.SelectedItem = null;
                string name = (e.CurrentSelection.FirstOrDefault() as Plants)?.Name;
                string img = (e.CurrentSelection.FirstOrDefault() as Plants)?.NameImg;
                string light = (e.CurrentSelection.FirstOrDefault() as Plants)?.Light;
                string water = (e.CurrentSelection.FirstOrDefault() as Plants)?.Watering;
                string soil = (e.CurrentSelection.FirstOrDefault() as Plants)?.Soil;
                string fertilizer = (e.CurrentSelection.FirstOrDefault() as Plants)?.Fertilizer;
                string transfer = (e.CurrentSelection.FirstOrDefault() as Plants)?.Transfer;
                int id = (e.CurrentSelection.FirstOrDefault() as Plants).PlantId;
                bookmark = repository.PlantBoormarker(id);
                Navigation.PushAsync(new InfoPlantPage(name, img, light, water, soil, fertilizer, transfer, id, bookmark));

            }
        }
    }
}