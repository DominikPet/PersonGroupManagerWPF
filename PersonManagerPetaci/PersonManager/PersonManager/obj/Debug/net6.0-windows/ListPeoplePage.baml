   M S B A M L   `   `   `  ����H  DPersonManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonManagerPersonManager  5      "    PersonManager.ListPeoplePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PersonManager     5        N� Title$  ListPeoplePage��5
      .��5      �    GradientBackground#��[  6   .+�5   
   �� -   5         ��Name$ lvPeople��5      $	��500��5      $	��300��5      $��50,40,50,110q�5      $	��Top=�5       �� AlternationCount$ 2��5      ��5      �� 5       �� 
TargetType" ��6   .�5      -   5        �� 5       �� Property � �� �� Value
 ��ح�5       �� Triggers 5      P� 5       P� Property �@��AlternationIndex P� Value$ 1��5   "   . �5      ��  � ��
 �����5   %   5      ]� 5      	 ]� 
Conditions	 5       �� 5!   "   
 �� Property
 �@��
IsSelected �� Value$
 True��5"   ,   ./�5$      ��  � ��
 ���_�5%   %   5&      5)       �� View 5+      �� 5,      .P�5-      ��  �� Width$	 126��6%   $��
First name��5.   %    �� DisplayMemberBinding 5/   %   �� *	FirstName+�� 50      $	 126��6%   $��	Last name��51   %    52   %   �� *
LastName+�� 53      $	 126��6%   $	��Age��54   %    55   %   �� *Age+�� 56      $	 126��6%   $��Email��57   %    �� CellTemplate 58      �� 59      .R�5:   "   �� $��	Underline{�5;   ,   
���   � � Cursor$
 Hand��5=   ,   ��5:   ,   �� *Email+ � ToolTip 5>   &   �� 5?   *    ��Name$ picture��60   $��60��5A   0   $��60��5B   0   ��5@   0   �� *Image+5B   0   5D   #   5E      5G      5H      5J      �� 5K   
   -   5         ��Name$ btnAdd��5N      $	��Add��5K      
��� � �
�������$
��Left=�5P      $��228,381,0,0q�5Q      $	��Top=�5R      $��83��5S      $��26��5T      �� 5U   
   -   5        $ btnEdit��5X      $
��Edit��5U      
���   �
�������$
��Left=�5Z      $��350,381,0,0q�5[      $	��Top=�5\      $��83��5]      $��26��5^      �� 5_   
   -   5        $ 	btnDelete��5b      $��Delete��5_      
���  ��
�������$
��Left=�5d      $��467,381,0,0q�5e      $	��Top=�5f      $��83��5g      $��26��5h      �� 5j   
   -   5        $ btnViewGroups��5l      
��� ���
���   �$��View groups��5n      $
��Left=�5o      $��117,381,0,0q�5p      $	��Top=�5q      $��26��5r      $��83��5s      5u      5v      