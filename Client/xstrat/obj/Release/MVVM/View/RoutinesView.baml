   M S B A M L   `   `   `  ���� A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  %clr-namespace:xstrat.Ui	xstrat.Ui  #    xstrat.MVVM.View.RoutinesView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:xstrat.MVVM.View     *local1clr-namespace:xstrat.Ui     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aEmartialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� .+���   �� Orientation$  
Horizontal=�.+��� -   $��RoutinesOverview��$	��330��$
��Left=����#181818 �� CornerRadius$ 20��$	��750��$��
20,10,20,0q�$	��Top=�._��� $��Center=�.+��� $  
Horizontal=�$��Center=�$��0,5,0,0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon  $��50��$��50��
�������$��Center=�   Kind$ 	Timetable=��� 
�������$��40(�$��Center=�$��10,10,10,10q�$��SemiBold"�.��	Routines:�� $	��600��$	��310��$
��Auto=�.���� -   $��
RoutinesSP��$  Vertical=��� -   $��	NewButton�����#336cb5
�������$��17(�$��SemiBold"�$��
10,10,10,0q�$��0q�$��Add New��$��40��$	��100�� � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� $  Vertical=�.+��� -   $��EditRoutine��$	��450��$	��600��$
��Left=����#181818$ 20��$��
20,10,20,0q�._��� .+��� $  
Horizontal=�$��Center=�$��0,5,0,0q�.+�  $��50��$��50��
�������$��Center=�$ FormatListCheckbox=��� 
�������$��40(�$��Center=�$��10,10,10,10q�$��Normal"�.��Steps:�� $
��Auto=�$	��436��$	��500��.���� -   $��sp�� J� 	AllowDrop . 
������ $	��420��$
��Auto��$	��300��$
��Left=��� -   $��ButtonsPanel��$	��450��$	��130��$
��Left=����#181818$ 20��$��	20,20,0,0q�._��� $  
Horizontal=�$��Center=�.+��� -   $��
SaveButton�����#336cb5
�������$��17(�$��SemiBold"�$��10,10,10,10q�$��0q�$
��Save��$��40��$	��180�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� -   $��OpenOverlayButton�����#336cb5
�������$��17(�$��SemiBold"�$��10,10,10,10q�$��0q�$��Open in Overlay��$��40��$	��180�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��