   M S B A M L   `   `   `  ����D  @ModernCRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ModernCRM.ViewsModernCRM.Views  5      ;"clr-namespace:ModernCRM.ViewModelsModernCRM.ViewModels  5      #    ModernCRM.Views.DashboardPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ModernCRM.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      3
viewmodels"clr-namespace:ModernCRM.ViewModels  5        N� Title$  DashboardPage��5       � DataContext 5      -   'ModernCRM.ViewModels.DashboardViewModel  5   
   .��5      � .+�5   
   �� $
��Auto=�6   .��5      �� .+�5      � $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��* �6+   �� 5      $��* �6+   �� 5      $��* �6+   .+�5      #  MaterialDesignThemes.Wpf.Card  $��0��6*   $��0,0,10,0q�6:      UniformCornerRadius$ 8Q�6L   $��16q�6d   .��5      �  � RowDefinitions 5       �� 5!   "   $
��Auto �60   �� 5"   "   $
��Auto �60   .+�5$      �� $��0��6)    �� Orientation$ 
Horizontal=�66   .+�5%   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountGroup=�6:   $��24��6N   $��24��6Y   $��Center=�6e      PrimaryHueMidBrush#���   6�   �� 5&   "   $��Toplam Müşteri��6,   $��8,0,0,0q�6B   $��Center=�6S   $��Medium"�6n   5'      �� 5(      $��1��6(   $��28(�6U   $
��Bold"�6c   $��0,10,0,0q�6u   ��65   �� *TotalCustomers+6u   5)      5*        5-      $��1��6*   $
��10,0q�6:   $ 8Q�6H   $��16q�6`   .��5.      �  5/      �� 50   "   $
��Auto �60   �� 51   "   $
��Auto �60   .+�53      �� $��0��6)   $ 
Horizontal=�66   .+�54   "     $ CashPlus=�6:   $��24��6J   $��24��6U   $��Center=�6a   ���#4CAF506|   �� 55   "   $��Toplam Gelir��6,   $��8,0,0,0q�6@   $��Center=�6Q   $��Medium"�6l   56      �� 57      $��1��6(   $��28(�6k   $
��Bold"�6y   $��0,10,0,0q�6�   ���#4CAF50��65   �� *TotalIncome+ �� StringFormat$ 
{0:N2} ₺��6�   58      59        5<      $��2��6*   $
��10,0q�6:   $ 8Q�6H   $��16q�6`   .��5=      �  5>      �� 5?   "   $
��Auto �60   �� 5@   "   $
��Auto �60   .+�5B      �� $��0��6)   $ 
Horizontal=�66   .+�5C   "     $ 	CashMinus=�6:   $��24��6K   $��24��6V   $��Center=�6b   ���#F443366}   �� 5D   "   $��Toplam Gider��6,   $��8,0,0,0q�6@   $��Center=�6Q   $��Medium"�6l   5E      �� 5F      $��1��6(   $��28(�6l   $
��Bold"�6z   $��0,10,0,0q�6�   ���#F44336��65   �� *TotalExpense+$ 
{0:N2} ₺��6�   5G      5H        5K      $��3��6*   $��10,0,0,0q�6:   $ 8Q�6L   $��16q�6d   .��5L      �  5M      �� 5N   "   $
��Auto �60   �� 5O   "   $
��Auto �60   .+�5Q      �� $��0��6)   $ 
Horizontal=�66   .+�5R   "     $ 	CashCheck=�6:   $��24��6K   $��24��6V   $��Center=�6b     SecondaryHueMidBrush#���  6}   �� 5S   "   $��Bakiye��6,   $��8,0,0,0q�6:   $��Center=�6K   $��Medium"�6f   5T      �� 5U      $��1��6(   $��28(�6g   $
��Bold"�6u   $��0,10,0,0q�6�   ��65   �� *	Balance+$ 
{0:N2} ₺��6�   5V      5W      5X      � 5[       5\      �� 5]      $��2* �6+   �� 5^      $��* �6+   .+�5b        $��0��6*   $��0,0,10,0q�6:   $ 8Q�6L   .��5c      �  5d      �� 5e   "   $
��Auto �60   �� 5f   "   $��* �60   .+�5i      �� $��0��6(   $��Son İşlemler��65   $��18(�6I   $��Medium"�6W   $��
16,16,16,8q�6k   &   System.Windows.Controls.DataGrid  5k      $��1��6'      AutoGenerateColumns$ False��6_   	   
IsReadOnly$
	 True��5l   '   
   CanUserAddRows$
 False��69      CanUserDeleteRows$ False��6P      CanUserReorderColumns$ False��5m   '      CanUserResizeRows$ False��6E      CanUserSortColumns$
 True��5n   '      HeadersVisibility$ Column=�6A   $��
16,0,16,16q�5o   '   $��1q�6;     MaterialDesignDivider#���  6O   ��5k   4   �� *RecentTransactions+   Columns 5p   "   0  *System.Windows.Controls.DataGridTextColumn  5q   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Tarih��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *Date+$ {0:dd.MM.yyyy}��6�     5r   &   $ 
Açıklama��69   $ * 6k    6K   �� *Description+6k     5s   &   $ Kategori��69   $	 120 6h    6K   �� *
Category+6h     5t   &   $ 	Müşteri��69   $	 150 6l    6J   �� *Customer.Name+6l   4	  .System.Windows.Controls.DataGridTemplateColumn	  5u   &   $ Tutar��6=   $	 120 6L    	  CellTemplate 5v   *   �� 5w   .   .R�5x   2   �� $��Right=�5z   <   ��5x   <   �� *Amount+$ 
{0:N2} ₺����5y   <   �� *Type+ # TransactionTypeToColorConverter �� 	Converter# [ 5z   <   5{   /   5}   '   5      5�      5�        5�      $��1��6*   $��10,0,0,0q�6:   $ 8Q�6L   .��5�      �  5�      �� 5�   "   $
��Auto �60   �� 5�   "   $��* �60   .+�5�      �� $��0��6(   $��Önemli Müşteriler��65   $��18(�6N   $��Medium"�6\   $��
16,16,16,8q�6p   �� 5�      $��1��6'   $��
16,0,16,16q�6Y   ��64   �� *TopCustomers+��5�   "   �� 5�   &   .R�5�   *   � $	��0,8q�6/    5�   .   �� 5�   2   $
��Auto �6C   �� 5�   2   $��* �6C   .+�5�   .   �� $��0��65   $��40��6E   $��40��6P    �� CornerRadius$ 20��6\     PrimaryHueLightBrush#���  6n   $��0,0,10,0q�6�   ._�5�   2   �� $��Center=�5�   <   $��Center=�6W   
�������$��Medium"�5�   O   ��5�   <   �� *Name+  NameToInitialsConverter# [ 5�   O   5�   /   �� 5�   .   $��1��69   .+�5�   2   �� $��Medium"�6R   ��6<   �� *Name+6R   �� 5�   2    J� Opacity$	 0.6Q�6U   $��12(�6c   ��6<   �� *	Company+6c   5�   /   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      