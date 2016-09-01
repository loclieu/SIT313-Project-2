using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Deakin_Helper
{
    public class ClassesPageCS : ContentPage
    {
        public ClassesPageCS()
        {
            Title = "Classes";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Classes data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}
