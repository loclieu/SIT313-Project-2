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
                IconSource = "contacts.png",
                TargetType = typeof(ContactsPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Unit",
                IconSource = "todo.png",
                 TargetType = typeof(HomePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Assginment",
                IconSource = "reminders.png",
                TargetType = typeof(HomePage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
