   M S B A M L   `   `   `  ����A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  5      1clr-namespace:xstrat.Calendarxstrat.Calendar  5      #    xstrat.MVVM.View.CalendarView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:xstrat.MVVM.View     5      0local1clr-namespace:xstrat.Calendar     5      -   5          >�Name$  
CalendarUI��5
      .��5      � .+�5   
   �� $
��Auto=�6   .��5      �� $��0q�6   ���#202020 �� CornerRadius$ 10��6>   $��10,10,10,10q�6P   ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� 
�������$��30(�6/   $��Center=�6=   .��6Z   Team Calendar:6j   #   xstrat.Calendar.CalendarMonth  5      -   5          Name$ CalendarMonthUI��5   +   $��
10,10,10,0q�6{      	GridBrush$ #336cb5��6�      GridBorderThickness$	 0.8Q�6�   $	��700��6�      Events 6D   ��  �� ElementName$ 
CalendarUI�� �� Path$ Events�6�   �� 5      ���#222222$��
0,-100,0,0q�62   $ 10��6F   ._�5      �� $ 
Horizontal=�6%   $��0,0,0,0q�6>   .+�5      �� -   5        $
��Row1��5   )   $ Vertical=�65   $	��100��6L   $	��200��6\   $��10q�6k   .+�5   "   �� -   5        $��OffDayChecks��5   �   
����������#b53333$��16(�6S   $��Center=�6a   	 d� 	IsChecked$
	 TrueY�6�   .��6�   
Off days6�   �� 5   "   -   5        $��ScrimChecks��5   �   
����������#336cb5$��16(�6S   $��Center=�6a   $
	 TrueY�6�   .��6�   Scrims6�   5      �� 5      -   5        $
��Row2��5   )   $ Vertical=�65   $	��100��6L   $	��200��6\   $��10q�6k   6y   �� 5      -   5        $
��Row3��5   )   $ Vertical=�65   $	��100��6L   $	��200��6\   $��10q�6k   6y   �� 5      -   5        $
��Row4��5   )   $ Vertical=�65   $	��100��6L   $	��200��6\   $��10q�6k   6y   �� 5      -	   5        $
��Row5��5   )   $ Vertical=�65   $	��100��6L   $	��200��6\   $��10q�6k   6y   5      5      5      5      5       5"      5#      