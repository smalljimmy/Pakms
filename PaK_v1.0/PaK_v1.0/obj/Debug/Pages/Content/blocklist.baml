   M S B A M L   `   `   `  ����Y  UICP.Controls.PrintableListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListViewICP.Controls.PrintableListView  5       PaK_v1.0'   !PaK_v1._0.Pages.Content.blocklist   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      ^icpTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListView  5        � 	Resources  5       �� 
TargetType �� BasedOn �� Property �� Value   HeaderStyleR  HeaderStyleL��%  '��       7��&	  R     7��&	 �     7���� 5   
   " ��6   8   .�5      ��  � ��$ Stretch=�6;   5      �� 5   
   " ��6%   8   .�5      ��  � ��$ Right=�6;   5      �� 5   
   " ��6%   8   .�5      ��  � ��$
 Left=�6;   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $	��Top=�6,   $��0,0,0,0q�6A   $��0��6R   .+�5      �� $��
Blockliste��6     Heading2#��[ 6*   �� 5      $ 
Horizontal=�6   $��	0,10,0,10q�63   .+�5       7  1FirstFloor.ModernUI.Windows.Controls.ModernButton    PrintIconData   IconData# [ 6#      EllipseDiameter$ 26Q�6p   	   	IconWidth$	 14Q�6�   
   
IconHeight$
 14Q�6�   $
��Left=�6�    � ToolTip$ Drucken��6�   ��6M   �� *Commands.print+6�   �� 5!      $�� ��6   $��80��6#   �� 5"      $	��250��62   $��15,5,0,0q�6>   ��6   �� *Today+6>   5#      5$      �� 5&   
   -   5        $��listView��5&   5    �� AlternationCount$ 2��6   $��1��6(   ��6E   �� *	BlockList+ �� View 5(      �� 5)      .P�5*      �� $��Zimmer��6%    �� Width$ 60��66    �� HeaderContainerStyle# [ 6A    �� CellTemplate 5+      �� 5,      .R�5-   "   ��  �� TextAlignment$
 Left=�6I   ��6,   �� *room_number+6I   5.      50      �� 51      $��Status��6%   $ 80��65   # [ 6@    52      �� 53      .R�54   "   �� $
 Left=�6D   ��6,   �� *status+6D   55      57      �� 58      $
��Name��6%   $	 150��63   # [ 6?    59      �� 5:      .R�5;   "   �� $
 Left=�6B   ��6,   �� *name+6B   5<      5>      �� 5?      $��Block��6%   $ 65��64   # [  6?    5@      �� 5A      .R�5B   "   �� $ Right=�6C   ��6,   �� *block+6C   5C      5E      �� 5F      $��Haben��6%   $ 65��64   # [  6?    5G      �� 5H      .R�5I   "   �� $ Right=�6D   ��6,   �� *credit+6D   5J      5L      �� 5M      $��Tagesrechnung��6%   $	 105��6<   # [  6H    5N      �� 5O      .R�5P   "   �� $ Right=�6H   ��6,   �� *
daily_bill+6H   5Q      5S      5T      5V   
   5W      5X      