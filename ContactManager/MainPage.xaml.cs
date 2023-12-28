//Author Iliya Popov 12.12.2023
using System;
using Xamarin.Forms;

namespace ContactManager
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            fmenu.MenuListView.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            FMenuItem item = e.SelectedItem as FMenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TPage));
                fmenu.MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
