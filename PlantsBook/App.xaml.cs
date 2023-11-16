using PlantsBook.Data;
using PlantsBook.Pages;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantsBook
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            // TODO Only do this when app first run
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("PlantsBook.Database.plants.db"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    
                    if (!File.Exists(PlantRepository.DbPath))
                    {
                        File.WriteAllBytes(PlantRepository.DbPath, memoryStream.ToArray());
                    }
                }
            }



        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
