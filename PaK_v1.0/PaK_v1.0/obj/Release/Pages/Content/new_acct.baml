   M S B A M L   `   `   `  ���� C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PaK_v1._0.ViewModelsPaK_v1._0.ViewModels  9!clr-namespace:PaK_v1._0.utilitiesPaK_v1._0.utilities       PaK_v1._0.Content.new_acct   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  .appvm"clr-namespace:PaK_v1._0.ViewModels  1	utilities!clr-namespace:PaK_v1._0.utilities    � 	Resources  $   PaK_v1._0.ViewModels.AcctNewVM   	AcctNewVM   booleanToVisibilityConverter&   PaK_v1._0.utilities.NotConverter  notConverter��%-   &	        &	      &	 
       ��   .���� .���� $	��300�� � DataContext# [  .+��� $��NEUES KONTO��  Heading2#��[ $��0,0,0,8q�6  0FirstFloor.ModernUI.Windows.Controls.BBCodeBlock     BBCode$i cBitte die persönlichen Daten erfassen. Übrige Daten können über das Konto-Panel erfasst werden.��$��0,0,0,16q��� -    ��Name$
 Form�� �� Orientation$ Vertical=� �� *	Account+   �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� R     7��'�� �     7��'	� �     7	��� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 0,0,0,4q��� " ��8   .���  � ��$	 120����  � ��$ Center=��� " ��8   .���  � ��$	 0,3q��� " 	�8   .���  � ��$	 0,3q�.+��� .+��� $��Vorname���� -   	 ��Name$	 TextFirstName��$	��150������ *act_firstname+
 �� Mode$
 TwoWay=� �� ValidatesOnDataErrors . �� .+��� $��Nachname���� -   $	 TextLastName��$	��150������ *act_lastname+$
 TwoWay=� . �� .+��� $��Pass-/Ausweis-Nr.���� -   $	 TextPassport��$	��150������ *act_passport_id+$
 TwoWay=� . �� .+��� $��Nationalität���� -    ��Name$ Nation��$	��150�� �� DisplayMemberPath$ nation�� �� SelectedValuePath$ 	nation_id������  �� Source# [   �� Path$ Nations� �� SelectedValue �� *	nation_id+$
 TwoWay=��� .+��� $��
Geschlecht��	� -    	�Name$ RadioGenderMale��$
��Male�� d� 	IsChecked �� *
act_gender+$
 TwoWay=�	� $��Female��$��8,0,0,0q� �� *
act_gender+$
 TwoWay=� �� 	Converter# [ �� .+��� $��
Geburtstag��(  "System.Windows.Controls.DatePicker  -     Name$ 	DateBirth��   SelectedDate �� $ act_birthday� �� StringFormat$ {0:MM-dd-yyyy}���� .+��� $��	Pseudonym���� -   $	 TextPseudonym��$	��150������ *act_pseudonym+�� .+��� $��Addresse���� -	   $	 TextAddress��$	��150������ *act_address+�� .+��� $	��Ort���� -
   $	 TextCity��$	��150������ *
act_city+�� .+��� $��Postleitzahl���� -   $	 TextZipCode��$	��150������ *	act_zip+�� .+��� $��Status�� �� Target ��  �� ElementName$ 	TextState���� -   $ 	AcctState��$	��150��$ ast_name��$ ast_id������ # [  $ 
AcctStates� �� # [  $ 	AcctState�$
 TwoWay=��� .+��� �� $��Düsseldorfer Verfahren��y��� # [  $ Duedo_Visible�# [  �� # [  $ Duedo_Checked�$
 TwoWay=��� .+��� -    ��Name$ errormessage��$��23��$
��Left=�$	��Top=�$	��450������ *Status+���� *	FgColor+�� $ 
Horizontal=�.+�7  1FirstFloor.ModernUI.Windows.Controls.ModernButton  -   $��btnSave��  DiskIconData   IconData# [    EllipseDiameter$ 26Q�   	IconWidth$ 14Q�   
IconHeight$ 14Q�$
��Left=� � ToolTip$ 	Speichern������ *Commands.save+