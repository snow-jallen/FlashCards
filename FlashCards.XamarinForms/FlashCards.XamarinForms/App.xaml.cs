using FlashCards.Data;
using FlashCards.Types;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FlashCards.XamarinForms
{
    public partial class App : Application
    {
        IDataStore dataStore;
        public App(INavigationService navigationService)
        {
            InitializeComponent();

            string dbPath = null;
            string dbName = "flashcards.db";
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
                    break;
                case Device.iOS:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", dbName);
                    SQLitePCL.Batteries_V2.Init();
                    break;
                default:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);
                    break;
            }
            dataStore = new SqliteDataStore(dbPath);
            
            MainPage = new MainPage(new MainPageViewModel(dataStore, navigationService));
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public interface INavigationService
    {
        Task<String> ShowPopupAsync(string prompt);
    }    
}
