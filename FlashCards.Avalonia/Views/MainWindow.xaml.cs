using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Windows.UI.Popups;

namespace FlashCards.Avalonia.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void myButton_Click(object sender, EventArgs e)
        {
            var msg = new MessageDialog("this is my message");
        }
    }
}
