using System;

using Xamarin.Forms;

namespace Deakin_Helper.Activity
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
            var todoItem = (Settings)BindingContext;
            App.Database_Settings.SaveItem(todoItem);
            this.Navigation.PopAsync();
        }

        void deleteClicked(object sender, EventArgs e)
        {
            var todoItem = (Settings)BindingContext;
            App.Database_Settings.DeleteItem(todoItem.ID);
            this.Navigation.PopAsync();
        }

        void cancelClicked(object sender, EventArgs e)
        {
            var todoItem = (Settings)BindingContext;
            this.Navigation.PopAsync();
        }
    }
}
