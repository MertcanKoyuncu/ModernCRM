using System.Windows.Controls;

namespace ModernCRM.Views
{
    public partial class CustomersPage : Page
    {
        public CustomersPage()
        {
            // Basit bir içerik oluştur
            TextBlock customersText = new TextBlock
            {
                Text = "Müşteriler Sayfası",
                FontSize = 24,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            
            // İçeriği sayfaya ekle
            Grid grid = new Grid();
            grid.Children.Add(customersText);
            this.Content = grid;
        }
    }
} 