//Author Iliya Popov 12.12.2023
using System;
using Xamarin.Forms;
using System.IO;
using ContactManager.MVC;

[assembly: ExportFont("IndieFlower.ttf", Alias = "Flower")]

namespace ContactManager
{
    public partial class App : Application
    {
        private static DbControler dbcontroler;
        public static DbControler CDataBase
        {
            get
            {
                if (dbcontroler == null)
                {
                    dbcontroler = new DbControler(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ContactsМ.db3"));
                }
                return dbcontroler;
            }
        }
        public App()
        {
            InitializeComponent();
            //Add custom code
            MainPage = new ContactManager.MainPage(); ;
        }

        protected override void OnStart()
        {
            //To do
        }

        protected override void OnSleep()
        {
            //To do
        }

        protected override void OnResume()
        {
            //To do
        }
    }
}
