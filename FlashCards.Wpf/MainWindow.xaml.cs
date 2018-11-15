using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlashCards.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var dataStore = new Data.SqliteDataStore("wpfFlashCards.db");
            dataStore.AddCard(new Types.Card("title", "fulltext", $"hint @ {DateTime.Now}"));
            var cards = dataStore.GetAllCards();
            System.Diagnostics.Debug.WriteLine($"I found {cards.Count()} cards!");
        }
    }
}
