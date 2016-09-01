using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Deakin_Helper
{
    class AssignmentPageCS : ContentPage
    {
        public AssignmentPageCS()
        {
            Title = "Assignment";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Assignment data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}
