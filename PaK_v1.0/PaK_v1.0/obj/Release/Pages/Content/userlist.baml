   M S B A M L   `   `   `  ���� C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PaK_v1._0.ViewModelsPaK_v1._0.ViewModels  &     PaK_v1._0.Pages.Content.userlist   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  .appvm"clr-namespace:PaK_v1._0.ViewModels    � 	Resources  %  PaK_v1._0.ViewModels.UserListVM   
UserListVM  HeaderStyleR �� 
TargetType �� BasedOn �� Property �� Value  HeaderStyleL��%�   &	        &	      7��&	 0     7��  �� " ��8   .���  � ��$ Right=��� " ��8   .���  � ��$
 Left=�.���   ContentRoot#��[  � ColumnDefinitions �� $	��420 ��� $��1 ��� $��4* �.+�]� -    ]�Name$	 dp2��$
��Auto��$
��Auto����. $��0,0,0,0q�.+��� $	��Top=�$��Benutzerliste��  Heading2#��[ $��0,0,0,8q��� -   $��listViewUsers�� �� AlternationCount$ 2��$	��420�� �� SelectedIndex$ 0��$
��Left=����� *
userView+	 �� SelectedItem	 �� *selectedUser+
 �� View
 �� .P��� $��Benutzer�� �� Width$	 100�� �� HeaderContainerStyle# [  �� CellTemplate �� .R���  �� TextAlignment$
 Left=����� *
usr_name+�� $��Vorname��$	 100��# [  �� .R��� $
 Left=����� *usr_firstname+�� $��Nachname��$	 100��# [  �� .R��� $
 Left=����� *usr_lastname+�� $��Rolle��$	 100��# [  �� .R��� $
 Left=����� *roles.role_name+�� $��1��]� $��2��$��2��$
��Auto��$
��Auto����. .+��� $	��Top=�.+��� $��Benutzer bearbeiten��#��[ $��10,0,0,8q��� -    ��Name$
 Form��$	��Top=� �� Orientation$ Vertical=�$��10,0,0,8q�  ��%�   '��       '�� R     7���� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 0,0,0,4q��� " ��8   .���  � ��$	 150����  � ��$ Center=�.+��� .+��� $��Benutzername���� -    ��Name$ TxtUserName��$	��150������ *lUser.usr_name+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . �� .+��� $��Passwort zurücksetzen��G� -   $��passwordBox��$	��150���� .+��� $��Benutzerrolle���� -    ��Name$
 Role��$	��150�� �� DisplayMemberPath$ 	role_name�� �� SelectedValuePath$ role_id������  �� Source# [   �� Path$ Roles� �� SelectedValue �� *lUser.role_id+$ TwoWay=��� .+��� $��Vorname���� -   $ TxtFirstName��$	��150������ *lUser.usr_firstname+$ TwoWay=� . �� .+��� $��Nachname���� -   $ TxtLastName��$	��150������ *lUser.usr_lastname+$ TwoWay=� . �� .+��� $��Telefon���� -	   $ TxtPhone��$	��150������ *lUser.usr_phone+$ TwoWay=��� .+��� $��Mobiltelefon���� -
   $ TxtMobilePhone��$	��150������ *lUser.usr_mobilephone+$ TwoWay=��� $	��Top=�$��10,0,0,0q�.+��� .+��� -    ��Name$ errormessage��$
��Auto��$
��Left=�$	��Top=�$	��330��$
��Wrap=����� *Status+���� *	FgColor+�� $ 
Horizontal=�$	��Top=�$��10,5,0,0q�.+�7  1FirstFloor.ModernUI.Windows.Controls.ModernButton  -   $��btnSave��  DiskIconData   IconData# [    EllipseDiameter$ 26Q�   	IconWidth$ 14Q�   
IconHeight$ 14Q�$
��Left=� � ToolTip$ 	Speichern������ *SaveCommand+����   �� ElementName$  passwordBox��