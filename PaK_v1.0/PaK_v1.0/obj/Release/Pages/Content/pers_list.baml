   M S B A M L   `   `   `  ���� C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PaK_v1._0.ViewModelsPaK_v1._0.ViewModels  9!clr-namespace:PaK_v1._0.utilitiesPaK_v1._0.utilities  !    PaK_v1._0.Content.pers_list   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  .appvm"clr-namespace:PaK_v1._0.ViewModels  1	utilities!clr-namespace:PaK_v1._0.utilities    � 	Resources      booleanToVisibilityConverter/  )PaK_v1._0.utilities.Bool2VisibleConverter  b2VConverter2  ,PaK_v1._0.utilities.BooleanToStringConverter  booleanToStringConverter&   PaK_v1._0.utilities.NotConverter  notConverter!  PaK_v1._0.ViewModels.AcctVM 
 AcctVM��%K   &	        &	      &	 
     &	      &	      ��          � DataContext ��  �� ResourceKey$ AcctVM��.���   ContentRoot#��[  � ColumnDefinitions �� -    ��Name$ gridcol1��$	��380 ��� $��1 ��� $��* � � RowDefinitions �� $
��0.5* ��� $
��0.5* �$��35������ *ActualHeight+ �� ElementName$ 
StackPanel�� �� Mode$ Default=�.+��� $��1��$��1��$��2���� $��5,0,5,0q�$��Stretch=�$
��Auto��$��0��$��2��$��0.5,0.5,0.5,0.5q�._�]� -    ]�Name$	 dp1��$
��Auto��$
��Auto����. .+��� 	 �� Orientation$	 
Horizontal=�$	��Top=�.+��� -   $��	searchBox��$	��0.7q�$
��Left=�$	��230��$��25��
�������
 � ToolTip$
 Search Person��$��Normal"�$��Stretch=�$	��Top=����� *ST+$ TwoWay=�.��.  (System.Windows.Interactivity.Interaction   	Behaviors '   !PaK_v1._0.utilities.KeyUpWithArgs     KeyUpCommand �� *SearchCommand+.��   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ GotFocus��.  (System.Windows.Interactivity.TriggerBase   Actions. 6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command �� *Commands.emptybox+ 	  CommandParameter �� $ 	searchBox��.��7
  1FirstFloor.ModernUI.Windows.Controls.ModernButton
    LupeIconData 
  IconData# [  
  EllipseDiameter$ 20Q� 
  	IconWidth$ 14Q� 
  
IconHeight$ 14Q�
�������{�.  �� -   $��PersListView�� �� SelectedIndex$ 0��$��
-20,10,0,0q����� *accountsView+$ TwoWay=� �� SelectedItem �� *selectedAccount+���� .R�� $��0,10,0,0q� �� $	��220 ��� $��75 ��� $��60 ��� $��* � �� $��* ��� $��* �.+��� $��0��$	 
Horizontal=�$��20(�.+��� ����  �� Path$ act_pseudonym��� $��1��$	 
Horizontal=�.+��� $��Zimmer:��$��Bottom=��� $��2��$��Right=�$	 
Horizontal=�.+��� $��Bottom=����� $ rooms.room_number��� $��1��$��0��$	 
Horizontal=�.+��� ���� $ act_firstname��� $�� ���� ���� $ act_lastname��� $��1��$��1��$	 
Horizontal=�.+��� $��Kontostand:���� $��1��$��2��$��Right=�$	 
Horizontal=�.+��� ���� $ act_balance��� $��Stretch=�$
��Auto��$��2��$��2��._�]� -   $ acct_hdr��$��2��$
��Auto��$
��Auto����. .+�� $��10,10,10,10q�$
��Auto��$	��Top=�$	��Top=�.+��� $	 Vertical=�.+��� $	 
Horizontal=�.+��� $
��Left=��� $��20(���� *lAccount.act_pseudonym+�� .+��� $
��Left=��� $�Konto: ��$��18(� �� $��18(���� *lAccount.act_id+ �� $�        �� �� $��18(���� *lAccount.act_firstname+ �� $� ��$
��Bold"� �� $��18(���� *lAccount.act_lastname+� $��10,10,10,10q�
������ .+��� -    ��Name$
 tabs��$��0q�
������    �� 
TargetType �� Property �� Value  HeaderLabelStyle �� Triggers �� Binding �� RelativeSource  �� AncestorType! �� Value" �� 
TargetType# ��Name$ �� Triggers% P� Property& P� Value' �� 
TargetName  svc��%�  '��       &	 %     '�� ,    &	 D    �� " ��.���  � ��$
 Left=��� " ��.���  � ��
 ����  ��  �� *
IsSelected+ �� $  TabItemL�! True.a���  � ��$
 Bold"���  � ��$ 15(���  �� *
IsSelected+ �� $  TabItemL�	! False.a���  � ��$ Light"���  � ��$ 15(��� " ��.���  � �� �� "" ��.R�� $��Panel��.+��� $# ContentSite��$��Center=�$��Center=�$��Header��$
��10,2q�$ P� % �@��
IsSelected& . . ��� $' Panel�� � ��
 ���� P� % �@��
IsSelected& .  . ��� $' Panel�� � ��
 ���� �� " ��.���  � y�$ 	Collapsed=���  � �� �� "" ��.R�� $��Panel��.+��� $# ContentSite��$��Center=�$��Center=�$��Header��$
��10,2q�$ P� % �@��
IsSelected& . . ��� $' Panel�� � ��
 ���� P� % �@��
IsSelected& .  . ��� $' Panel�� � ��
 ����  ��  �� $ ast_id�! 1.a���  � y�$ Visible=�.@��� 
������ $��0q�
������ ( �� 
IsSelected( �� *TabSelected+$ TwoWay=�y��� $ AcctVisible�) �� 	Converter#) [ ���� $��KONTO��$��Stretch=�$��12(�#��[ .��� $��10q� �� $	��280 ��� $��* � �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��1��$��0��$	 Vertical=�$��20,0,0,0q�  * �� BasedOn��%  '��       '�� R     7��'�� �     7��'	� �     7	��� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 0,0,0,4q��� " ��8*   .���  � ��$ 90����  � ��$ Center=��� " ��8*   .���  � ��$	 0,3q��� " 	�8*   .���  � ��$	 0,3q�.+��� .+��� $��Addresse���� -   + ��Name$+ TextAddress��$	��150������ *lAccount.act_address+�� .+��� $	��Ort���� -   $+ TextCity��$	��150������ *lAccount.act_city+�� .+��� $��Postleitzahl���� -	   $+ TextZipCode��$	��150������ *lAccount.act_zip+�� .+��� $��Email���� -
   $+ Email��$	��150������ *lAccount.act_email+�� .+��� $��Telefon���� -   $+ 	TextPhone��$	��150������ *lAccount.act_phone+�� .+��� $�� ���� .+��� $��Zimmer���� -   , ��Name$
, Room��$	��150��- �� DisplayMemberPath$- room_number��. �� SelectedValuePath$. room_id������ / �� Source#/ [ $ Rooms�0 �� SelectedValue0 �� *lAccount.room_id+$ TwoWay=��� .+��� $��Miete���� -   $, Rental��$	��150��$- tar_name��$. 	tariff_id������ #/ [ $ Tariffs�0 �� *lAccount.tariff_id+$ TwoWay=��� .+��� $��Depot���� -   $+ TextDeposit��$	��150������ *lAccount.act_deposit+�� $��0��$��0��$	 Vertical=�  ��%  '��       '�� R     7��'�� �     7��'	� �     7	��� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 0,0,0,4q��� " ��8*   .���  � ��$	 120����  � ��$ Center=��� " ��8*   .���  � ��$	 0,3q��� " 	�8*   .���  � ��$	 0,3q�.+��� .+��� $��Vorname���� -   $+ 	FirstName��$	��150������ *lAccount.act_firstname+�� .+��� $��Nachname���� -   $+ LastName��$	��150������ *lAccount.act_lastname+�� .+��� $��Pass-/Ausweis-Nr.���� -   $+ TextPassport��$	��150������ *lAccount.act_passport_id+�� .+��� $��Nationalität���� -   $, Nation��$	��150��$- nation��$. 	nation_id������ #/ [ $ Nations�0 �� *lAccount.nation_id+$ TwoWay=��� .+��� $��
Geschlecht��	� -   1 	�Name$1 RadioGenderMale��$
��Male��2 d� 	IsChecked2 �� *lAccount.act_gender+$ TwoWay=�	� $��Female��$��8,0,0,0q�2 �� *lAccount.act_gender+$ TwoWay=�#) [ �� .+��� $��
Geburtstag��(  "System.Windows.Controls.DatePicker  -   3  Name$3 	DateBirth��4   SelectedDate4 �� *lAccount.act_birthday+5 �� StringFormat$5 {0:MM-dd-yyyy}���� .+��� $��	Pseudonym���� -   $+ TextPseudonym��$	��150������ *lAccount.act_pseudonym+�� .+��� $��Status���� -   $, 	AcctState��$	��150��$- ast_name��$. ast_id������ #/ [ $ 
AcctStates�0 �� *	AcctState+$ TwoWay=��� .+��� �� $��Düsseldorfer Verfahren��y��� *Duedo_Visible+#) [  2 �� *Duedo_Checked+$ TwoWay=��� .+��� �� -   6 ��Name$6 Active��$��Aktiver Gast��2 �� *lAccount.act_active+#) [ �� $��2��$��1��$	 Vertical=�.+��� $	 
Horizontal=�.+��� $��Notizen��$	��120��$��Center=�$
��Left=��� -   $+ 	TextNotes��$	��430��$	��100��7 �� TextWrapping$
7 Wrap=�8 �� AcceptsReturn8 . ���� *lAccount.act_notes+�� $	 
Horizontal=�.+��� $��Passport��$	��120��$��Center=�$
��Left=�
  -    	 DiskIconData# [	 $��4��$ 26Q�$ 14Q�$ 14Q�$
��Left=�$
 Scan passport���� $��2��$��2��$��0,10,0,0q�$	 
Horizontal=�.+�
  -   $��btnSave��# [	 $ 26Q�$ 14Q�$ 14Q�$
��Left=�$
 	Speichern������ *Commands.saveacct+�� $�� ��$��92���� -   9 ��Name$9 errormessage��$��23��$
��Left=�$	��Top=�$	��450������ *Status+���� *	FgColor+
  -   $��btnPrint�� 
 PrintIconData# [
 $ 26Q�$ 14Q�$ 14Q�$
��Left=�$��0,5,0,0q�$
 Fragebogen drucken������ *Commands.print+�� -   : ��Name$: SvcTab��
������ $��0q�
������ y��� $ 
SvcVisible�#) [ ( �� *TabSelector+$ TwoWay=�#) [ ���� $��SERVICES��$��Stretch=�$��12(�#��[ .��� $��0q�.+��� $	 Vertical=�$��10,0,0,0q�  ��%  '��       '�� R     7��'�� �     7��'	� �     7	��� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 0,0,0,4q��� " ��8*   .���  � ��$ 90����  � ��$ Center=��� " ��8*   .���  � ��$	 0,3q��� " 	�8*   .���  � ��$	 0,3q�.+��� .+��� $��Grösse���� -   $+ 	txtHeight��$	��150������ *lPersData.pdt_height+�� .+��� $��Gewicht���� -   $+ 	txtWeight��$	��150������ *lPersData.pdt_weight+�� .+��� $��	Haarfarbe���� -    $+ 
txtHaircol��$	��150������ *lPersData.pdt_hair_color+�� .+��� $��Körperfarbe���� -!   $+ 
txtBodycol��$	��150������ *lPersData.pdt_body_color+�� .+��� $��Brustumfang���� -"   $+ txtBustsize��$	��150������ *lPersData.pdt_bust_size+�� .+��� $��
Referenzen���� -#   $+ txtReferences��$	��250������ *lPersData.pdt_reference+�� .+��� $��Spezialitäten���� -$   $+ txtSecialsvc��$	��250������ *lPersData.pdt_spec_services+�� .+��� $�� ���� $	 
Horizontal=�.+��� $	��120��$��Berufserfahrung��2 �� *lPersData.pdt_experience+#) [ �� $�� ���� $��Stammkundschaft��2 �� *!lPersData.pdt_regular_customers+#) [ �� $	 
Horizontal=�.+��� $	��120��$��Tattoo��2 �� *lPersData.pdt_tattoo+#) [ �� $�� ���� $��Piercing��2 �� *lPersData.pdt_piercing+#) [ �� $	 Vertical=�$��0,10,0,0q�.+��� .+��� $��Services��$
��Bold"��� .+��� -%   ; ��Name$; 
serviceLst������ *	SvcList+$ TwoWay=����� .R��� ���� *Svc.svc_name+2 �� $ 
IsSelected�$ TwoWay=��� $��0,15,0,0q�.+�
  -&   $��btnSave2��# [	 $ 26Q�$ 14Q�$ 14Q�$
��Left=�$
 	Speichern������ *Commands.savepers+�� $�� ���� -'   $9 errmsg2��$��23��$
��Left=�$	��Top=�$	��450������ *	Status2+���� *
FgColor2+