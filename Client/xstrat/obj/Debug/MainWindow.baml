   M S B A M L   `   `   `  ����A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:xstrat.MVVM.ViewModelxstrat.MVVM.ViewModel  5   	   3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  5   	   clr-namespace:xstratxstrat  5   	       xstrat.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9	viewModel#clr-namespace:xstrat.MVVM.ViewModel     5   	   /viewclr-namespace:xstrat.MVVM.View     5   	   &localclr-namespace:xstrat     5   	   $	��800��5
   	   $
��1350��6     � WindowStyle$
  None=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	   
������  � AllowsTransparency .  � DataContext 5      )  #xstrat.MVVM.ViewModel.MainViewModel  5   
   .��5      �� ���#131313 �� CornerRadius$ 20��6"   ._�5      �  � ColumnDefinitions 5      �� 5      $	��200 �6'   �� 5       � RowDefinitions 5      �� 5      $��25 �6$   �� 5      .+�5#      �� -   5        $��2��5#      ���#303030._�5(      � $��Stretch=�6   .+�5*      �� $��./Images/topbar.png��6    $
��Left=�6=   $��Center=�6X   $��3,0,0,0q�6s   �� 5,      $��Right=�6%    �� Orientation$ 
Horizontal=�5-   !   .+�5/      �� -   5        $��20��5/   %   $��20��60   $
��🗕��50   !   
������ $��0q�52   !   
�������$
��Bold"�54   !   $��0,0,0,3q�55   !   56   @   �� 58      -   5        $��20��58   %   $��20��60   $
��🗙��59   !   
������ $��0q�5;   !   
�������$
��Bold"�5=   !   5>   =   5A      5C      5D      �� 5F      ���#101010$��2��6.   $ 12��6;   ._�5G      �� .+�5H      	� $
��Home��6&   $��50��5I      
�������$��14(�5K         MenuButtonTheme#��[  5L       d� 	IsChecked$
 TrueY�5M      ��5N      �� *HomeViewCommand+	� 5Q      $��Strats��6&   $��50��5R      
�������$��14(�5T      #��[  5U      ��5V      �� *StratMakerViewCommand+	� 5X      $
��Team��6"   $��50��5Y      
�������$��14(�5[      #��[  5\      ��5]      �� *TeamViewCommand+	� 5_      $��Calendar��6"   $��50��5`      
�������$��14(�5b      #��[  5c      ��5d      �� *CalendarViewCommand+	� 5f      $��Scrims��6"   $��50��5g      
�������$��14(�5i      #��[  5j      ��5k      �� *ScrimViewCommand+	� 5n      $��Stats��6"   $��50��5o      
�������$��14(�5q      #��[  5r      ��5s      �� *StatsViewCommand+	� 5w      $��Routines��6"   $��50��5x      
�������$��14(�5z      #��[  5{      ��5|      �� *RoutinesViewCommand+	� 5~      $��Skin Switcher��6&   $��50��5      
�������$��14(�5�      #��[  5�      ��5�      �� *SkinSwitcherViewCommand+	� 5�      $��Settings��6&   $��50��5�      
�������$��14(�5�      #��[  5�      ��5�      �� *SettingsViewCommand+	� 5�      $��About��6&   $��50��5�      
�������$��14(�5�      #��[  5�      ��5�      �� *AboutViewCommand+5�      5�      �� 5�      -   5        $��contentControl��5�      $��1��5�   !   $��1��5�      $��	0,0,10,10q�5�      ��5�      �� *CurrentView+5�      5�      5�      