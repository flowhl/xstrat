   M S B A M L   `   `   `  ����O  KWPFExtensions, Version=1.0.3437.34043, Culture=neutral, PublicKeyToken=nullV;clr-namespace:WPFExtensions.Controls;assembly=WPFExtensionsWPFExtensions.Controls  5      A =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View 5      %clr-namespace:xstrat.Ui	xstrat.Ui 6;   %   xstrat.MVVM.View.StratMakerView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nwpfext;clr-namespace:WPFExtensions.Controls;assembly=WPFExtensions     5      0localclr-namespace:xstrat.MVVM.View     5      *local1clr-namespace:xstrat.Ui     6;   .��5
      �   � ColumnDefinitions  5   
   �� 5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      �� 5      $	��150 �6   .+�5   
   ]� .+�5      o� -   5        $
��Menu��5   =   $	��Top=�6   ���#202020$
��Auto��6I   5      �� 5   
   ���#202020$��0q�6&    �� CornerRadius$ 0,0,20,0��6:   $��2��6R   ._�5      �   5      �� 5      $	��300 �6'   �� 5      .+�5      ��  �� Orientation$ Vertical=�6   $��0��64   .+�5      �� -   5        $��MapSelector��5   @   $	��150��6   $��10,10,10,10q�6+   6�   5      5      5       �� 5!   
   ���#161616$��0q�6&   $��1��6;   ._�5"      �   5#      �� 5$      $��* �6'   �� 5%      $
��Auto �6'   .+�5'      (   "WPFExtensions.Controls.ZoomControl  
������ .��5(      � -   5        $��
MapContent��5(      .+�5)      �� -   5        $��
WallsLayer��5)   !    K� ZIndex$ 1��63   .+�5*        xstrat.Ui.WallControl  -   5          Name$ WallControl1��5*   1   $��9��6G   $��60��6R   $ 2��6]    �� Left$	 300��6n   
 �� Top$	 200��6�   6�   5+      �� 5,      -   5        $��MapStack��5,   >   $ 
Horizontal=�6%   6P   5-      5.      9� 5/       9� ExpandDirection$
 Left=�6   $��1��62   $��Right=�6B   {�. ���#171717.��50      �� -   5        $��	Kommentar��50      
�������$	��200��6B   	 �� TextWrapping$
	 Wrap=�6N   ���#171717
 �� AcceptsReturn
 . 6�   51      52      53      54      55      