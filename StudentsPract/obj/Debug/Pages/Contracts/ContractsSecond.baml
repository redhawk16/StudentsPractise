   M S B A M L   `   `   `  ����H  DStudentsPract, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:StudentsPract.Pages.ContractsStudentsPract.Pages.Contracts  5      =#clr-namespace:StudentsPract.ClassesStudentsPract.Classes  5      3    -StudentsPract.Pages.Contracts.ContractsSecond   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:StudentsPract.Pages.Contracts     5      7classes#clr-namespace:StudentsPract.Classes     5        N� Title$  ContractsSecond��5
         	PageStyle#��[  5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   ��  �� Orientation$ Vertical=�6   $
��Left=�6,   $��0��6G   .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      $
��auto �6'   $	��150��64    5      �� 5      �� 5      .+�5!      �� $��Вид практики��6   $��0��6/   $��0��6?   �� 5"      -   5         ��Name$ 	formPract��5"      $��1��6.   $��0��6>   �� 5%      $��Тип практики��6   $��0��6/   $��1��6?   �� 5&      -   5        $ 
type_pract��5&      $��1��6/   $��1��6?   5'      5(      �� 5+   
   $ 
Horizontal=�6   $��Right=�6.   $	��Top=�6J   $��0��6b   6q   �� 5-   
   $��1��6   $��0 10 0 0q�6"   .+�5.      R� -   5         R�Name$ treeView��5.      $	��150��5/      ��50      ��  �� RelativeSource ��  �� AncestorType$
 PageL� �� Path$ TreeView�	 � 	Resources	 52      
 �� DataType"   StudentsPract.Classes.Parent �� ItemsSource d� 	IsChecked �� Mode �� UpdateSourceTrigger!   StudentsPract.Classes.Child��%�  (��       53   /   *, +)(�� �     57   #   *, +)�� 53      "
  6/    6R   �� *	Members+.R�54      �� -   5        ��54   #   �� *Name+ 6<   �� $$ (classes:ItemHelper.IsChecked)�$ TwoWay=�$ PropertyChanged=�55   F   56      �� 57      "
  6#   .R�58      �� -   5        ��58   #   �� *Name+ 6<   �� $$ (classes:ItemHelper.IsChecked)�$ TwoWay=�$ PropertyChanged=�59   F   5:      5;      ��5=      �� 5>       �� 
TargetType" Q�6   .�5?      ��  �� Property �@Q�
IsExpanded �� Value .  67   5@      5B      �� 5D      -   5        $��?��5D      $y�	Collapsed=�6@   �� 5F      -   5         ��Name$ textBoxCrew��5F      5G      �� 5I   
   $��2��6   $��36(�6   $��Bottom=�6+   $��Arial Black)�6F    J� Opacity$	 0.4Q�6_   $��2��6m   �� 5L   
   $ 
Horizontal=�6   $��Right=�6.   $��2��6J   .+�5M      �� -   5         ��Name$ btnClose��5M   G   $��
Выход��6     MyButton#��[ 6%   $��Bottom=�6n   �� 5N      $��
Назад��6   #��[ 6%   -  'System.Windows.Input.NavigationCommands   
BrowseBack#��Z 6G   $��Right=�6z   $��Bottom=�6�   �� 5O      -	   5        $ 	btnCreate��5O   N   $��Сформировать��6   #��[ 6,   $��Bottom=�6v   5P      5Q      5R      