using System.Windows;

namespace PhotoSorter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Bootstrapper.Instance.SetupContainer();

            base.OnStartup(e);
        }
    }
}
