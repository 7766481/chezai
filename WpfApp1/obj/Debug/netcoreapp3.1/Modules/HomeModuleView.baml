   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp1.ModulesWpfApp1.Modules  5      1clr-namespace:WpfApp1.ModulesWpfApp1.Modules  5      $    WpfApp1.Modules.HomeModuleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WpfApp1.Modules     5      1Modulesclr-namespace:WpfApp1.Modules     5      $   WpfApp1.Modules.BaseModuleView    Loaded$  BaseModuleView_Loaded��6<   .��5	      � -   5         �Name$ GdRoot��5	      .+�5
   
   � .+�5      �� -   5         ��Name$ image��5      $��../Images/background.png��6#   �� 5      -   5        $ 	imgViewer��5      $��108,-454,0,0q�6'   z�5      V� 5      .~�5      ��  �� ScaleX$	 1.1Q�6)    �� ScaleY$	 1.1Q�66   �� 5      �� 5      T� 5      5      5      �� 5      $��../Images/line1.png��6   5      �� 5      $��../Images/line2.png��6   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $��Right=�6F   $��0,50,20.2,0q�6b   .+�5      � -   5        $ 	gridCarIn��5      $��0,0,7,0q�6&   .+�5      �� $��车内监控��6   $��Center=�6'   ���	#FF01AEFF$��20(�6[   $
��Bold"�6i   �� 5      $��..//Images/carout.png��6   $
��None=�67   $��0,10,0,0q�6F   �� 5      $��..//Images/carimage.png��6   $
��None=�69   $��0,25,0,0q�6H   5       � 5!      -   5        $ 
gridCarOut��5!      $��7,0,0,0q�6)   .+�5"      �� $��车外监控��6   $��Center=�6'   ���	#FF01AEFF$��20(�6[   $
��Bold"�6i   �� 5#      $��..//Images/carout.png��6   $
��None=�67   $��0,10,0,0q�6F   �� 5$      $��..//Images/carimage.png��6   $
��None=�69   $��0,25,0,0q�6H   5%      5&      �� 5'   
   $��Center=�6   $��Bottom=�62   $��0,0,0,50q�6M   $ 
Horizontal=�6_   $y�	Collapsed=�6x   .+�5(      �� $��开启��6   $
��Left=�6"   $��0,0,50,0q�6=   $	��Top=�6O   ���	#FF0E88FD$��16(�6~   $	��280��6�   ��5)      �� 5*       �� 
TargetType" ��6&   .R�5+      � .+�5,      �� $��BtnFont��6-   #��z��6=   $��Microsoft YaHei UI)�6b   $
��Bold"�6�   $��30(�6�   ���#01e5ff$��Center=�6�   $��Center=�6�   �� 5-      $ 	ImgBtnBg3��6$   $��Images\btnbackground.png��67   $��Uniform=�6Y   5.       �� Triggers 5/      P� 50       P� Property �@J�IsMouseOver	 P� Value$
	 True��6=   . �51   "   �� 
 �� 
TargetName$
 	ImgBtnBg3��6_    �� Property � �� �� Value$! ..\Images\btnbackground.png��6;   6_   52      P� 53       � ��$
	 True��6;   . �54   "   �� $
 	ImgBtnBg3��6_    � ��$! ..\Images\btnbackground.png��6;   6_   55      P� 56       � {�$	 False��6;   . �57   "   �� $
 	ImgBtnBg3��6_    � ��$! ..\Images\btnbackground.png��6;   6_   58      5:      5<      �� 5>      $��关闭��6   $
��Left=�6"   $��50,0,0,0q�6=   $	��Top=�6O   ���	#FF0E88FD$��16(�6~   $	��280��6�   ��5?      �� 5@      " ��6&   .R�5A      � .+�5B      �� $��BtnFont��6-   #��z��6=   $��Microsoft YaHei UI)�6b   $
��Bold"�6�   $��30(�6�   ���#01e5ff$��Center=�6�   $��Center=�6�   �� 5C      $ 	ImgBtnBg3��6$   $!��..\Images\btnbackground.png��67   $��Uniform=�6\   5D       5E      P� 5F       �@J�IsMouseOver$
	 True��6=   . �5G   "   �� $
 	ImgBtnBg3��6_    � ��$! ..\Images\btnbackground.png��6;   6_   5H      P� 5I       � ��$
	 True��6;   . �5J   "   �� $
 	ImgBtnBg3��6_    � ��$! ..\Images\btnbackground.png��6;   6_   5K      P� 5L       � {�$	 False��6;   . �5M   "   �� $
 	ImgBtnBg3��6_    � ��$! ..\Images\btnbackground.png��6;   6_   5N      5P      5R      5S      5W      5X      