using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pets
{
    public partial class App : Application
    {

        private static string URL = "https://mascota-app.onrender.com/";

        private static string TOKEN_FIRMA = "09d25e094faa6ca2556c818166b7a9563b93f7099f6f0f4caa6cf63b88e8d3e7";

        public static string TOKEN;

        

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage( new Login(URL , TOKEN_FIRMA));
            MainPage = new NavigationPage(new Solicitud());
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
