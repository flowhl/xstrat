   M S B A M L   `   `   `  ����A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  5      %clr-namespace:xstrat.Ui	xstrat.Ui  6;   '    !xstrat.MVVM.View.SkinSwitcherView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:xstrat.MVVM.View     5      *local1clr-namespace:xstrat.Ui     6;   .��5	      � .+�5
   
   ��   �� Orientation$  
Horizontal=�6   .+�5      �� $	��280��6   $	��280��6!   ���#202020 �� CornerRadius$ 10��6C   $
��Left=�6U   $	��Top=�6p   $��10,10,10,10q�6�   ._�5      �� $  Vertical=�6   $��Center=�64   $	��Top=�6Q   $��5,5,5,5q�6i   .+�5      �� $  
Horizontal=�6!   $��Center=�6:   .+�5      �� 
�������$��28(�63   $��SemiBold"�6A   $��Center=�6W   .��6y   Skins:6�      xstrat.Ui.ToggleSwitch  5      -   5          Name$ TS��5   .      xstrat.Ui.ToggleSwitch   MouseLeftButtonDown$ TS_MouseLeftButtonDown��6:   $��40��6g   $��10,0,0,0q�6s   $��Center=�6�   6�   5      �� 5      -   5        $��ApplyBtn��5   -   $��Apply��6   
����������#252525$��0q�6e   $��0,10,0,0q�6y   $��40��6�   $	��200��6�   $��20(�6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6$   .�5   "   ��  �@��CornerRadius$ 10��6A   5      5      5      �� 5      -   5        $��Error��5      
���  ��6<   �� 5      ���#336cb5$��8��62   $��0q�6=   $	��200��6Q   $ 5��6]   $��0,30,0,0q�6n   6�   �� 5      -   5        $��CurrentToNoSkin��5   F   $$��Save current as no-skin config��6   
����������#252525$��0q�6�   $��0,30,0,0q�6�   $��30��6�   $	��200��6�   $��14(�6�    5      ��%_   '��       �� 5      " ��6$   .�5   "   ��  �@��CornerRadius$ 10��6A   5      5      5       �� 5!      -   5        $��CurrentToSkin��5!   C   $!��Save current as skin config��6   
����������#252525$��0q�6�   $��0,5,0,0q�6�   $��30��6�   $	��200��6�   $��14(�6�    5"      ��%_   '��       �� 5#      " ��6$   .�5$   "   ��  �@��CornerRadius$ 10��6A   5%      5&      5'      5)      5*      �� 5,      $	��280��6   $	��280��6!   ���#202020$��10,10,10,10q�6C   $ 10��6X   $��Right=�6j   $	��Top=�6�   ._�5-      �� $  Vertical=�6   .+�5.      �� 
�������$��Info:��6/   $��Center=�6?   $��0q�6\   $��18(�6p   $��SemiBold"�6~   6�   �� 5/      
�������$��Center=�63   $��SemiBold"�6P   How set up:6s   �� 50      
�������$��Center=�63   $��0,5,0,0q�6P   )'1: Unequip all skins and close the game6�   �� 51      
�������$��Center=�63   $��0,5,0,0q�6P   " 2: Click Save as non-skin config6�   �� 52      
�������$��Center=�63   $��0,5,0,0q�6P   423: Start game and equip all skins. Then close game6�   �� 53      
�������$��Center=�63   $��0,5,0,0q�6P   4: Click Save as skin config6   �� 54      
�������$��Center=�63   $��SemiBold"�6P   $��0,20,0,0q�6f   
How use:6�   �� 55      
�������$��Center=�63   $��0,5,0,0q�6P   1: Close game6p   �� 56      
�������$��Center=�63   $��0,5,0,0q�6P   2: Use button to toggle skins6�   �� 57      
�������$��Center=�63   $��0,5,0,0q�6P   3: Click apply6q   �� 58      
�������$��Center=�63   $��0,5,0,0q�6P   4: Start the game6t   59      5:      5;      5<      5=      