   M S B A M L   `   `   `  ����C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PaK_v1._0.utilitiesPaK_v1._0.utilities  5      Y UICP.Controls.PrintableListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListViewICP.Controls.PrintableListView 5      a ]Itenso.Windows.Controls.ListViewLayout, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null�dclr-namespace:Itenso.Windows.Controls.ListViewLayout;assembly=Itenso.Windows.Controls.ListViewLayout&Itenso.Windows.Controls.ListViewLayout 5	      5clr-namespace:PaK_v1._0.ContentPaK_v1._0.Content  5
          PaK_v1._0.Content.cleared   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      1	utilities!clr-namespace:PaK_v1._0.utilities  5      ^icpTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListView  5      octrldclr-namespace:Itenso.Windows.Controls.ListViewLayout;assembly=Itenso.Windows.Controls.ListViewLayout  5	      +localclr-namespace:PaK_v1._0.Content  5
        � 	Resources  5         AcctSrc  BoolToVisibilityConverter2 �� 
TargetType �� BasedOn �� Property �� Value  HeaderStyleR  HeaderStyleL  HdrTemplate��%�  &	        &	      '�� &     7��&	 x     7��&	 �     7��&	     �� 5   
   6   �� 5   
   6'   �� 5   
   " ��6   8   .�5      ��  � ��$ Stretch=�6;   5      �� 5   
   " ��6%   8   .�5      ��  � ��$ Right=�6;   5      �� 5    
   " ��6%   8   .�5!      ��  � ��$
 Left=�6;   5"      �� 5$   
   .R�5%      �� $��Right=�6   ��64   �� 5&      5(      .��5*      �   ContentRoot#��[ 6    � ColumnDefinitions 5+   
   �� 5-      $	��510 �6   �� 5.      $��1 �6   �� 5/      $��4* �6   .+�52   
   ]� -   5         ]�Name$	 dp2��52      $
��Auto��6!   $
��Auto��6.   ��. $��0,0,0,0q�6Q   .+�53      �� $	��Top=�6   $��Abrechnungen��6-     Heading2#��[ 6A   $��0,0,0,8q�6c   �� 54       �� Orientation$ 
Horizontal=�6   $	��Top=�62   $��	0,10,0,10q�6G   .+�55      �� $	��von��6   $��30��6&   $��0,5,0,0q�61   (  "System.Windows.Controls.DatePicker  56      -   5        $��dpFrom��56         SelectedDate 6+   �� *dtFrom+�� 57      $�� ��6   $��20��6#   �� 58      $	��bis��6   $��30��6&   $��0,5,0,0q�61     59      -   5        $
��dpTo��59       6*   �� *dtTo+�� 5;      $�� ��6   $��10��6#   7  1FirstFloor.ModernUI.Windows.Controls.ModernButton  5<        LupeIconData	   IconData#	 [ 6#   
   EllipseDiameter$
 26Q�6p      	IconWidth$ 14Q�6�      
IconHeight$ 14Q�6�   $
��Left=�6�    � ToolTip$ Suchen��6�   ��6L   �� *Commands.search+6�     5=        PrintIconData#	 [ 6#   $
 26Q�6z   $ 14Q�6�   $ 14Q�6�   $
��Left=�6�   $ Drucken��6�   ��6M   �� *Commands.printClearences+6�   5>      �� 5@      -   5        $��listViewClearances��5@   ,    �� AlternationCount$ 2��6   $	��410��6F    �� SelectedIndex$ 0��6x   $
��Left=�6�   ��6R   �� *clearanceView+ �� SelectedItem 6�   �� *selectedClearance+ �� View 5A      �� 5B      .P�5C      �� $��Nr��6%    �� Width$ 80��61    �� CellTemplate 5D      �� 5E      .R�5F   %   ��  �� TextAlignment$ Center=�6G   ��6/   �� *clr_id+6G   5G      5I      �� 5K      $��Datum��6%   $ 80��64    5L      �� 5M      .R�5N   "   �� $ Right=�6V   ��6,   �� *
clr_date+ �� StringFormat$ d��6V   5O      5Q      �� 5R      $
��Zeit��6%   $ 80��63    5S      �� 5T      .R�5U   "   �� $ Right=�6V   ��6,   �� *
clr_date+$ t��6V   5V      5X      �� 5Z      $��Betrag��6%   $ 80��65    �� HeaderContainerStyle# [ 6@    5[      �� 5\      .R�5]   "   �� $ Right=�6E   ��6,   �� *	clr_sum+6E   5^      5`      �� 5a      $
��User��6%   $ 80��63    5b      �� 5c      .R�5d   "   �� $
 Left=�6L   ��6,   �� *users.usr_name+6L   5e      5g      5h      5j      5k      �� 5l   
   $��1��6   ]� 5m   
   $��2��6   $��2��6%   $
��Auto��66   $
��Auto��6C   ��. .+�5n      �� $	��Top=�6   .+�5o        #	 [ 6#   $
 26Q�6�   $ 14Q�6�   $ 14Q�6�   $
��Left=�6�   $��	10,0,0,10q�6�   $ Drucken��6�   ��6M   ��  �� ElementName$ listView�� �� Path$ PrintCommand�6�   5p      �� 5q      $	��Top=�6   $��10,0,0,0q�6.   .+�5s      6  0ICP.Controls.PrintableListView.PrintableListView  -   5        $��listView��5s   =   $ 2��6(      
PageMargin$ 40q�6M      PageSize$' !793.247244094488,1122.70866141732��6]      
HeaderSize$ 300,100��6�      
FooterSize$ 300,180��6�   ��6�   �� $ listViewClearances��$, &SelectedItem.bookingListCollectionView� 5t      �� 5u      .P�5v      �� $��Datum��6-   $	 100��6<    5w   "   �� 5x   &   .R�5y   *   �� $ Right=�6^   ��64   �� *
bkg_date+$ d��6^   5z   '   5|      �� 5}      $
��Zeit��6-   $ 70��6;    5~   "   �� 5   &   .R�5�   *   �� $ Right=�6^   ��64   �� *
bkg_date+$ t��6^   5�   '   5�      �� 5�      $��Konto��6-   $ 90��6=   # [ 6H    5�   "   �� 5�   &   .R�5�   *   �� $ Right=�6U   ��64   �� *accounts.act_id+6U   5�   '   5�      �� 5�      $��Betrag��6-   $	 100��6=   # [ 6I    5�   "   �� 5�   &   .R�5�   *   �� $ Right=�6P   ��64   �� *
bkg_amount+6P   5�   '   5�      �� 5�      $
��User��6-   $	 100��6;    5�   "   �� 5�   &   .R�5�   .   �� $
 Left=�6X   ��68   �� *users.usr_name+6X   5�   '   5�      5�         
ReportBody 5�      �� 5�      .P�5�      �� $��Nr��6-   $ 40��69   # [ 6m    �� DisplayMemberBinding 6E   �� *bkg_id+6m   �� 5�      $��Datum��6-   $	 100��6<   # [ 6�    6H   �� *
bkg_date+$ d��6�   �� 5�      $
��Zeit��6-   $	 100��6<   # [ 6�    6H   �� *
bkg_date+$ t��6�   �� 5�      $��Betrag��6-   $	 100��6=   # [ 6u    6I   �� *
bkg_amount+6u   �� 5�      $
��Name��6-   $	 100��6<   # [ 6x    6H   �� *users.usr_name+6x   5�         PageHeaderTemplate 5�      �� 5�      .R�5�      � $��5q�6#   $��Center=�6.     � RowDefinitions  5�   "   �� 5�   &   $��* �64   6A   �� 5�   &   $
��Auto �64   6D   .+�5�   "   �� $��	20,50,0,0q�6,   $��1��6?   $
��Left=�6L   $��Center=�6g   
���   �
�������$��20(�6�   $��25��6�   �� 5�   *   $�  ��6.    �� 5�   *   $�Abrechnung vom ��6.    �� 5�   *   �6.   �� *ParentDataContext.dtFrom+$ d�� �� 5�   *   $� bis ��6.    �� 5�   *   �6.   �� *ParentDataContext.dtTo+$ d�� �� 5�   *   $�  ��6.   5�   #   5�      5�      !   PageFooterTemplate! 5�      �� 5�      .R�5�      �� $ 
Horizontal=�6%   $��20,0,5,0q�6>   .+�5�      �� $��Center=�6(   $��2q�6C   $��Count:��6N   6^   �� 5�   "   $��Center=�6,   $��2q�6G   ��6R   �� *ParentDataContext.Count+6}   �� 5�      $��Center=�6(   $��2q�6C   $��
Summe: EUR��6N   6b   �� 5�   "   $��Center=�6,   $��2q�6G   ��6R   �� *ParentDataContext.Sum+6{   5�      5�      5�      5�      5�      5�      5�      