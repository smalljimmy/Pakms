   M S B A M L   `   `   `  ����  PaK_v1.0'    !PaK_v1._0.Pages.Content.uncleared   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5        � 	Resources  5	       �� 
TargetType �� BasedOn �� Property �� Value �� Path �� Mode �� Triggers ]� 
Conditions	 �� Property
 �� Value   HeaderStyleR��%�  '��       7��&	  �    7���� 5   
   " ��6   8   .�5      ��  � ��$ Stretch=�6;   �� 5       �@��
IsSelected 6+   �� $ 
IsSelected�$ TwoWay=� 5      ]� 5       5      �� 5      	 �@��AlternationIndex$
 1��6M   �� 5      	 �@��
IsSelected
 .  6:   �� 5      	 �@J�IsMouseOver
 .  6;   ./�5      ��  � �� �	#EEEEEEEE63   5      5      �� 5   
   " ��6%   8   .�5      ��  � ��$ Right=�6;   5      5      .��5       �   ContentRoot#��[ 6    � RowDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $��* �6   �� 5$      $
��Auto �6   .+�5&   
   �� $��0��6   .+�5'      �� $��
Abrechnung��6     Heading2#��[ 6*   �� 5(      $E��?Es können mehrere Einträge zur Abrechnung ausgewählt werden.��6   �� 5)       �� Orientation$ 
Horizontal=�6   $��	0,10,0,10q�63   .+�5*      �� $	��von��6   $��30��6&   $��0,5,0,0q�61   (  "System.Windows.Controls.DatePicker  5+         SelectedDate 6   �� *dtFrom+�� 5,      $�� ��6   $��20��6#   �� 5-      $	��bis��6   $��30��6&   $��0,5,0,0q�61     5.       6   �� *dtTo+�� 5/      $�� ��6   $��10��6#   7  1FirstFloor.ModernUI.Windows.Controls.ModernButton  51        LupeIconData   IconData# [ 6#      EllipseDiameter$ 26Q�6p      	IconWidth$ 14Q�6�      
IconHeight$ 14Q�6�   $
��Left=�6�    � ToolTip$ Suchen��6�   ��6L   �� *Commands.search+6�   �� 52      $�� ��6   $��40��6#     53        CashIconData# [ 6#   $ 26Q�6o   $ 14Q�6�   $ 14Q�6�   $
��Left=�6�   $ 	Abrechnen��6�   ��6L   �� *Commands.clear+6�   55      56      �� 58   
   $
��Auto=�6   $��1��6;   .��59      �� .+�5;      ��  �� AlternationCount$ 2��6   $	��600��6T   $
��Left=�6`   ��60   �� *bookingView+ �� View 5<      �� 5=      .P�5?      �� $��Datum��6-    �� Width$	 100��6<    �� CellTemplate 5@   "   �� 5A   &   .R�5B   *   ��  �� TextAlignment$ Center=�6K   ��64   �� *Datum+6K   5C   '   5E      �� 5F      $
��Zeit��6-   $	 100��6;    5G   "   �� 5H   &   .R�5I   *   �� $ Center=�6J   ��64   �� *Zeit+6J   5J   '   5L      �� 5M      $��Konto��6-   $	 100��6<    �� HeaderContainerStyle# [  6H    5N   "   �� 5O   &   .R�5P   *   �� $ Right=�6Q   ��64   �� *Kontonummer+6Q   5Q   '   5S      �� 5T      $��Betrag��6-   $	 100��6=   # [  6I    5U   "   �� 5V   &   .R�5W   *   �� $ Right=�6P   ��64   �� *
Gutschrift+6P   5X   '   5Z      �� 5[      $
��User��6-   $	 100��6;    5\   "   �� 5]   &   .R�5^   *   �� $ Center=�6J   ��64   �� *User+6J   5_   '   5a      5b      5d      5f      5g      � 5i   
   $��2��6    � ColumnDefinitions 5j      �� 5k      $	��300 �6#   �� 5l      $	��100 �6#   �� 5m      $
��Auto �6#   .+�5o      6  0FirstFloor.ModernUI.Windows.Controls.BBCodeBlock  $��0��6      BBCode$# [b][size=15]Total:[/size][/b]��6.   $
��Left=�6U   �� 5p      $��1��6   $
��Bold"�6(   $��15(�6:   $��Right=�6m   ��6H   �� *totalSelectedAmount+6m   5r      5t      5u      