   M S B A M L   `   `   `  ����H  DStudentsPract, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:StudentsPract.Pages.DirectionsStudentsPract.Pages.Directions  5   	   2    ,StudentsPract.Pages.Directions.Direction_Add   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:StudentsPract.Pages.Directions     5   	     � Title$1  +Добавление направления��5   	      WindowStyle#���   5
   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � SizeToContent$ WidthAndHeight=�5   	    � WindowStartupLocation$ CenterOwner=�5   	    � AllowsTransparency . '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CornerRadius$ 0��6      GlassFrameThickness$ 0q�6(   	   ResizeBorderThickness$	 3q�6@   
   NonClientFrameEdges$

 None=�6Z   .��5      � $��5q�6     PrimaryColor#���  6   .+�5   
   � $��10q�6    � RowDefinitions 5      �� 5      $��* �6    6-   �� 5      $
��auto �6    60   .+�5      ��  �� Orientation$ Vertical=�6   $��0��60   .+�5      �� $1��+Добавление направления��6     TextSecondaryColor#���  5       $��13(�5        $��Center=�5!       $��Center=�5"       � 5%      $	��Top=�6   $��0 5 0 10q�6,   .+�5&      �� $��1��6   ��5'      �� 5(       �� EndPoint$	 0,0&�62    �� 
StartPoint$	 1,0&�6A   .��5)   "   �  � Color$ Transparent��6/    � Offset$ 0Q�6C   � 5*   "   $	 0.5Q�6q    6/   ��  �� Path$ Color�  AccentColor �� Source# [ 6q   � 5+   "   $ Transparent��6/   $ 1Q�6C   5,      5.      5/      � 50      $
��auto��6   $
��Left=�6$    � ColumnDefinitions 51      �� 52      �� 53      $
��auto �6+   $	��150��68    55      �� 56      �� 57      �� 58      �� 59      �� 5:      �� 5;      �� 5<      .+�5?      �� $-��'Название направления��6   $��0��6;   $��0��6K   $��0 0 0 10q�6X   �� 5@      -   5         ��Name$
 name��5@      $��1��6,   $��0��6<   $��	10 0 0 10q�6I   �� 5B      $#��Код направления��6   $��0��66   $��1��6F   $��0 0 0 10q�6S   �� 5C      -   5        $
 code��5C      $��1��6,   $��1��6<   $��	10 0 0 10q�6I   �� 5E      $��Кафедра��6   $��0��6.   $��2��6>   $��0 0 0 10q�6K   �� 5F      -   5         ��Name$ id_cathedra��5F      $��1��64   $��2��6D   $��	10 0 0 10q�6Q   5H      5I      �� 5K      $ 
Horizontal=�6   $��1��62   $��Center=�6?   $��
10 20 10 0q�6\   .+�5L      �� -   5         ��Name$ btnAdd��5L      $��Добавить��6)     MyButton#���  6<   {�.  6w   �� 5M      -   5        $ 	FormClose��5M      $��Отмена��6,   #���  6=   6`   5N      5O      �� 5Q   
   $	��0.7q�6   #���  6'   #���  6S    K� ZIndex$ -1��6    J� Effect 5R      3  -System.Windows.Media.Effects.DropShadowEffect  5S         
BlurRadius$ 10Q�6#      ShadowDepth$ 0Q�63      RenderingBias$ Quality=�6�      Color 6C   �� $ Color�# [ 6�   5U      5V      5W      