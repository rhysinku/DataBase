using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace DataBase
{
    public partial class App : Application
    {

        static SQLiteHelper db;
        public static SQLiteHelper SQLitedb
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database4.db3"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
