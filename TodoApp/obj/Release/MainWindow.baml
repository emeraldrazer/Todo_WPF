   M S B A M L   `   `   `  ���� B  >TodoApp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null!clr-namespace:TodoAppTodoApp      TodoApp.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:TodoApp       � Title$  Overcomplicated Todo App��$	��450��$	��750��$	��450��$	��790��$��Roboto)� � 
ResizeMode$ CanMinimize=�.���  � ColumnDefinitions �� $
��203* ��� $
��587* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�� $��0�����#353b48$��2�� � Cursor$
 Hand��.+���  �� Orientation$ 
Horizontal=�$��Center=�$��10q�.+��� -   $��taskName��$	��250��$��20��$��1��$��5q�$��
 Task Name�� �� TextAlignment$
 Left=�$��Center=� � ToolTip$ Name of the task���� -   $��taskDescription��$	��250��$��20��$��1��$��5q�$��Task Description��$
 Left=�$��Center=�$ Description of the task��(  "System.Windows.Controls.DatePicker  -   $��taskDate��$��Center=�$��Center=��� -   $��1��$��Add Task��$��Right=�$��10q�$	��100��$��20�����#353b48
��������� $��2��$��10,10,10,10q�$��2��.���� -    ��Name$ parentStackPanel��