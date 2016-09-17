using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace Deakin_Helper
{
    public class App : Application
    {
        // Create Database
        static ClassesDatabase database;
        static AssignmentDatabase assignmentdb;

        public App()
        {
            // The root page of your application
            MainPage = new MainPage();

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

        // Create database if it doesn't exist
        public static AssignmentDatabase AssignmentDB
        {
            get
            {
                if (assignmentdb == null)
                {
                    assignmentdb = new AssignmentDatabase();
                }
                return assignmentdb;
            }
        }

        public int ResumeAtClassesId { get; set; }
        public int ResumeAtAssignmentId { get; set; }

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
            Debug.WriteLine("OnSleep saving ResumeAtClassesId = " + ResumeAtClassesId);
            Debug.WriteLine("OnSleep saving ResumeAtClassesId = " + ResumeAtAssignmentId);
            // the app should keep updating this value, to
            // keep the "state" in case of a sleep/resume
            Properties["ResumeAtClassesId"] = ResumeAtClassesId;
            Properties["ResumeAtAssignmentId"] = ResumeAtAssignmentId;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Debug.WriteLine("OnResume");
        }
    }
}
