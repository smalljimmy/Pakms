   M S B A M L   `   `   `  ����Y  UICP.Controls.PrintableListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListViewICP.Controls.PrintableListView  5       PaK_v1.0'   !PaK_v1._0.Pages.Content.birthdays   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      ^icpTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListView  5        � 	Resources  5       �� 
TargetType �� BasedOn �� Property �� Value   HeaderStyleR  HeaderStyleL��%  '��       7��&	  R     7��&	 �     7���� 5   
   " ��6   8   .�5      ��  � ��$ Stretch=�6;   5      �� 5   
   " ��6%   8   .�5      ��  � ��$ Right=�6;   5      �� 5   
   " ��6%   8   .�5      ��  � ��$
 Left=�6;   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $	��Top=�6,   $��0,0,0,0q�6A   $��0��6R   .+�5      �� $��Geburtstage��6     Heading2#��[ 6+   �� 5      $ 
Horizontal=�6   $��	0,10,0,10q�63   .+�5       �� $��Am��6   $��30��6%   $��0,5,0,0q�60   (  "System.Windows.Controls.DatePicker  5!         SelectedDate 6   �� *dtFrom+ �� Mode$ TwoWay=��� 5"      $�� ��6   $��10��6#   7  1FirstFloor.ModernUI.Windows.Controls.ModernButton  5#        LupeIconData	   IconData#	 [ 6#   
   EllipseDiameter$
 26Q�6p      	IconWidth$ 14Q�6�      
IconHeight$ 14Q�6�   $
��Left=�6�    � ToolTip$ Suchen��6�   ��6L   �� *Commands.search+6�   �� 5$      $�� ��6   $��40��6#     5%        PrintIconData#	 [ 6#   $
 26Q�6�   $ 14Q�6�   $ 14Q�6�   $
��Left=�6�   $ Drucken��6�   ��6M   ��  �� ElementName$ listView�� �� Path$ PrintCommand�6�   5&      5'      6   0ICP.Controls.PrintableListView.PrintableListView  5)   
   -   5        $��listView��5)   B    �� AlternationCount$ 2��6    $��1��65      
PageMargin$ 40q�6R      PageSize$' !793.247244094488,1122.70866141732��6b      
HeaderSize$ 300,100��6�      
FooterSize$ 300,180��6�   ��6�   �� *	Birthdays+ �� View 5+      �� 5,      .P�5-      �� $��
Geburtstag��6%    �� Width$	 100��6:    �� HeaderContainerStyle# [ 6F    �� CellTemplate 5.      �� 5/      .R�50   "   ��  �� TextAlignment$
 Left=�6F   ��6,   �� *
birthday+6F   51      53      �� 54      $
��Name��6%   $	 150��63   # [ 6?    55      �� 56      .R�57   "   �� $
 Left=�6B   ��6,   �� *name+6B   58      5:      �� 5;      $��Zimmer��6%   $ 80��66   # [ 6A    5<      �� 5=      .R�5>   "   �� $
 Left=�6I   ��6,   �� *room_number+6I   5?      5A      �� 5B      $��Status��6%   $ 80��65   # [ 6@    5C      �� 5D      .R�5E   "   �� $
 Left=�6D   ��6,   �� *status+6D   5F      5H      5J         
ReportBody 5M      �� 5N      .P�5O      �� $��
Geburtstag��6%   $	 100��6:   # [ 6F    �� DisplayMemberBinding 6{   �� *
birthday+5U      �� 5V      $
��Name��6%   $	 150��63   # [ 6?    6t   �� *name+5\      �� 5]      $��Zimmer��6%   $ 80��65   # [ 6@    6u   �� *room_number+5c      �� 5d      $��Status��6%   $ 80��65   # [ 6@    6u   �� *status+5j      5k         PageHeaderTemplate 5m      �� 5n      .R�5o      � $��5q�6    5p      �� 5q      $��* �6,   69   �� 5r      $
��Auto �6,   6<   .+�5u      �� $��0��6$   $��Center=�61   $��Center=�6N   
���   �$��20(�6�   ��6i   �� *ParentDataContext.Title+6�   5w      5x         PageFooterTemplate 5z      �� 5{      .R�5|      �� $ 
Horizontal=�6!   $��1��6:   .+�5}      �� $��10(�6$   $��Page Number:��62   6H   �� 5~      $��10(�6$   ��62   �� *
PageNumber+6P   5      5�      5�      5�      5�      