﻿using System;
using Xamarin.Forms;

namespace Deakin_Helper
{
    public partial class AssignmentPageX : ContentPage
    {
        public AssignmentPageX()
        {
            InitializeComponent();
            dateEntry.SetValue(DatePicker.MinimumDateProperty, DateTime.Now.AddDays(-1));
            NavigationPage.SetHasNavigationBar(this, true);

        }
        void saveClicked(object sender, EventArgs e)
        {
            var assignmentItem = (Assignment)BindingContext;

            if (unitCodeEntry.Text == null)
            {
                DisplayAlert("Error", "Unit Code is Empty", "OK");
            }
            else if (unitNameEntry.Text == null)
            {
                DisplayAlert("Error", "Unit Name is Empty", "OK");
            }
            else if (assignmentNameEntry.Text == null)
            {
                DisplayAlert("Error", "Assignment Name is Empty", "OK");
            }
            else
            {
                App.AssignmentDB.SaveItem(assignmentItem);
                this.Navigation.PopAsync();
            }
        }

        void deleteClicked(object sender, EventArgs e)
        {
            var assignmentItem = (Assignment)BindingContext;
            App.AssignmentDB.DeleteItem(assignmentItem.ID);
            this.Navigation.PopAsync();
        }

        void cancelClicked(object sender, EventArgs e)
        {
            var assignmentItem = (Assignment)BindingContext;
            this.Navigation.PopAsync();
        }
    }
}
