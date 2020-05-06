using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using Services;
using ViewModels;

namespace Views.Views
{
    public partial class MainWindow : BaseWindow<MainWindowModel>
    {
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
            this.AttachDevTools(KeyGesture.Parse("Ctrl+Shift+D"));

            this.WhenActivated(disposables =>
            {
               /* ViewModel?.ExitCommand?.SubscribeWithLog(_ =>
                {
                    Close();
                });*/
            });
        }
    }
}
