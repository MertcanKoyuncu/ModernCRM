   M S B A M L   `   `   `  ����D  @ModernCRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ModernCRM	ModernCRM  5   	       ModernCRM.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ModernCRM     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
Modern CRM��5	   	   $	��720��6   $
��1280��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   �� $��0��6      PrimaryHueDarkBrush#���   6%   .+�5      �� $��
MODERN CRM��6   $��24(�6*   $
��Bold"�68   
�������$��
20,30,0,40q�6]   $
��Left=�6q   �� 5      -   5         ��Name$ BtnDashboard��5        MaterialDesignFlatButton#��[ 6+   
�������$��0,0,0,10q�6p   $��Stretch=�6�   $
��Left=�6�   $��20,10q�6�   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ViewDashboard=�6.   $��Center=�6C   $��0,0,10,0q�6^   �� 5      $��	Ana Sayfa��6    5      5      �� 5      -   5        $ BtnCustomers��5      #��[ 6+   
�������$��0,0,0,10q�6p   $��Stretch=�6�   $
��Left=�6�   $��20,10q�6�   .��5      �� $ 
Horizontal=�6   .+�5        $ AccountMultiple=�6.   $��Center=�6E   $��0,0,10,0q�6`   �� 5      $��Müşteriler��6    5      5       �� 5"      -   5        $ 	BtnAgents��5"      #��[ 6(   
�������$��0,0,0,10q�6m   $��Stretch=�6   $
��Left=�6�   $��20,10q�6�   .��5#      �� $ 
Horizontal=�6   .+�5$        $ 
AccountTie=�6.   $��Center=�6@   $��0,0,10,0q�6[   �� 5%      $��Temsilciler��6    5&      5'      �� 5)      -   5        $ BtnTransactions��5)      #��[ 6.   
�������$��0,0,0,10q�6s   $��Stretch=�6�   $
��Left=�6�   $��20,10q�6�   .��5*      �� $ 
Horizontal=�6   .+�5+        $ CashMultiple=�6.   $��Center=�6B   $��0,0,10,0q�6]   �� 5,      $��
İşlemler��6    5-      5.      �� 50      -   5        $ 	BtnImport��50      #��[ 6(   
�������$��0,0,0,10q�6m   $��Stretch=�6   $
��Left=�6�   $��20,10q�6�   .��51      �� $ 
Horizontal=�6   .+�52        $ Import=�6.   $��Center=�6<   $��0,0,10,0q�6W   �� 53      $��İçe Aktar��6    54      55      �� 57      -   5        $ 
BtnReports��57      #��[ 6)   
�������$��0,0,0,10q�6n   $��Stretch=�6�   $
��Left=�6�   $��20,10q�6�   .��58      �� $ 
Horizontal=�6   .+�59        $ ChartBar=�6.   $��Center=�6>   $��0,0,10,0q�6Y   �� 5:      $��Raporlar��6    5;      5<      �� 5>      -   5        $ BtnSettings��5>      #��[ 6*   
�������$��0,0,0,10q�6o   $��Stretch=�6�   $
��Left=�6�   $��20,10q�6�   .��5?      �� $ 
Horizontal=�6   .+�5@        $	 Cog=�6.   $��Center=�69   $��0,0,10,0q�6T   �� 5A      $��Ayarlar��6    5B      5C      5D      � 5G   
   $��1��6     MaterialDesignPaper#���  6    � RowDefinitions 5H      �� 5I      $��60 �6    �� 5J      $��* �6    .+�5N      � $��0��6   
������� 5O      �� 5P      $��* �6'   �� 5Q      $
��Auto �6'   .+�5U      �� -   5         ��Name$ TxtPageTitle��5U      $��0��62   $��	Ana Sayfa��6B   $��20(�6S   $��Medium"�6a   $��20,0,0,0q�6u   $��Center=�6�   �� 5X      $��1��6   $ 
Horizontal=�6-   $��0,0,20,0q�6F   .+�5Y      �� $��Admin Kullanıcı��6    $��Center=�67   $��0,0,10,0q�6R   �� 5Z        MaterialDesignIconButton#��[ 6   .��5[        $ AccountCircle=�62   $��30��6G   $��30��6R   5\      5]      5^       � 5a      -	   5          �Name$ ContentFrame��5a      $��1��6*   $��20q�67     � NavigationUIVisibility$ Hidden=�6C   5b      5c      5d      