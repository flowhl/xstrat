   M S B A M L   `   `   `  ���� A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  %clr-namespace:xstrat.Ui	xstrat.Ui  '    !xstrat.MVVM.View.SkinSwitcherView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:xstrat.MVVM.View     *local1clr-namespace:xstrat.Ui     .��� .+���   �� Orientation$  
Horizontal=�.+��� $	��280��$	��280�����#202020 �� CornerRadius$ 10��$
��Left=�$	��Top=�$��10,10,10,10q�._��� $  Vertical=�$��Center=�$	��Top=�$��5,5,5,5q�.+��� $  
Horizontal=�$��Center=�.+��� 
�������$��28(�$��SemiBold"�$��Center=�.��Skins:   xstrat.Ui.ToggleSwitch  -     Name$ TS��   xstrat.Ui.ToggleSwitch   MouseLeftButtonDown$ TS_MouseLeftButtonDown��$��40��$��10,0,0,0q�$��Center=��� -   $��ApplyBtn��$��Apply��
����������#252525$��0q�$��0,10,0,0q�$��40��$	��200��$��20(� � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� -   $��Error��
���  ���� ���#336cb5$��8��$��0q�$	��200��$ 5��$��0,30,0,0q��� -   $��CurrentToNoSkin��$$��Save current as no-skin config��
����������#252525$��0q�$��0,30,0,0q�$��30��$	��200��$��14(� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� -   $��CurrentToSkin��$!��Save current as skin config��
����������#252525$��0q�$��0,5,0,0q�$��30��$	��200��$��14(� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� $	��280��$	��280�����#202020$��10,10,10,10q�$ 10��$��Right=�$	��Top=�._��� $  Vertical=�.+��� 
�������$��Info:��$��Center=�$��0q�$��18(�$��SemiBold"��� 
�������$��Center=�$��SemiBold"�How set up:�� 
�������$��Center=�$��0,5,0,0q�)'1: Unequip all skins and close the game�� 
�������$��Center=�$��0,5,0,0q�" 2: Click Save as non-skin config�� 
�������$��Center=�$��0,5,0,0q�423: Start game and equip all skins. Then close game�� 
�������$��Center=�$��0,5,0,0q�4: Click Save as skin config�� 
�������$��Center=�$��SemiBold"�$��0,20,0,0q�
How use:�� 
�������$��Center=�$��0,5,0,0q�1: Close game�� 
�������$��Center=�$��0,5,0,0q�2: Use button to toggle skins�� 
�������$��Center=�$��0,5,0,0q�3: Click apply�� 
�������$��Center=�$��0,5,0,0q�4: Start the game