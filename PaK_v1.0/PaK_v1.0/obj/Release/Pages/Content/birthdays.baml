   M S B A M L   `   `   `  ���� Y  UICP.Controls.PrintableListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListViewICP.Controls.PrintableListView   PaK_v1.0'   !PaK_v1._0.Pages.Content.birthdays   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  ^icpTclr-namespace:ICP.Controls.PrintableListView;assembly=ICP.Controls.PrintableListView    � 	Resources   �� 
TargetType �� BasedOn �� Property �� Value   HeaderStyleR  HeaderStyleL��%�   '��       7��&	  -     7��&	 X     7���� " ��8   .���  � ��$ Stretch=��� " ��8   .���  � ��$ Right=��� " ��8   .���  � ��$
 Left=�.���  � RowDefinitions �� $
��Auto ��� $��* �.+���  �� Orientation$ Vertical=�$	��Top=�$��0,0,0,0q�$��0��.+��� $��Geburtstage��  Heading2#��[ �� $ 
Horizontal=�$��	0,10,0,10q�.+��� $��Am��$��30��$��0,5,0,0q�(  "System.Windows.Controls.DatePicker     SelectedDate �� *dtFrom+ �� Mode$ TwoWay=��� $�� ��$��10��7  1FirstFloor.ModernUI.Windows.Controls.ModernButton    LupeIconData	   IconData#	 [ 
   EllipseDiameter$
 26Q�   	IconWidth$ 14Q�   
IconHeight$ 14Q�$
��Left=� � ToolTip$ Suchen������ *Commands.search+�� $�� ��$��40��    PrintIconData#	 [ $
 26Q�$ 14Q�$ 14Q�$
��Left=�$ Drucken������  �� ElementName$ listView�� �� Path$ PrintCommand�6   0ICP.Controls.PrintableListView.PrintableListView  -   $��listView�� �� AlternationCount$ 2��$��1��   
PageMargin$ 40q�   PageSize$' !793.247244094488,1122.70866141732��   
HeaderSize$ 300,100��   
FooterSize$ 300,180������ *	Birthdays+ �� View �� .P��� $��
Geburtstag�� �� Width$	 100�� �� HeaderContainerStyle# [  �� CellTemplate �� .R���  �� TextAlignment$
 Left=����� *
birthday+�� $
��Name��$	 150��# [  �� .R��� $
 Left=����� *name+�� $��Zimmer��$ 80��# [  �� .R��� $
 Left=����� *room_number+�� $��Status��$ 80��# [  �� .R��� $
 Left=����� *status+   
ReportBody �� .P��� $��
Geburtstag��$	 100��# [  �� DisplayMemberBinding �� *
birthday+�� $
��Name��$	 150��# [  �� *name+�� $��Zimmer��$ 80��# [  �� *room_number+�� $��Status��$ 80��# [  �� *status+   PageHeaderTemplate �� .R�� $��5q� �� $��* ��� $
��Auto �.+��� $��0��$��Center=�$��Center=�
���   �$��20(����� *ParentDataContext.Title+   PageFooterTemplate �� .R��� $ 
Horizontal=�$��1��.+��� $��10(�$��Page Number:���� $��10(����� *
PageNumber+