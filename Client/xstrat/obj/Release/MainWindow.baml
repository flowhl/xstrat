   M S B A M L   `   `   `  ���� A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:xstrat.MVVM.ViewModelxstrat.MVVM.ViewModel  3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  clr-namespace:xstratxstrat      xstrat.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9	viewModel#clr-namespace:xstrat.MVVM.ViewModel     /viewclr-namespace:xstrat.MVVM.View     &localclr-namespace:xstrat     $	��800��$
��1350��  � WindowStyle$
  None=� � 
ResizeMode$ CanResizeWithGrip=�
������  � AllowsTransparency .  � DataContext )  #xstrat.MVVM.ViewModel.MainViewModel  .���� ���#131313 �� CornerRadius$ 20��._��  � ColumnDefinitions �� $	��200 ���  � RowDefinitions �� $��25 ��� .+��� -   $��2�����#303030._�� $��Stretch=�.+��� $��./Images/topbar.png��$
��Left=�$��Center=�$��3,0,0,0q��� $��Right=� �� Orientation$ 
Horizontal=�.+��� -   $��20��$��20��$
��🗕��
������ $��0q�
�������$
��Bold"�$��0,0,0,3q��� -   $��20��$��20��$
��🗙��
������ $��0q�
�������$
��Bold"��� ���#101010$��2��$ 12��._��� .+�	� $
��Home��$��50��
�������$��14(�   MenuButtonTheme#��[   d� 	IsChecked$
 TrueY����� *HomeViewCommand+	� $��Strats��$��50��
�������$��14(�#��[  ���� *StratMakerViewCommand+	� $
��Team��$��50��
�������$��14(�#��[  ���� *TeamViewCommand+	� $��Calendar��$��50��
�������$��14(�#��[  ���� *CalendarViewCommand+	� $��Routines��$��50��
�������$��14(�#��[  ���� *RoutinesViewCommand+	� $��Skin Switcher��$��50��
�������$��14(�#��[  ���� *SkinSwitcherViewCommand+	� $��Settings��$��50��
�������$��14(�#��[  ���� *SettingsViewCommand+	� $��About��$��50��
�������$��14(�#��[  ���� *AboutViewCommand+�� -   $��contentControl��$��1��$��1��$��	0,0,10,10q����� *CurrentView+