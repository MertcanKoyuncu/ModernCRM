   M S B A M L   `   `   `  ���� D  @ModernCRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ModernCRM	ModernCRM      ModernCRM.MainWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:ModernCRM     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  
Modern CRM��$	��720��$
��1280��.���  � ColumnDefinitions �� $	��250 ��� $��* �.+��� $��0��   PrimaryHueDarkBrush#���   .+��� $��
MODERN CRM��$��24(�$
��Bold"�
�������$��
20,30,0,40q�$
��Left=��� -    ��Name$ BtnDashboard��  MaterialDesignFlatButton#��[ 
�������$��0,0,0,10q�$��Stretch=�$
��Left=�$��20,10q�.����  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ViewDashboard=�$��Center=�$��0,0,10,0q��� $��	Ana Sayfa���� -   $ BtnCustomers��#��[ 
�������$��0,0,0,10q�$��Stretch=�$
��Left=�$��20,10q�.���� $ 
Horizontal=�.+�  $ AccountMultiple=�$��Center=�$��0,0,10,0q��� $��Müşteriler���� -   $ 	BtnAgents��#��[ 
�������$��0,0,0,10q�$��Stretch=�$
��Left=�$��20,10q�.���� $ 
Horizontal=�.+�  $ 
AccountTie=�$��Center=�$��0,0,10,0q��� $��Temsilciler���� -   $ BtnTransactions��#��[ 
�������$��0,0,0,10q�$��Stretch=�$
��Left=�$��20,10q�.���� $ 
Horizontal=�.+�  $ CashMultiple=�$��Center=�$��0,0,10,0q��� $��
İşlemler���� -   $ 	BtnImport��#��[ 
�������$��0,0,0,10q�$��Stretch=�$
��Left=�$��20,10q�.���� $ 
Horizontal=�.+�  $ Import=�$��Center=�$��0,0,10,0q��� $��İçe Aktar���� -   $ 
BtnReports��#��[ 
�������$��0,0,0,10q�$��Stretch=�$
��Left=�$��20,10q�.���� $ 
Horizontal=�.+�  $ ChartBar=�$��Center=�$��0,0,10,0q��� $��Raporlar���� -   $ BtnSettings��#��[ 
�������$��0,0,0,10q�$��Stretch=�$
��Left=�$��20,10q�.���� $ 
Horizontal=�.+�  $	 Cog=�$��Center=�$��0,0,10,0q��� $��Ayarlar��� $��1��  MaterialDesignPaper#���   � RowDefinitions �� $��60 ��� $��* �.+�� $��0��
������� �� $��* ��� $
��Auto �.+��� -    ��Name$ TxtPageTitle��$��0��$��	Ana Sayfa��$��20(�$��Medium"�$��20,0,0,0q�$��Center=��� $��1��$ 
Horizontal=�$��0,0,20,0q�.+��� $��Admin Kullanıcı��$��Center=�$��0,0,10,0q���   MaterialDesignIconButton#��[ .��  $ AccountCircle=�$��30��$��30�� � -	     �Name$ ContentFrame��$��1��$��20q�  � NavigationUIVisibility$ Hidden=�