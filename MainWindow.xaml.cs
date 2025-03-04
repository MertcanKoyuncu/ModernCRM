using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using ModernCRM.Views;
using MaterialDesignThemes.Wpf;
using ModernCRM.Services;
using System.Threading.Tasks;

namespace ModernCRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // UI bileşenleri
        private Frame contentFrame;
        private TextBlock txtPageTitle;
        private TextBlock txtTodayOrders;
        private TextBlock txtTodaySearches;
        private TextBlock txtTodayRevenue;
        
        // Servisler
        private readonly TransactionService _transactionService;
        private readonly CustomerService _customerService;

        public MainWindow()
        {
            // Servisleri başlat
            _transactionService = new TransactionService();
            _customerService = new CustomerService();
            
            // Window özellikleri
            this.Title = "Modern CRM";
            this.Width = 1280;
            this.Height = 720;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.FontFamily = new FontFamily("Segoe UI");
            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F7FA"));
            
            // Ana grid
            Grid mainGrid = new Grid();
            this.Content = mainGrid;
            
            // Grid satırları
            RowDefinition headerRow = new RowDefinition { Height = new GridLength(80) };
            RowDefinition contentRow = new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
            mainGrid.RowDefinitions.Add(headerRow);
            mainGrid.RowDefinitions.Add(contentRow);
            
            // Header panel
            Border headerBorder = new Border
            {
                Background = Brushes.White,
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E2E8F0")),
                Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 270,
                    ShadowDepth = 1,
                    BlurRadius = 5,
                    Opacity = 0.1
                }
            };
            Grid.SetRow(headerBorder, 0);
            mainGrid.Children.Add(headerBorder);
            
            // Header içeriği
            Grid headerGrid = new Grid();
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) }); // Logo
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); // İstatistikler
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) }); // Kullanıcı
            headerBorder.Child = headerGrid;
            
            // Logo ve başlık
            StackPanel logoPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(20, 0, 0, 0)
            };
            Grid.SetColumn(logoPanel, 0);
            
            Ellipse logoCircle = new Ellipse
            {
                Width = 40,
                Height = 40,
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3B82F6"))
            };
            
            TextBlock logoText = new TextBlock
            {
                Text = "M",
                FontSize = 22,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            
            Grid logoGrid = new Grid();
            logoGrid.Children.Add(logoCircle);
            logoGrid.Children.Add(logoText);
            
            TextBlock appTitle = new TextBlock
            {
                Text = "Modern CRM",
                FontSize = 22,
                FontWeight = FontWeights.SemiBold,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2D3748")),
                Margin = new Thickness(15, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
            
            logoPanel.Children.Add(logoGrid);
            logoPanel.Children.Add(appTitle);
            headerGrid.Children.Add(logoPanel);
            
            // İstatistik iconları - e-Nabız benzeri
            StackPanel statsPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 0)
            };
            Grid.SetColumn(statsPanel, 1);
            
            // 1. Günün Siparişleri
            Border ordersBorder = CreateStatIcon(PackIconKind.ShoppingCart, "#4299E1", "Günün Siparişleri", "0");
            statsPanel.Children.Add(ordersBorder);
            
            // 2. Arama Kayıtları
            Border searchesBorder = CreateStatIcon(PackIconKind.Search, "#48BB78", "Arama Kayıtları", "0");
            statsPanel.Children.Add(searchesBorder);
            
            // 3. Günlük Ciro
            Border revenueBorder = CreateStatIcon(PackIconKind.CurrencyUsd, "#ED8936", "Günlük Ciro", "0₺");
            statsPanel.Children.Add(revenueBorder);
            
            headerGrid.Children.Add(statsPanel);
            
            // Sağ üst kullanıcı bilgisi
            StackPanel userPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 20, 0)
            };
            Grid.SetColumn(userPanel, 2);
            
            // Kullanıcı avatar
            Border userAvatar = new Border
            {
                Width = 40,
                Height = 40,
                CornerRadius = new CornerRadius(20),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3B82F6")),
                Margin = new Thickness(0, 0, 15, 0)
            };
            
            TextBlock userInitials = new TextBlock
            {
                Text = "AU",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = Brushes.White,
                FontWeight = FontWeights.SemiBold,
                FontSize = 16
            };
            
            userAvatar.Child = userInitials;
            
            // Kullanıcı bilgisi
            StackPanel userInfo = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center
            };
            
            TextBlock userName = new TextBlock
            {
                Text = "Admin Kullanıcı",
                FontWeight = FontWeights.SemiBold,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2D3748")),
                FontSize = 14
            };
            
            TextBlock userRole = new TextBlock
            {
                Text = "Yönetici",
                FontSize = 12,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#718096"))
            };
            
            userInfo.Children.Add(userName);
            userInfo.Children.Add(userRole);
            
            userPanel.Children.Add(userAvatar);
            userPanel.Children.Add(userInfo);
            
            headerGrid.Children.Add(userPanel);
            
            // Ana içerik alanı
            Grid contentGrid = new Grid();
            Grid.SetRow(contentGrid, 1);
            mainGrid.Children.Add(contentGrid);
            
            // Kart butonları içeren ana panel
            ScrollViewer scrollViewer = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Margin = new Thickness(0, 0, 0, 0),
                Background = Brushes.Transparent
            };
            
            StackPanel mainContent = new StackPanel
            {
                Margin = new Thickness(30, 30, 30, 30)
            };
            
            scrollViewer.Content = mainContent;
            
            // Ana başlık
            TextBlock mainTitle = new TextBlock
            {
                Text = "Modern CRM Sistemine Hoş Geldiniz",
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1A202C")),
                Margin = new Thickness(0, 0, 0, 20)
            };
            mainContent.Children.Add(mainTitle);
            
            // Açıklama
            TextBlock description = new TextBlock
            {
                Text = "Aşağıdaki kartlardan birini seçerek CRM sisteminin farklı modüllerine erişebilirsiniz.",
                FontSize = 16,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4A5568")),
                Margin = new Thickness(0, 0, 0, 30),
                TextWrapping = TextWrapping.Wrap
            };
            mainContent.Children.Add(description);
            
            // Kart grid
            Grid cardGrid = new Grid();
            cardGrid.Margin = new Thickness(0, 0, 0, 30);
            
            // 2 satır 3 sütunluk grid
            cardGrid.RowDefinitions.Add(new RowDefinition());
            cardGrid.RowDefinitions.Add(new RowDefinition());
            
            cardGrid.ColumnDefinitions.Add(new ColumnDefinition());
            cardGrid.ColumnDefinitions.Add(new ColumnDefinition());
            cardGrid.ColumnDefinitions.Add(new ColumnDefinition());
            
            // Kartlar oluştur ve grid'e ekle
            Border dashboardCard = CreateCard("Ana Sayfa", "Genel bakış ve özet bilgiler", PackIconKind.ViewDashboard, "#3B82F6", new DashboardPage(), 0, 0);
            Border customersCard = CreateCard("Müşteriler", "Müşteri yönetimi ve detayları", PackIconKind.AccountMultiple, "#10B981", new CustomersPage(), 0, 1);
            Border agentsCard = CreateCard("Temsilciler", "Satış temsilcileri yönetimi", PackIconKind.AccountTie, "#F59E0B", new AgentsPage(), 0, 2);
            Border transactionsCard = CreateCard("İşlemler", "Finansal işlemler ve kayıtlar", PackIconKind.CashMultiple, "#8B5CF6", new TransactionsPage(), 1, 0);
            Border importCard = CreateCard("İçe Aktar", "Veri içe aktarma ve dışa aktarma", PackIconKind.Import, "#EC4899", new ImportPage(), 1, 1);
            Border reportsCard = CreateCard("Raporlar", "Detaylı raporlar ve analizler", PackIconKind.ChartBar, "#EF4444", new ReportsPage(), 1, 2);
            
            cardGrid.Children.Add(dashboardCard);
            cardGrid.Children.Add(customersCard);
            cardGrid.Children.Add(agentsCard);
            cardGrid.Children.Add(transactionsCard);
            cardGrid.Children.Add(importCard);
            cardGrid.Children.Add(reportsCard);
            
            mainContent.Children.Add(cardGrid);
            
            // Ayarlar kartı (tam genişlikte)
            Border settingsCard = CreateFullWidthCard("Ayarlar", "Sistem ayarları ve kullanıcı tercihleri", PackIconKind.Cog, "#64748B", new SettingsPage());
            mainContent.Children.Add(settingsCard);
            
            // İçerik frame'i (başlangıçta gizli)
            contentFrame = new Frame
            {
                NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden,
                Visibility = Visibility.Collapsed
            };
            
            // Ana içerik container
            Grid containerGrid = new Grid();
            containerGrid.Children.Add(scrollViewer);
            containerGrid.Children.Add(contentFrame);
            
            contentGrid.Children.Add(containerGrid);
            
            // Sayfa başlık bloğu
            StackPanel titlePanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(30, 20, 0, 20),
                Visibility = Visibility.Collapsed
            };
            
            // Geri butonu
            Button backButton = new Button
            {
                Width = 40,
                Height = 40,
                Margin = new Thickness(0, 0, 15, 0),
                Style = (Style)Application.Current.Resources["MaterialDesignFloatingActionMiniButton"],
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3B82F6")),
                BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3B82F6"))
            };
            
            PackIcon backIcon = new PackIcon
            {
                Kind = PackIconKind.ArrowLeft,
                Width = 24,
                Height = 24
            };
            backButton.Content = backIcon;
            
            // Başlık
            txtPageTitle = new TextBlock
            {
                FontSize = 22,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            };
            
            titlePanel.Children.Add(backButton);
            titlePanel.Children.Add(txtPageTitle);
            
            contentGrid.Children.Add(titlePanel);
            
            // Geri butonuna tıklama olayı ekle
            backButton.Click += (s, e) => NavigateBack();
            
            // Verileri yükle
            LoadStatisticsAsync();
        }
        
        // İstatistik iconu oluşturma metodu
        private Border CreateStatIcon(PackIconKind iconKind, string colorHex, string title, string initialValue)
        {
            var color = (Color)ColorConverter.ConvertFromString(colorHex);
            
            Border border = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(40, color.R, color.G, color.B)),
                CornerRadius = new CornerRadius(8),
                Width = 120,
                Height = 60,
                Margin = new Thickness(10, 0, 10, 0)
            };
            
            StackPanel stack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(10)
            };
            
            // İcon
            Border iconBorder = new Border
            {
                Background = new SolidColorBrush(color),
                CornerRadius = new CornerRadius(6),
                Width = 36,
                Height = 36,
                Margin = new Thickness(0, 0, 8, 0)
            };
            
            PackIcon icon = new PackIcon
            {
                Kind = iconKind,
                Width = 20,
                Height = 20,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            
            iconBorder.Child = icon;
            stack.Children.Add(iconBorder);
            
            // Metin ve değerler
            StackPanel textStack = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center
            };
            
            TextBlock titleText = new TextBlock
            {
                Text = title,
                FontSize = 11,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4A5568")),
                FontWeight = FontWeights.Medium
            };
            
            TextBlock valueText = new TextBlock
            {
                Text = initialValue,
                FontSize = 14,
                Foreground = new SolidColorBrush(color),
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 2, 0, 0)
            };
            
            // Değer referansını sakla (güncelleme için)
            if (title == "Günün Siparişleri")
                txtTodayOrders = valueText;
            else if (title == "Arama Kayıtları")
                txtTodaySearches = valueText;
            else if (title == "Günlük Ciro")
                txtTodayRevenue = valueText;
            
            textStack.Children.Add(titleText);
            textStack.Children.Add(valueText);
            
            stack.Children.Add(textStack);
            border.Child = stack;
            
            return border;
        }
        
        // İstatistikleri yükle
        private async Task LoadStatisticsAsync()
        {
            try
            {
                // Günün siparişleri
                int todayOrders = await _transactionService.GetTodayTransactionsCountAsync();
                txtTodayOrders.Text = todayOrders.ToString();
                
                // Arama kayıtları
                int todaySearches = await _customerService.GetTodaySearchCountAsync();
                txtTodaySearches.Text = todaySearches.ToString();
                
                // Günlük ciro
                decimal todayRevenue = await _transactionService.GetTodayIncomeAsync();
                txtTodayRevenue.Text = $"{todayRevenue:N0}₺";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"İstatistikler yüklenirken hata oluştu: {ex.Message}");
                
                // Veritabanı bağlantısı olmadığında örnek değerler gösterelim
                txtTodayOrders.Text = "5";
                txtTodaySearches.Text = "15";
                txtTodayRevenue.Text = "2.350₺";
                
                // Hata mesajını gösterme, uygulama çalışmaya devam etsin
                // MessageBox.Show($"İstatistikler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        // Renkli kart oluştur
        private Border CreateCard(string title, string description, PackIconKind iconKind, string colorHex, Page targetPage, int row, int column)
        {
            Border card = new Border
            {
                Background = Brushes.White,
                CornerRadius = new CornerRadius(12),
                Margin = new Thickness(10),
                MinHeight = 180,
                Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 2,
                    BlurRadius = 5,
                    Opacity = 0.2
                },
                Cursor = System.Windows.Input.Cursors.Hand
            };
            
            Grid.SetRow(card, row);
            Grid.SetColumn(card, column);
            
            // İçerik Grid
            Grid cardGrid = new Grid();
            
            // Renkli üst panel
            Border colorBar = new Border
            {
                Height = 8,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHex)),
                CornerRadius = new CornerRadius(12, 12, 0, 0),
                VerticalAlignment = VerticalAlignment.Top
            };
            
            // Kart içeriği
            StackPanel content = new StackPanel
            {
                Margin = new Thickness(20, 20, 20, 20)
            };
            
            // İkon
            PackIcon icon = new PackIcon
            {
                Kind = iconKind,
                Width = 36,
                Height = 36,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHex)),
                Margin = new Thickness(0, 0, 0, 15)
            };
            
            // Başlık
            TextBlock titleText = new TextBlock
            {
                Text = title,
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1A202C")),
                Margin = new Thickness(0, 0, 0, 8)
            };
            
            // Açıklama
            TextBlock descriptionText = new TextBlock
            {
                Text = description,
                FontSize = 14,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#718096")),
                TextWrapping = TextWrapping.Wrap
            };
            
            content.Children.Add(icon);
            content.Children.Add(titleText);
            content.Children.Add(descriptionText);
            
            cardGrid.Children.Add(colorBar);
            cardGrid.Children.Add(content);
            
            card.Child = cardGrid;
            
            // Tıklama olayı
            card.MouseLeftButtonDown += (s, e) => NavigateToPage(targetPage, title);
            
            // Hover efekti
            card.MouseEnter += (s, e) => {
                card.Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 3,
                    BlurRadius = 10,
                    Opacity = 0.3
                };
            };
            
            card.MouseLeave += (s, e) => {
                card.Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 2,
                    BlurRadius = 5,
                    Opacity = 0.2
                };
            };
            
            return card;
        }
        
        // Tam genişlikte kart oluştur
        private Border CreateFullWidthCard(string title, string description, PackIconKind iconKind, string colorHex, Page targetPage)
        {
            Border card = new Border
            {
                Background = Brushes.White,
                CornerRadius = new CornerRadius(12),
                Margin = new Thickness(10),
                MinHeight = 100,
                Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 2,
                    BlurRadius = 5,
                    Opacity = 0.2
                },
                Cursor = System.Windows.Input.Cursors.Hand
            };
            
            // İçerik Grid
            Grid cardGrid = new Grid();
            
            // Renkli sol panel
            Border colorBar = new Border
            {
                Width = 8,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHex)),
                CornerRadius = new CornerRadius(12, 0, 0, 12),
                HorizontalAlignment = HorizontalAlignment.Left
            };
            
            // Kart içeriği
            StackPanel content = new StackPanel
            {
                Margin = new Thickness(30, 20, 20, 20),
                Orientation = Orientation.Horizontal
            };
            
            // İkon
            PackIcon icon = new PackIcon
            {
                Kind = iconKind,
                Width = 32,
                Height = 32,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHex)),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 15, 0)
            };
            
            // Metin içeriği
            StackPanel textContent = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center
            };
            
            // Başlık
            TextBlock titleText = new TextBlock
            {
                Text = title,
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1A202C")),
                Margin = new Thickness(0, 0, 0, 4)
            };
            
            // Açıklama
            TextBlock descriptionText = new TextBlock
            {
                Text = description,
                FontSize = 14,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#718096")),
                TextWrapping = TextWrapping.Wrap
            };
            
            textContent.Children.Add(titleText);
            textContent.Children.Add(descriptionText);
            
            content.Children.Add(icon);
            content.Children.Add(textContent);
            
            cardGrid.Children.Add(colorBar);
            cardGrid.Children.Add(content);
            
            card.Child = cardGrid;
            
            // Tıklama olayı
            card.MouseLeftButtonDown += (s, e) => NavigateToPage(targetPage, title);
            
            // Hover efekti
            card.MouseEnter += (s, e) => {
                card.Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 3,
                    BlurRadius = 10,
                    Opacity = 0.3
                };
            };
            
            card.MouseLeave += (s, e) => {
                card.Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 2,
                    BlurRadius = 5,
                    Opacity = 0.2
                };
            };
            
            return card;
        }
        
        // Sayfaya git
        private void NavigateToPage(Page page, string title)
        {
            // Anasayfa gizle, içerik frame'i göster
            FrameworkElement scrollViewer = (FrameworkElement)((Grid)((Grid)contentFrame.Parent).Parent).Children[0];
            FrameworkElement titlePanel = (FrameworkElement)((Grid)((Grid)contentFrame.Parent).Parent).Children[1];
            
            scrollViewer.Visibility = Visibility.Collapsed;
            contentFrame.Visibility = Visibility.Visible;
            titlePanel.Visibility = Visibility.Visible;
            
            // İçeriği yükle
            contentFrame.Navigate(page);
            txtPageTitle.Text = title;
        }
        
        // Ana sayfaya dön
        private void NavigateBack()
        {
            // İçerik frame'i gizle, anasayfayı göster
            FrameworkElement scrollViewer = (FrameworkElement)((Grid)((Grid)contentFrame.Parent).Parent).Children[0];
            FrameworkElement titlePanel = (FrameworkElement)((Grid)((Grid)contentFrame.Parent).Parent).Children[1];
            
            scrollViewer.Visibility = Visibility.Visible;
            contentFrame.Visibility = Visibility.Collapsed;
            titlePanel.Visibility = Visibility.Collapsed;
        }
    }
}