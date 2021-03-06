﻿using System;
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

            // Separate entries
            listView.SeparatorVisibility = SeparatorVisibility.Default;
            listView.SeparatorColor = Color.FromHex("C8C7CC");
            assignmentListView.SeparatorVisibility = SeparatorVisibility.Default;
            assignmentListView.SeparatorColor = Color.FromHex("C8C7CC");

            DateTime today = DateTime.Today;          
            DateTime dueSoon = DateTime.Today.AddDays(7); 

            //string day = today.DayOfWeek.ToString();


            // reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtClassesId = -1;
            ((App)App.Current).ResumeAtAssignmentId = -1;
            ((App)App.Current).ResumeAtSettingsId = -1;

            // Add item to listView
            listView.ItemsSource = App.Database.GetTodayClass(today);
            assignmentListView.ItemsSource = App.AssignmentDB.GetTodayAssignment(today, dueSoon);
            settingsListView.ItemsSource = App.SettingsDB.GetItems();

            // Get Number of items in database to show
            var todaysClassesItem = App.Database.GetTodayClass(today);
            int classesCount = todaysClassesItem.Count();

            var dueAssignmentItem = App.AssignmentDB.GetTodayAssignment(today, dueSoon);
            int AssignmentCount = dueAssignmentItem.Count();

            var allSettingsItem = App.SettingsDB.GetItems();
            int SettingsCount = allSettingsItem.Count();

            // Change listview height corresponding to the number of items
            listViewStack.HeightRequest = classesCount * 51;
            assignmentStackView.HeightRequest = AssignmentCount * 51;
            settingsStackView.HeightRequest = SettingsCount * 51;
        }

        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null) return;
            // do something with e.SelectedItem
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        void AssignmentItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null) return;
            // do something with e.SelectedItem
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        void SettingsItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null) return;
            // do something with e.SelectedItem
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
