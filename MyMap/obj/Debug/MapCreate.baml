   M S B A M L   `   `   `  ����@  <MyMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyMapMyMap  5   	   7 clr-namespace:MyMap.ControlBarUCMyMap.ControlBarUC  5   	   1clr-namespace:MyMap.ViewModelMyMap.ViewModel  5   	       MyMap.MapCreate   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:MyMap     5   	   /uc clr-namespace:MyMap.ControlBarUC     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   *local1clr-namespace:MyMap.ViewModel  5   	   -   5        $��mapCreateWindow��5   	      MapCreateVM  � DataContext#  [  5
   	    � Title$ 
Create Map��5   	   $	��800��6   $
��1400��6)    � WindowStartupLocation$ CenterScreen=�5   	     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	   
���   �$	��0.4q�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedWindowCommand+   CommandParameter 6L   ��  �� ElementName$ mapCreateWindow��5      .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��auto �6   6,   �� 5%      6   .+�5'   
   � $��0��6   .+�5(      %   MyMap.ControlBarUC.ControlBarUC  $
��auto��6   $��	275,0,0,0q�6`   
 � Tag 6-   �� *Title+$ mapCreateWindow��6v   5)      � 5*   
   $��1��6   
������� � ColumnDefinitions 5+      �� 5,      6%   �� 5-      $
��0.4* �6#   62   �� 5.      $��0.01* �6#   63   .+�52      �� $��1��6   $	��750��6,   $	��750��69   .��53      � $��5q�6    54      �� 55      $
��auto �6(   68   �� 56      $
��auto �6(   68   �� 57      $
��auto �6(   68   �� 58      $
��auto �6(   68   �� 59      $
��auto �6(   68   �� 5:      $
��auto �6(   68   �� 5;      $
��auto �6(   68   �� 5<      $
��auto �6(   68   �� 5=      $
��auto �6(   68   �� 5>      $
��auto �6(   68   �� 5?      $
��auto �6(   68   .+�5A      � $��0��6    5B      �� 5C      61   �� 5D      61   .+�5F      #  MaterialDesignThemes.Wpf.Card  $��0��6.   $��7q�6>   .��5G      �� -   5        $��bindingText1��5G   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ X��6:    % !MaterialDesignFloatingHintTextBox#��[ 6]   $
��auto��6�   $��15q�6�   $
��auto��6�   ��6�   �� *CoordinatorX+6�   5H        5I      $��1��6.   $��7q�6>   .��5J      �� -   5        $��bindingText2��5J   &   $ Y��6:   #��[ 6]   $
��auto��6�   $��15q�6�   $
��auto��6�   ��6�   �� *CoordinatorY+6�   5K      5L        5M      $��1��6*   $��7q�67   .��5N      �� -   5        $��address��5N   "   $ Tên Địa Điểm��61   #��[ 6_   $
��auto��6�   $��15q�6�   $	��400��6�   ��6�   �� *AddressNameCreate+6�   5O        5Q      $��2��6*   $��7q�67   .��5R      ��  � ToolTip$  Tạo địa điểm mới��6E   ��6!   �� *CreateNewVertex+.��5S      �� $
��Wrap=�6(   $��TẠO ĐỊA ĐIỂM��6=    �� TextAlignment$ Center=�6R   6l   5T      5U      � 5V      $��3��6    5W      �� 5X      61   �� 5Y      61   .+�5[        $��0��6.   $��7q�6>   .��5\      �� $ X Gần đó��6'   #��[ 6Q   $
��auto��6�   $��15q�6�   $
��auto��6�   ��6�   �� *CoordinatorXNear+6�   5]        5^      $��1��6.   $��7q�6>   .��5_      �� $ Y Gần đó��6'   #��[ 6Q   $
��auto��6�   $��15q�6�   $
��auto��6�   ��6�   �� *CoordinatorYNear+6�   5`      5a        5b      $��4��6*   $��7q�67   .��5c      �� $$ Tên Địa Điểm Gần Đó��6#   #��[ 6X   $
��auto��6�   $��15q�6�   $	��400��6�   ��6�   �� *AddressNameNear+6�   5d      � 5e      $��5��6    5f      �� 5g      61   �� 5h      61   .+�5j        $��0��6.   $��7q�6>   .��5k      �� ��6%   �� *
ChooseV1+.��5l   "   �� $
��Wrap=�6,   $��CHỌN ĐIỂM 1��6A   $ Center=�6U   6o   5m      5n        5o      $��1��6.   $��7q�6>   .��5p      �� ��6%   �� *
ChooseV2+.��5q   "   �� $
��Wrap=�6,   $��CHỌN ĐIỂM 2��6A   $ Center=�6U   6o   5r      5s      5t        5u      $��6��6*   $��7q�67   .��5v      �� $) #Nối hai điểm chọn với nhau��6L   ��6!   �� *CreateNewVertex_Vertex+.��5w      �� $
��Wrap=�6(   $��NỐI ĐIỂM��6=   $ Center=�6N   6h   5x      5y        5z      $��7��6*   $��8q�67   .��5{      �� $&  Xoá nối 2 điểm đã chọn��6I   ��6!   �� *DeleteVertex_Vertex+.��5|      �� $
��Wrap=�6(   $��XOÁ NỐI ĐIỂM��6=   $ Center=�6R   6l   5}      5~        5      $��8��6*   $��7q�67   .��5�      �� $&  Cập nhật điểm đã chọn��6H   ��6!   �� *UpdateVertexChoose+.��5�      �� $
��Wrap=�6(   $��CẬP NHẬT ĐIỂM��6=   $ Center=�6S   6m   5�      5�      � 5�      $��9��6    5�      �� 5�      61   �� 5�      61   .+�5�        $��0��6.   $��7q�6>   .��5�      �� ��6%   �� *ChooseDiemDi+.��5�   "   �� $
��Wrap=�6,   $��13(�6@   $��CHỌN ĐIỂM ĐI��6N   $ Center=�6b   6|   5�      5�        5�      $��1��6.   $��7q�6>   .��5�      �� ��6%   �� *ChooseDiemDen+.��5�   "   �� $
��Wrap=�6,   $��13(�6@   $��CHỌN ĐIỂM ĐẾN��6N   $ Center=�6d   6~   5�      5�      5�        5�      $ Thông tin Đường Từ��6*   $��10��6G   $��7q�6U   $
��auto��6`   $	��360��6n   $��Stretch=�6~   .��5�      �� $��Disabled=�6'   $
��auto��6N   .��5�      �� ��6'   �� *
PathList+ �� SelectedItem 6H   �� *SelectedVertex+ �� View 5�   "   �� 5�   &   .P�5�   *   ��  �� Width$	 140��69   $��Tên Đường��6E    �� DisplayMemberBinding 6X   �� *
NamePath+6�   �� 5�   *   $	 110��69   $��Distance��6E    6W   �� *
Distance+6�   5�   '   5�      5�      5�      5�      5�      � 5�      $��0��6   .+�5�       	   MyMap.ViewModel.ZoomBorder	  -   5         	 Name$ border��5�   $   }�.  	  Child. 5�      �� -   5        $��myCanvas��5�   8   $
��auto��6   $
��auto��6*    5�        5�      $ 	MouseDown��6-   .	 5�   "     
 68   �� *	MouseDown+ 6V   �� $ myCanvas��5�      .+�5�      �� $
��auto��6!   $
��auto��6.   $��Resources\my_new_task.jpg��6<   6a   �� 5�      .+�5�      �� ��6+   �� *	AllVertex+��5�   "   �� 5�   &   .R�5�   *   �� 
������ $
��auto��6J   $
��auto��6W   6g   5�   '   ��5�   "   �� 5�   &    �� 
TargetType" ��6,   .�5�   *   ��  �� Property �@��Left �� Value 6H   �� *
CanvasLeft+�� 5�   *    �@��Top 6G   �� *	CanvasTop+5�   '   ��5�   "   �� 5�   &   .R�5�   *   �� $��Black"�6K    �� Padding$ 4q�6^   $��7(�6j   $ Center=�6w   $��Center=�6�   $��Center=�6�   $��WrapWithOverflow=�6�   ��64   �� *Index+��6�   �� *Height+��6  �� *Width+��5�   .   !� 5�   2    !� Visual 5�   6   A� 5�   :   
��� �����6B   �� *Height+��6\   �� *Width+5�   ;   5�   3   5�   +   5�   '   5�      A� 5�      $��16��6&   $��16��61   
��� � �
��� � �$��2��6X    �� Left 5�      ��  �� Path$ p1�  �� UpdateSourceTrigger$  PropertyChanged=�
! �� Top! 5�      �� $ p2�$  PropertyChanged=�5�      A� 5�      $��16��6&   $��16��61   
��� � �
���  ��$��2��6V    5�      �� $ CoordinatorX�$  PropertyChanged=�! 5�      �� $ CoordinatorY�$  PropertyChanged=�5�      A� 5�      $��16��6'   $��16��62   
��� ���
��� E��$��2��6_    5�      �� $ p3�$  PropertyChanged=�! 5�      �� $ p4�$  PropertyChanged=�5�      F� 5�      -   5        $��patDirection��5�   F   
��� ���$��3��6m   ��6#   �� $ PatDirection�6�   5�      5�      5�      5�      5�      5�      5�      