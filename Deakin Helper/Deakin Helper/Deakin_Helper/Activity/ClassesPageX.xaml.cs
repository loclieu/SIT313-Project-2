using System;
using System.Collections.Generic;
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
            dateEntry.SetValue(DatePicker.DateProperty, DateTime.Now);
            NavigationPage.SetHasNavigationBar(this, true);
        }
        void saveClicked(object sender, EventArgs e)
        {
            var todoItem = (Classes)BindingContext;
            App.Database.SaveItem(todoItem);
            this.Navigation.PopAsync();
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
