   M S B A M L   `   `   `  ���� C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PaK_v1._0.utilitiesPaK_v1._0.utilities  Y UICP.Controls.PrintableListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListViewICP.Controls.PrintableListView a ]Itenso.Windows.Controls.ListViewLayout, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null�dclr-namespace:Itenso.Windows.Controls.ListViewLayout;assembly=Itenso.Windows.Controls.ListViewLayout&Itenso.Windows.Controls.ListViewLayout 5clr-namespace:PaK_v1._0.ContentPaK_v1._0.Content      PaK_v1._0.Content.cleared   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  1	utilities!clr-namespace:PaK_v1._0.utilities  ^icpTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListView  octrldclr-namespace:Itenso.Windows.Controls.ListViewLayout;assembly=Itenso.Windows.Controls.ListViewLayout  +localclr-namespace:PaK_v1._0.Content    � 	Resources     AcctSrc  BoolToVisibilityConverter2 �� 
TargetType �� BasedOn �� Property �� Value  HeaderStyleR  HeaderStyleL  HdrTemplate��%�   &	        &	      '�� 
     7��&	 7     7��&	 b     7��&	 �     �� �� �� " ��8   .���  � ��$ Stretch=��� " ��8   .���  � ��$ Right=��� " ��8   .���  � ��$
 Left=��� .R��� $��Right=����� .���   ContentRoot#��[  � ColumnDefinitions �� $	��510 ��� $��1 ��� $��4* �.+�]� -    ]�Name$	 dp2��$
��Auto��$
��Auto����. $��0,0,0,0q�.+��� $	��Top=�$��Abrechnungen��  Heading2#��[ $��0,0,0,8q���  �� Orientation$ 
Horizontal=�$	��Top=�$��	0,10,0,10q�.+��� $	��von��$��30��$��0,5,0,0q�(  "System.Windows.Controls.DatePicker  -   $��dpFrom��   SelectedDate �� *dtFrom+�� $�� ��$��20���� $	��bis��$��30��$��0,5,0,0q�  -   $
��dpTo�� �� *dtTo+�� $�� ��$��10��7  1FirstFloor.ModernUI.Windows.Controls.ModernButton    LupeIconData	   IconData#	 [ 
   EllipseDiameter$
 26Q�   	IconWidth$ 14Q�   
IconHeight$ 14Q�$
��Left=� � ToolTip$ Suchen������ *Commands.search+    PrintIconData#	 [ $
 26Q�$ 14Q�$ 14Q�$
��Left=�$ Drucken������ *Commands.printClearences+�� -   $��listViewClearances�� �� AlternationCount$ 2��$	��410�� �� SelectedIndex$ 0��$
��Left=����� *clearanceView+ �� SelectedItem �� *selectedClearance+ �� View �� .P��� $��Nr�� �� Width$ 80�� �� CellTemplate �� .R���  �� TextAlignment$ Center=����� *clr_id+�� $��Datum��$ 80�� �� .R��� $ Center=����� *
clr_date+ �� StringFormat$ d���� $
��Zeit��$ 80�� �� .R��� $ Center=����� *
clr_date+$ t���� $��Betrag��$ 80�� �� HeaderContainerStyle# [  �� .R��� $ Right=����� *	clr_sum+�� $
��User��$ 80�� �� .R��� $ Center=����� *users.usr_name+�� $��1��]� $��2��$��2��$
��Auto��$
��Auto����. .+��� $	��Top=�.+�  #	 [ $
 26Q�$ 14Q�$ 14Q�$
��Left=�$��	10,0,0,10q�$ Drucken������  �� ElementName$ listView�� �� Path$ PrintCommand��� $	��Top=�$��10,0,0,0q�.+�6  0ICP.Controls.PrintableListView.PrintableListView  -   $��listView��$ 2��   
PageMargin$ 40q�   PageSize$' !793.247244094488,1122.70866141732��   
HeaderSize$ 300,100��   
FooterSize$ 300,180������ $ listViewClearances��$, &SelectedItem.bookingListCollectionView� �� .P��� $��Datum��$	 100�� �� .R��� $ Center=����� *
bkg_date+$ d���� $
��Zeit��$ 70�� �� .R��� $ Center=����� *
bkg_date+$ t���� $��Konto��$ 90��# [  �� .R��� $ Right=����� *accounts.act_id+�� $��Betrag��$	 100��# [  �� .R��� $ Right=����� *
bkg_amount+�� $
��User��$	 100�� �� .R��� $ Center=����� *users.usr_name+   
ReportBody �� .P��� $��Nr��$ 40��# [  �� DisplayMemberBinding �� *bkg_id+�� $��Datum��$	 100��# [  �� *
bkg_date+$ d���� $
��Zeit��$	 100��# [  �� *
bkg_date+$ t���� $��Betrag��$	 100��# [  �� *
bkg_amount+�� $
��Name��$	 100��# [  �� *users.usr_name+   PageHeaderTemplate �� .R�� $��5q�$��Center=�  � RowDefinitions  �� $��* ��� $
��Auto �.+��� $��	20,50,0,0q�$��1��$
��Left=�$��Center=�
���   �
�������$��20(�$��25���� $�  �� �� $�Abrechnung vom �� �� ��� *ParentDataContext.dtFrom+$ d�� �� $� bis �� �� ��� *ParentDataContext.dtTo+$ d�� �� $�  ��!   PageFooterTemplate! �� .R��� $ 
Horizontal=�$��20,0,5,0q�.+��� $��Center=�$��2q�$��Count:���� $��Center=�$��2q����� *ParentDataContext.Count+�� $��Center=�$��2q�$��
Summe: EUR���� $��Center=�$��2q����� *ParentDataContext.Sum+