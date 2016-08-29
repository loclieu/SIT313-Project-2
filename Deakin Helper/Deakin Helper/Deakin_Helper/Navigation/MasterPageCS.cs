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
                IconSource = "contacts.png",
                TargetType = typeof(HomePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Unit",
                IconSource = "todo.png",
                TargetType = typeof(HomePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Assignment",
                IconSource = "reminders.png",
                TargetType = typeof(HomePage)
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
