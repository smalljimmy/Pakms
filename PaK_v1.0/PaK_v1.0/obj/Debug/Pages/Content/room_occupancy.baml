   M S B A M L   `   `   `  ����Y  UICP.Controls.PrintableListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListViewICP.Controls.PrintableListView  5       PaK_v1.0,   &PaK_v1._0.Pages.Content.room_occupancy   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      ^icpTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListView  5        � 	Resources  5       �� 
TargetType �� BasedOn �� Property �� Value   HeaderStyleR  HeaderStyleL��%j  '��       7��&	  �     7��&	 �     7���� 5   
   " ��6   8   .�5      ��  � ��$ Stretch=�6;   �� 5       � ��
 �����6,   �� 5       � ��$ 1,1,1,1q�60   5      �� 5   
   " ��6%   8   .�5      ��  � ��$ Right=�6;   5      �� 5   
   " ��6%   8   .�5      ��  � ��$
 Left=�6;   5      5$      .��5'      �  � RowDefinitions 5(   
   �� 5)      $
��Auto �6   �� 5*      $��* �6   .+�5-   
   ��  �� Orientation$ Vertical=�6   $	��Top=�6,   $��0,0,0,0q�6A   $��0��6R   .+�5.      ��   Heading2#��[ 6/   ��6   �� *Title+6/   �� 5/      $ 
Horizontal=�6   $��	0,10,0,10q�63   .+�50      7  1FirstFloor.ModernUI.Windows.Controls.ModernButton    PrintIconData   IconData# [ 6#      EllipseDiameter$ 26Q�6p   	   	IconWidth$	 14Q�6�   
   
IconHeight$
 14Q�6�   $
��Left=�6�    � ToolTip$ Drucken��6�   ��6M   �� *Commands.print+6�   �� 51      $�� ��6   $��80��6#   �� 52      $	��250��62   $��15,5,0,0q�6>   ��6   �� *Today+6>   53      54      �� 56   
   -   5        $��listView��56   5    �� AlternationCount$ 2��6   $��1��6(   ��6E   �� *	Occupancy+ �� View 57      �� 58      .P�59      �� $��Zimmer��6%    �� Width$ 90��66    �� HeaderContainerStyle# [ 6A    �� CellTemplate 5:      �� 5;      .R�5<   "   ��  �� TextAlignment$
 Left=�6I   ��6,   �� *room_number+6I   5=      5?      �� 5@      $��Konto��6%   $ 60��64   # [ 6?    5A      �� 5B      .R�5C   "   �� $
 Left=�6H   ��6,   �� *
account_id+6H   5D      5F      �� 5G      $��Künstlername��6%   $	 180��6;   # [ 6G    5H      �� 5I      .R�5J   "   �� $
 Left=�6G   ��6,   �� *	pseudonym+6G   5K      5M      �� 5N      $��	Bemerkung��6%   $	 260��68   # [ 6D    5O      �� 5P      .R�5Q   "   �� $
 Left=�6C   ��6,   �� *notes+6C   5R      5T      �� 5U      $��Tarif��6%   $	 150��64   # [ 6@    5V      �� 5W      .R�5X   "   �� $
 Left=�6D   ��6,   �� *tariff+6D   5Y      5[      5\      5^      5_      5a      