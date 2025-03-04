using System;
using System.Windows;

namespace ModernCRM;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        try
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Uygulama başlatılırken bir hata oluştu: {ex.Message}",
                "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            this.Shutdown();
        }
    }
}

