   M S B A M L   `   `   `  ����A  =xstrat, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nullclr-namespace:xstratxstrat  5      =#clr-namespace:xstrat.MVVM.ViewModelxstrat.MVVM.ViewModel  5      3clr-namespace:xstrat.MVVM.Viewxstrat.MVVM.View  5          
xstrat.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      &localclr-namespace:xstrat     5      9	viewModel#clr-namespace:xstrat.MVVM.ViewModel     5      /viewclr-namespace:xstrat.MVVM.View     5        �� 	Resources  5
       �� MergedDictionaries �� Source �� DataType)  #xstrat.MVVM.ViewModel.HomeViewModel   xstrat.MVVM.View.HomeView-  'xstrat.MVVM.ViewModel.SettingsViewModel#   xstrat.MVVM.View.SettingsView*  $xstrat.MVVM.ViewModel.AboutViewModel    xstrat.MVVM.View.AboutView1  +xstrat.MVVM.ViewModel.SkinSwitcherViewModel'   !xstrat.MVVM.View.SkinSwitcherView-	  'xstrat.MVVM.ViewModel.RoutinesViewModel#
   xstrat.MVVM.View.RoutinesView/  )xstrat.MVVM.ViewModel.StratMakerViewModel%   xstrat.MVVM.View.StratMakerView)   #xstrat.MVVM.ViewModel.TeamViewModel   xstrat.MVVM.View.TeamView-  'xstrat.MVVM.ViewModel.CalendarViewModel#   xstrat.MVVM.View.CalendarView*  $xstrat.MVVM.ViewModel.ScrimViewModel    xstrat.MVVM.View.ScrimView   HighlightedBackgroundBrush �� Color  MenuBackgroundBrush  NormalBorderBrush  SolidMenuFontBrush  HighlightedText �� 
TargetType �� Property �� Value �� 
TargetType	 �� Orientation
 K� IsItemsHost ��Name � ColumnDefinitions ��Name z� SharedSizeGroup ��Name �Name F�Name �Name �� Path �� RelativeSource �� Padding �� AncestorType � IsSharedSizeScope-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers P� Property P� Value �� 
TargetName J� SnapsToDevicePixels �� Stretch  ScrollThumbs �� CornerRadius  ScrollBarTrackThumb  � RowDefinitions! ]�Name" ]� Thumb# n�Name$ ]� IncreaseRepeatButton% ��Name& J� Opacity' ]� DecreaseRepeatButton( P� 
SourceName) �� Angle�� 5   
    5      �� 5      $ Ui/MenuButtonTheme.xaml?�6%   %�"  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5!      *,	 +)(�� �     5$      *, +)(�� ,    5'      *, +)(�� ^    5*      *, +)(�� �    5-      *, +)&	  �    &	 �    &	     &	 %    &	 H    'o� k    7  7  7  'm� �    7   7  7  7  7  7  '�� 1    &	 1    &	 u    '�� 1    �� 5      "  6   .R�5        5      �� 5      "  6   .R�5        5      �� 5      "  6   .R�5        5      �� 5      "  6   .R�5        5       �� 5!      " 	 6   .R�5"      
  5#      �� 5$      "  6   .R�5%        5&      �� 5'      "  6   .R�5(        5)      �� 5*      "  6   .R�5+        5,      �� 5-      "  6   .R�5.        5/      �� 54      $ #336cb5��6A   �� 55      $ #505050��6:   �� 56      $ #202020��68   �� 57      $ 	#FFFFFFFF��69   �� 58      $ 	#FFFFFFFF��66   �� 59      " o�6   .�5:      ��  �@�OverridesDefaultStyle . 6:   �� 5;       �@J�SnapsToDevicePixels . 68   �� 5=       � ��8   6/   �� 5>       � �� 5?      �� 5@      " o�6*   .R�5A      �� 8�� 8�� $��0q�5D      ._�5E   "   �� }�. $	 
Horizontal=�6A   
 . 6Z   5F      5G      5I      5J      �� 5K      " m�6   .�5L      ��  � �� 5M      �� 5N      " m�6*   .R�5O      �� $ Border��6%   #��z��5P      #��z��5Q      $��0q�5R      ._�5S   "   �  5T   &   �� 5U   *   $
 Col0��6;   $��17��6I   $
��Auto �6W   $ MenuItemIconColumnGroup��6d   �� 5V   *   $
��Auto �6;   $ MenuTextColumnGroup��6H   �� 5W   *   $
��Auto �6;   $ MenuItemIGTColumnGroup��6H   �� 5X   *   $
 Col3��6;   $��14 �6I   .+�5\   &   �� $
 Icon��6X   $��0��67   $��4,0,6,0q�6G   $��Center=�6f   $
��Icon��6�   � 5_   &   $ 
GlyphPanel��6`   $��0��6+   $y�Hidden=�6;   $��4,0,6,0q�6O   $��Center=�6t   .+�5`   *   F� $ GlyphPanelpath��6/   $��Center=�6G   #��z��6b   =����    �� �     >I Ѡ%& @�p �`Vl ��* �`Vl     Ѡ%& �0F 	$��LeftToRight=�6�   5a   '   �� 5d   &   $ 
HeaderHost��5f   !   $��1��5d   7   #��z��5e   !   ��. $��Header��5h   !   �� 5k   &   $ IGTHost��5m   !   $��2��5k   7   $��8,1,8,1q�5l   !   $��InputGestureText��5n   !   $��Center=�5o   !   � 5r   &   $ 
ArrowPanel��6L   $��3��6+   $��4,0,6,0q�6;   $��Center=�6`   .+�5s   *   F� $ ArrowPanelPath��6/   $��Right=�6G   $��Center=�6c   #��z��6~   "����        �     z � 	=  	= 	6�   5t   '   � 5w   &   $ SubMenuPopup��6�   $��Right=�6�   |�.  #��� -�6�   ��6,   �� $ IsSubmenuOpen� �� *TemplatedParent+.��5x   *   �� $ SubMenuBorder��61   $��0q�6�   $ 2,2,2,2q�6�   ��6H   �� $ 
Foreground� �� " o�._�5y   .   � $ SubMenu��63    . .+�5{   2   �� 
 . $ Cycle=�6P   5|   /   5}   +   5~   '   5   #   5�       5�      P� 5�   "    �@m�Role$ TopLevelHeader=�6:   . �5�   &   ��  � ��$ 6,1,6,1q�6@   �� 5�   &   $ SubMenuPopup��6Q    � ��$ Bottom=�6B   6Q   �� 5�   &   $
 Col0��6K    � ��$ 0��6A   6K   �� 5�   &   $
 Col3��6K    � ��$
 Auto �6>   6K   �� 5�   &   $
 Icon��6U    � y�$ 	Collapsed=�6C   6U   �� 5�   &   $ 
GlyphPanel��6U    � y�$ 	Collapsed=�6C   6U   �� 5�   &   $ IGTHost��6U    � y�$ 	Collapsed=�6C   6U   �� 5�   &   $ 
ArrowPanel��6U    � y�$ 	Collapsed=�6C   6U   5�   #   P� 5�   "    �@m�Role$ TopLevelItem=�6:   . �5�   &   ��  � ��$ 6,1,6,1q�6@   �� 5�   &   $ 
ArrowPanel��6U    � y�$ 	Collapsed=�6C   6U   5�   #   P� 5�   "    �@m�Role$ SubmenuHeader=�6:   . �5�   &   ��  � ��$	 Top=�6G   �� 5�   &    � ��$ 0,2,0,2q�6@   5�   #   P� 5�   "    �@m�Role$ SubmenuItem=�6:   . �5�   &   ��  � ��$	 Top=�6G   �� 5�   &    � ��$ 0,2,0,2q�6@   �� 5�   &   $ 
ArrowPanel��6U    � y�$ 	Collapsed=�6C   6U   5�   #   P� 5�   "   " �@m�IsSuspendingPopupAnimation . . �5�   &   �� $ SubMenuPopup��6T    � ��$
 None=�6G   6T   5�   #   P� 5�   "    6:   Z�  �@m�Icon. �5�   &   �� $
 Icon��6U    � y�$ 	Collapsed=�6C   6U   5�   #   P� 5�   "    �@m�	IsChecked . . �5�   &   �� $ 
GlyphPanel��6S    � y�$ Visible=�6C   6S   �� 5�   &   $
 Icon��6U    � y�$ 	Collapsed=�6C   6U   5�   #   P� 5�   "    �@m�IsHighlighted . . �5�   &   �� 8   $ Border��6w    � ���� 5�   &   8   � ��6C   �� 5�   &   8  $ Border��6o    � ��5�   #   P� 5�   "    �@m�IsHighlighted .  . �5�   &   �� 8  $ Border��6p    � ���� 5�   &   8   � ��6C   �� 5�   &   8  $ Border��6q    � ��5�   #   P� 5�   "    � {� .  . �5�   &   ��  � ��
 �����6C   5�   #   5�      5�      5�      �� 5�      " ��6   .�5�      ��  �@�OverridesDefaultStyle . 6:   �� 5�       � �� �#3030306/   �� 5�       � ��
 ���� 6/   �� 5�       � �� 5�      �� 5�      " ��6*   .R�5�      �� #��z��6%    . $��10��5�      $��10��5�      ._�5�   "   F� ����pH$u {f�@QȨ� {f�@QȨ� 6��/\#@QH$u 6��/\#@p�9 {f�@q��!�$@{f�@q��!�$@6��/\#@Q�9 6��/\#@p    {f�@Q�� {f�@Q�� 6��/\#@Q    6��/\#@p�9 !����@q��!�$@!����@q��!�$@P�O�O@Q�9 P�O�O@pH$u <���� @QȨ� <���� @QȨ� �Gb@QH$u �Gb@�H$u     �Ȩ�     �Ȩ� �� �H$u �� 	#��z��6�  $
��9.53��6�  $
 Fill=�6�  $	��Top=�6�  $��9.677��6�  5�      5�      5�      5�      �� 5�      " n�6)   .�5�      ��  � �� 5�      �� 5�      " n�6*   .R�5�      � $
 Grid��6#   .+�5�   "   �� $��Stretch=�6,   $��Stretch=�6J   $
��Auto��6f   $
��Auto��6s   
������ 6�   �� 5�   "   $ 
Rectangle1��6)   $ 10��6=   $��Stretch=�6O   $��Stretch=�6m   $
��Auto��6�   $
��Auto��6�   #��z��6�   5�       5�      P� 5�   "    �@�Tag$ 
Horizontal��69   . �5�   &   �� $ 
Rectangle1��6-    � ��$
 Auto��6V   �� 5�   &   $ 
Rectangle1��6-    � ��$ 7��6W   5�   #   5�      5�      5�      �� 5�      " n�5�   	   .�5�      ��  � �� 5�      �� 5�      " n�6*   .R�5�      � $
 Grid��6#   .+�5�   "   �� $��Stretch=�6,   $��Stretch=�5�   !   $
��Auto��5�   !   $
��Auto��5�   !   
������ 5�   !   �� 5�   "   $ CornerScrollBarRectangle��6)   $ 3��5�      $��Stretch=�5�      $��Stretch=�5�      $
��Auto��5      $
��Auto��5     $��0,1,0,1q�5     #��z��5     5      5     P� 5  "    �@�Tag$ 
Horizontal��5  !   . �5  &   �� $ CornerScrollBarRectangle��6-    � ��$
 Auto��5
  !   �� 5  &   $ CornerScrollBarRectangle��6-    � ��$ 6��5  !   5  #   5     5     5     �� 5     " ��6   .�5     ��  �@��IsFlicksEnabled .  5     �� 5      � �� �#6565655     �� 5      � �� �#3030305     �� 5      � ��$ 7��5     �� 5      � �� 5     �� 5     " ��6*   .R�5      � $ GridRoot��6#   $��7��5!     #��z��5"       5#  "   �� 5$  &   $��0.00001* �64   .+�5&  "   ]� $! 
PART_Track��6(   $��0��5'     ��. |�.  " 5*  &   n� 5+  *   $# Thumb��60   #��z��5,  %   #���  5-  %   $ 5/  &   �� 50  *   $% PageUp��67   $��ScrollBar.PageDownCommand��51  -   $& 0Q�52  -   |�.  53  -   ' 55  &   �� 56  *   $% PageDown��67   $��ScrollBar.PageUpCommand��57  -   $& 0Q�58  -   |�.  59  -   5;  #   5<      5=     P� 5>  "   $( Thumb��6*    �@J�IsMouseOver . . �5A  &   �� $ Thumb��5B  !    � �� �#8080805C  !   5D  #   P� 5E  "   $( Thumb��6*    �@n�
IsDragging . . �5H  &   �� $ Thumb��5I  !    � �� �#5555555J  !   5K  #   P� 5M  "    � {� .  . �5O  &   �� $ Thumb��6-    � y�$ 	Collapsed=�5Q  !   5R  #   P� 5S  "    �@��Orientation$ 
Horizontal=�5T  !   . �5U  &   �� $ GridRoot��6-    �@�LayoutTransform 5W  *   �� 5X  .   $	) -90Q�6>   5Z  '   �� 5[  &   $ 
PART_Track��6-    �@�LayoutTransform 5]  *   �� 5^  .   $	) -90Q�6>   5`  '   �� 5a  &    � ��$
 Auto��5b  !   �� 5c  &    � ��$ 8��5d  !   �� 5e  &   $ Thumb��6-    �@�Tag$ 
Horizontal��5g  !   �� 5h  &   $ PageDown��6-    � ��$ ScrollBar.PageLeftCommand��5j  !   �� 5k  &   $ PageUp��6-    � ��$  ScrollBar.PageRightCommand��5m  !   5n  #   5p     5r     5s     5v     5z     