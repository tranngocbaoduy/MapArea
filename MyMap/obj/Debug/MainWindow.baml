   M S B A M L   `   `   `  ����@  <MyMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyMapMyMap  5   	   7 clr-namespace:MyMap.ControlBarUCMyMap.ControlBarUC  5   	   1clr-namespace:MyMap.ViewModelMyMap.ViewModel  5   	       MyMap.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:MyMap     5   	   /uc clr-namespace:MyMap.ControlBarUC     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   *local1clr-namespace:MyMap.ViewModel  5   	   -   5        $��
mainWindow��5   	    
  MainVM  � DataContext#  [  5
   	    � Title$3 -Phần mềm quản lý bản đồ khu vực��5   	   $	��800��61   $
��1400��6>    � WindowStartupLocation$ CenterScreen=�5   	     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	   
���   �$	��0.4q�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedWindowCommand+   CommandParameter 6L   ��  �� ElementName$ 
mainWindow��5      .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��auto �6   6,   �� 5%      6   .+�5'   
   � $��0��6   .+�5(      %   MyMap.ControlBarUC.ControlBarUC  $
��auto��6   $��	275,0,0,0q�6[   
 � Tag 6-   �� *Title+$ 
mainWindow��6q   5)      � 5*   
   $��1��6   
������� � ColumnDefinitions 5+      �� 5,      6%   �� 5-      $
��0.3* �6#   62   �� 5.      $��0.01* �6#   63   .+�50      � $��1��6   $��5q�6#    51      �� 52      $
��auto �6$   64   �� 53      $
��auto �6$   64   �� 54      $
��auto �6$   64   �� 55      $
��auto �6$   64   �� 56      $
��auto �6$   64   �� 57      $
��auto �6$   64   �� 58      $
��auto �6$   64   �� 59      $
��auto �6$   64   �� 5:      $
��auto �6$   64   .+�5<      #  MaterialDesignThemes.Wpf.Card  $��0��6&   $��7q�63   .��5=      �� -   5        $��FormText��5=   b   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Từ��6>    % !MaterialDesignFloatingHintTextBox#��[ 6r   $
��auto��6�   $��15q�6�   $	��400��6�   ��6   �� *V1_VERTEXNAME+.��6�    5>        5?      $ KeyUp��6-   .	 5@   "     
 68   �� *FromAddressCommand+ 6_   �� $ FormText��5A      .��5B   2   5C      5D        5E      $��1��6&   $��7q�63   .��5F      �� -   5        $��ToText��5F      $ Đến��6L   #��[ 6q   $
��auto��6�   $��15q�6�   $	��400��6�   ��6,   �� *V2_VERTEXNAME+.��6�    5G        5H      $ KeyUp��6-   .	 5I   "     
 68   �� *ToAddressCommand+ 6]   �� $ ToText��5J      .��5K   2   5L      5M      � 5O      $��2��6    5P      �� 5Q      6-   �� 5R      6-   .+�5T        $��0��6*   $��7q�6:   .��5U      �� ��6!   �� *
ChooseV1+.��5V      �� $
��Wrap=�6(   $��13(�6<   $��CHỌN ĐIỂM ĐI��6J    �� TextAlignment$ Center=�6^   6x   5W      5X        5Y      $��1��6*   $��7q�6:   .��5Z      �� ��6!   �� *
ChooseV2+.��5[      �� $
��Wrap=�6(   $��13(�6<   $��CHỌN ĐIỂM ĐẾN��6J   $ Center=�6`   6z   5\      5]      5^        5_       � ToolTip$ Thông tin Đường Từ��6&   $��3��6C   $��7q�6P   $
��auto��6[   $	��360��6i   $��Stretch=�6y   .��5`      �� $��Disabled=�6#   $
��auto��6J   .��5a      �� ��6#   �� *
VertexList+ �� SelectedItem 6F   �� *SelectedVertex+ �� View 5b      �� 5c   "   .P�5d   &   �� $��Tên Đường��65    �� DisplayMemberBinding 6H   �� *
VERTEXNAME+6v   5e   #   5g      5h      5i        5k      
���   �$	��0.4q�6:   $��7q�6P   $��8��6[   $	��350��6h   $	��350��6u   $��Stretch=�6�   .��5l      �� $��Disabled=�6#   .��5m      �� ��6#   �� *
PathList+ 6D   �� *SelectedItem+ �� UpdateSourceTrigger$ PropertyChanged=� 5n      �� 5o   "   .P�5p   &   ��  �� Width$	 140��65   $��Tên Đường��6A    6T   �� *
NamePath+6�   �� 5q   &   $	 110��65   $��Distance��6A    6S   �� *
Distance+6   5r   #   5t      5u      5v      5w      � 5x      $��0��6   .+�5y       	   MyMap.ViewModel.ZoomBorder	  -   5         	 Name$ border��5y   Q   |�. $
��auto��65   $
��auto��6B   }�.  	  Child. 5z      �� -   5        $��myCanvas��5z   8   $
��auto��6   $
��auto��6*    5{        5|      $ 	MouseDown��6-   .	 5}   "     
 68   �� *	MouseDown+ 6V   �� $ myCanvas��5~      .+�5�      �� 
 �� Top$ -3500��6     �� Left$ -3500��63   $
��auto��6G   $
��auto��6T   $��Resources\my_new_task.jpg��6b   5�      �� 5�      $
��auto��6"   $
��auto��6/   .+�5�      �� ��6+   �� *	AllVertex+��5�   "   �� 5�   &   .R�5�   *   �� 
������ $
��auto��6J   $
��auto��6W   5�   +   5�   '   ��5�   "   �� 5�   &    �� 
TargetType" ��6,   .�5�   *   ��  �� Property �@��Left �� Value 6H   �� *
CanvasLeft+�� 5�   *    �@��Top 6G   �� *	CanvasTop+5�   '   ��5�   "   �� 5�   &   .R�5�   *   �� $��Black"�6K    �� Padding$ 4q�6^   $��7(�6j   $ Center=�6w   $��Center=�6�   $��Center=�6�   $��WrapWithOverflow=�6�   ��64   �� *Index+��6�   �� *Height+��6  �� *Width+��5�   .   !� 5�   2     !� Visual  5�   6   A� 5�   :   
��� �����6B   �� *Height+��6\   �� *Width+5�   ;   5�   3   5�   +   5�   '   5�      A� 5�      $��16��6&   $��16��61   
��� � �
��� � �$��2��6X    5�      �� ! �� Path$! p1�$ PropertyChanged=� 5�      �� $! p2�$ PropertyChanged=�5�      A� 5�      $��16��6&   $��16��61   
��� � �
���  ��$��2��6V    5�      �� $! CoordinatorX�$ PropertyChanged=� 5�      �� $! CoordinatorY�$ PropertyChanged=�5�      A� 5�      $��16��6'   $��16��62   
��� ���
��� E��$��2��6_    5�      �� $! p3�$ PropertyChanged=� 5�      �� $! p4�$ PropertyChanged=�5�      F� 5�      -   5        $��patDirection��5�   F   
��� ���$��3��6m   ��6#   �� $! PatDirection�6�   5�      5�      5�      5�      5�      5�      5�      