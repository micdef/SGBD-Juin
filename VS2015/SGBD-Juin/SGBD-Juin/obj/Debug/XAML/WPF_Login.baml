   M S B A M L   `   `   `  ����D  @SGBD-Juin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SGBD_Juin.XAMLSGBD_Juin.XAML  5   	       SGBD_Juin.XAML.WPF_Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SGBD_Juin.XAML     5   	     � Title$  Authentification��5   	   $��202.266��6"   $��389.235��63    � WindowStartupLocation$ CenterScreen=�6C    � Icon$( "/SGBD-Juin;component/Icon/Logo.ico��6h   .��5	      � .+�5
   
   �� -   5         ��Name$ 	IMG_Login��5
      $
��Left=�6#   $	��100��6>   $��	10,33,0,0q�6K   $	��Top=�6^   $	��100��6v   $.��(/SGBD-Juin;component/Image/SYS_Login.png��6�    J� RenderTransformOrigin$ 0.531,0.085&�6�   �� 5   
   -   5         ��Name$ LBL_Username��5      $��Nom d'utilisateur :��6&   $
��Left=�6D   $��
115,10,0,0q�6_   $	��Top=�6s   $	��257��6�   �� 5   
   -   5         ��Name$ TXT_Username��5      $
��Left=�6(   $��23��6C   $��
115,41,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��257��6�   $��1��6�   �� 5   
   -   5        $ LBL_Password��5      $��Mot de passe :��6&   $
��Left=�6?   $��
115,69,0,0q�6Z   $	��Top=�6n   $	��257��6�   G� 5   
   -   5         G�Name$ PWD_Password��5      $
��Left=�6,   $��115,100,0,0q�6G   $	��Top=�6\   $	��256��6t   $��23��6�   $��2��6�   �� 5   
   -   5        	 ��Name$	 BTN_Connection��5      $��Se connecter��6)   $
��Left=�6@   $��115,137,0,0q�6[   $	��Top=�6p   $	��116��6�   
 �� 	IsDefault
 . $��3��6�   �� 5   
   -   5        $	 
BTN_Cancel��5      $��Annuler��6%   $
��Left=�67   $��255,137,0,0q�6R   $	��Top=�6g   $	��116��6    �� IsCancel . $��4��6�   5      5      