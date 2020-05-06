using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ViewModels;
using Views.Views;

namespace Views
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            ApplyStyles();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowModel(),
                };
            }
            base.OnFrameworkInitializationCompleted();
        }

        private void ApplyStyles()
        {
           /* Styles.Add(new BaseTheme());

            var theme = Environment.GetEnvironmentVariable("RADISH_THEME");

            if (theme == null)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Styles.Add(new MacosTheme());
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Styles.Add(new WindowsTheme());
                }
            }
            else if (theme.Equals("windows", StringComparison.InvariantCultureIgnoreCase))
            {
                Styles.Add(new WindowsTheme());
            }
            else // if (theme.Equals("macos", StringComparison.InvariantCultureIgnoreCase))
            {
                Styles.Add(new MacosTheme());
            }*/
        }
    }
}
