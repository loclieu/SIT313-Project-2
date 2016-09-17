using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace Deakin_Helper
{
    public partial class ClassesPage : ContentPage
    {
        public ClassesPage()
        {
            InitializeComponent();

            // Toolbar for each of OS running
            #region toolbar
            ToolbarItem tbi = null;
            if (Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                {
                    var todoItem = new Classes();
                    var todoPage = new ClassesPageX();
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("+", "Add", () =>
                {
                    var todoItem = new Classes();
                    var todoPage = new ClassesPageX();
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
            ((App)App.Current).ResumeAtClassesId = -1;
            listView.ItemsSource = App.Database.GetItems();
        }

        // Selecting Items of the listview
        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var ClassesItem = (Classes)e.SelectedItem;
            var classPage = new ClassesPageX();
            classPage.BindingContext = ClassesItem;

            ((App)App.Current).ResumeAtClassesId = ClassesItem.ID;
            Debug.WriteLine("setting ResumeAtClassesId = " + ClassesItem.ID);

            Navigation.PushAsync(classPage);
        }
    }
}
