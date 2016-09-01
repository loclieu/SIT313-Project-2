using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Deakin_Helper
{
   public class SettingPageCS : ContentPage
    {
        public SettingPageCS()
        {
            Title = "Settings";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Settings data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}
