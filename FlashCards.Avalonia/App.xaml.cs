using Avalonia;
using Avalonia.Markup.Xaml;

namespace FlashCards.Avalonia
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
