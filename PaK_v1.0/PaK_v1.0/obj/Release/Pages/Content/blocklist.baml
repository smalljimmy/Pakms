   M S B A M L   `   `   `  ���� Y  UICP.Controls.PrintableListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListViewICP.Controls.PrintableListView   PaK_v1.0'   !PaK_v1._0.Pages.Content.blocklist   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  ^icpTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListView    � 	Resources   �� 
TargetType �� BasedOn �� Property �� Value   HeaderStyleR  HeaderStyleL��%�   '��       7��&	  -     7��&	 X     7���� " ��8   .���  � ��$ Stretch=��� " ��8   .���  � ��$ Right=��� " ��8   .���  � ��$
 Left=�.���  � RowDefinitions �� $
��Auto ��� $��* �.+���  �� Orientation$ Vertical=�$	��Top=�$��0,0,0,0q�$��0��.+��� $��
Blockliste��  Heading2#��[ �� $ 
Horizontal=�$��	0,10,0,10q�.+�7  1FirstFloor.ModernUI.Windows.Controls.ModernButton    PrintIconData   IconData# [    EllipseDiameter$ 26Q�	   	IconWidth$	 14Q�
   
IconHeight$
 14Q�$
��Left=� � ToolTip$ Drucken������ *Commands.print+�� $�� ��$��80���� $	��250��$��15,5,0,0q����� *Today+�� -   $��listView�� �� AlternationCount$ 2��$��1������ *	BlockList+ �� View �� .P��� $��Zimmer�� �� Width$ 60�� �� HeaderContainerStyle# [  �� CellTemplate �� .R���  �� TextAlignment$
 Left=����� *room_number+�� $��Status��$ 80��# [  �� .R��� $
 Left=����� *status+�� $
��Name��$	 150��# [  �� .R��� $
 Left=����� *name+�� $��Block��$ 65��# [   �� .R��� $ Right=����� *block+�� $��Haben��$ 65��# [   �� .R��� $ Right=����� *credit+�� $��Tagesrechnung��$	 105��# [   �� .R��� $ Right=����� *
daily_bill+