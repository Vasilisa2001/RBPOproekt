   M S B A M L   `   `   `  ����B  >BankWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BankWPF.PagesBankWPF.Pages  5      '    !BankWPF.Pages.PersonalAccountPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:BankWPF.Pages     5      -   5          N� Title$  PersonalAccountPage��5	      .��5      � ��5   
   �� 5       �� ImageSource$+ %1593730170_68-p-foni-s-bankami-90.jpg��6    � ColumnDefinitions 5   
   �� 5      $
��139* �6   �� 5      $
��261* �6   .+�5   
   �� -   5         ��Name$ firstNameSecondNameLabel��5      $��Label��62   $��
10,10,10,0q�6B   $	��Top=�6V   $��26��6n   $��Center=�6z   �� 5   
   -   5        $ accountNumberLabel��5      $��Label��6,   $��
10,55,10,0q�6<   $	��Top=�6P   $��26��6h   $��Center=�6t   �� 5   
   -   5        $ 
moneyLabel��5      $��Label��6$   $��10,100,10,0q�64   $	��Top=�6I   $��26��6a   $��Center=�6m   �� 5   
   -   5        $!��Пополнить счет��5      $��1��6*   $
��Left=�6:   $��
159,13,0,0q�6U   $	��Top=�6i   $	��101��6�   $��23��6�   ���	#FF5992BD6�   �� 5   
   -   5         ��Name$ getMoneyTextBox��5      $��1��6+   $
��Left=�6;   $��23��6V   $��
265,13,0,0q�6b    �� TextWrapping$
 Wrap=�6v   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $'��!Выполнить перевод��5      $��1��6-   $
��Left=�6=   $��212,134,0,0q�6X   $	��Top=�6m   $	��123��6�   ���	#FF5491BE$��21��6�   �� 5   
   -   5        $ loginSendTextBox��5      $��1��6,   $
��Left=�6<   $��25��6W   $��
159,84,0,0q�6c   $
 Wrap=�6w   $	��Top=�6�   $	��120��6�   �� 5   
   -	   5        $ moneySendTextBox��5      $��1��6,   $
��Left=�6<   $��25��6W   $��
340,84,0,0q�6c   $
 Wrap=�6w   $	��Top=�6�   $	��120��6�   �� 5   
   $��Логин:��6   $��1��6!   $
��Left=�61   $��	98,84,0,0q�6L   $	��Top=�6_   $��25��6w   $��56��6�   �� 5   
   $��Сумма:��6   $��1��6!   $
��Left=�61   $��
287,84,0,0q�6L   $	��Top=�6`   $��25��6x   $��48��6�   �� 5   
   -
   5        $��
Выход��5      $
��Left=�6!   $��
94,330,0,0q�6<   $	��Top=�6P   $��75��6h   ���	#FF5D3DCA$��21��6�   5      5       