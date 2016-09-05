using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Deakin_Helper
{
    public partial class TodoItemPageX : ContentPage
    {
        public TodoItemPageX()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);

        }
        void saveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            App.Database.SaveItem(todoItem);
            this.Navigation.PopAsync();
        }

        void deleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            App.Database.DeleteItem(todoItem.ID);
            this.Navigation.PopAsync();
        }

        void cancelClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            this.Navigation.PopAsync();
        }

        void speakClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
        }
    }
}
