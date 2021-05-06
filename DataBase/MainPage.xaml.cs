using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataBase
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            // get all person
            var personList = await App.SQLitedb.GetItemsAsync();
            if (personList != null)
            {
                lstPersons.ItemsSource = personList;
            }
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Person person = new Person()
                {
                    Name = txtName.Text
                };
                await App.SQLitedb.SaveItemAsync(person);
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person added Successfully", "OK");
                //Get All Persons  
                var personList = await App.SQLitedb.GetItemsAsync();
                if (personList != null)
                {
                    lstPersons.ItemsSource = personList;
                }
            }
            else
            {
                await DisplayAlert("Error", "Input Name", "Ok");
            }
            }
        
        private async void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                //get person
                var person = await App.SQLitedb.GetItemAsync(Convert.ToInt32(txtPersonId.Text));
                if (person != null)
                {
                    txtName.Text = person.Name;
                    await DisplayAlert("Success", "Person Name: " + person.Name, "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please Enter ID", "OK");
            }
        }
        
        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                Person person = new Person()
                {
                    PersonID = Convert.ToInt32(txtPersonId.Text),
                    Name = txtName.Text
                };
                // update
                await App.SQLitedb.SaveItemAsync(person);

                txtPersonId.Text = string.Empty;
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person Updated", "OK");
                //get person
            }
            var personlist = await App.SQLitedb.GetItemsAsync();
            if (personlist != null)
            {
                lstPersons.ItemsSource = personlist;
            }
            else
            {
                await DisplayAlert("Error", "Input Person ID", "OK");
            }
          
        }

        private async void BtnDelete_Clicked (object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                //person
                var delete = await App.SQLitedb.GetItemAsync(Convert.ToInt32(txtPersonId.Text));
                if (delete != null)
                {
                    await App.SQLitedb.DeleteItemAsync(delete);
                    txtPersonId.Text = string.Empty;
                    await DisplayAlert("Success", "Person Deleted", "OK");

                    var displaylist = await App.SQLitedb.GetItemsAsync();
                    if (displaylist != null)
                    {
                        lstPersons.ItemsSource = displaylist;
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "Please Enter", "OK");
            }
        }

        private async void BtnDeleteAll_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Warning", "Are you sure to delete", "OK" ,"Cancel");
            if (result == true)
            {
                await App.SQLitedb.DeleteAll<Person>();
                var display = await App.SQLitedb.GetItemsAsync();
                if (display != null)
                {
                    lstPersons.ItemsSource = display;
                }
            }   
            else
            {
                var display = await App.SQLitedb.GetItemsAsync();
                if (display != null)
                {
                    lstPersons.ItemsSource = display;
                }
            }
        }


    }
}
