   M S B A M L   `   `   `  ����   PaK_v1.0'    !PaK_v1._0.Pages.Content.uncleared   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI    � 	Resources   �� 
TargetType �� BasedOn �� Property �� Value �� Path �� Mode �� Triggers ]� 
Conditions	 �� Property
 �� Value   HeaderStyleR��%F  '��       7��&	  �     7���� " ��8   .���  � ��$ Stretch=���  �@��
IsSelected �� $ 
IsSelected�$ TwoWay=� ]�  �� 	 �@��AlternationIndex$
 1���� 	 �@��
IsSelected
 .  �� 	 �@J�IsMouseOver
 .  ./���  � �� �	#EEEEEEEE�� " ��8   .���  � ��$ Right=�.���   ContentRoot#��[  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��.+��� $��
Abrechnung��  Heading2#��[ �� $E��?Es können mehrere Einträge zur Abrechnung ausgewählt werden.����  �� Orientation$ 
Horizontal=�$��	0,10,0,10q�.+��� $	��von��$��30��$��0,5,0,0q�(  "System.Windows.Controls.DatePicker     SelectedDate �� *dtFrom+�� $�� ��$��20���� $	��bis��$��30��$��0,5,0,0q�   �� *dtTo+�� $�� ��$��10��7  1FirstFloor.ModernUI.Windows.Controls.ModernButton    LupeIconData   IconData# [    EllipseDiameter$ 26Q�   	IconWidth$ 14Q�   
IconHeight$ 14Q�$
��Left=� � ToolTip$ Suchen������ *Commands.search+�� $�� ��$��40��    CashIconData# [ $ 26Q�$ 14Q�$ 14Q�$
��Left=�$ 	Abrechnen������ *Commands.clear+�� $
��Auto=�$��1��.���� .+���  �� AlternationCount$ 2��$	��600��$
��Left=����� *bookingView+ �� View �� .P��� $��Datum�� �� Width$	 100�� �� CellTemplate �� .R���  �� TextAlignment$ Center=����� *Datum+�� $
��Zeit��$	 100�� �� .R��� $ Center=����� *Zeit+�� $��Konto��$	 100�� �� HeaderContainerStyle# [   �� .R��� $ Right=����� *Kontonummer+�� $��Betrag��$	 100��# [   �� .R��� $ Right=����� *
Gutschrift+�� $
��User��$	 100�� �� .R��� $ Center=����� *User+� $��2�� � ColumnDefinitions �� $	��300 ��� $	��100 ��� $
��Auto �.+�6  0FirstFloor.ModernUI.Windows.Controls.BBCodeBlock  $��0��   BBCode$# [b][size=15]Total:[/size][/b]��$
��Left=��� $��1��$
��Bold"�$��15(�$��Right=����� *totalSelectedAmount+