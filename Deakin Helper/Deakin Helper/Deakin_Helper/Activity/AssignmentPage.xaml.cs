using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Deakin_Helper
{
    public partial class AssignmentPage : ContentPage
    {
        public AssignmentPage()
        {
            InitializeComponent();
            // Toolbar for each of OS running
            #region toolbar
            ToolbarItem tbi = null;
            if (Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                {
                    var assignmentItem = new Assignment();
                    var assignmentPage = new AssignmentPageX();
                    assignmentPage.BindingContext = assignmentItem;
                    Navigation.PushAsync(assignmentPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("+", "icon_addClasses", () =>
                {
                    var assignmentItem = new Assignment();
                    var assignmentPage = new AssignmentPageX();
                    assignmentPage.BindingContext = assignmentItem;
                    Navigation.PushAsync(assignmentPage);
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
            ((App)App.Current).ResumeAtAssignmentId = -1;
            listView.ItemsSource = App.AssignmentDB.GetItems();
        }

        // Selecting Items of the listview
        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var AssignmentItem = (Assignment)e.SelectedItem;
            var assignmentPage = new AssignmentPageX();
            assignmentPage.BindingContext = AssignmentItem;

            ((App)App.Current).ResumeAtAssignmentId = AssignmentItem.ID;
            Debug.WriteLine("setting ResumeAtAssignmentId = " + AssignmentItem.ID);

            Navigation.PushAsync(assignmentPage);
        }
    }
}
