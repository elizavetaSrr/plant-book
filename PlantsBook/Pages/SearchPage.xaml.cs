using PlantsBook.Data;
using PlantsBook.Models;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantsBook.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public static PlantRepository repository = new PlantRepository();
        public List<Plants> Plants { get; set; } = CreateItems.Plants;
        public int bookmark;

        public SearchPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);

            BindingContext = this;

        }
        protected override void OnAppearing()
        {
            BindingContext = this;
            base.OnAppearing();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            collPlants.ItemsSource = CreateItems.GetSearchResults(searchBar.Text);
        }

        private void CollPlants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(collPlants.SelectedItem != null)
            {
                collPlants.SelectedItem = null;
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