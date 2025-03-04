using System.Windows.Controls;

namespace ModernCRM.Views
{
    /// <summary>
    /// ImportPage.xaml için etkileşim mantığı
    /// </summary>
    public partial class ImportPage : Page
    {
        public ImportPage()
        {
            // Basit bir içerik oluştur
            TextBlock importText = new TextBlock
            {
                Text = "İçe Aktarma Sayfası",
                FontSize = 24,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            
            // İçeriği sayfaya ekle
            Grid grid = new Grid();
            grid.Children.Add(importText);
            this.Content = grid;
        }
    }
} 