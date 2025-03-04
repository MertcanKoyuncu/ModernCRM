using System.Windows.Controls;

namespace ModernCRM.Views
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            // Basit bir içerik oluştur
            TextBlock settingsText = new TextBlock
            {
                Text = "Ayarlar Sayfası",
                FontSize = 24,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            
            // İçeriği sayfaya ekle
            Grid grid = new Grid();
            grid.Children.Add(settingsText);
            this.Content = grid;
        }
    }
} 