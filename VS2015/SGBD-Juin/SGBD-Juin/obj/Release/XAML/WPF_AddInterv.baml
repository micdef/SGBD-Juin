   M S B A M L   `   `   `  ���� D  @SGBD-Juin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SGBD_Juin.XAMLSGBD_Juin.XAML  "    SGBD_Juin.XAML.WPF_AddInterv   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:SGBD_Juin.XAML       � Title$'  !Formulaire d'ajout d'intervention��$��304.249��$	��800�� � WindowStartupLocation$ CenterScreen=� � Icon$( "/SGBD-Juin;component/Icon/Logo.ico��.��� .+��� -    ��Name$ LBL_RMANumber��$��Numéro du ticket :��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��110���� -    ��Name$ TXT_RMANumber��$
��Left=�$��26��$��
125,10,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$	��657�� �� 
IsReadOnly . �� -   $ LBL_DateBeg��$��Date de début :��$
��Left=�$��	10,41,0,0q�$	��Top=�$	��102��(  "System.Windows.Controls.DatePicker  -     Name$ DTP_DateBeg��$��Right=�$��
0,42,251,0q�$	��Top=�$��26��$	��416��$��1���� -   $ LBL_HeureBeg��$��Heure de début :��$
��Left=�$��
546,41,0,0q�$	��Top=�$	��102���� -   $ TXT_HeureBeg��$
��Left=�$��26��$��
653,41,0,0q�$
 Wrap=�$�� ��$	��Top=�$��51��$��2���� -   $ LBL_HBeg��$��h��$
��Left=�$��
709,41,0,0q�$	��Top=��� -   $ TXT_MinuteBeg��$
��Left=�$��26��$��
731,41,0,0q�$
 Wrap=�$�� ��$	��Top=�$��51��$��3���� -	   $ LBL_DateFin��$��Date de fin :��$
��Left=�$��	10,73,0,0q�$	��Top=�$	��102��  -
   $ DTP_DateFin��$��Right=�$��
0,73,251,0q�$	��Top=�$��26��$	��416��$��4���� -   $ LBL_HeureFin��$��Heure de fin :��$
��Left=�$��
546,73,0,0q�$	��Top=�$	��102���� -   $ TXT_HeureFin��$
��Left=�$��26��$��
653,73,0,0q�$
 Wrap=�$�� ��$	��Top=�$��51��$��5���� -   $ LBL_HFin��$��h��$
��Left=�$��
709,73,0,0q�$	��Top=��� -   $ TXT_MinuteFin��$
��Left=�$��26��$��
731,73,0,0q�$
 Wrap=�$�� ��$	��Top=�$��51��$��6���� -   $ 
LBL_Object��$��Objet :��$
��Left=�$��
10,104,0,0q�$	��Top=��� -   $ 
TXT_Object��$
��Left=�$��26��$��
10,135,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��772��$��7���� -   $ LBL_Note��$��Note :��$
��Left=�$��
10,166,0,0q�$	��Top=��� -   $ TXT_Note��$
��Left=�$��26��$��
10,197,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��772��$��8���� -    ��Name$ 
BTN_Accept��$��Encoder��$
��Left=�$��682,242,0,0q�$	��Top=�$	��100��$��9��	 �� 	IsDefault	 . �� -   $ BTN_RAZ��$��Remise à Zéro��$
��Left=�$��577,242,0,0q�$	��Top=�$	��100��$��10���� -   $ 
BTN_Cancel��$��Annuler��$
��Left=�$��472,242,0,0q�$	��Top=�$	��100��$��11��
 �� IsCancel
 . 