   M S B A M L   `   `   `  ����A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  5      #    xstrat.MVVM.View.RegisterView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:xstrat.MVVM.View     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6;   .��5	      � .+�5
   
   ��   �� Orientation$  Vertical=�6   $��Center=�6,   $��	0,-65,0,0q�6I    �� CanVerticallyScroll .  $��Center=�6x   .+�5      �� $��/Images/slogan.png��6   $	��250��60   $��65��6<   �� 5      
�������$��Register now!��6'   $��Center=�6?   $��20(�6\   $��SemiBold"�6j   $��	0,10,0,20q�6�   �� 5      -   5        $��Error��5      $�� ��6!   $��Center=�6,   
���  ��$	��250��6Z   �� 5      ���#202020 �� CornerRadius$ 10��6*   $��0,5,0,0q�6<   ._�5      �� $  
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ NameIcon��5   .   $��Center=�6@      Kind$ Person=�6]   $��Center=�6k   
�������$��10,0,0,0q�6�   �� 5      -   5         ��Name$ username��5      $��30��60   $	��200��6<    �� 
CaretBrush
 �����
������ $��0q�6t   $��5,5,5,5q�6�   $��username��6�   $��Center=�6�   
�������6�   5      5      �� 5      ���#202020$ 10��6*   $��0,15,0,0q�6<   ._�5      �� $  
Horizontal=�6   .+�5        -   5        $ 	EmailIcon��5   .   $��Center=�6A   $ Email=�6^   $��Center=�6k   
�������$��10,0,0,0q�6�   �� 5      -   5        $ email��5      $��30��6-   $	��200��69   
 �����
������ $��0q�6q   $��5,5,5,5q�6�   $��email��6�   $��Center=�6�   
�������6�   5      5      �� 5      ���#202020$ 10��6*   $��0,20,0,0q�6<   ._�5      �� $  
Horizontal=�6   .+�5        -   5        $ PwIcon��5   .   $��Center=�6>   $ Password=�6[   $��Center=�6k   
�������$��10,0,0,0q�6�   G� 5      -   5         G�Name$ password��5   "   $��30��64   $	��200��6@    G� 
CaretBrush
 �����
������ $��0q�6x   	 G� Password$	  ��6�   $��5,5,5,5q�6�   $��Center=�6�   
�������6�   5      5      �� 5       $  
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   �� 5!      -   5        $��RegisterBtn��5!   -   $��40��6   $	��250��6!   
�������$��Register��6S   $��17(�6f   ���#202020$��0q�6�   $��0,10,0,0q�6�   
 � 	Resources
 5"       �� 
TargetType �� Property �� Value��%_   '��       �� 5#      " ��6   .�5$      ��  �@��CornerRadius$ 10��69   5%      5&      5'      �� 5(      -	   5        $��BackBtn��5(   -   $��40��6   $	��250��6!   
�������$��Back to login��6O   $��17(�6g   ���#202020$��0q�6�   $��0,10,0,0q�6�   
 5)      ��%_   '��       �� 5*      " ��6   .�5+      ��  �@��CornerRadius$ 10��69   5,      5-      5.      5/      50      51      