   M S B A M L   `   `   `  ����A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null%clr-namespace:xstrat.Ui	xstrat.Ui  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� BasedOn �� 
TargetType   MenuButtonTheme �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value  MyMenuItemTemplateKey � ColumnDefinitions	 z� SharedSizeGroup
 ��Name m� InputGestureText �� CornerRadius �� Triggers �� 
TargetName  MyMenuItemStyle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      !localclr-namespace:xstrat.Ui  5      %L	  &	        7d�&	 �    &	 S    7  7  �� 5      8    " 	�5      �5   
   �� 5	       � �� 5
      �� 5      " 	�6&   .R�5      � $��Stretch=�6   $��Stretch=�5      #��z��5      .+�5      �� #��z��5   !   $��Center=�5   !   $��20,0,0,0q�5   *   5      5      5      �� 5       � ��
 ���� 6+   �� 5       � ��$ 0q�60    5   
   P� 5       �@d�	IsChecked$
 TrueY�6+   . �5       ��  � �� �#0909096/   5!      5$      �� 5&      " m�64   .R�5'   
   � $��Border��6   $��25��6    5(      �� 5)      $��32 �6#   $
	 Icon��6.   �� 5*      $��* �6#   �� 5+      $
��Auto �6#   $	 Shortcut��60   �� 5,      $��13 �6#   .+�5.      �� $��
BorderIcon��6   $��0��6'   
���  ��$��0,0,1,0q�6I   ._�5/      �� $
��Icon��6#   $��5,0,5,0q�6/   $��Center=�6@   $
��Icon��6[   50      �� 51      $��
HeaderHost��6   $��1��61   $��Header��6A   $��5,0,0,0q�6X   $��Center=�6i   ��. 6�   �� 52      $
 InputGestureText��6   $��2��62   #��z 6B   $��10,2,2,2q�6l   $��Center=�6~   $��Right=�6�   �� 53      $��BorderChecked��6   $��3��6*   $ 2��6:   
������ $��5,2,5,2q�6d   �� 54      $��BorderDisable��6   $��Stretch=�6*   $��Stretch=�6F   
������ 6d   55       56   
   P� 57       6&   Z�  �@m�Icon. �58      �� $
 Icon��6    � y�$ Hidden=�6A   59      P� 5:       �@m�IsHighlighted . . �5;      �� $ Border��6    � ��
 ��  �6C   5<      P� 5=       �@m�	IsChecked . . �5>      �� $ BorderChecked��6    � ��
 � � �6J   5?      P� 5@       � {� .  . �5A      �� $ BorderDisable��6    � �� �	#3FFFFFFF6J   5B      P� 5C       � {� . . �5D      ��  � ��
 �   �6/   5E      5G      �� 5H      " m�6$   .�5I   
   ��  �@�OverridesDefaultStyle . 62   �� 5J   
    � ��$ Verdana)�6'   �� 5K   
    � ��$ 8.5pt(�6%    5L   
   P� 5M       �@m�Role$ TopLevelItem=�6&   . �5N      ��  � ��8   6-   5O      P� 5Q       �@m�Role$ SubmenuItem=�6&   . �5R      ��  � ��8  6-   5S      P� 5T       �@m�	IsChecked . . �5U      ��  � ��
 � � �6/   5V      5X      5Z      