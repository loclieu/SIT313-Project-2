using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Deakin_Helper
{
    public partial class ClassesPageX : ContentPage
    {
 
        public ClassesPageX()
        {
            InitializeComponent();

            dateEntry.SetValue(DatePicker.MinimumDateProperty, DateTime.Now.AddDays(-1));
            //dateEntry.SetValue(DatePicker.DateProperty, DateTime.Now);
            
            NavigationPage.SetHasNavigationBar(this, true);         
            
        }
      
        void saveClicked(object sender, EventArgs e)
        {
            var todoItem = (Classes)BindingContext;
            if (unitCodeEntry.Text == null)
            {
                DisplayAlert("Error", "Unit Code is Empty", "OK");
            }
            else if (unitNameEntry.Text == null)
            {
                DisplayAlert("Error", "Unit Name is Empty", "OK");
            }
            else if (roomNumberEntry.Text == null)
            {
                DisplayAlert("Error", "Room Number is Empty", "OK");
            }
            else if (classTypeEntry.Text == null)
            {
                DisplayAlert("Error", "Class Type is Empty", "OK");
            }
            else
            {          
            App.Database.SaveItem(todoItem);
            this.Navigation.PopAsync(); 
            }

         
             

        }

        void deleteClicked(object sender, EventArgs e)
        {
            var todoItem = (Classes)BindingContext;
            App.Database.DeleteItem(todoItem.ID);
            this.Navigation.PopAsync();
        }

        void cancelClicked(object sender, EventArgs e)
        {
            var todoItem = (Classes)BindingContext;
            this.Navigation.PopAsync();
        }
    }

   
}
