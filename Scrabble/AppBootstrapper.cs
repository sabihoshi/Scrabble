using System.Windows;
using Caliburn.Micro;
using Scrabble.ViewModels;

namespace Scrabble
{
    public class AppBootstrapper : BootstrapperBase
    {
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<GameWindowViewModel>();
        }
    }
}