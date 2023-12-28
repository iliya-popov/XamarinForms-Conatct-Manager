using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactManager.MVC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContacts : ContentPage
    {
        public AddContacts()
        {
            InitializeComponent();
        }
        private DbCitizensModelTbl citizens;
        public AddContacts(DbCitizensModelTbl contactsModel)
        {
            InitializeComponent();
            Title = "Редактиране";
            citizens = contactsModel;
            this.NamesEntry.Text = contactsModel.Names;
            this.PhoneNumber.Text = contactsModel.Phone;
            this.Address.Text = contactsModel.Address;
            this.NamesEntry.Focus();
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.NamesEntry.Text) || string.IsNullOrWhiteSpace(this.PhoneNumber.Text))
            {
                await DisplayAlert("Празни полета", "Моля попълнете празните полета", "ОК");
            }
            else if (citizens != null)
            {
                UpdateContacts();
            }
            else
            {
                InsertContacts();
            }
        }

        async void UpdateContacts()
        {
            citizens.Names = this.NamesEntry.Text;
            citizens.Phone = this.PhoneNumber.Text;
            citizens.Address = this.Address.Text;
            await App.CDataBase.UpdateCitizensData(citizens);
            await this.Navigation.PopAsync();
        }

        async void InsertContacts()
        {
            await App.CDataBase.InsertCitizensData(new ContactManager.MVC.DbCitizensModelTbl
            {
                Names = NamesEntry.Text,
                Phone = PhoneNumber.Text,
                Address = Address.Text
            });
            await Navigation.PopAsync();
        }
    }
}