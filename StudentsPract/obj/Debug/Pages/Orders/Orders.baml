   M S B A M L   `   `   `  ����H  DStudentsPract, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:StudentsPract.Pages.ContractsStudentsPract.Pages.Contracts  5      =#clr-namespace:StudentsPract.ClassesStudentsPract.Classes  5      '    !StudentsPract.Pages.Orders.Orders   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:StudentsPract.Pages.Contracts     5      7classes#clr-namespace:StudentsPract.Classes     5        � Title$-  'Формирование приказа��5	      $	��450��6+   $	��800��68      WindowStyle#��[  5
       � ShowInTaskbar . .��5      � .+�5   
   �� $/��)Наименование практики��6   $
��Left=�60   $��	10,10,0,0q�6K   $	��Top=�6^   �� 5   
   $��Номер группы��6   $
��Left=�6'   $��	10,46,0,0q�6B   $	��Top=�6U   �� 5   
   $+��%Период прохождения c��6   $
��Left=�6/   $��	10,82,0,0q�6J   $	��Top=�6]   �� 5   
   $ ��Ответственный��6   $
��Left=�6(   $��
10,125,0,0q�6C   $	��Top=�6W   �� 5   
   -   5         ��Name$ combobox_groupe��5      $
��Left=�6,   $��
208,50,0,0q�6G   $	��Top=�6[   $	��129��6s   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
first_date��5         SelectedDateFormat$ Short=�6)   $��208,83,455,295q�6D     5   
   -   5        $ second_date��5      $ Short=�6*   $��379,83,283,295q�6E   �� 5   
   $
��по��6   $
��Left=�6   $��
342,82,0,0q�68   $	��Top=�6L   $��32��6d   �� 5   
   -   5        $��combobox_otvetsven��5      $
��Left=�6-   $��208,129,0,0q�6H   $	��Top=�6]   $	��129��6u   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagrid��5      $
��Left=�6%   $	��175��6@   $��	5,193,0,0q�6M   $	��Top=�6`   $	��772��6x      AutoGenerateColumns .     
IsReadOnly .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	  ��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6/   �� *fio+  5      $	  ��6%   
 6/   �� *group+4  .System.Windows.Controls.DataGridComboBoxColumn  5      $	  ��6)      DisplayMemberPath$
 name��6k      SelectedValuePath$ address��6�      ItemsSource 63   ��  �� Path$  (classes:Helper.OPractise)�   SelectedValueBinding 6�   �� *place+  5      $	  ��6%   
 6/   �� *
employee+5      �� 5   
   $9��3Список студентов для отчета��6   $��Center=�66   $��	0,160,0,0q�6S   $	��Top=�6f   �� 5   
   -   5         ��Name$ btnClose��5        MyButton#��[ 6#   $��
Выход��6E   $
��Left=�6U   $��
10,384,0,0q�6p   $	��Top=�6�   6�   �� 5    
   -   5        $ 	add_studs��5       #��[ 6$   $)��#Добавить студентов��6F   $
��Left=�6c   $��319,381,0,0q�6~   $	��Top=�6�   6�   �� 5!   
   -   5        $ 
form_order��5!      #��[ 6%   $��Сформировать��6G   $
��Left=�6^   $��654,384,0,0q�6y   $	��Top=�6�   6�   �� 5"   
   -	   5        $��
form_pract��5"      $
��Left=�6%   $��23��6@   $��
208,14,0,0q�6L   $	��Top=�6`   $	��129��6x   �� 5#   
   -
   5        $ combobox_type��5#      $
��Left=�6*   $��
479,14,0,0q�6E   $	��Top=�6Y   $	��120��6q   {�.  6}   �� 5$   
   $��Тип практики��6   $
��Left=�6'   $��
365,10,0,0q�6B   $	��Top=�6V   5%      5&      