using System.Windows.Controls;

namespace ModernCRM.Views
{
    public partial class AgentsPage : Page
    {
        public AgentsPage()
        {
            // Basit bir içerik oluştur
            TextBlock agentsText = new TextBlock
            {
                Text = "Temsilciler Sayfası",
                FontSize = 24,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            
            // İçeriği sayfaya ekle
            Grid grid = new Grid();
            grid.Children.Add(agentsText);
            this.Content = grid;
        }
    }
} 