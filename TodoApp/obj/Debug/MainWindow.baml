   M S B A M L   `   `   `  ����B  >TodoApp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null!clr-namespace:TodoAppTodoApp  5   	       TodoApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TodoApp     5   	     � Title$  Overcomplicated Todo App��5   	   $	��450��6*   $	��750��67   $	��450��6C   $	��790��6S   $��Roboto)�6b    � 
ResizeMode$ CanMinimize=�6v   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��203* �6   �� 5      $
��587* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   ���#353b48$��2��61    � Cursor$
 Hand��6E   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��10q�6M   .+�5      �� -   5        $��taskName��5      $	��250��6*   $��20��66   $��1��6B   $��5q�6O   $��
 Task Name��6Z    �� TextAlignment$
 Left=�6l   $��Center=�6�    � ToolTip$ Name of the task��6�   �� 5      -   5        $��taskDescription��5      $	��250��61   $��20��6=   $��1��6I   $��5q�6V   $��Task Description��6a   $
 Left=�6y   $��Center=�6�   $ Description of the task��6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��taskDate��5      $��Center=�6-   $��Center=�6J   6g   �� 5      -   5        $��1��5      $��Add Task��6&   $��Right=�69   $��10q�6U   $	��100��6a   $��20��6m   ���#353b48
�������6�   5      5      �� 5   
   $��2��6   $��10,10,10,10q�6$   $��2��69   .��5      �� -   5         ��Name$ parentStackPanel��5      5!      5"      5#      5$      