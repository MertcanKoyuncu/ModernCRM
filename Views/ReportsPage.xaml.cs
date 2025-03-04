using System.Windows.Controls;

namespace ModernCRM.Views
{
    public partial class ReportsPage : Page
    {
        public ReportsPage()
        {
            // Basit bir içerik oluştur
            TextBlock reportsText = new TextBlock
            {
                Text = "Raporlar Sayfası",
                FontSize = 24,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            
            // İçeriği sayfaya ekle
            Grid grid = new Grid();
            grid.Children.Add(reportsText);
            this.Content = grid;
        }
    }
} 