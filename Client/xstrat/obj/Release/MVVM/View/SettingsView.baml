   M S B A M L   `   `   `  ���� A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  %clr-namespace:xstrat.Ui	xstrat.Ui  #    xstrat.MVVM.View.SettingsView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:xstrat.MVVM.View     *local1clr-namespace:xstrat.Ui     .����   �� Orientation$  
Horizontal=�$	��775��$
��1150��.+��� $  Vertical=�.+��� $��0q����#202020 �� CornerRadius$ 10��$	��300��$	��200��$��10,10,10,10q�._��� $  Vertical=�$��5,5,5,5q�.+��� 
�������$��18(�$��General:��$��Center=�$��SemiBold"��� $  Vertical=�.+��� $  
Horizontal=�$
��Left=�.+�   xstrat.Ui.ToggleSwitch  -     Name$ RememberMeSettings��$��20���� 
�������$��14(�$��Right=�.��Stay logged in for 30 days�� -   $��RememberMeBtn��$
��Save��
����������#252525$��0q�$��10,0,0,0q�$��25��$��70�� � 	Resources  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 5���� $  
Horizontal=�.+��� 
�������$��Bottom=�.��
Api-Url:�� -   $��APIText�����#336cb5$��Center=�
������ $��25��$��0q�.��https://api.xstrat.app�� $��0q����#202020$ 10��$	��300��$	��200��$��10,10,10,10q�._��� $  Vertical=�$��5,5,5,5q�.+��� 
�������$��18(�$��Skin Switcher:��$��SemiBold"�$��Center=��� 
�������$��14(�$��Savegames folder:��$��Center=�$��0,0,0,0q��� -   $��SkinSwitcherPathDisplay�����#252525$
��Wrap=�
�������$��10(�$��40��$�� ���� -   $��SkinSwitcherPickPathBtn��$��
Pick here:��
����������#252525$��0q�$��0,10,0,0q�$��30��$��90�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� $��0,20,0,0q����#606060
������ $��WrapWithOverflow=�hfSelect this folder: "C:\Program Files (x86)\Ubisoft\Ubisoft Game Launcher\savegames\YourAccountID\635"