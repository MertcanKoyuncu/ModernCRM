   M S B A M L   `   `   `  ���� D  @ModernCRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ModernCRM.ViewsModernCRM.Views  ;"clr-namespace:ModernCRM.ViewModelsModernCRM.ViewModels  #    ModernCRM.Views.DashboardPage   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:ModernCRM.Views     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  3
viewmodels"clr-namespace:ModernCRM.ViewModels    N� Title$  DashboardPage�� � DataContext -   'ModernCRM.ViewModels.DashboardViewModel  .��� .+��� $
��Auto=�.���� .+�� $��0,0,0,20q� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��0��$��0,0,10,0q�   UniformCornerRadius$ 8Q�$��16q�.���  � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountGroup=�$��24��$��24��$��Center=�   PrimaryHueMidBrush#���   �� $��Toplam Müşteri��$��8,0,0,0q�$��Center=�$��Medium"��� $��1��$��28(�$
��Bold"�$��0,10,0,0q����� *TotalCustomers+  $��1��$
��10,0q�$ 8Q�$��16q�.���  �� $
��Auto ��� $
��Auto �.+��� $��0��$ 
Horizontal=�.+�  $ CashPlus=�$��24��$��24��$��Center=����#4CAF50�� $��Toplam Gelir��$��8,0,0,0q�$��Center=�$��Medium"��� $��1��$��28(�$
��Bold"�$��0,10,0,0q����#4CAF50���� *TotalIncome+ �� StringFormat$ 
{0:N2} ₺��  $��2��$
��10,0q�$ 8Q�$��16q�.���  �� $
��Auto ��� $
��Auto �.+��� $��0��$ 
Horizontal=�.+�  $ 	CashMinus=�$��24��$��24��$��Center=����#F44336�� $��Toplam Gider��$��8,0,0,0q�$��Center=�$��Medium"��� $��1��$��28(�$
��Bold"�$��0,10,0,0q����#F44336���� *TotalExpense+$ 
{0:N2} ₺��  $��3��$��10,0,0,0q�$ 8Q�$��16q�.���  �� $
��Auto ��� $
��Auto �.+��� $��0��$ 
Horizontal=�.+�  $ 	CashCheck=�$��24��$��24��$��Center=�  SecondaryHueMidBrush#���  �� $��Bakiye��$��8,0,0,0q�$��Center=�$��Medium"��� $��1��$��28(�$
��Bold"�$��0,10,0,0q����� *	Balance+$ 
{0:N2} ₺���  �� $��2* ��� $��* �.+�  $��0��$��0,0,10,0q�$ 8Q�.���  �� $
��Auto ��� $��* �.+��� $��0��$��Son İşlemler��$��18(�$��Medium"�$��
16,16,16,8q�&   System.Windows.Controls.DataGrid  $��1��   AutoGenerateColumns$ False��	   
IsReadOnly$
	 True��
   CanUserAddRows$
 False��   CanUserDeleteRows$ False��   CanUserReorderColumns$ False��   CanUserResizeRows$ False��   CanUserSortColumns$
 True��   HeadersVisibility$ Column=�$��
16,0,16,16q�$��1q�  MaterialDesignDivider#���  ���� *RecentTransactions+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Tarih��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Date+$ {0:dd.MM.yyyy}��  $ 
Açıklama��$ *  �� *Description+  $ Kategori��$	 120  �� *
Category+  $ 	Müşteri��$	 150  �� *Customer.Name+4	  .System.Windows.Controls.DataGridTemplateColumn	  $ Tutar��$	 120  	  CellTemplate �� .R��� $��Right=����� *Amount+$ 
{0:N2} ₺������ *Type+ # TransactionTypeToColorConverter �� 	Converter# [   $��1��$��10,0,0,0q�$ 8Q�.���  �� $
��Auto ��� $��* �.+��� $��0��$��Önemli Müşteriler��$��18(�$��Medium"�$��
16,16,16,8q��� $��1��$��
16,0,16,16q����� *TopCustomers+���� .R�� $	��0,8q� �� $
��Auto ��� $��* �.+��� $��0��$��40��$��40�� �� CornerRadius$ 20��  PrimaryHueLightBrush#���  $��0,0,10,0q�._��� $��Center=�$��Center=�
�������$��Medium"����� *Name+  NameToInitialsConverter# [ �� $��1��.+��� $��Medium"����� *Name+��  J� Opacity$	 0.6Q�$��12(����� *	Company+