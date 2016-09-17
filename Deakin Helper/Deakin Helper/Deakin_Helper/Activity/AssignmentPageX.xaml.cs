using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Deakin_Helper
{
    public partial class AssignmentPageX : ContentPage
    {
        public AssignmentPageX()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);

        }
        void saveClicked(object sender, EventArgs e)
        {
            var assignmentItem = (Assignment)BindingContext;
            App.AssignmentDB.SaveItem(assignmentItem);
            this.Navigation.PopAsync();
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
