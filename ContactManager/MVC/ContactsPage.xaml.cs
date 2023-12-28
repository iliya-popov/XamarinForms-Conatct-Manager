//Author Iliya Popov 12.12.2023
using ContactManager.MVC;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                this.ContactsView.ItemsSource = await App.CDataBase.ReadCitizensTbl();
            }
            catch
            {
                await DisplayAlert("Грешка", "В базата данни няма записи", "ОК");
            }
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new AddContacts());
        }
        async void Edit_SwipeItem_Invoked(object sender, EventArgs e)
        {
            var s = sender as SwipeItem;
            var citizens = s.CommandParameter as DbCitizensModelTbl;
            await this.Navigation.PushAsync(new AddContacts(citizens));
        }

        async void Del_SwipeItem_Invoked(object sender, EventArgs e)
        {
            var s = sender as SwipeItem;
            var citizens = s.CommandParameter as DbCitizensModelTbl;
            var dialogResult = await DisplayAlert("Премахни", $"Потвърждавате ли {citizens.Names} да бъде премахнат окончателно", "Да", "Не");
            if (dialogResult)
            {
                await App.CDataBase.DeleteCitizensData(citizens);
                this.ContactsView.ItemsSource = await App.CDataBase.ReadCitizensTbl();
            }
        }

        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ContactsView.ItemsSource = await App.CDataBase.SearchCitizensData(e.NewTextValue);
        }
    }
}