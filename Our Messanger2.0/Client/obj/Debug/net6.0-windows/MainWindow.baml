   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	     � Title$  	Messanger��5   	   $	��450��6   $	��800��6(    � DataContext 5	         Client.MessClient  5
   
    � 	Resources 5       �� 
TargetType �� Property �� Value��%_  '��       '�� }     '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 3q�6'   �� 5       �@��TextAlignment$ Center=�6.   5      �� 5   
   " ��6   .�5      ��  � ��$ 3q�6'   �� 5       �@��TextAlignment$ Center=�6.   5      �� 5   
   " ��6   .�5      ��  � ��$ 3q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� .+�5       A�  A� Columns$ 4��6   .+�5!      �� $��IP��6   �� 5"      $
��Port��6   �� 5#      $
��Nick��6   5$      A� 5%      $ 4��6   .+�5&      �� ��6   �� *IP+�� 5'      ��6   �� *Port+�� 5(      ��6   �� *Nick+�� 5)      $��Подключиться��6<   ��6   �� *ConnectCommand+6<   5*      5+      �� 5-   
   $��1��6    �� TextAlignment$
 Left=�5/      	 �� 
IsReadOnly$
	 True��50      
 �� IsReadOnlyCaretVisible$

 True��51      ��5.      �� *Chat+51      � 53   
   $��2��6    � ColumnDefinitions 54      �� 55      $��4* �6#   �� 56      $��6* �6#   �� 57      $	��15* �6#   �� 58      $��4* �6#   .+�5:      �� $��Ник:��6   $��0��5;      �� 5<       �� MaxLines$ 5��6   $
 Left=�5>      $��1��5?       �� TextWrapping$
 Wrap=�5@      $��3,3,3,3q�6*   ��5=      �� *Target+5@   *   �� 5B      $ 5��6   $
 Left=�5D      $��2��5E      $
 Wrap=�5F      $��3,3,3,3q�6*   ��5C      �� *	Message+5F   *   �� 5G      $��3��5H      $��Отправить��5J      $��3,3,3,3q�6%   ��5I      �� *SendCommand+5J   %   5K      5L      5M      