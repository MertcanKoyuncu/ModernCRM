   M S B A M L   `   `   `  ����D  @ModernCRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ModernCRM.ViewsModernCRM.Views  5      &     ModernCRM.Views.TransactionsPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ModernCRM.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  TransactionsPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      � $��0��6   $	��300��6#   $
��Left=�6/   .+�5      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ İşlem ara...��6    !  MaterialDesignOutlinedTextBox#��[  5      .��6Q    J� InputBindings 5      �� 5      
 �� Key$ Return��6%    �� Command 62   �� *SearchCommand+ �� CommandParameter 6T   �� *Text+ �� RelativeSource �� 	 �� AncestorType	 TextBox.��5    -   5!      '  !MaterialDesignThemes.Wpf.PackIcon  5"      
   Kind$
 Magnify=�6*   $��10,0,0,0q�69   $��Center=�6K   5#      �� 5&      $��1��6     MaterialDesignRaisedButton#��[ 6%   $��0,0,10,0q�5'   :   ���#4CAF50��6   �� *AddIncomeCommand+.��5(      ��  �� Orientation$ 
Horizontal=�6   .+�5)        $
 CashPlus=�6.   $��Center=�6>   $��0,0,8,0q�6Y   �� 5*      $��
Yeni Gelir��6    5+      5,      �� 5/      $��2��6   #��[ 6%   ���#F44336��50      �� *AddExpenseCommand+.��51      �� $ 
Horizontal=�6   .+�52        $
 	CashMinus=�6.   $��Center=�6?   $��0,0,8,0q�6Z   �� 53      $��
Yeni Gider��6    54      55      56      #  MaterialDesignThemes.Wpf.Card  59   
   $��1��6      UniformCornerRadius$ 8Q�6+   .��5:      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��6<      
IsReadOnly$
 True��5;         CanUserAddRows$ False��6)      CanUserDeleteRows$ False��6@      CanUserReorderColumns$ False��5<         CanUserResizeRows$ False��65      CanUserSortColumns$
 True��5=         HeadersVisibility$ Column=�61   $��16q�5>      $��1q�6#     MaterialDesignDivider#���  67   ��5:      �� *Transactions+   Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ Tarih��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6p   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Date+ �� StringFormat$ {0:dd.MM.yyyy}��6p   4	  .System.Windows.Controls.DataGridTemplateColumn	  5A      $
 Tür��6-   $ 80 6:    	  CellTemplate 5B      �� 5C      .R�5D   "   �� $ 
Horizontal=�6-   .+�5E   &     $��Center=�5G   >   $��0,0,5,0q�6Y   
 5E   >   �� *Type+ " TransactionTypeToIconConverter �� 	Converter# [ ��5F   >   �� *Type+ # TransactionTypeToColorConverter# [ 5G   Y   �� 5H   &   ��60   �� *Type+ " TransactionTypeToTextConverter# [ ��5I   0   �� *Type+# [ 5J   #   5K      5M        5N      $ 
Açıklama��6)   $ * 6[    6;   �� *Description+6[     5O      $ Kategori��6)   $	 120 6X    6;   �� *
Category+6X     5P      $ Ödeme Yöntemi��6)   $	 120 6b    6@   �� *PaymentMethod+6b     5Q      $ 	Müşteri��6)   $	 150 6\    6:   �� *Customer.Name+6\   	  5R      $ Tutar��6-   $	 120 6<    5S      �� 5T      .R�5U   "   �� $��Right=�5W   ,   ��5U   ,   �� *Amount+$ 
{0:N2} ₺����5V   ,   �� *Type+# [ 5W   ,   5X      5Z      	  5[      $ 
İşlemler��6-   $	 100 6?    5\      �� 5]      .R�5^   "   �� $ 
Horizontal=�6-   .+�5_   &   ��   MaterialDesignIconButton#��[ 6-    � ToolTip$ Düzenle��6_   ��5`   -   �� *$"DataContext.EditTransactionCommand+ �� 	 DataGrid��5a   -   �� .��5b   *     $
 Pencil=�6B   5c   '   �� 5d   &   #��[ 6-   $	 Sil��6_   ��5e   -   �� *&$DataContext.DeleteTransactionCommand+ �� 	 DataGrid��5f   -   �� .��5g   *     $
 Delete=�6B   5h   '   5i   #   5j      5l      5n      5o      5p      5q      