﻿using System;
using Xamarin.Forms;

namespace Deakin_Helper
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;

            if (Device.OS == TargetPlatform.Windows)
            {
                Master.Icon = "swap.png";
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}