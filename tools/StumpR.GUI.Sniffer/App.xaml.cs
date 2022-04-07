using System.Windows;
using System.Windows.Threading;

namespace StumpR.GUI.Sniffer;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show($"An error occurred - {e.Exception}",
            "Error",
            MessageBoxButton.OK,
            MessageBoxImage.Error);
    }
}