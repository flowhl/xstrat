   M S B A M L   `   `   `  ����A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  5      %clr-namespace:xstrat.Ui	xstrat.Ui  6;   #    xstrat.MVVM.View.RoutinesView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:xstrat.MVVM.View     5      *local1clr-namespace:xstrat.Ui     6;   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aEmartialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6b   .��5	      � .+�5
   
   ��   �� Orientation$  
Horizontal=�6   .+�5      �� -   5        $��RoutinesOverview��5   �   $	��330��6   $
��Left=�6!   ���#181818 �� CornerRadius$ 20��6Q   $	��750��6c   $��
20,10,20,0q�6p   $	��Top=�6�   ._�5      �� $��Center=�6   .+�5      �� $  
Horizontal=�6!   $��Center=�6:   $��0,5,0,0q�6W   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��50��61   $��50��6=   
�������$��Center=�6[      Kind$ 	Timetable=�6v   6�   �� 5      
�������$��40(�63   $��Center=�6A   $��10,10,10,10q�6^   $��SemiBold"�6s   .��6�   	Routines:6�   5      �� 5      $	��600��6#   $	��310��60   $
��Auto=�6<   .��5      �� -   5        $��
RoutinesSP��5   <   $  Vertical=�6%   5      5      �� 5      -   5        $��	NewButton��5   �   ���#336cb5
�������$��17(�6E   $��SemiBold"�6S   $��
10,10,10,0q�6i   $��0q�6}   $��Add New��6�   $��40��6�   $	��100��6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6$   .�5   "   ��  �@��CornerRadius$ 10��6A   5      5      5      5      5      �� 5      $  Vertical=�6   .+�5      �� -   5        $��EditRoutine��5   �   $	��450��6   $	��600��6%   $
��Left=�62   ���#181818$ 20��6b   $��
20,10,20,0q�6t   ._�5       �� .+�5!      �� $  
Horizontal=�6%   $��Center=�6>   $��0,5,0,0q�6[   .+�5"        $��50��65   $��50��6A   
�������$��Center=�6_   $ FormatListCheckbox=�6z   6�   �� 5#      
�������$��40(�67   $��Center=�6E   $��10,10,10,10q�6b   $��Normal"�6w   .��6�   Steps:6�   5$      �� 5%      $
��Auto=�6'   $	��436��6J   $	��500��6V   .��5&      �� -   5        $��sp��5&   )    J� 	AllowDrop . 
������ $	��420��5'   =   $
��Auto��6I   $	��300��6W   $
��Left=�6g   5(      5)      5*      5+      �� 5,      -   5        $��ButtonsPanel��5,   �   $	��450��6   $	��130��6%   $
��Left=�62   ���#181818$ 20��6b   $��	20,20,0,0q�6t   ._�5-      �� $  
Horizontal=�6!   $��Center=�6:   .+�5.      �� -   5        $��
SaveButton��5.   �   ���#336cb5
�������$��17(�6I   $��SemiBold"�6W   $��10,10,10,10q�6m   $��0q�6�   $
��Save��6�   $��40��6�   $	��180��6�    5/      ��%_   '��       �� 50   "   " ��6(   .�51   &   ��  �@��CornerRadius$ 10��6E   52   #   53      54      �� 55      -   5        $��OpenOverlayButton��55   �   ���#336cb5
�������$��17(�6I   $��SemiBold"�6W   $��10,10,10,10q�6m   $��0q�6�   $��Open in Overlay��6�   $��40��6�   $	��180��6�    56      ��%_   '��       �� 57   "   " ��6(   .�58   &   ��  �@��CornerRadius$ 10��6E   59   #   5:      5;      5<      5=      5>      5?      5@      5A      