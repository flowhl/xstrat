   M S B A M L   `   `   `  ���� A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  %clr-namespace:xstrat.Ui	xstrat.Ui      xstrat.MVVM.View.TeamView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:xstrat.MVVM.View     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  $local1clr-namespace:xstrat.Ui  .��� .+��� $
��Auto=�.����   �� Orientation$  Vertical=�.+��� -   $��JoinCreatePanel��$  
Horizontal=�$y�	Collapsed=�.+��� -   $��JoinTeamPannel��$��0q����#161616 �� CornerRadius$ 10��$	��350��$	��280��$��10,10,10,10q�$
��Left=�._��� $  Vertical=�$��5,5,5,5q�.+��� 
�������$��24(�$��SemiBold"�$��0,10,0,0q�$��Center=�.��No team? Join now!�� ���#202020$ 10��$��0,20,0,0q�$	��250��._��� $  
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  -     Name$ 	joinIcon1��$��Center=�   Kind$ 	PersonAdd=�$��Center=�
�������$��10,0,0,0q��� -    ��Name$ team_id��$��30��$	��200�� �� 
CaretBrush
 �����
������ $��0q�$��5,5,5,5q�$��Team ID��$��Center=�
��������� ���#202020$ 10��$��0,20,0,0q�$	��250��._��� $  
Horizontal=�.+�  -   $ 	joinIcon2��$��Center=�$ Password=�$��Center=�
�������$��10,0,0,0q��� -   $ password��$��30��$	��200��
 �����
������ $��0q�$��Join Password��$��5,5,5,5q�$��Center=�
��������� -   $��JoinBtn��$��40��$	��250��
�������$
��Join��$��17(����#202020$��0q�$��0,20,0,0q� � 	Resources  �� 
TargetType �� Property	 �� Value��%:   '��       �� " ��.���  �@��CornerRadius$	 10���� -   $��CreateTéamPanel��$��0q����#161616$ 10��$	��350��$	��280��$��10,10,10,10q�$
��Left=�._��� $  Vertical=�$��5,5,5,5q�.+��� 
�������$��24(�$��SemiBold"�$��0,10,0,0q�$��Center=�.��Create your own!�� ���#202020$ 10��$��0,20,0,0q�$	��250��._��� $  
Horizontal=�.+�  -	   $ 	EmailIcon��$��Center=�$ Email=�$��Center=�
�������$��10,0,0,0q��� -
   $ 	team_name��$��30��$	��200��
 �����
������ $��0q�$��5,5,5,5q�$��	Team Name��$��Center=�
�������   xstrat.Ui.DataSelector  -   
  Name$
 GameSelector��   type$ 2��$	��250��$��0,20,0,0q��� -   $��	CreateBtn��$��40��$	��250��
�������$��Create��$��17(����#202020$��0q�$��0,20,0,0q� ��%:   '��       �� " ��.���  �@��CornerRadius$	 10���� -   $��TeamDashboard��$  
Horizontal=�$y�	Collapsed=�.+��� $��0q����#121212$ 10��$	��820��$	��620��$��10,10,10,10q�$
��Left=�._��� $  Vertical=�.+��� 
�������$��34(�$��SemiBold"�$��0,10,0,0q�$��Center=�.��
Your Team:   xstrat.Ui.TeamDashboard  -     Name$ 
TDashboard��$	��600��$	��800��   xstrat.Ui.OffDaysList  -     Name$ offDayPanel��$
��Left=�$	��620��$	��820��$y�Hidden=�