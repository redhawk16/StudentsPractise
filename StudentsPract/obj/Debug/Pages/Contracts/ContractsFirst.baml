   M S B A M L   `   `   `  ����H  DStudentsPract, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:StudentsPract.Pages.ContractsStudentsPract.Pages.Contracts  5      =#clr-namespace:StudentsPract.ClassesStudentsPract.Classes  5      2    ,StudentsPract.Pages.Contracts.ContractsFirst   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:StudentsPract.Pages.Contracts     5      7classes#clr-namespace:StudentsPract.Classes     5        N� Title$  ContractsFirst��5
         	PageStyle#��[  5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   ��  �� Orientation$ Vertical=�6   $
��Left=�6,   $��0��6G   .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      $	��150��6'    5      �� 5      �� 5      �� 5      .+�5"      �� $!��Номер договора��6   $��0��61   $��0��6A   �� 5#      -   5         ��Name$ contract_num��5#      $��1��60   $��0��6@   6M   �� 5&      $5��/Наименование организации��6   $��0��6;   $��1��6K   �� 5'      -   5         ��Name$ contract_org��5'      $��1��61   $��1��6A   $��31��6N   $��Bottom=�6Z   �� 5*      $/��)Руководитель практики��6   $��0��68   $��2��6H   �� 5+      -   5        $ contract_empl��5+       �� 
IsReadOnly . {�.  $��1��6U   $��2��6e   5,      5-      �� 50   
   $ 
Horizontal=�6   $��Right=�6.   $	��Top=�6J   $��0��6b   .+�51      �� $��Дата��6   (  "System.Windows.Controls.DatePicker  52      -   5          Name$
 date��52         SelectedDateFormat$ Short=�6'   53      �� 55   
   $��1��6   $��0 10 0 0q�6"   .+�57      R� -   5        	 R�Name$	 treeView��57      $	��150��58      ��59      �� 
 �� RelativeSource
 ��  �� AncestorType$
 PageL� �� Path$ TreeView� � 	Resources 5:       �� DataType"   StudentsPract.Classes.Parent �� ItemsSource d� 	IsChecked �� Mode �� UpdateSourceTrigger!   StudentsPract.Classes.Child��%�  (��       5;   /   *, +)(�� �     5L   #   *, +)�� 5;      "  6/    6R   �� *	Members+.R�5<      �� -   5        ��5<   #   �� *Name+ 6<   �� $$ (classes:ItemHelper.IsChecked)�$ TwoWay=�$ PropertyChanged=�5J      5K      �� 5L      "  6#   .R�5M      �� -   5        ��5M   #   �� *Name+ 6<   �� $$ (classes:ItemHelper.IsChecked)�$ TwoWay=�$ PropertyChanged=�5[      5\      5]      ��5^      �� 5_       �� 
TargetType" Q�6   .�5`      ��  �� Property �@Q�
IsExpanded �� Value .  67   5a      5c      �� 5e      -   5        $��?��5e      $y�	Collapsed=�6@   �� 5g      -	   5         ��Name$ textBoxCrew��5g      5i      �� 5k   
   $��1��6   $��36(�6   $��Bottom=�6+   $��Arial Black)�6F    J� Opacity$	 0.4Q�6_   $��2��6m   �� 5n   
   $ 
Horizontal=�6   $��Right=�6.   $��2��6J   .+�5o      �� -
   5         ��Name$ btnClose��5o   G   $��
Выход��6     MyButton#��[ 6%   $��Bottom=�6n   �� 5p      -   5        $ btnNext��5p   G   $��
Далее��6   #��[ 6%   {�.  $��Bottom=�6   5q      5r      5s      