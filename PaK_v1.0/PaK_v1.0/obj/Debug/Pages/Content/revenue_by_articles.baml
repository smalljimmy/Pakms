   M S B A M L   `   `   `  ����  PaK_v1.01    +PaK_v1._0.Pages.Content.revenue_by_articles   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5        � 	Resources  5       �� 
TargetType �� BasedOn   HeaderStyleR �� Property �� Value  HeaderStyleL��%�   '��       7��&	  &     7��&	 v     7���� 5
   
   " ��6   8   5      �� 5   
   " ��6%   8   .�5      ��  � ��$ Right=�6;   5      �� 5   
   " ��6%   8   .�5      ��  � ��$
 Left=�6;   5      5      .��5"      �   ContentRoot#��[ 6    � RowDefinitions 5#   
   �� 5$      $
��Auto �6   �� 5%      $��* �6   �� 5&      $
��Auto �6   .+�5(   
   �� $��0��6   .+�5*      ��   Heading2#��[ 6/   ��6   �� *title+6/   �� 5+       �� Orientation$ 
Horizontal=�6   $��	0,10,0,10q�63   .+�5,      �� $	��von��6   $��30��6&   $��0,5,0,0q�61   (  "System.Windows.Controls.DatePicker  5-         SelectedDate 6   �� *dtFrom+�� 5.      $�� ��6   $��20��6#   �� 5/      $	��bis��6   $��30��6&   $��0,5,0,0q�61     50       6   �� *dtTo+�� 51      $�� ��6   $��10��6#   7  1FirstFloor.ModernUI.Windows.Controls.ModernButton  53        LupeIconData   IconData# [ 6#   	   EllipseDiameter$	 26Q�6p   
   	IconWidth$
 14Q�6�      
IconHeight$ 14Q�6�   $
��Left=�6�    � ToolTip$ Suchen��6�   ��6L   �� *Commands.search+6�   �� 54      $�� ��6   $��40��6#     55        PrintIconData# [ 6#   $	 26Q�6p   $
 14Q�6�   $ 14Q�6�   $
��Left=�6�   $ Drucken��6�   ��6M   �� *Commands.print+6�   57      58      �� 5:   
   $
��Auto=�6   $��1��6;   .��5;      �� .+�5<      ��  �� AlternationCount$ 2��6   $	��600��6P   $
��Left=�6\   ��60   �� *	revView+ �� View 5=      �� 5>      .P�5?      ��  �� Width$	 200��6H    �� HeaderContainerStyle# [ 6T   ��6-   �� *	hdrname+ �� CellTemplate 5A   &   �� 5B   &   .R�5C   *   ��  �� TextAlignment$
 Left=�6J   ��64   �� *name+6J   5D   '   5F      �� 5G      $��Anzahl��6-   $	 100��6=   # [  6I    5H   "   �� 5I   &   .R�5J   *   �� $ Right=�6L   ��64   �� *number+6L   5K   '   5M      �� 5N      $��Betrag��6-   $	 100��6=   # [  6I    5O   "   �� 5P   &   .R�5Q   *   �� $ Right=�6L   ��64   �� *amount+6L   5R   '   5T      5U      5W      5Y      5Z      � 5\   
   $��2��6    � ColumnDefinitions 5]      �� 5^      $	��300 �6#   �� 5_      $	��100 �6#   �� 5`      $
��Auto �6#   .+�5b      6  0FirstFloor.ModernUI.Windows.Controls.BBCodeBlock  $��0��6      BBCode$# [b][size=15]Total:[/size][/b]��6.   $
��Left=�6U   �� 5c      $��1��6   $
��Bold"�6(   $��15(�6:   $��Right=�6e   ��6H   �� *totalAmount+6e   5e      5g      5h      