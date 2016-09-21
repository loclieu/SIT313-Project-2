using System;
using Xamarin.Forms;

namespace Deakin_Helper
{
    public partial class SettingPageX : ContentPage
    {
        public SettingPageX()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);

        }
        void saveClicked(object sender, EventArgs e)
        {
            var settingsItem = (Settings)BindingContext;

            if (fullNameEntry.Text == null)
            {
                DisplayAlert("Error", "Name is Empty", "OK");
            }
            else if (emailEntry.Text == null)
            {
                DisplayAlert("Error", "Email is Empty", "OK");
            }
            else if (studentIDEntry.Text == null)
            {
                DisplayAlert("Error", "StudentID is Empty", "OK");
            }
            else
            {
                App.SettingsDB.SaveItem(settingsItem);
                this.Navigation.PopAsync();
            }
        }

        void deleteClicked(object sender, EventArgs e)
        {
            var settingsItem = (Settings)BindingContext;
            App.SettingsDB.DeleteItem(settingsItem.ID);
            this.Navigation.PopAsync();
        }

        void cancelClicked(object sender, EventArgs e)
        {
            var setttingsItem = (Settings)BindingContext;
            this.Navigation.PopAsync();
        }
    }
}
