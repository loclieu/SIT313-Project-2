using System;
using System.Linq;

using Xamarin.Forms;

namespace Deakin_Helper
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DateTime today = DateTime.Today;
            string day = today.DayOfWeek.ToString();

            // reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtClassesId = -1;
            ((App)App.Current).ResumeAtAssignmentId = -1;
            ((App)App.Current).ResumeAtSettingsId = -1;

            // Add item to listView
            listView.ItemsSource = App.Database.GetItems();
            assignmentListView.ItemsSource = App.AssignmentDB.GetItems();
            settingsListView.ItemsSource = App.SettingsDB.GetItems();

            // Get Number of items in database
            var allClassesItem = App.Database.GetItems();
            int classesCount = allClassesItem.Count();

            var allAssignmentItem = App.AssignmentDB.GetItems();
            int AssignmentCount = allAssignmentItem.Count();

            var allSettingsItem = App.SettingsDB.GetItems();
            int SettingsCount = allSettingsItem.Count();

            // Change listview height corresponding to the number of items
            listViewStack.HeightRequest = classesCount * 50;
            assignmentStackView.HeightRequest = AssignmentCount * 50;
            settingsStackView.HeightRequest = SettingsCount * 50;
        }

        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        void AssignmentItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        void SettingsItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
