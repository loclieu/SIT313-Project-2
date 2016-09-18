using System;

using Xamarin.Forms;

namespace Deakin_Helper
{
    public partial class CloudDeakinPage : ContentPage
    {
        public CloudDeakinPage()
        {
            InitializeComponent();

            // Set Deakin URL
            webview.Source = "https://sync.deakin.edu.au/";

        }

        private void backClicked(object sender, EventArgs e)
        {
            // Check to see if there is anywhere to go back to
            if (webview.CanGoBack)
            {
                webview.GoBack();
            }
            else { // If not, leave the view
                Navigation.PopToRootAsync();
            }
        }

        private void forwardClicked(object sender, EventArgs e)
        {
            if (webview.CanGoForward)
            {
                webview.GoForward();
            }
        }
    }
}
