using System.Windows;

namespace GreekFire.Client.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootStrapper = new Bootstrapper();
            bootStrapper.Run();
        }
    }
}