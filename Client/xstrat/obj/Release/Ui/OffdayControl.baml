   M S B A M L   `   `   `  ���� A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null%clr-namespace:xstrat.Ui	xstrat.Ui      xstrat.Ui.OffdayControl   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:xstrat.Ui     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFMaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  X TXceed.Wpf.Toolkit, Version=4.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  .��� $��60��$	��700��$��Center=�$��Center=�.+��� $��60��$	��700��  �� CornerRadius$  10�����#181818._���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�$��30��$
��Left=�.+��� -   $��DeleteButton��$��30��$��30��
������ 
�������$��0q�$��0,0,70,0q���'  !MaterialDesignThemes.Wpf.PackIcon  $��20��$��20��   Kind$ DeleteOutline=��� -   $��	TitleText��$	��200��
�������
������ $��0q�$��Title��$��Center=�$��18(�$��0,0,10,0q��� ���#AAAAAA$��Center=�$��15(�.��
Created on�� -   $��CreationDate�����#AAAAAA$��Center=�$��15(�$��0,0,80,0q�.��
01.01.2022   xstrat.Ui.DataSelector  -     Name$ TypeSelector��   type$ 3��$	��130��$��25��$��5,0,0,0q��� $ 
Horizontal=�$��30��$��Center=�.+�(  "System.Windows.Controls.DatePicker  -   $��FromDatePicker��
������ $��4q�$��Center=�$��0q����#336cb5   CalendarStyle ��  �� 
TargetType&   System.Windows.Controls.Calendar"  .���  �� Property � �� �� Value
 �   ���  � ��$ 0q�	 � 	Resources	 :  4System.Windows.Controls.Primitives.DatePickerTextBox��%`   '        �� "  .���  � ��
 ���� ��  � ��$ 0q���  � �� �#336cb5�� -   $��TimeControl��$ 
Horizontal=�.+��� ���#336cb5$��Center=�$��15(�$��	20,0,10,0q�.��From  $ Clock=����#AAAAAA$��20��$��20��$��Center=�(� $��20��.��   xstrat.Ui.NumberBox  -   
  Name$
 FromHour��   allowNegative .     limit$ 23���� ���#AAAAAA$��Center=�$��15(�$��-5,0,0,0q�.��h(� $��20��.��  -   $
 
FromMinute�� .  $ 59���� ���#AAAAAA$��Center=�$��15(�$��-5,0,0,0q�.��min�� ���#336cb5$��Center=�$��15(�$��	10,0,10,0q�.��to  $ Clock=����#AAAAAA$��20��$��20��$��Center=�(� $��20��.��  -	   $
 ToHour�� .  $ 23���� ���#AAAAAA$��Center=�$��15(�$��-5,0,0,0q�.��h(� $��20��.��  -
   $
 ToMinute�� .  $ 59���� ���#AAAAAA$��Center=�$��15(�$��-5,0,0,0q�.��min