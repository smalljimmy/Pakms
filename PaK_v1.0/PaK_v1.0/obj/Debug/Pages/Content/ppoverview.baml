   M S B A M L   `   `   `  ����Y  UICP.Controls.PrintableListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListViewICP.Controls.PrintableListView  5       PaK_v1.0(   "PaK_v1._0.Pages.Content.ppoverview   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      ^icpTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListView  5        � 	Resources  5       �� 
TargetType �� BasedOn �� Property �� Value   HeaderStyleR  HeaderStyleL��%  '��       7��&	  R     7��&	 �     7���� 5   
   " ��6   8   .�5      ��  � ��$ Stretch=�6;   5      �� 5   
   " ��6%   8   .�5      ��  � ��$ Right=�6;   5      �� 5   
   " ��6%   8   .�5      ��  � ��$
 Left=�6;   5      5      .��5      ]� $��0,0,0,0q�6   .+�5   
   ��  �� Orientation$ Vertical=�6   $	��Top=�6,   $��0,0,0,0q�6A   .+�5      ��   Heading2#��[ 6/   ��6   �� *Title+6/   �� 5      $ 
Horizontal=�6   $��	0,10,0,10q�63   .+�5      �� $��Am��6   $��30��6%   $��0,5,0,0q�60   (  "System.Windows.Controls.DatePicker  5         SelectedDate 6   �� *dtFrom+ �� Mode$ TwoWay=��� 5       $�� ��6   $��10��6#   7  1FirstFloor.ModernUI.Windows.Controls.ModernButton  5!        LupeIconData   IconData# [ 6#   	   EllipseDiameter$	 26Q�6p   
   	IconWidth$
 14Q�6�      
IconHeight$ 14Q�6�   $
��Left=�6�    � ToolTip$ Suchen��6�   ��6L   �� *Commands.search+6�   �� 5"      $�� ��6   $��40��6#     5#        PrintIconData# [ 6#   $	 26Q�6p   $
 14Q�6�   $ 14Q�6�   $
��Left=�6�   $ Drucken��6�   ��6M   �� *Commands.print+6�   5$      5%      �� 5&   
   .+�5'      �� -   5        $��listView��5'   ,    �� AlternationCount$ 2��6   ��6<   �� *
persView+ �� View 5(      �� 5)      .P�5*      �� $��Zimmer��6)    �� Width$ 80��6:    �� HeaderContainerStyle# [ 6E    �� CellTemplate 5+      �� 5,   "   .R�5-   &   ��  �� TextAlignment$
 Left=�6F   ��60   �� *Room+6F   5.   #   50      �� 51      $
��Name��6)   $	 100��67   # [ 6C    52      �� 53   "   .R�54   &   �� $
 Left=�6J   ��60   �� *
Lastname+6J   55   #   57      �� 58      $��Vorname��6)   $	 100��6:   # [ 6F    59      �� 5:   "   .R�5;   &   �� $
 Left=�6K   ��60   �� *	Firstname+6K   5<   #   5>      �� 5?      $��	Pseudonym��6)   $	 100��6<   # [ 6H    5@      �� 5A   "   .R�5B   &   �� $
 Left=�6K   ��60   �� *	Pseudonym+6K   5C   #   5E      �� 5F      $��
Geburtstag��6)   $ 80��6=   # [ 6H    5G      �� 5H   "   .R�5I   &   �� $
 Left=�6J   ��60   �� *
Birthday+6J   5J   #   5L      �� 5M      $��
Geburtsort��6)   $	 100��6=   # [ 6I    5N      �� 5O   "   .R�5P   &   �� $
 Left=�6L   ��60   �� *
Birthplace+6L   5Q   #   5S      �� 5T      $��Nation��6)   $ 60��69   # [ 6D    5U      �� 5V   "   .R�5W   &   �� $
 Left=�6M   ��60   �� *Countrycode+6M   5X   #   5Z      �� 5[      $��
Passnummer��6)   $	 100��6=   # [ 6I    5\      �� 5]   "   .R�5^   &   �� $
 Left=�6L   ��60   �� *
Passportid+6L   5_   #   5a      5b      5d      5e      5f      5g      