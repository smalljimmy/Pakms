   M S B A M L   `   `   `  ���� C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PaK_v1._0.ContentPaK_v1._0.Content  9!clr-namespace:PaK_v1._0.utilitiesPaK_v1._0.utilities  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel !    PaK_v1._0.Content.acct_list   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  +localclr-namespace:PaK_v1._0.Content  1	utilities!clr-namespace:PaK_v1._0.utilities  Bscm8clr-namespace:System.ComponentModel;assembly=WindowsBase    � 	Resources     AcctSrc �� SortDescriptions+  %System.ComponentModel.SortDescription   PropertyName  tariffs 	 rooms 
 states  nations  BoolToVisibilityConverter22  ,PaK_v1._0.utilities.BooleanToStringConverter  BooleanToStringConverter��%�   &	        &	 :     &	 ?     &	 D     &	 I     &	 N     &	 S     ��    $ act_lastname��  $ act_firstname���� �� �� �� ��   .��� -    �Name$ Accounts��  ContentRoot#��[  � DataContext ��  �� Source# [   � ColumnDefinitions �� $	��380 ��� $��1 ��� $��* �.+�]� -    ]�Name$	 dp2��$
��Auto��$
��Auto����. $��-5,0,0,0q�.+�%   PaK_v1._0.Content.SearchControl  %   PaK_v1._0.Content.SearchControl   SearchHandler$ SearchHandler��$	��Top=�$��0,0,0,0q��� -   $��AccountsListView��$	 �� IsSynchronizedWithCurrentItem$
	 TrueY�
 �� SelectedIndex$
 0��$��0,10,0,0q�����  �� Mode$ OneWay=����� .R�� $��0,10,0,0q� �� $	��210 ��� $��75 ��� $��70 ��� $��* � � RowDefinitions �� $��* ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�$
��Bold"�.+��� ���� *act_lastname+�� $��, ���� ���� *act_firstname+�� $��1��.+��� $��Zimmer:���� $��2��$��Right=�.+��� ����  �� Path$ rooms.room_number��� $��1��$��0��$
��Bold"�$��Italic$�.+��� ���� *act_pseudonym+�� $��1��$��1��.+��� $��Kontostand:���� $��1��$��2��$��Right=�.+��� ���� *act_balance+�� $��1��$��1��$
��-3,0q�$	��3,0q�
������ $��Stretch=��� $��Stretch=�$
��Auto��$��2��$��2��._�]� -   $ acct_hdr��$��2��$
��Auto��$
��Auto����. .+�� $��10,10,10,10q�$
��Auto��$	��Top=�$	��Top=�.+��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $	��200��$
��Left=��� $
��Bold"���� *act_firstname+ �� $� ��$
��Bold"� �� $
��Bold"���� *act_lastname+�� $��Right=��� $
��Bold"���� *act_pseudonym+� $��10,10,10,10q�
������ .+��� -    ��Name$
 tabs��$��0q�
������    �� 
TargetType �� Property �� Value  HeaderLabelStyle �� Triggers �� Binding �� RelativeSource �� AncestorType �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName 	 svc��%�  '��       &	 %     '�� ,    &		 D    �� " ��.���  � ��$
 Left=��� " ��.���  � ��
 ����  ��  �� *
IsSelected+ �� $ TabItemL� True.a���  � ��$
 Bold"���  � ��$ 15(���  �� *
IsSelected+ �� $ TabItemL�	 False.a���  � ��$ Light"���  � ��$ 15(��� " ��.���  � �� �� " ��.R�� $��Panel��.+��� $ ContentSite��$��Center=�$��Center=�$��Header��$
��10,2q� P�  �@��
IsSelected . . ��� $ Panel�� � ��
 ���� P�  �@��
IsSelected .  . ��� $ Panel�� � ��
 ���� �� " ��.���  � y�$ 	Collapsed=���  � �� �� " ��.R�� $��Panel��.+��� $ ContentSite��$��Center=�$��Center=�$��Header��$
��10,2q� P�  �@��
IsSelected . . ��� $ Panel�� � ��
 ���� P�  �@��
IsSelected .  . ��� $ Panel�� � ��
 ����  ��  �� $ ast_id� 1.a���  � y�$ Visible=�.@��� 
������ $��0q�
������ ���� $��KONTO��$��Stretch=�$��12(�#��[ .��� $��10q� �� $	��280 ��� $��* � �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��1��$��0��$ Vertical=�$��20,0,0,0q�   �� BasedOn��%  '��       '�� R     7��'�� �     7��'	� �     7	��� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 0,0,0,4q��� " ��8   .���  � ��$ 90����  � ��$ Center=��� " ��8   .���  � ��$	 0,3q��� " 	�8   .���  � ��$	 0,3q�.+��� .+��� $��Addresse���� -    ��Name$ TextAddress��$	��150������ *act_address+�� .+��� $	��Ort���� -   $ TextCity��$	��150������ *
act_city+�� .+��� $��Postleitzahl���� -   $ TextZipCode��$	��150������ *	act_zip+�� .+��� $��Email���� -	   $ Email��$	��150������ *	act_email+�� .+��� $��Telefon���� -
   $ 	TextPhone��$	��150������ *	act_phone+�� .+��� $�� ���� .+��� $��Zimmer���� -     ��Name$
  Room��$	��150��! �� DisplayMemberPath$! room_number��" �� SelectedValuePath$" room_id������ # [ # �� SelectedValue# �� *	room_id+$ TwoWay=��� .+��� $��Miete���� -   $  Rental��$	��150��$! tar_name��$" 	tariff_id������ # [ # �� *	tariff_id+$ TwoWay=��� .+��� $��Depot���� -   $ TextDeposit��$	��150������ *act_deposit+�� $��0��$��0��$ Vertical=�  ��%  '��       '�� R     7��'�� �     7��'	� �     7	��� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 0,0,0,4q��� " ��8   .���  � ��$	 120����  � ��$ Center=��� " ��8   .���  � ��$	 0,3q��� " 	�8   .���  � ��$	 0,3q�.+��� .+��� $��Vorname���� -   $ 	FirstName��$	��150������ *act_firstname+�� .+��� $��Nachname���� -   $ LastName��$	��150������ *act_lastname+�� .+��� $��Pass-/Ausweis-Nr.���� -   $ TextPassport��$	��150������ *act_passport_id+�� .+��� $��Nationalität���� -   $  Nation��$	��150��$! nation��$" 	nation_id������ # [ # �� *	nation_id+$ TwoWay=��� .+��� $��
Geschlecht��	� -   $ 	�Name$$ RadioGenderMale��$
��Male��	� $��Female��$��8,0,0,0q��� .+��� $��
Geburtstag��(  "System.Windows.Controls.DatePicker  -   %  Name$% 	DateBirth��&   SelectedDate& �� $ act_birthday�' �� StringFormat$' {0:MM-dd-yyyy}���� .+��� $��	Pseudonym���� -   $ TextPseudonym��$	��150������ *act_pseudonym+�� .+��� $��Status��( �� Target( �� ) �� ElementName$) 	TextState���� -   $  	AcctState��$	��150��$! ast_name��$" ast_id������ # [ # �� *ast_id+$ TwoWay=��� .+��� �� -   * ��Name$* duedotax��$��Düsseldorfer Verfahren��+ d� 	IsChecked+ �� $ pers_data.pdt_duedo_tax�, �� 	Converter#, [ �� .+��� �� -   $* Active��$��Aktiver Gast��+ �� *
act_active+#, [ �� $��2��$��1��$ Vertical=�.+��� $ 
Horizontal=�.+��� $��Notizen��$	��120��$��Center=�$
��Left=��� -   $ 	TextNotes��$	��430��$	��100��- �� TextWrapping$
- Wrap=�. �� AcceptsReturn. . ���� *	act_notes+�� $��2��$��2��$��0,10,0,0q�$ 
Horizontal=�.+�7  1FirstFloor.ModernUI.Windows.Controls.ModernButton  -    
 DiskIconData/   IconData#/ [
 $��4��0   EllipseDiameter$0 26Q�1   	IconWidth$1 14Q�2   
IconHeight$2 14Q�$
��Left=�3 � ToolTip$3 	Speichern���� $�� ��$��92���� -   4 ��Name$4 notifier��$�� ���� -   5 ��Name$5 SvcTab��
������ $��0q�
������ #��[	 ���� -   $��SERVICES��$��Stretch=�$��12(�#��[ .��� $��0q�.+��� $ Vertical=�$��10,0,0,0q�  ��%  '��       '�� R     7��'�� �     7��'	� �     7	��� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 0,0,0,4q��� " ��8   .���  � ��$ 90����  � ��$ Center=��� " ��8   .���  � ��$	 0,3q��� " 	�8   .���  � ��$	 0,3q�.+��� .+��� $��Grösse���� -   $ 	txtHeight��$	��150������ $ pers_data.pdt_height��� .+��� $��Gewicht���� -   $ 	txtWeight��$	��150������ $ pers_data.pdt_weight��� .+��� $��	Haarfarbe���� -   $ 
txtHaircol��$	��150������ $ pers_data.pdt_hair_color��� .+��� $��Körperfarbe���� -    $ 
txtBodycol��$	��150������ $ pers_data.pdt_body_color��� .+��� $��Brustumfang���� -!   $ txtBustsize��$	��150������ $ pers_data.pdt_bust_size��� .+��� $��
Referenzen���� -"   $ txtReferences��$	��250������ $ pers_data.pdt_reference��� .+��� $��Spezialitäten���� -#   $ txtSecialsvc��$	��250������ $! pers_data.pdt_spec_services��� .+��� $�� ���� $ 
Horizontal=�.+��� $	��120��$��Berufserfahrung��+ �� $ pers_data.pdt_experience�#, [ �� $�� ���� $��Stammkundschaft��+ �� $% pers_data.pdt_regular_customers�#, [ �� $ 
Horizontal=�.+��� $	��120��$��Tattoo��+ �� $ pers_data.pdt_tattoo�#, [ �� $�� ���� $��Piercing��+ �� $ pers_data.pdt_piercing�#, [ �� $ Vertical=�$��0,10,0,0q�.+��� .+��� $��Services��$
��Bold"��� .+��� -$   6 ��Name$6 
serviceLst������ .R��� ���� *Svc.svc_name++ �� *
IsSelected+�� $��0,15,0,0q�.+�  -%   7  Name$7 Save_Svc��#/ [
 $0 26Q�$1 14Q�$2 14Q�$
��Left=�$3 	Speichern���� $�� ���� -&   $4 	notifier2��$
��test��$	��200��