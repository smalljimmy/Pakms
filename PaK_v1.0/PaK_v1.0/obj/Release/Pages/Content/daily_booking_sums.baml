   M S B A M L   `   `   `  ����   PaK_v1.00    *PaK_v1._0.Pages.Content.daily_booking_sums   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  .���    ContentRoot#��[  .+�]� .+��� $	��Top=�$��	Buchungen��  Heading2#��[ $��0,0,0,8q���   �� Orientation$  
Horizontal=�$	��Top=�.+��� $	��Von��$��0,0,10,0q�(  "System.Windows.Controls.DatePicker  -   $��dtFrom��$��0,0,0,8q�   SelectedDate �� *dtFrom+�� $	��Bis��$��	50,0,10,0q�  -   $
��dtTo��$��0,0,0,8q� �� *dtTo+7  1FirstFloor.ModernUI.Windows.Controls.ModernButton    LupeIconData   IconData# [ $��50,0,0,0q�   EllipseDiameter$ 26Q�   	IconWidth$ 14Q�   
IconHeight$ 14Q�$
��Left=� � ToolTip$ Suchen������ *Commands.search+�� $
��Auto=�$��1��.��&   System.Windows.Controls.DataGrid  -   $	��DG1��   AutoGenerateColumns .     
IsReadOnly . ���� *Bkings+	   Columns	 =  7FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Datum��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ Datum�  $
 Einzahlungen�� �� $ 
Gutschrift�  $
 	Belastung�� �� $ 	Belastung�