   M S B A M L   `   `   `  ����C  ?PaK_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PaK_v1._0.ViewModelsPaK_v1._0.ViewModels  5	      9!clr-namespace:PaK_v1._0.utilitiesPaK_v1._0.utilities  5
      *    $PaK_v1._0.Pages.Content.edit_article   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      .appvm"clr-namespace:PaK_v1._0.ViewModels  5	      1	utilities!clr-namespace:PaK_v1._0.utilities  5
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
������� � ToolTip$ Artikel suchen��6�   $��Normal"�6�   $��Stretch=�6�   $	��Top=�6  ��6�   �� *ST+ �� Mode$ TwoWay=�.��6  .  (System.Windows.Interactivity.Interaction   	Behaviors 5(      '   !PaK_v1._0.utilities.KeyUpWithArgs  5)      	   KeyUpCommand	 66   �� *SearchCommand+.��5*   3   
   Triggers
 5+      /  )System.Windows.Interactivity.EventTrigger  5,         	EventName$ GotFocus��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5-   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 68   �� *Commands.emptybox+   CommandParameter 6^   ��  �� ElementName$ 	searchBox��5.      .��5/   2   50      7	  1FirstFloor.ModernUI.Windows.Controls.ModernButton	  51        LupeIconData 	  IconData# [ 6'    	  EllipseDiameter$ 20Q�6P    	  	IconWidth$ 14Q�6e    	  
IconHeight$ 14Q�6t   
�������{�.  6�   52      �� 53      -   5        $��ArtListView��53      $��
-20,10,0,0q�6�   ��6.   �� *articlesView+ �� SelectedItem 6T   �� *SelectedArticle+$ TwoWay=���54      �� 55      .R�56      � $��0,10,0,0q�6#    57   "   �� 58   &   $	��200 �67   �� 59   &   $	��200 �67   �� 5:   &   $��* �67   .+�5A   "   �� $��0��6-   $ 
Horizontal=�6=   .+�5B   &   �� $��16(�6X   ��60   ��  �� Path$ prod_grp.pgr_name�6X   5C   #   �� 5D   "   $��1��6-   $ 
Horizontal=�6=   .+�5E   &   �� $��16(�6O   ��60   �� $ art_name�6O   5F   #   5G      5I      5K      5L      5M      �� 5N   
   $��Stretch=�6   $
��Auto��6-   $��2��6;   $��2��6K   ._�5O      ]� -   5        $ acct_hdr��5O      $��2��6*   $
��Auto��6:   $
��Auto��6G   ��. .+�5P      � $��10,10,10,10q�6   $
��Auto��6,   $	��Top=�6:   $	��Top=�6R   .+�5Q      �� $ Vertical=�6!   .+�5R      �� .+�5S      �� $
��Left=�6(   �� 5T   &   $�Produktgruppe: ��6*   $��18(�6A    �� 5U   &   $��18(�6]   �6*   �� *#!SelectedArticle.prod_grp.pgr_name+6]    �� 5V   &   $�        ��6*    �� 5W   &   $�	Artikel: ��6*   $��18(�6;    �� 5X   &   $��18(�6T   �6*   �� *SelectedArticle.art_name+6T   5Y      5Z      5[      5\      � 5]      $��10,10,10,10q�6   
������ .+�5^      �� $ Vertical=�6!     5_       �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� �     7���� 5`      " ��6$   .�5a   "   ��  �@��Orientation$ 
Horizontal=�6@   �� 5b   "    � ��$ 0,0,0,4q�6;   5c      �� 5d      " ��6$   8   .�5e   "   ��  � ��$	 150��6:   �� 5f   "    � ��$ Center=�6F   5g      5h      .+�5i      �� .+�5j      �� $��Produktgruppe��6$   �� 5k      -   5         ��Name$
 Type��5k   '   $	��200��65    �� DisplayMemberPath$ pgr_name��6h    �� SelectedValuePath$ pgr_id��6�   ��6A   �� $ 	PrdGrpSrc� �� SelectedValue 6�   �� *	ProdGrpId+5l      �� 5m      .+�5n      �� $��Artikelname��6$   �� 5o      -   5         ��Name$ Article��5o   &   $	��200��67   ��6C   �� *	Article+$ TwoWay=�5p      �� 5q      .+�5r      �� $�� ��6$   5s      �� 5t      .+�5u      �� $��Preise��6$   $��SemiBold"�65   5v      �� 5w      $ Vertical=�6%   .+�5x      �� -   5         ��Name$ PriceTypeSrc��5x   +   ��6A   �� *PriceTypeSrc+$ TwoWay=���5y   "   �� 5z   &   .R�5{   *   �� $ 
Horizontal=�65   .+�5|   .   �� ��64   �� *PriceType.ptp_name+$ TwoWay=��� 5}   .   $	��200��66     �� TextAlignment$  Right=�6f   ��6B   �� *Price+$ TwoWay=�6f   5~   +   5   '   5�      5�      �� 5�      .+�5�      �� $�� ��6$   5�      �� 5�      .+�5�      �� -	   5        ! ��Name$! errormessage��5�   O   $��23��6(   $
��Left=�64   $	��Top=�6~   $	��500��6�   ��6f   �� *Status+��6�   �� *	FgColor+5�      	  5�      -
   5        $��btnSave��5�   +     DiskIconData# [ 6:   $ 26Q�6�   $ 14Q�6�   $ 14Q�6�   $
��Left=�6�   $ 	Speichern��6�   ��6c   �� $ Commands.save�6�   5�      5�      5�      5�      5�      5�      