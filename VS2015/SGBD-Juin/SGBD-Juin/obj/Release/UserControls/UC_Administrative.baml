   M S B A M L   `   `   `  ���� D  @SGBD-Juin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SGBD_Juin.UserControlsSGBD_Juin.UserControls  .    (SGBD_Juin.UserControls.UC_Administrative   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:SGBD_Juin.UserControls     .��� -     �Name$  Grid_Administrative��.+�� -   $  	Grid_Menu��$
��Left=�$��68��$��	10,10,0,0q�$	��Top=�$	��996������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ White��$ 1Q�� $ 	#FF70DAB9��$ 0.012Q�.+��� -    ��Name$ BTN_Exit��$�� ��$
��Left=�$��	10,10,0,0q�$	��Top=�$��48��$��48����Z�  J� OpacityMask ��  �� ImageSource$- '/SGBD-Juin;component/Image/SYS_Quit.png������ $- '/SGBD-Juin;component/Image/SYS_Quit.png���� -   $ BTN_Restart��$�� ��$
��Left=�$��	63,10,0,0q�$	��Top=�$��48��$��48����Z�  �� $0 */SGBD-Juin;component/Image/SYS_Restart.png������ $0 */SGBD-Juin;component/Image/SYS_Restart.png���� -   $ 
BTN_RMAAdd��$�� ��$
��Left=�$��
137,10,0,0q�$	��Top=�$��48��$��48��
���   ���Z�  �� $, &/SGBD-Juin;component/Image/RMA_Add.png������ $, &/SGBD-Juin;component/Image/RMA_Add.png���� -   $ BTN_RMARemove��$�� ��$
��Left=�$��
190,10,0,0q�$	��Top=�$��48��$��48����Z�  �� $/ )/SGBD-Juin;component/Image/RMA_Remove.png������ $/ )/SGBD-Juin;component/Image/RMA_Remove.png���� -   $ BTN_RMASearch��$�� ��$
��Left=�$��243,10,0,10q�$��48����Z�  �� $/ )/SGBD-Juin;component/Image/RMA_Search.png������ $/ )/SGBD-Juin;component/Image/RMA_Search.png���� -   $ BTN_RMAClose��$�� ��$
��Left=�$��
296,10,0,0q�$	��Top=�$��48��$��48����Z�  �� $. (/SGBD-Juin;component/Image/RMA_Close.png������ $. (/SGBD-Juin;component/Image/RMA_Close.png���� -	   $ BTN_RMAReopen��$�� ��$
��Left=�$��
349,10,0,0q�$	��Top=�$��48��$��48����Z�  �� $/ )/SGBD-Juin;component/Image/RMA_ReOpen.png������ $/ )/SGBD-Juin;component/Image/RMA_ReOpen.png���� -
   $ BTN_MySettings��$�� ��$
��Left=�$��
938,10,0,0q�$	��Top=�$��48��$��48��
���   ���Z�  �� $3 -/SGBD-Juin;component/Image/SYS_MySettings.png������ $3 -/SGBD-Juin;component/Image/SYS_MySettings.png���� -   $ BTN_ClientAdd��$�� ��$
��Left=�$��
424,10,0,0q�$	��Top=�$��48��$��48����Z�  �� $, &/SGBD-Juin;component/Image/CLI_Add.png������ $, &/SGBD-Juin;component/Image/CLI_Add.png���� -   $ BTN_ClientMod��$�� ��$
��Left=�$��
477,10,0,0q�$	��Top=�$��48��$��48����Z�  �� $- '/SGBD-Juin;component/Image/CLI_Edit.png������ $- '/SGBD-Juin;component/Image/CLI_Edit.png��&   System.Windows.Controls.DataGrid  -     Name$ DGV_RMAList��$
��Left=�$��	10,83,0,0q�$	��Top=�$	��644��$	��996��	   
IsReadOnly	 . 