   M S B A M L   `   `   `  ����D  @SGBD-Juin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SGBD_Juin.XAMLSGBD_Juin.XAML  5   	   %    SGBD_Juin.XAML.WPF_SearchClient   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SGBD_Juin.XAML     5   	     � Title$  Rechercher un client...��5   	   $	��480��6)   $	��600��66    � WindowStartupLocation$ CenterScreen=�6B    � Icon$( "/SGBD-Juin;component/Icon/Logo.ico��6g   .��5	      � .+�5
   
   �� -   5         ��Name$ 
GRP_Search��5
      $��Champs de recherche��6'   $
��Left=�6D   $��	10,10,0,0q�6_   $	��Top=�6r   $	��572��6�   $��58��6�   .��5      � $
��Left=�6   $��39��6.   $	��Top=�6:   $	��562��6R   $��0,0,-2,0q�6^   .+�5      �� -   5         ��Name$ TXT_ClientName��5      $
��Left=�62   $��26��6M   $��	133,7,0,0q�6Y    �� TextWrapping$
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��419��6�   $��1��6�   �� 5      -   5         ��Name$ LBL_ClientName��5      $��Nom du client :��60   $
��Left=�6J   $��10,7,0,0q�6e   $	��Top=�6w   $	��118��6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
DGV_Client��5      $
��Left=�6'   $��	10,73,0,0q�6B   $	��Top=�6U   $	��341��6m   $	��572��6z      
IsReadOnly . 6�   �� 5   
   -   5        	 ��Name$	 	BTN_Close��5      $��Retour sans sélection��6$   $
��Left=�6D   $��428,419,0,0q�6_   $	��Top=�6t   $	��154��6�   $��2��6�   
 �� IsCancel
 . 6�   5      5      