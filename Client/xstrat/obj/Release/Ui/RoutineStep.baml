   M S B A M L   `   `   `  ���� A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null%clr-namespace:xstrat.Ui	xstrat.Ui      xstrat.Ui.RoutineStep   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:xstrat.Ui     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� .+���   �� Orientation$  
Horizontal=�$	��420��$	��100��$
��Left=�.+��� $  Vertical=�$	��200��$	��100��$
��Left=�.+��� -    ��Name$ Header_Textbox��
�������
������ $��30(�$��Header��$��40��$��0q��� $
��Auto=�$��60��.���� -   $ Body_Textbox��
�������
������ $��15(�$��Description��$��60��$��0q� �� AcceptsReturn .  �� TextWrapping$
 Wrap=��� $	��180��$  Vertical=�$	��100��$��Right=�.+��� $  
Horizontal=�$��50��$��Center=�$	��150��.+��� -    ��Name$ 
Count_Plus��$��0q�$��30��$��30�����#336cb5.��'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��$��Center=�$��Center=�   Kind$	 Add=�
������� � 	Resources  �� 
TargetType �� Property	 �� Value��%:   '��       �� " ��.���  �@��CornerRadius$	 10���� -   
 ��Name$
 Count_Value��
�������$��SemiBold"�$��1��$��70��$��25(�$��Center=�$��Center=�$��0,0,0,0q�$��Center=��� -   $ Count_Minus��$��0q�$��30��$��30�����#336cb5.��  $��30��$��30��$��Center=�$��Center=�$ Minus=�
������� ��%:   '��       �� " ��.���  �@��CornerRadius$	 10���� $  
Horizontal=�$��50��$��Center=�$	��150��.+��� -   $ Duration_Plus��$��0q�$��30��$��30�����#336cb5.��  $��30��$��30��$��Center=�$��Center=�$	 Add=�
������� ��%:   '��       �� " ��.���  �@��CornerRadius$	 10���� -   $
 Duration_Value��
�������$��SemiBold"�$
��1:00��$��Center=�$��25(�$��Center=�$��70��$��0,0,0,0q��� -   $ Duration_Minus��$��0q�$��30��$��30�����#336cb5.��  $��30��$��30��$��Center=�$��Center=�$ Minus=�
������� ��%:   '��       �� " ��.���  �@��CornerRadius$	 10��� $��40��$
��Left=�.+��� $  
Horizontal=�$��40��.+��� $  Vertical=� K� ZIndex$ 1��$��Center=�$
��Left=�.+��� -	   $��DeleteButton��$��20��$��20��
������ 
�������$��0q�$	��Top=�$��0,0,0,30q�.��  $ Delete=�
�������$��20��$��20��$��Center=��� -
   $��AddBelowButton��$��20��$��20��
������ 
�������$��0q�$��Bottom=�$��0,30,0,0q�.��  $
 Plus=�
�������$��20��$��20��$��0q�$��Center=��� $  Vertical=�$ 1��$��Center=�$��Right=�.+��� -   $��MoveUpButton��$��20��$��20��
������ 
�������$��0q�$	��Top=�$��0,0,0,30q�.��  $ ArrowUp=�
�������$��20��$��20��$��Center=��� -   $��MoveDownButton��$��20��$��20��
������ 
�������$��0q�$��Bottom=�$��0,30,0,0q�.��  $ 	ArrowDown=�
�������$��20��$��20��$��0q�$��Center=�  ���#707070$��30��$��30��$
 Drag=�$��Center=�$��Center=��� $	��100��$��40��$
��Left=����#303030$ -1��