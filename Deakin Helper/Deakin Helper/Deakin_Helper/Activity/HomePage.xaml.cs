using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ((App)App.Current).ResumeAtTodoId = -1;
            // Add item to listView
            listView.ItemsSource = App.Database.GetItems();
            // Get Number of items in database
            var allItem = App.Database.GetItems();
            int count = allItem.Count();
            // Change listview height corresponding to the number of items
            listViewStack.HeightRequest = count * 20;    
        }

        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}
