using System;
using Xamarin.Forms;
using System.Diagnostics;
using SQLite;
using System.Linq;

namespace Deakin_Helper
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();

        }
        
        // Load the listview of data from database
        protected override void OnAppearing()
        {
            base.OnAppearing();


            // Clear toolbar items
            ToolbarItems.Clear();

            // Make sure user can't add 2 users
            if (DataCount() == 0)
            {
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
                    tbi = new ToolbarItem("+", "Add", () =>
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

            // reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtSettingsId = -1;

            listView.ItemsSource = App.SettingsDB.GetItems();
        }

        // Selecting Items of the listview
        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var SettingsItem = (Settings)e.SelectedItem;
            var settingsPage = new SettingPageX();
            settingsPage.BindingContext = SettingsItem;

            ((App)App.Current).ResumeAtSettingsId = SettingsItem.ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + SettingsItem.ID);

            Navigation.PushAsync(settingsPage);
        }


        // Returns number of rows in table
        protected int DataCount()
        {
            SQLiteConnection db = DependencyService.Get<ISQLite>().GetConnection();

            var allItems = db.Table<Settings>().ToList();
            int count = allItems.Count();
            return count;
        }
    }
}
