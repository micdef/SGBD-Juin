   M S B A M L   `   `   `  ����D  @SGBD-Juin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SGBD_Juin.XAMLSGBD_Juin.XAML  5   	   "    SGBD_Juin.XAML.WPF_SearchRMA   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SGBD_Juin.XAML     5   	     � Title$  Recherche de ticket��5   	   $��394.653��6%   $	��600��66    � WindowStartupLocation$ CenterScreen=�6B    � Icon$( "/SGBD-Juin;component/Icon/Logo.ico��6g   .��5	      � .+�5
   
   �� -   5         ��Name$ 
GRP_Search��5
      $��Champs de recherche��6'   $
��Left=�6D   $��	10,10,0,0q�6_   $	��Top=�6r   $	��572��6�   $	��108��6�   .��5      � $
��Left=�6   $��91��6.   $	��Top=�6:   $	��562��6R   $��0,0,-2,0q�6^   .+�5      	� -   5         	�Name$ 
RDB_NumRMA��5      $��Numéro du ticket :��62   $
��Left=�6O   $��	10,12,0,0q�6j   $	��Top=�6}   $��1��6�   �� 5      -   5         ��Name$ 
TXT_NumRMA��5      $
��Left=�6.   $��23��6I   $��
133,10,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��419��6�   $��2��6�   	� 5      -   5        $ RDB_NomClient��5      $��Nom du client :��65   $
��Left=�6O   $��	10,40,0,0q�6j   $	��Top=�6}   $��3��6�   �� 5      -   5        $ TXT_NomClient��5      $
��Left=�61   $��23��6L   $��
133,38,0,0q�6X   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��419��6�   $��4��6�   �� 5      -   5         ��Name$ CHK_ClosedRMA��5      $��Tickets cloturés.��62   $
��Left=�6N   $��	10,66,0,0q�6i   $	��Top=�6|   $	��118��6�   $��5��6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
DGV_Search��5      $
��Left=�6'   $��
10,123,0,0q�6B   $	��Top=�6V   $	��206��6n   $	��572��6{   	   
IsReadOnly	 . 6�   �� 5   
   -   5        
 ��Name$
 	BTN_Close��5      $��Retour��6$   $
��Left=�65   $��482,334,0,0q�6P   $	��Top=�6e   $	��100��6}   $��6��6�    �� IsCancel . 6�   5      5      