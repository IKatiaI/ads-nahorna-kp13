   M S B A M L   `   `   `  ����G  Cpraktuchna_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:praktuchna_3praktuchna_3  5   	   !    praktuchna_3.Administration   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:praktuchna_3     5   	     � Title$  Administration��5   	   $��470.011��6    $��748.4��61   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
users_grid��5
      $
��Left=�6'   $	��267��6B   $��
10,163,0,0q�6O   $	��Top=�6c   $	��239��6{   �� 5   
   $>��8Перегляд користувачів списком��6   $
��Left=�68   $��29��6S   $��
10,134,0,0q�6_   $	��Top=�6s   $	��239��6�   �� 5   
   $>��8Введіть пароль адміністратора��6   $
��Left=�68   $��29��6S   $��	10,10,0,0q�6_   $	��Top=�6r   $	��239��6�   G� 5   
   -   5         G�Name$ authorise_password_tb��5      $
��Left=�65   $��20(�6P   $��34��6^   $��	10,44,0,0q�6j   $	��Top=�6}   $	��229��6�   �� 5   
   -   5         ��Name$ authorize_bt��5      $"��Авторизуватись��6'   $
��Left=�6@   $��22��6[   $��	10,83,0,0q�6g   $	��Top=�6z   $	��229��6�   6�   �� 5   
   $:��4Зміна паролю Адміністратора��6   $��20(�66   $
��Left=�6D   $��34��6_   $��
368,15,0,0q�6k   $	��Top=�6   $	��290��6�   �� 5   
   $2��,Введіть поточний пароль��6   $
��Left=�62   $��29��6M   $��
298,67,0,0q�6Y   $	��Top=�6m   $	��152��6�   �� 5   
   $,��&Введіть новий пароль��6   $
��Left=�6/   $��29��6J   $��
574,67,0,0q�6V   $	��Top=�6j   $	��152��6�   G� 5   
   -   5        $ current_password_tb��5      $
��Left=�63   $��20(�6N   $��29��6\   $��298,101,0,0q�6h   $	��Top=�6}   $	��173��6�   G� 5   
   -   5        $ new_password_tb��5      $
��Left=�6/   $��20(�6J   $��29��6X   $��553,101,0,0q�6d   $	��Top=�6y   $	��173��6�   �� 5   
   $%��Повторіть пароль��6   $
��Left=�6+   $��29��6F   $��298,152,0,0q�6R   $	��Top=�6g   $	��115��6   G� 5   
   -   5        $ repeat_password_tb��5      $
��Left=�62   $��20(�6M   $��29��6[   $��429,152,0,0q�6g   $	��Top=�6|   $	��173��6�   �� 5   
   -   5        $ change_password_bt��5      $��Оновити��6-   $
��Left=�6?   $��29��6Z   $��632,152,0,0q�6f   $	��Top=�6{   $��94��6�   6�   �� 5   
   $<��6Перегляд кожного користувача��6   $
��Left=�67   $��24��6R   $��298,199,0,0q�6^   $	��Top=�6s   $	��186��6�   �� 5   
   $$��Ім'я користувача��6   $
��Left=�6+   $��24��6F   $��298,228,0,0q�6R   $	��Top=�6g   $	��115��6   �� 5   
   $-��'Прізвище користувача��6   $
��Left=�6/   $��24��6J   $��298,257,0,0q�6V   $	��Top=�6k   $	��136��6�   �� 5   
   $��
Логін��6   $
��Left=�6    $��24��6;   $��553,234,0,0q�6G   $	��Top=�6\   $��49��6t   �� 5   
   $��Статус��6   $
��Left=�6!   $��29��6<   $��553,263,0,0q�6H   $	��Top=�6]   $��49��6u   �� 5   
   -   5        $ prev_user_bt��5      $��Попередній��6'   $
��Left=�6<   $��24��6W   $��298,286,0,0q�6c   $	��Top=�6x   $��94��6�   6�   �� 5   
   -	   5        $ next_user_bt��5      $��Наступний��6'   $
��Left=�6;   $��24��6V   $��632,286,0,0q�6b   $	��Top=�6w   $��94��6�   6�   �� 5   
   $*��$Обмеження на пароль��6   $
��Left=�6.   $��24��6I   $��411,286,0,0q�6U   $	��Top=�6j   $	��137��6�   �� 5   
   $/��)Додавання користувача��6   $
��Left=�60   $��24��6K   $��298,315,0,0q�6W   $	��Top=�6l   $	��152��6�   �� 5    
   -
   5         ��Name$ new_user_login_tb��5       $
��Left=�6-   $��20(�6H   $��29��6V   $��298,344,0,0q�6b    �� TextWrapping$
 Wrap=�6w   $	��Top=�6�   $	��152��6�   �� 5!   
   -   5        $ user_state_bt��5!      $/��)Встановити активність��6(   $
��Left=�6H   $��19��6c   $��595,353,0,0q�6o   $	��Top=�6�   $	��131��6�   6�   �� 5"   
   -   5        $ user_restriction_bt��5"      $��Встановити��6.   $
��Left=�6C   $��18��6^   $��656,377,0,0q�6j   $	��Top=�6   $��70��6�   6�   �� 5#   
   -   5        $ add_new_user_bt��5#      $)��#Додати користувача��6*   $
��Left=�6G   $��24��6b   $��298,377,0,0q�6n   $	��Top=�6�   $	��152��6�   6�   �� 5$   
   -   5        $ exit_bt��5$      $"��Вийти з системи��6"   $
��Left=�6<   $��24��6W   $��298,406,0,0q�6c   $	��Top=�6x   $	��152��6�   6�   �� 5%   
   -   5        $ close_window_bt��5%      $��Закрити вікно��6*   $
��Left=�6B   $��24��6]   $��493,406,0,0q�6i   $	��Top=�6~   $	��233��6�   6�   �� 5&   
   $�� ��6   $
��Left=�6   $��24��66   $��493,199,0,0q�6B   $	��Top=�6W   $	��186��6o   �� 5'   
   -   5         ��Name$ user_name_lb��5'      $�� ��6&   $
��Left=�61   $��24��6L   $��402,228,0,0q�6X   $	��Top=�6m   $	��146��6�   �� 5(   
   -   5        $ user_surname_lb��5(      $�� ��6)   $
��Left=�64   $��24��6O   $��439,258,0,0q�6[   $	��Top=�6p   $	��114��6�   �� 5)   
   -   5        $ user_login_lb��5)      $�� ��6'   $
��Left=�62   $��24��6M   $��602,234,0,0q�6Y   $	��Top=�6n   $	��119��6�   �� 5*   
   -   5        $ user_status_lb��5*      $��12(�6(   $�� ��66   $
��Left=�6A   $��23��6\   $��595,263,0,0q�6h   $	��Top=�6}   $	��119��6�   �� 5+   
   -   5        $ user_restriction_lb��5+      $�� ��6-   $
��Left=�68   $��26��6S   $��553,292,0,0q�6_   $	��Top=�6t   $��74��6�   �� 5,   
   -   5         ��Name$ user_status_cb��5,      $��Статус��6+   $
��Left=�6<   $��493,355,0,0q�6W   $	��Top=�6l   $��87��6�    J� RenderTransformOrigin$ 
0.559,2.25&�6�   �� 5-   
   -   5        $ user_restriction_cb��5-      $*��$Обмеження на пароль��60   $
��Left=�6N   $��493,379,0,0q�6i   $	��Top=�6~   $	��149��6�   5/      50      