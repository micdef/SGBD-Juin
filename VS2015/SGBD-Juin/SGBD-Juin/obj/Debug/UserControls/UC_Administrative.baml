   M S B A M L   `   `   `  ����D  @SGBD-Juin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SGBD_Juin.UserControlsSGBD_Juin.UserControls  5      .    (SGBD_Juin.UserControls.UC_Administrative   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:SGBD_Juin.UserControls     5      .��5	      � -   5          �Name$  Grid_Administrative��5	      .+�5
   
   � -   5        $  	Grid_Menu��5
      $
��Left=�6"   $��68��6=   $��	10,10,0,0q�6I   $	��Top=�6\   $	��996��6t   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5      $ White��6#   $ 1Q�61   � 5      $ 	#FF70DAB9��6#   $ 0.012Q�65   5      .+�5      �� -   5         ��Name$ BTN_Exit��5      $�� ��6'   $
��Left=�62   $��	10,10,0,0q�6M   $	��Top=�6`   $��48��6x   $��48��6�   ��6�   Z�  J� OpacityMask 5      �� 5       �� ImageSource$- '/SGBD-Juin;component/Image/SYS_Quit.png��6!   ��5      �� 5      $- '/SGBD-Juin;component/Image/SYS_Quit.png��6!   5      �� 5      -   5        $ BTN_Restart��5      $�� ��6*   $
��Left=�65   $��	63,10,0,0q�6P   $	��Top=�6c   $��48��6{   $��48��6�   ��6�   Z�  5      �� 5      $0 */SGBD-Juin;component/Image/SYS_Restart.png��6!   ��5      �� 5      $0 */SGBD-Juin;component/Image/SYS_Restart.png��6!   5!      �� 5"      -   5        $ 
BTN_RMAAdd��5"      $�� ��6)   $
��Left=�64   $��
137,10,0,0q�6O   $	��Top=�6c   $��48��6{   $��48��6�   
���   ���6�   Z�  5#      �� 5$      $, &/SGBD-Juin;component/Image/RMA_Add.png��6!   ��5&      �� 5'      $, &/SGBD-Juin;component/Image/RMA_Add.png��6!   5)      �� 5*      -   5        $ BTN_RMARemove��5*      $�� ��6,   $
��Left=�67   $��
190,10,0,0q�6R   $	��Top=�6f   $��48��6~   $��48��6�   ��6�   Z�  5+      �� 5,      $/ )/SGBD-Juin;component/Image/RMA_Remove.png��6!   ��5.      �� 5/      $/ )/SGBD-Juin;component/Image/RMA_Remove.png��6!   51      �� 52      -   5        $ BTN_RMASearch��52      $�� ��6,   $
��Left=�67   $��243,10,0,10q�6R   $��48��6g   ��6r   Z�  53      �� 54      $/ )/SGBD-Juin;component/Image/RMA_Search.png��6!   ��56      �� 57      $/ )/SGBD-Juin;component/Image/RMA_Search.png��6!   59      �� 5:      -   5        $ BTN_RMAClose��5:      $�� ��6+   $
��Left=�66   $��
296,10,0,0q�6Q   $	��Top=�6e   $��48��6}   $��48��6�   ��6�   Z�  5;      �� 5<      $. (/SGBD-Juin;component/Image/RMA_Close.png��6!   ��5>      �� 5?      $. (/SGBD-Juin;component/Image/RMA_Close.png��6!   5A      �� 5B      -	   5        $ BTN_RMAReopen��5B      $�� ��6,   $
��Left=�67   $��
349,10,0,0q�6R   $	��Top=�6f   $��48��6~   $��48��6�   ��6�   Z�  5C      �� 5D      $/ )/SGBD-Juin;component/Image/RMA_ReOpen.png��6!   ��5F      �� 5G      $/ )/SGBD-Juin;component/Image/RMA_ReOpen.png��6!   5I      �� 5J      -
   5        $ BTN_MySettings��5J      $�� ��6-   $
��Left=�68   $��
938,10,0,0q�6S   $	��Top=�6g   $��48��6   $��48��6�   
���   ���6�   Z�  5K      �� 5L      $3 -/SGBD-Juin;component/Image/SYS_MySettings.png��6!   ��5N      �� 5O      $3 -/SGBD-Juin;component/Image/SYS_MySettings.png��6!   5Q      �� 5R      -   5        $ BTN_ClientAdd��5R      $�� ��6,   $
��Left=�67   $��
424,10,0,0q�6R   $	��Top=�6f   $��48��6~   $��48��6�   ��6�   Z�  5S      �� 5T      $, &/SGBD-Juin;component/Image/CLI_Add.png��6!   ��5V      �� 5W      $, &/SGBD-Juin;component/Image/CLI_Add.png��6!   5Y      �� 5Z      -   5        $ BTN_ClientMod��5Z      $�� ��6,   $
��Left=�67   $��
477,10,0,0q�6R   $	��Top=�6f   $��48��6~   $��48��6�   ��6�   Z�  5[      �� 5\      $- '/SGBD-Juin;component/Image/CLI_Edit.png��6!   ��5^      �� 5_      $- '/SGBD-Juin;component/Image/CLI_Edit.png��6!   5a      5b      &   System.Windows.Controls.DataGrid  5c   
   -   5          Name$ DGV_RMAList��5c      $
��Left=�6(   $��	10,83,0,0q�6C   $	��Top=�6V   $	��644��6n   $	��996��6{   	   
IsReadOnly	 . 6�   5d      5e      