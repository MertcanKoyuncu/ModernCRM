using System.Windows.Controls;

namespace ModernCRM.Views
{
    public partial class TransactionsPage : Page
    {
        public TransactionsPage()
        {
            // Basit bir içerik oluştur
            TextBlock transactionsText = new TextBlock
            {
                Text = "İşlemler Sayfası",
                FontSize = 24,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            
            // İçeriği sayfaya ekle
            Grid grid = new Grid();
            grid.Children.Add(transactionsText);
            this.Content = grid;
        }
    }
} 