   M S B A M L   `   `   `  ���� D  @SGBD-Juin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SGBD_Juin.XAMLSGBD_Juin.XAML  "    SGBD_Juin.XAML.WPF_SearchRMA   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:SGBD_Juin.XAML       � Title$  Recherche de ticket��$��394.653��$	��600�� � WindowStartupLocation$ CenterScreen=� � Icon$( "/SGBD-Juin;component/Icon/Logo.ico��.��� .+��� -    ��Name$ 
GRP_Search��$��Champs de recherche��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��572��$	��108��.��� $
��Left=�$��91��$	��Top=�$	��562��$��0,0,-2,0q�.+�	� -    	�Name$ 
RDB_NumRMA��$��Numéro du ticket :��$
��Left=�$��	10,12,0,0q�$	��Top=�$��1���� -    ��Name$ 
TXT_NumRMA��$
��Left=�$��23��$��
133,10,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��419��$��2��	� -   $ RDB_NomClient��$��Nom du client :��$
��Left=�$��	10,40,0,0q�$	��Top=�$��3���� -   $ TXT_NomClient��$
��Left=�$��23��$��
133,38,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��419��$��4���� -    ��Name$ CHK_ClosedRMA��$��Tickets cloturés.��$
��Left=�$��	10,66,0,0q�$	��Top=�$	��118��$��5��&   System.Windows.Controls.DataGrid  -     Name$ 
DGV_Search��$
��Left=�$��
10,123,0,0q�$	��Top=�$	��206��$	��572��	   
IsReadOnly	 . �� -   
 ��Name$
 	BTN_Close��$��Retour��$
��Left=�$��482,334,0,0q�$	��Top=�$	��100��$��6�� �� IsCancel . 