   M S B A M L   `   `   `  ����@  <MyMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MyMap.ControlBarUCMyMap.ControlBarUC  5      %    MyMap.ControlBarUC.ControlBarUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:MyMap.ControlBarUC     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $��ucControlBar��5         ControlBarVM  � DataContext#  [  5
        MaterialDesignBody#���  5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *MouseDownWindowCommand+   CommandParameter 6O   ��  �� ElementName$ ucControlBar��5        5   
   $ MouseDoubleClick��6   . 5         6$   �� *MouseDoubleClickWindowCommand+ 6V   �� $ ucControlBar��5        5   
   $ Loaded��6   . 5         6$   �� *LoadedAccountWindowCommand+ 6S   �� $ 
mainWindow��5       .��5#      � 	 � 	Resources	 5$   
   (  "MaterialDesignThemes.Wpf.ColorZone
 �� 
TargetType �� Property �� Value��%V   '        �� 5%      "
  6   .�5&      ��  � ��$ 0q�6+   67   5'      5(       � ColumnDefinitions 5)   
   �� 5*      $	��65* �6   �� 5+      $	��11* �6    � RowDefinitions 5-   
   �� 5.      �� 5/      $��5* �6   .+�51   
     ���#68ffb1   Mode$ 
PrimaryMid=�69   $��10q�6K   $��
-277,0,0,0q�6X   $��2��6l   $��2��6}   .��52      ]� .+�53      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   
������ 	 54      ��%�   '��       �� 55      "
 ��6    .�56      ��  � ��$ 40��66   6C   �� 57       � ��
 ���� 6Q   �� 58       � ��$ 0q�6@   6L   59      5:      .+�5;      � $��40��6   $
��12 0q�6'    � ToolTip$ Sign In��65   y�6G   �� *VisibleLoginButton+.+�5<      F� $��20��6    �� Stretch$ UniformToFill=�6+   
���   �$
��auto��6Q   ����� �  	= � $�  z � 	=  	= � �  � � 	=  	= � z  z � 	=  	= � �  	= � 	=  	= � � ��� ��Q��k0@���  -1���  -1��� -1 -1� 	=  -1� 	= ��� 	= ��� `�s ���  � ��� 	6`    5=        5>      $ MouseLeftButtonDown��6-   . 5?   "      68   �� *SignInCommand+ 6Z   �� $ ucControlBar��5@      5B      � 5C      $��40��6   $
��12 0q�6'   $ Sign Up��65   y�6G   �� *VisibleLoginButton+.+�5D      F� $��20��6   $ UniformToFill=�6+   
���   �$
��auto��6Q   �������� ��� �$� ��� ��j ��� ��j �����j  -1���^ -1���^�����^��� p���� ��� ��� Ѐ�[ ��� р�[ ��j � 	= ��j � 	= ��� �@B ��� �@B  � � 	=  � � 	= ��� р�[ ��� р�[  � �@T�  � �@T� ��� ����  � ���! z   	=  	= ����  	=   	=  	= ��ا  z   	=  	= ����  �   	=  	= 	6_    5E        5F      $ MouseLeftButtonDown��6-   . 5G   "      68   �� *SignUpCommand+ 6Z   �� $ ucControlBar��5H      5J      �� 5K      $ Minimize Window��5M      ��5K      �� *MinimizeWindowCommand+��5L      �� $ ucControlBar��.��5N      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=�62   5O      �� 5P      $ Maximize Window��5R      ��5P      �� *MaximizeWindowCommand+��5Q      �� $ ucControlBar��.��5S        $ WindowMaximize=�62   5T      �� 5U      $ Close��5W       c� OverflowMode$ AsNeeded=�6-   ��5U      �� *CloseWindowCommand+��5V      �� $ ucControlBar��.��5X        $ WindowClose=�62   5Y      5Z      �� 5[      $ 
Horizontal=�6   +	  %MaterialDesignThemes.Wpf.RippleAssist 	  
IsCentered . .+�5\      d�  ' #MaterialDesignHamburgerToggleButton#���  6#   �� 5^      $��30 0 0 0q�6    $��25(�63   $
��Bold"�6A   $��Center=�6S   ��6n   �� *Tag+$ ucControlBar��6�   5t      �� 5u      .+�5v      ��  �� Right$ 20��6    
 �� Top$ 5��62   $��25(�6A   $
��Bold"�6O   $��Center=�6a   ��6}   �� *ShowNameUser+6�   5w      5x      5y      5z      5{      