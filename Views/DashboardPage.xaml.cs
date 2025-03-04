using System.Windows.Controls;

namespace ModernCRM.Views
{
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            // Basit bir içerik oluştur
            TextBlock dashboardText = new TextBlock
            {
                Text = "Ana Sayfa İçeriği",
                FontSize = 24,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            
            // İçeriği sayfaya ekle
            Grid grid = new Grid();
            grid.Children.Add(dashboardText);
            this.Content = grid;
        }
    }
} 