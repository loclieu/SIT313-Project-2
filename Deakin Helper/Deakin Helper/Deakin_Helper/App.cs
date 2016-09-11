using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace Deakin_Helper
{
    public class App : Application
    {
        // Create Database
        static ClassesDatabase database;
        public App()
        {
            // The root page of your application
            MainPage = new MainPage();

            // Set colours (not working)
            MainPage.SetValue(VisualElement.BackgroundColorProperty, Color.Purple);

        }
        // Create database if it doesn't exist
        public static ClassesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ClassesDatabase();
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
            Debug.WriteLine("OnStart");

            // always re-set when the app starts
            // users expect this (usually)
            //			Properties ["ResumeAtTodoId"] = "";
            /*
            if (Properties.ContainsKey("ResumeAtTodoId"))
            {
                var rati = Properties["ResumeAtTodoId"].ToString();
                Debug.WriteLine("   rati=" + rati);
                if (!String.IsNullOrEmpty(rati))
                {
                    Debug.WriteLine("   rati = " + rati);
                    ResumeAtTodoId = int.Parse(rati);

                    if (ResumeAtTodoId >= 0)
                    {
                        var todoPage = new ClassesPageX();
                        todoPage.BindingContext = Database.GetItem(ResumeAtTodoId);

                        MainPage.Navigation.PushAsync(
                            todoPage,
                            false); // no animation
                    }
                }
            }*/
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Debug.WriteLine("OnSleep saving ResumeAtTodoId = " + ResumeAtTodoId);
            // the app should keep updating this value, to
            // keep the "state" in case of a sleep/resume
            Properties["ResumeAtTodoId"] = ResumeAtTodoId;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Debug.WriteLine("OnResume");
        }
    }
}
