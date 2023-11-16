using PlantsBook.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantsBook.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoriesPage : ContentPage
	{
        
        public CategoriesPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private async void Search_Clicked(object sender, EventArgs e)
        {
            CreateItems.CreatListCommon();
            await Navigation.PushAsync(new SearchPage());
            

        }
        private void CategoryOne_Clicked(object sender, EventArgs e)
        {
            CreateItems.CreatListOne();
            Navigation.PushAsync(new SearchPage());
        }
        private void CategoryTwo_Clicked(object sender, EventArgs e)
        {
            CreateItems.CreatListTwo();
            Navigation.PushAsync(new SearchPage());
        }
        private void CategoryThree_Clicked(object sender, EventArgs e)
        {
            CreateItems.CreatListThree();
            Navigation.PushAsync(new SearchPage());
        }
        private void CategoryFour_Clicked(object sender, EventArgs e)
        {
            CreateItems.CreatListFour();
            Navigation.PushAsync(new SearchPage());
        }


    }
}