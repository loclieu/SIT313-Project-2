using System.Collections.Generic;
using Xamarin.Forms;

namespace Deakin_Helper
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Home",
                IconSource = "icon_home.png",
                TargetType = typeof(HomePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Classes",
                IconSource = "icon_classes.png",
                 TargetType = typeof(ClassesPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Assignment",
                IconSource = "icon_assignments.png",
                TargetType = typeof(AssignmentPage)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Cloud Deakin",
                IconSource = "icon_cloud.png",
                TargetType = typeof(CloudDeakinPage)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Settings",
                IconSource = "icon_settings.png",
                TargetType = typeof(SettingPage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
