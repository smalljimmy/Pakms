   M S B A M L   `   `   `  ����C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PaK_v1._0.ContentPaK_v1._0.Content  5      $    PaK_v1._0.Content.booking_list   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      +localclr-namespace:PaK_v1._0.Content  5      .��5
      ]� .+�5   
   �� $	��Top=�6   $��	Buchungen��6)      Heading2#��[  6:   $��0,0,0,8q�6\   �� 5   
     �� Orientation$  
Horizontal=�6   $	��Top=�6.   .+�5      �� $	��Von��6   $��0,0,10,0q�6$   (  "System.Windows.Controls.DatePicker  5      -   5        $��dtFrom��5      $��0,0,0,8q�6'   �� 5      $	��Bis��6   $��	50,0,10,0q�6$     5      -   5        $
��dtTo��5      $��0,0,0,8q�6%   7  1FirstFloor.ModernUI.Windows.Controls.ModernButton  5      -   5        $��	btnSearch��5   Z     LupeIconData   IconData# [ 6   $��50,0,0,0q�6H      EllipseDiameter$ 26Q�6k      	IconWidth$ 14Q�6�      
IconHeight$ 14Q�6�   $
��Left=�6�    � ToolTip$ Suchen��6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $	��DG1��5         AutoGenerateColumns .     
IsReadOnly . ��6   ��    Columns 5      =  7FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Datum��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 69   �� *Datum+  5      $
	 Zeit��6)   
 67   �� *Zeit+  5      $	 Kontonummer��6)   
 6>   �� *Kontonummer+  5      $	 
Gutschrift��6)   
 6=   �� *
Gutschrift+  5      $	 	Belastung��6)   
 6<   �� *	Belastung+  5      $	 Zimmer��6)   
 69   �� *Zimmer+  5      $
	 User��6)   
 67   �� *User+5!      5"      5#      