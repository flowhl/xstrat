   M S B A M L   `   `   `  ���� A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  %clr-namespace:xstrat.Ui	xstrat.Ui       xstrat.MVVM.View.LoginView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:xstrat.MVVM.View     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  $local1clr-namespace:xstrat.Ui  -   .��� .+���   �� Orientation$  Vertical=�$��Center=�$��	0,-65,0,0q� �� CanVerticallyScroll .  $��Center=�.+��� $��/Images/slogan.png��$	��260��$��65���� 
�������$��
User Login��$��Center=�$��20(�$��SemiBold"�$��	0,10,0,20q��� -   $��Error��$�� ��$��Center=�
���  ��$	��250���� ���#202020 �� CornerRadius$ 10��$��0,0,0,0q�._��� $  
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  -     Name$ 	EmailIcon��$��Center=�   Kind$ Email=�$��Center=�
�������$��10,0,0,0q��� -    ��Name$ email��$��30��$	��200�� �� 
CaretBrush
 �����
������ $��0q�$��5,5,5,5q�$��email��$��Center=�
��������� ���#202020$ 10��$��0,20,0,0q�._��� $  
Horizontal=�.+�  -   $ PwIcon��$��Center=�$ Password=�$��Center=�
�������$��10,0,0,0q�G� -    G�Name$ password��$��30��$	��200�� G� 
CaretBrush
 �����
������ $��0q�	 G� Password$	  ��$��5,5,5,5q�$��Center=�
�������� .+��� $  
Horizontal=�$
��Left=�.+�   xstrat.Ui.ToggleSwitch  -   
  Name$
 
RememberMe��$��15���� ���#336cb5$��Right=�.��Remember me�� -   $��ForgotPW�����#336cb5$��Right=�.��Forgot Password�� -	   $��LoginBtn��$��40��$	��250��
�������$��Login��$��17(����#202020$��0q�$��0,20,0,0q� � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� $  
Horizontal=�$��Center=�$��0,10,0,0q�.+��� ���#336cb5$��8��$��0q�$	��100��$ 5���� ���#336cb5$��OR���� ���#336cb5$��8��$��0q�$	��100��$ 5���� -
   $��RegisterBtn��$��40��$	��250��
�������$��Register��$��17(����#202020$��0q�$��0,10,0,0q� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��