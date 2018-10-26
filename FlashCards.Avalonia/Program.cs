using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using FlashCards.Avalonia.ViewModels;
using FlashCards.Avalonia.Views;

namespace FlashCards.Avalonia
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAvaloniaApp().Start<MainWindow>(() => new MainWindowViewModel());
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .LogToDebug();
    }
}
