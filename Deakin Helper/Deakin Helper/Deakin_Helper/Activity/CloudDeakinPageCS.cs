using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Deakin_Helper
{
    public class CloudDeakinPageCS : ContentPage
    {
        public CloudDeakinPageCS()
        {
            Title = "Cloud Deakin";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Cloud Deakin data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}
