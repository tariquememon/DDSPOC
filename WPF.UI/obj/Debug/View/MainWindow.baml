   M S B A M L   `   `   `  ����A  =WPF.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPF.UIWPF.UI  5   	       WPF.UI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPF.UI     5   	     � Title$$  POC - Disconnected Data Source��5   	   $	��800��60   $	��800��6=   $��20(�6I   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� $��0��62    �� DisplayMemberPath$
 Name��5      ��5      �� *People+ �� SelectedItem 5      �� *SelectedPerson+ �� Mode$ TwoWay=�5      � 5   
   $��1��6   y�6   �� *
ShowDetail+    BooleanToVisibilityConverter �� 	Converter# [   � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5       $
��Auto �6    .+�5#      �� $
��Name��6   $��
10 10 10 0q�6#   $��0��67   �� 5$      $��1��6   $��
10 0 10 10q�5%   D   ��5$   #   �� *SelectedPerson.Name+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5%   D   �� 5'      $��Street Number��6   $��
10 10 10 0q�6,   $��2��6@   �� 5(      $��3��6   $��
10 0 10 10q�5)   D   ��5(   #   �� *!SelectedPerson.Address.StreetNo+$ TwoWay=�$ PropertyChanged=�5)   D   �� 5+      $��Street Name��6   $��
10 10 10 0q�6*   $��4��6>   �� 5,      $��5��6   $��
10 0 10 10q�5-   D   ��5,   #   �� *#!SelectedPerson.Address.StreetName+$ TwoWay=�$ PropertyChanged=�5-   D   �� 5/      $��State��6   $��
10 10 10 0q�6$   $��6��68   �� 50      $��7��6   $��
10 0 10 10q�51   D   ��50   #   �� *SelectedPerson.Address.State+$ TwoWay=�$ PropertyChanged=�51   D   �� 53      $��	Post Code��6   $��
10 10 10 0q�6(   $��8��6<   �� 54      $��9��6   $��
10 0 10 10q�55   D   ��54   #   �� *!SelectedPerson.Address.PostCode+$ TwoWay=�$ PropertyChanged=�55   D   ]� 57      $��10��6   $��10q�6&   .+�58      �� $��Right=�6   .+�59      �� $	��Add��6   $	��125��6+   $��10q�67   ��5:      �� *AddEmailCommand+�� 5;      $��Remove��6   $	��125��6.   $��10q�6:   ��5<      �� *RemoveEmailCommand+5=      &   System.Windows.Controls.DataGrid  5>         AutoGenerateColumns .  	   RowHeaderWidth$	 0Q�5@   7   ��5>      �� *SelectedPerson.Emails+ 5?      �� *SelectedEmail+$ TwoWay=�
   Columns
 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Emails��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5C   -   �� *EmailAddress+$ TwoWay=�$ PropertyChanged=�5E      5F      �� 5H      $��11��6    �� Orientation$ 
Horizontal=�6'   .+�5I      �� $
��Save��6   $	��125��6(   $��10q�64   ��6@   �� *SaveCommand+�� 5J      $��Reset��6   $	��125��6)   $��10q�65   ��6A   �� *ResetCommand+5K      5L      5M      5N      