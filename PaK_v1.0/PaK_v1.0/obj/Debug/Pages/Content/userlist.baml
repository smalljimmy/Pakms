   M S B A M L   `   `   `  ����C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PaK_v1._0.ViewModelsPaK_v1._0.ViewModels  5      &     PaK_v1._0.Pages.Content.userlist   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      .appvm"clr-namespace:PaK_v1._0.ViewModels  5        � 	Resources  5      %  PaK_v1._0.ViewModels.UserListVM   
UserListVM  HeaderStyleR �� 
TargetType �� BasedOn �� Property �� Value  HeaderStyleL��%�   &	        &	      7��&	 c     7��  5   
   6   �� 5   
   " ��6%   8   .�5      ��  � ��$ Right=�6;   5      �� 5   
   " ��6%   8   .�5      ��  � ��$
 Left=�6;   5      5      .��5      �   ContentRoot#��[ 6    � ColumnDefinitions 5   
   �� 5      $	��420 �6   �� 5      $��1 �6   �� 5      $��4* �6   .+�5   
   ]� -   5         ]�Name$	 dp2��5      $
��Auto��6!   $
��Auto��6.   ��. $��0,0,0,0q�6Q   .+�5      �� $	��Top=�6   $��Benutzerliste��6-     Heading2#��[ 6B   $��0,0,0,8q�6d   �� 5      -   5        $��listViewUsers��5   ,    �� AlternationCount$ 2��6   $	��420��6A    �� SelectedIndex$ 0��6n   $
��Left=�6�   ��6M   �� *
userView+	 �� SelectedItem	 6�   �� *selectedUser+
 �� View
 5      �� 5      .P�5       �� $��Benutzer��6)    �� Width$	 100��6;    �� HeaderContainerStyle# [ 6G    �� CellTemplate 5!      �� 5"   "   .R�5#   &   ��  �� TextAlignment$
 Left=�6J   ��60   �� *
usr_name+6J   5$   #   5&      �� 5'      $��Vorname��6)   $	 100��6:   # [ 6F    5(      �� 5)   "   .R�5*   &   �� $
 Left=�6O   ��60   �� *usr_firstname+6O   5+   #   5-      �� 5.      $��Nachname��6)   $	 100��6;   # [ 6G    5/      �� 50   "   .R�51   &   �� $
 Left=�6N   ��60   �� *usr_lastname+6N   52   #   54      �� 55      $��Rolle��6)   $	 100��68   # [ 6D    56      �� 57   "   .R�58   &   �� $
 Left=�6Q   ��60   �� *roles.role_name+6Q   59   #   5;      5<      5>      5?      �� 5@   
   $��1��6   ]� 5A   
   $��2��6   $��2��6%   $
��Auto��66   $
��Auto��6C   ��. .+�5B      �� $	��Top=�6   .+�5C      �� $��Benutzer bearbeiten��6   #��[ 67   $��10,0,0,8q�6Y   5D      �� 5E      -   5         ��Name$
 Form��5E      $	��Top=�6'    �� Orientation$ Vertical=�6=   $��10,0,0,8q�6T     5G      ��%  '��       '�� �     7���� 5H      " ��6   .�5I      ��  �@��Orientation$ 
Horizontal=�68   �� 5J       � ��$ 0,0,0,4q�63   5K      �� 5L      " ��6   8   .�5M      ��  � ��$	 150��62   �� 5N       � ��$ Center=�6>   5O      5P      .+�5R      �� .+�5S      �� $��Benutzername��6   �� 5T      -   5         ��Name$ TxtUserName��5T      $	��150��63   ��6?   �� *lUser.usr_name+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 5U      �� 5V      .+�5W      �� $��Passwort zurücksetzen��6   G� 5X      -   5        $��passwordBox��5X   "   $	��150��65   5Z      �� 5[      .+�5\      �� $��Benutzerrolle��6   �� 5]      -   5         ��Name$
 Role��5]      $	��150��6-    �� DisplayMemberPath$ 	role_name��6�    �� SelectedValuePath$ role_id��6�   ��69   ��  �� Source# [   �� Path$ Roles� �� SelectedValue 6�   �� *lUser.role_id+$ TwoWay=�5^      �� 5_      .+�5`      �� $��Vorname��6   �� 5a      -   5        $ TxtFirstName��5a      $	��150��64   ��6@   �� *lUser.usr_firstname+$ TwoWay=� . 5b      �� 5c      .+�5d      �� $��Nachname��6   �� 5e      -   5        $ TxtLastName��5e      $	��150��63   ��6?   �� *lUser.usr_lastname+$ TwoWay=� . 5f      �� 5g      .+�5h      �� $��Telefon��6   �� 5i      -	   5        $ TxtPhone��5i      $	��150��60   ��6<   �� *lUser.usr_phone+$ TwoWay=�5j      �� 5k      .+�5l      �� $��Mobiltelefon��6   �� 5m      -
   5        $ TxtMobilePhone��5m      $	��150��66   ��6B   �� *lUser.usr_mobilephone+$ TwoWay=�5n      5o      �� 5p      $	��Top=�6   $��10,0,0,0q�6.   .+�5q      �� .+�5r      �� -   5         ��Name$ errormessage��5r   J   $
��Auto��6    $
��Left=�6/   $	��Top=�6y   $	��330��6�   $
��Wrap=�6�   ��6a   �� *Status+��6�   �� *	FgColor+6�   5s      �� 5t      $ 
Horizontal=�6   $	��Top=�66   $��10,5,0,0q�6K   .+�5u      7  1FirstFloor.ModernUI.Windows.Controls.ModernButton  -   5        $��btnSave��5u   '     DiskIconData   IconData# [ 66      EllipseDiameter$ 26Q�6�      	IconWidth$ 14Q�6�      
IconHeight$ 14Q�6�   $
��Left=�6�    � ToolTip$ 	Speichern��6  ��6_   �� *SaveCommand+��6   ��   �� ElementName$  passwordBox��5|      5}      5~      5      5�      5�      