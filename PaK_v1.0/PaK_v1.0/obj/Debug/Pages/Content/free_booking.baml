   M S B A M L   `   `   `  ����C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PaK_v1._0.ViewModelsPaK_v1._0.ViewModels  5	      9!clr-namespace:PaK_v1._0.utilitiesPaK_v1._0.utilities  5
      *    $PaK_v1._0.Pages.Content.free_booking   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      .appvm"clr-namespace:PaK_v1._0.ViewModels  5	      1	utilities!clr-namespace:PaK_v1._0.utilities  5
        � 	Resources  5          booleanToVisibilityConverter/  )PaK_v1._0.utilities.Bool2VisibleConverter  b2VConverter2  ,PaK_v1._0.utilities.BooleanToStringConverter  booleanToStringConverter&   PaK_v1._0.utilities.NotConverter  notConverter��%t   &	        &	      &	 &     &	 9     �� 5   
   6'     5   
   6*     5   
   6-     5   
   6!   5      .��5      �   ContentRoot#��[ 6    � ColumnDefinitions 5   
   �� 5      -   5         ��Name$ gridcol1��5   +   $	��380 �6   6+   �� 5      $��1 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5       $
��0.5* �6   $��35��6*   .+�5#   
   �� $��1��6   $��1��6"   $��2��62   �� 5$   
   $��5,0,5,0q�6   $��Stretch=�6"   $
��Auto��6>   $��0��6L   $��2��6\   $��0.5,0.5,0.5,0.5q�6m   ._�5%      ]� -   5         ]�Name$	 dp1��5%      $
��Auto��6%   $
��Auto��62   ��. .+�5&      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�66   .+�5'      �� -   5        $��	searchBox��5'      $	��0.7q�6/   $
��Left=�6E   $	��230��6`   $��25��6o   
������� � ToolTip$ Search Person��6�   $��Normal"�6�   $��Stretch=�6�   $	��Top=�6  ��6�   �� *ST+ �� Mode$ TwoWay=�.��6  .  (System.Windows.Interactivity.Interaction   	Behaviors 5(      '   !PaK_v1._0.utilities.KeyUpWithArgs  5)      	   KeyUpCommand	 66   �� *SearchCommand+.��5*   3   
   Triggers
 5+      /  )System.Windows.Interactivity.EventTrigger  5,         	EventName$ GotFocus��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5-   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 68   �� *Commands.emptybox+   CommandParameter 6^   ��  �� ElementName$ 	searchBox��5.      .��5/   2   51      7	  1FirstFloor.ModernUI.Windows.Controls.ModernButton	  52        LupeIconData 	  IconData# [ 6'    	  EllipseDiameter$ 20Q�6P    	  	IconWidth$ 14Q�6e    	  
IconHeight$ 14Q�6t   
�������{�.  6�   53      �� 54      -   5        $��PersListView��54      $��
-20,10,0,0q�6�   ��6/   �� *accountsView+ �� SelectedItem 6U   �� *SelectedAccount+$ TwoWay=���56      �� 57      .R�58      � $��0,10,0,0q�6#    59   "   �� 5:   &   $	��220 �67   �� 5;   &   $��75 �67   �� 5<   &   $��60 �67   �� 5=   &   $��* �67    5?   "   �� 5@   &   $��* �64   �� 5A   &   $��* �64   .+�5D   "   �� $��0��6-   $ 
Horizontal=�6=   $��20(�6V   .+�5E   &   �� ��60   ��  �� Path$ act_pseudonym�5F   #   �� 5G   "   $��1��6-   $ 
Horizontal=�6=   .+�5H   &   �� $��Zimmer:��60   $��Bottom=�6?   5I   #   �� 5J   "   $��2��6-   $��Right=�6=   $ 
Horizontal=�6Y   .+�5K   &   �� $��Bottom=�6X   ��60   �� $ rooms.room_number�6X   5L   #   �� 5M   "   $��1��6-   $��0��6:   $ 
Horizontal=�6J   .+�5N   &   �� ��60   �� $ act_firstname��� 5O   &   $�� ��60   �� 5P   &   ��60   �� $ act_lastname�5Q   #   �� 5R   "   $��1��6-   $��1��6:   $ 
Horizontal=�6J   .+�5S   &   �� $��Kontostand:��60   5T   #   �� 5U   "   $��1��6-   $��2��6:   $��Right=�6J   $ 
Horizontal=�6f   .+�5V   &   �� ��60   �� $ act_balance�5W   #   5X      5Z      5\      5]      5^      �� 5_   
   $��Stretch=�6   $
��Auto��6-   $��2��6;   $��2��6K   ._�5`      ]� -   5        $ acct_hdr��5`      $��2��6*   $
��Auto��6:   $
��Auto��6G   ��. .+�5a      � $��10,10,10,10q�6   $
��Auto��6,   $	��Top=�6:   $	��Top=�6R   .+�5b      �� $ Vertical=�6!   .+�5c      �� $ 
Horizontal=�6%   .+�5d      �� $
��Left=�6(   �� 5e   "   $��20(�6U   �6&   �� *SelectedAccount.act_pseudonym+6U   5f      5g      �� 5h      .+�5i      �� $
��Left=�6(   �� 5j   &   $�Konto: ��6*   $��18(�69    �� 5k   &   $��18(�6R   �6*   �� *SelectedAccount.act_id+6R    �� 5l   &   $�        ��6*    �� 5m   &   $��18(�6Y   �6*   �� *SelectedAccount.act_firstname+6Y    �� 5n   &   $� ��6*   $
��Bold"�63    �� 5o   &   $��18(�6X   �6*   �� *SelectedAccount.act_lastname+6X   5p      5q      5r      5s      � 5t      $��10,10,10,10q�6   
������ .+�5u      �� $ Vertical=�6!     5v       �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� �     7���� 5w      " ��6$   .�5x   "   ��  �@��Orientation$ 
Horizontal=�6@   �� 5y   "    � ��$ 0,0,0,4q�6;   5z      �� 5{      " ��6$   8   .�5|   "   ��  � ��$	 150��6:   �� 5}   "    � ��$ Center=�6F   5~      5      .+�5�      �� .+�5�      �� $��Kontostand (EUR)��6$   �� 5�      $��23��6(   $��Right=�64   $	��Top=�6�   $	��150��6�   ��6P   �� *SelectedAccount.act_balance+$ TwoWay=�6�   5�      �� 5�      .+�5�      �� $��Betrag (EUR)��6$   �� 5�      $	��150��6&   ��62   �� *Amount+$ TwoWay=�5�      �� 5�      .+�5�      �� $��Zweck��6$   �� 5�      $	��350��6&   ��62   �� *	Comment+$ TwoWay=�5�      �� 5�      .+�5�      �� -   5         ��Name$ errormessage��5�   O   $��23��6(   $
��Left=�64   $	��Top=�6~   $	��450��6�   ��6f   �� *Status+��6�   �� *	FgColor+5�      	  5�      -   5        $��btnSave��5�   +     DiskIconData# [ 6:   $ 26Q�6�   $ 14Q�6�   $ 14Q�6�   $
��Left=�6�   $ 	Speichern��6�   ��6c   �� $ Commands.save�6�   5�      5�      5�      5�      5�      5�      