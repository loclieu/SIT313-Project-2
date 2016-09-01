using Xamarin.Forms;


namespace Deakin_Helper
{
    public class HomePageCS : ContentPage
    {
        public HomePageCS()
        {
            Title = "Home";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Home Page data goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}
