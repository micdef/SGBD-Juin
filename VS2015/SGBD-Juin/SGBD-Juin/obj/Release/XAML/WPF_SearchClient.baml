   M S B A M L   `   `   `  ���� D  @SGBD-Juin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SGBD_Juin.XAMLSGBD_Juin.XAML  %    SGBD_Juin.XAML.WPF_SearchClient   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:SGBD_Juin.XAML       � Title$  Rechercher un client...��$	��480��$	��600�� � WindowStartupLocation$ CenterScreen=� � Icon$( "/SGBD-Juin;component/Icon/Logo.ico��.��� .+��� -    ��Name$ 
GRP_Search��$��Champs de recherche��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��572��$��58��.��� $
��Left=�$��39��$	��Top=�$	��562��$��0,0,-2,0q�.+��� -    ��Name$ TXT_ClientName��$
��Left=�$��26��$��	133,7,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��419��$��1���� -    ��Name$ LBL_ClientName��$��Nom du client :��$
��Left=�$��10,7,0,0q�$	��Top=�$	��118��&   System.Windows.Controls.DataGrid  -     Name$ 
DGV_Client��$
��Left=�$��	10,73,0,0q�$	��Top=�$	��341��$	��572��   
IsReadOnly . �� -   	 ��Name$	 	BTN_Close��$��Retour sans sélection��$
��Left=�$��428,419,0,0q�$	��Top=�$	��154��$��2��
 �� IsCancel
 . 