   M S B A M L   `   `   `  ���� D  @SGBD-Juin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SGBD_Juin.XAMLSGBD_Juin.XAML  !    SGBD_Juin.XAML.WPF_ModifRMA   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:SGBD_Juin.XAML       � Title$*  $Formulaire de modification du ticket��$��600.561��$	��800�� � WindowStartupLocation$ CenterScreen=� � Icon$( "/SGBD-Juin;component/Icon/Logo.ico��.��� .+��� -    ��Name$ GRP_ClientInformation��$��Informations client :��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��155��$	��772��.��� $
��Left=�$	��135��$��0,0,-2,0q�$	��Top=�$	��762��{�.  .+��� -    ��Name$ LBL_ClientName��$��Nom :��$
��Left=�$��	10,10,0,0q�$	��Top=�$��49���� -    ��Name$ TXT_ClientName��$
��Left=�$��26��$��	64,10,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��688���� -   $ LBL_ClientZipCode��$��Code Postal :��$
��Left=�$��	10,41,0,0q�$	��Top=�$��81���� -   $ TXT_ClientZipCode��$
��Left=�$��26��$��	96,41,0,0q�$
 Wrap=�$�� ��$	��Top=�$��66���� -   $ LBL_ClientCity��$��Ville :��$
��Left=�$��
167,41,0,0q�$	��Top=�$��41���� -   $ TXT_ClientCity��$
��Left=�$��26��$��
213,41,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��181���� -   $ LBL_ClientStreet��$��Rue :��$
��Left=�$��
399,41,0,0q�$	��Top=�$��41���� -	   $ TXT_ClientStreet��$
��Left=�$��26��$��
445,41,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��307���� -
   $ LBL_ClientStreetNB��$��Num Maison :��$
��Left=�$��	10,72,0,0q�$	��Top=�$��88���� -   $ TXT_ClientStreetNB��$
��Left=�$��26��$��
103,72,0,0q�$
 Wrap=�$�� ��$	��Top=�$��59���� -   $ LBL_ClientStreetBox��$��Boîte :��$
��Left=�$��
167,72,0,0q�$	��Top=�$��48���� -   $ TXT_ClientStreetBox��$
��Left=�$��26��$��
220,72,0,0q�$
 Wrap=�$�� ��$	��Top=�$��59���� -   $ LBL_ClientTel��$��Tel :��$
��Left=�$��
284,72,0,0q�$	��Top=�$��34���� -   $ TXT_ClientTel��$
��Left=�$��26��$��
323,72,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��197���� -   $ LBL_ClientFax��$��Fax :��$
��Left=�$��
525,72,0,0q�$	��Top=�$��34���� -   $ TXT_ClientFax��$
��Left=�$��26��$��
564,72,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��188���� -   $ LBL_ClientMail��$��e-Mail :��$
��Left=�$��
10,103,0,0q�$	��Top=�$��49���� -   $ TXT_ClientMail��$
��Left=�$��26��$��
64,103,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��688���� -   $ LBL_RMAObject��$��Objet : ��$
��Left=�$��
10,170,0,0q�$	��Top=��� -   $ TXT_RMAObjec��$
��Left=�$��23��$��
10,201,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��772��$��1���� -   $ LBL_RMANote��$��Note :��$
��Left=�$��
10,229,0,0q�$	��Top=��� -   $ TXT_RMANote��$
��Left=�$��23��$��
10,260,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��772��$��2��&   System.Windows.Controls.DataGrid  -     Name$ DGV_InterventionList��$
��Left=�$��
10,288,0,0q�$	��Top=�$	��247��$	��741��   
IsReadOnly . �� -   	 ��Name$	 BTN_AddInterv��$�� ��$
��Left=�$��756,288,0,0q�$	��Top=�$��26��$��26��$��3������ 
 �� ImageSource$/
 )/SGBD-Juin;component/Image/Interv_Add.png���� -   $	 BTN_RemoveInterv��$�� ��$
��Left=�$��756,319,0,0q�$	��Top=�$��26��$��26��$��4������ $2
 ,/SGBD-Juin;component/Image/Interv_Remove.png���� -   $	 
BTN_Accept��$��Modifier��$
��Left=�$��682,540,0,0q�$	��Top=�$	��100��$��5���� -   $	 
BTN_Cancel��$��Annuler��$
��Left=�$��577,540,0,0q�$	��Top=�$	��100��$��6�� �� IsCancel . 