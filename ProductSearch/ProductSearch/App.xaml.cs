using System.Windows;

namespace ProductSearch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
