   M S B A M L   `   `   `  ����A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  5      %clr-namespace:xstrat.Ui	xstrat.Ui  6�        xstrat.MVVM.View.LoginView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:xstrat.MVVM.View     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6;   $local1clr-namespace:xstrat.Ui  6�   -   5        .��5	      � .+�5
   
   ��   �� Orientation$  Vertical=�6   $��Center=�6,   $��	0,-65,0,0q�6I    �� CanVerticallyScroll .  $��Center=�6x   .+�5      �� $��/Images/slogan.png��6   $	��260��60   $��65��6<   �� 5      
�������$��
User Login��6'   $��Center=�6<   $��20(�6Y   $��SemiBold"�6g   $��	0,10,0,20q�6}   �� 5      -   5        $��Error��5      $�� ��6!   $��Center=�6,   
���  ��$	��250��6Z   �� 5      ���#202020 �� CornerRadius$ 10��6*   $��0,0,0,0q�6<   ._�5      �� $  
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ 	EmailIcon��5   .   $��Center=�6A      Kind$ Email=�6^   $��Center=�6k   
�������$��10,0,0,0q�6�   �� 5      -   5         ��Name$ email��5      $��30��6-   $	��200��69    �� 
CaretBrush
 �����
������ $��0q�6q   $��5,5,5,5q�6�   $��email��6�   $��Center=�6�   
�������6�   5      5      �� 5      ���#202020$ 10��6*   $��0,20,0,0q�6<   ._�5      �� $  
Horizontal=�6   .+�5        -   5        $ PwIcon��5   .   $��Center=�6>   $ Password=�6[   $��Center=�6k   
�������$��10,0,0,0q�6�   G� 5      -   5         G�Name$ password��5   "   $��30��64   $	��200��6@    G� 
CaretBrush
 �����
������ $��0q�6x   	 G� Password$	  ��6�   $��5,5,5,5q�6�   $��Center=�6�   
�������6�   5      5      � 5      .+�5      �� $  
Horizontal=�6   $
��Left=�66   .+�5         xstrat.Ui.ToggleSwitch  -   5        
  Name$
 
RememberMe��5   *   $��15��6>   6L   �� 5      ���#336cb5$��Right=�61   .��6M   Remember me6Z   5      �� 5      -   5        $��ForgotPW��5   I   ���#336cb5$��Right=�6-   .��6x   Forgot Password6�   5       �� 5!      -	   5        $��LoginBtn��5!   -   $��40��6   $	��250��6!   
�������$��Login��6P   $��17(�6`   ���#202020$��0q�6�   $��0,20,0,0q�6�    � 	Resources 5"       �� 
TargetType �� Property �� Value��%_   '��       �� 5#      " ��6   .�5$      ��  �@��CornerRadius$ 10��69   5%      5&      5'      �� 5)      $  
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   .+�5*      �� ���#336cb5$��8��6.   $��0q�69   $	��100��6M   $ 5��6Y   6l   �� 5+      ���#336cb5$��OR��6-   6<   �� 5,      ���#336cb5$��8��6.   $��0q�69   $	��100��6M   $ 5��6Y   6l   5-      �� 5.      -
   5        $��RegisterBtn��5.   -   $��40��6   $	��250��6!   
�������$��Register��6S   $��17(�6f   ���#202020$��0q�6�   $��0,10,0,0q�6�    5/      ��%_   '��       �� 50      " ��6   .�51      ��  �@��CornerRadius$ 10��69   52      53      54      55      56      57      