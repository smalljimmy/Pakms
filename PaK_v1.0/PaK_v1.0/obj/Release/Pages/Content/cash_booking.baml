   M S B A M L   `   `   `  ���� C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PaK_v1._0.ViewModelsPaK_v1._0.ViewModels  9!clr-namespace:PaK_v1._0.utilitiesPaK_v1._0.utilities  *    $PaK_v1._0.Pages.Content.cash_booking   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  .appvm"clr-namespace:PaK_v1._0.ViewModels  1	utilities!clr-namespace:PaK_v1._0.utilities    � 	Resources      booleanToVisibilityConverter/  )PaK_v1._0.utilities.Bool2VisibleConverter  b2VConverter2  ,PaK_v1._0.utilities.BooleanToStringConverter  booleanToStringConverter&   PaK_v1._0.utilities.NotConverter  notConverter��%<   &	        &	      &	 
     &	      ��       .���   ContentRoot#��[  � ColumnDefinitions �� -    ��Name$ gridcol1��$	��380 ��� $��1 ��� $��* � � RowDefinitions �� $
��0.5* ��� $
��0.5* �$��35��.+��� $��1��$��1��$��2���� $��5,0,5,0q�$��Stretch=�$
��Auto��$��0��$��2��$��0.5,0.5,0.5,0.5q�._�]� -    ]�Name$	 dp1��$
��Auto��$
��Auto����. .+���  �� Orientation$ 
Horizontal=�$	��Top=�.+��� -   $��	searchBox��$	��0.7q�$
��Left=�$	��230��$��25��
������� � ToolTip$ Search Person��$��Normal"�$��Stretch=�$	��Top=����� *ST+ �� Mode$ TwoWay=�.��.  (System.Windows.Interactivity.Interaction   	Behaviors '   !PaK_v1._0.utilities.KeyUpWithArgs  	   KeyUpCommand	 �� *SearchCommand+.��
   Triggers
 /  )System.Windows.Interactivity.EventTrigger     	EventName$ GotFocus��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *Commands.emptybox+   CommandParameter ��  �� ElementName$ 	searchBox��.��7	  1FirstFloor.ModernUI.Windows.Controls.ModernButton	    LupeIconData 	  IconData# [  	  EllipseDiameter$ 20Q� 	  	IconWidth$ 14Q� 	  
IconHeight$ 14Q�
�������{�.  �� -   $��PersListView��$��
-20,10,0,0q����� *accountsView+ �� SelectedItem �� *SelectedAccount+$ TwoWay=����� .R�� $��0,10,0,0q� �� $	��220 ��� $��75 ��� $��60 ��� $��* � �� $��* ��� $��* �.+��� $��0��$ 
Horizontal=�$��20(�.+��� ����  �� Path$ act_pseudonym��� $��1��$ 
Horizontal=�.+��� $��Zimmer:��$��Bottom=��� $��2��$��Right=�$ 
Horizontal=�.+��� $��Bottom=����� $ rooms.room_number��� $��1��$��0��$ 
Horizontal=�.+��� ���� $ act_firstname��� $�� ���� ���� $ act_lastname��� $��1��$��1��$ 
Horizontal=�.+��� $��Kontostand:���� $��1��$��2��$��Right=�$ 
Horizontal=�.+��� ���� $ act_balance��� $��Stretch=�$
��Auto��$��2��$��2��._�]� -   $ acct_hdr��$��2��$
��Auto��$
��Auto����. .+�� $��10,10,10,10q�$
��Auto��$	��Top=�$	��Top=�.+��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $
��Left=��� $��20(���� *SelectedAccount.act_pseudonym+�� .+��� $
��Left=��� $�Konto: ��$��18(� �� $��18(���� *SelectedAccount.act_id+ �� $�        �� �� $��18(���� *SelectedAccount.act_firstname+ �� $� ��$
��Bold"� �� $��18(���� *SelectedAccount.act_lastname+� $��10,10,10,10q�
������ .+��� $ Vertical=�   �� 
TargetType �� Property �� Value �� BasedOn��%�   '��       '�� R     7���� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 0,0,0,4q��� " ��8   .���  � ��$	 150����  � ��$ Center=�.+��� .+��� $��Kontostand (EUR)���� $��23��$��Right=�$	��Top=�$	��150������ *SelectedAccount.act_balance+$ TwoWay=��� .+��� $��Betrag (EUR)���� -    ��Name$ 	TxtAmount��$	��150������ *Amount+$ TwoWay=��� .+��� $��	Kommentar���� -   $ 
TxtComment��$	��300������ *	Comment+$ TwoWay=��� .+��� $�� ���� $5��/(*Kommentar bei Negativ-Beträgen erforderlich)��$	��350���� .+��� -    ��Name$ errormessage��$��23��$
��Left=�$	��Top=�$	��600������ *Status+���� *	FgColor+	  -	   $��btnSave��  DiskIconData# [ $ 26Q�$ 14Q�$ 14Q�$
��Left=�$ 	Speichern������ $ Commands.save�