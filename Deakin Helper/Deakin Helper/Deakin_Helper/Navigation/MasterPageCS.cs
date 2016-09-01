using System.Collections.Generic;
using Xamarin.Forms;

namespace Deakin_Helper
{
    public class MasterPageCS : ContentPage
    {
        public ListView ListView { get { return listView; } }

        ListView listView;

        public MasterPageCS()
        {
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Home",
                IconSource = "icon_home.png",
                TargetType = typeof(HomePageCS)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Classes",
                IconSource = "icon_classes.png",
                TargetType = typeof(ClassesPageCS)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Assignment",
                IconSource = "icon_assignments.png",
                TargetType = typeof(AssignmentPageCS)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Cloud Deakin",
                IconSource = "icon_cloud.png",
                TargetType = typeof(CloudDeakinPageCS)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Settings",
                IconSource = "icon_settings.png",
                TargetType = typeof(SettingPageCS)
            });


            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() => {
                    var imageCell = new ImageCell();
                    imageCell.SetBinding(TextCell.TextProperty, "Title");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
                    return imageCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };

            Padding = new Thickness(0, 40, 0, 0);
            Icon = "hamburger.png";
            Title = "Personal Organiser";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    listView
                }
            };
        }
    }
}
