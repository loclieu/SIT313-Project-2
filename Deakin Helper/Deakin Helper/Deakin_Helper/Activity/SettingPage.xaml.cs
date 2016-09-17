using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace Deakin_Helper
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();

            // Toolbar for each of OS running
            #region toolbar
            ToolbarItem tbi = null;
            if (Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                {
                    var todoItem = new Settings();
                    var todoPage = new SettingPageX();
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("+", "plus", () =>
                {
                    var todoItem = new Settings();
                    var todoPage = new SettingPageX();
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                tbi = new ToolbarItem("Add", "add.png", () =>
                {
                    var todoItem = new TodoItem();
                    var todoPage = new TodoItemPageX();
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                }, 0, 0);
            }

            ToolbarItems.Add(tbi);


            #endregion
        }
        // Load the listview of data from database
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = App.Database_Settings.GetItems();
        }

        // Selecting Items of the listview
        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var SettingsItem = (Settings)e.SelectedItem;
            var settingsPage = new SettingPageX();
            settingsPage.BindingContext = SettingsItem;

            ((App)App.Current).ResumeAtTodoId = SettingsItem.ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + SettingsItem.ID);

            Navigation.PushAsync(settingsPage);
        }
    }
}
