   M S B A M L   `   `   `  ����@  <MyMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyMapMyMap  5   	   7 clr-namespace:MyMap.ControlBarUCMyMap.ControlBarUC  5   	       MyMap.Login   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:MyMap     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   )uc clr-namespace:MyMap.ControlBarUC  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��loginWindow��5   	     � Title$  Đăng nhập��5
   	   $	��350��6   $	��400��6(      LoginVM � DataContext# [  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
���   �$	��0.4q�5   	     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      �  � 	Resources 5   
    �� 
TargetType	 �� Property
 �� Value��%V   '�       �� 5      " �6   .�5       �� 	 � ��$
 0q�6+   67   5!      5"       � RowDefinitions 5#   
   �� 5$      $
��auto �6   6,   �� 5%      6   .+�5'   
   � $��0��6   .+�5(      %   MyMap.ControlBarUC.ControlBarUC  $
��auto��6   $
��auto��6,   $��276,0,0.4,-0.2q�6h   
 � Tag 69   �� *Title+ �� ElementName$ loginWindow��6�   5)      #  MaterialDesignThemes.Wpf.Card  5*   
   $��1��6   $	��400��6+   $	��300��67   $��Center=�6D   $��Center=�6_   .��5+      �  5,      ��%^   '�       �� 5-      " �6   .�5.      �� 	 � ��$
 	10 1 10 5q�63   6G   5/      50       51      �� 52      6'   �� 53      6'   �� 54      6'   .+�56      � $��0��6   .+�57      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập��68    % !MaterialDesignFloatingHintTextBox#��[ 6g   ��6   �� *
UserName+6g   58      � 59      $��1��6   .+�5:      G� -   5         G�Name$ PasswordBox��5;      $y�Visible=�6.   $ Mật khẩu��5<       ) %MaterialDesignFloatingHintPasswordBox#��[ 6C   .  (System.Windows.Interactivity.Interaction   Triggers 5=      /  )System.Windows.Interactivity.EventTrigger  5>         	EventName$ PasswordChanged��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5?   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 5@   %   �� *PasswordChangedCommand+   CommandParameter 5A   %   �� $ PasswordBox��5B      5D      5E      � 5F      $��2��6    � ColumnDefinitions 5H      �� 5I      6-   �� 5J      6-   .+�5L      ��  �� 	IsDefault . $��0��5N        MaterialDesignRaisedButton#��[ 6-   
��� �|�$��Normal$�6x    � ToolTip$/ )Resource name: MaterialDesignRaisedButton��6�   $	��120��6�   ��5L      �� *ClickLoginButton+��5M      �� $ loginWindow��.��5N   �   Đăng nhập5P      �� 5Q      $��1��5S      #��[ 6)   
��� E��$��Normal$�6t   $/ )Resource name: MaterialDesignRaisedButton��6�   $	��120��6�   ��5Q      �� *ClickCloseLoginForm+��5R      �� $ loginWindow��.��5S   �   Thoát5U      5W      5X      5Y      5Z      5[      