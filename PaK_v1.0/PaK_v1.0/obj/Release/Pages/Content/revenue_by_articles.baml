   M S B A M L   `   `   `  ����   PaK_v1.01    +PaK_v1._0.Pages.Content.revenue_by_articles   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI    � 	Resources   �� 
TargetType �� BasedOn   HeaderStyleR �� Property �� Value  HeaderStyleL��%�   '��       7��&	       7��&	 :     7���� " ��8   �� " ��8   .���  � ��$ Right=��� " ��8   .���  � ��$
 Left=�.���   ContentRoot#��[  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��.+���   Heading2#��[ ���� *title+��  �� Orientation$ 
Horizontal=�$��	0,10,0,10q�.+��� $	��von��$��30��$��0,5,0,0q�(  "System.Windows.Controls.DatePicker     SelectedDate �� *dtFrom+�� $�� ��$��20���� $	��bis��$��30��$��0,5,0,0q�   �� *dtTo+�� $�� ��$��10��7  1FirstFloor.ModernUI.Windows.Controls.ModernButton    LupeIconData   IconData# [ 	   EllipseDiameter$	 26Q�
   	IconWidth$
 14Q�   
IconHeight$ 14Q�$
��Left=� � ToolTip$ Suchen������ *Commands.search+�� $�� ��$��40��    PrintIconData# [ $	 26Q�$
 14Q�$ 14Q�$
��Left=�$ Drucken������ *Commands.print+�� $
��Auto=�$��1��.���� .+���  �� AlternationCount$ 2��$	��600��$
��Left=����� *	revView+ �� View �� .P���  �� Width$	 200�� �� HeaderContainerStyle# [ ���� *	hdrname+ �� CellTemplate �� .R���  �� TextAlignment$
 Left=����� *name+�� $��Anzahl��$	 100��# [   �� .R��� $ Right=����� *number+�� $��Betrag��$	 100��# [   �� .R��� $ Right=����� *amount+� $��2�� � ColumnDefinitions �� $	��300 ��� $	��100 ��� $
��Auto �.+�6  0FirstFloor.ModernUI.Windows.Controls.BBCodeBlock  $��0��   BBCode$# [b][size=15]Total:[/size][/b]��$
��Left=��� $��1��$
��Bold"�$��15(�$��Right=����� *totalAmount+