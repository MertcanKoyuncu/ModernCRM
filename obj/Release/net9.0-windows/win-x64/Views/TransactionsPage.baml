   M S B A M L   `   `   `  ���� D  @ModernCRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ModernCRM.ViewsModernCRM.Views  &     ModernCRM.Views.TransactionsPage   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:ModernCRM.Views     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  TransactionsPage��.���  � RowDefinitions �� $
��Auto ��� $��* �.+�� $��0��$��0,0,0,20q� � ColumnDefinitions �� $��* ��� $
��Auto ��� $
��Auto �.+�� $��0��$	��300��$
��Left=�.+��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ İşlem ara...�� !  MaterialDesignOutlinedTextBox#��[  .�� J� InputBindings �� 
 �� Key$ Return�� �� Command �� *SearchCommand+ �� CommandParameter �� *Text+ �� RelativeSource �� 	 �� AncestorType	 TextBox.��'  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Magnify=�$��10,0,0,0q�$��Center=��� $��1��  MaterialDesignRaisedButton#��[ $��0,0,10,0q����#4CAF50���� *AddIncomeCommand+.����  �� Orientation$ 
Horizontal=�.+�  $
 CashPlus=�$��Center=�$��0,0,8,0q��� $��
Yeni Gelir���� $��2��#��[ ���#F44336���� *AddExpenseCommand+.���� $ 
Horizontal=�.+�  $
 	CashMinus=�$��Center=�$��0,0,8,0q��� $��
Yeni Gider��#  MaterialDesignThemes.Wpf.Card  $��1��   UniformCornerRadius$ 8Q�.��&   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��   
IsReadOnly$
 True��   CanUserAddRows$ False��   CanUserDeleteRows$ False��   CanUserReorderColumns$ False��   CanUserResizeRows$ False��   CanUserSortColumns$
 True��   HeadersVisibility$ Column=�$��16q�$��1q�  MaterialDesignDivider#���  ���� *Transactions+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Tarih��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Date+ �� StringFormat$ {0:dd.MM.yyyy}��4	  .System.Windows.Controls.DataGridTemplateColumn	  $
 Tür��$ 80  	  CellTemplate �� .R��� $ 
Horizontal=�.+�  $��Center=�$��0,0,5,0q�
 �� *Type+ " TransactionTypeToIconConverter �� 	Converter# [ ���� *Type+ # TransactionTypeToColorConverter# [ �� ���� *Type+ " TransactionTypeToTextConverter# [ ���� *Type+# [   $ 
Açıklama��$ *  �� *Description+  $ Kategori��$	 120  �� *
Category+  $ Ödeme Yöntemi��$	 120  �� *PaymentMethod+  $ 	Müşteri��$	 150  �� *Customer.Name+	  $ Tutar��$	 120  �� .R��� $��Right=����� *Amount+$ 
{0:N2} ₺������ *Type+# [ 	  $ 
İşlemler��$	 100  �� .R��� $ 
Horizontal=�.+���   MaterialDesignIconButton#��[  � ToolTip$ Düzenle������ *$"DataContext.EditTransactionCommand+ �� 	 DataGrid���� .��  $
 Pencil=��� #��[ $	 Sil������ *&$DataContext.DeleteTransactionCommand+ �� 	 DataGrid���� .��  $
 Delete=�