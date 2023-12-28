//Author Iliya Popov 12.12.2023
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogoutPage : ContentPage
    {
        public LogoutPage()
        {
            InitializeComponent();
        }

        private void ExitBtn_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}