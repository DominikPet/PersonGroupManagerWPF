   M S B A M L   `   `   `  ����H  DPersonManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonManagerPersonManager  5      !    PersonManager.EditGroupPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PersonManager     5        N� Title$  EditGroupPage��5
      .��5      �    GradientBackground#��[  6   .+�5   
   �� -   5         ��Name$ lbName��5      
�������$��Name of group��5      $
��Left=�5      $��
235,34,0,0q�5      $	��Top=�5      $��25��5      $	��100��5      �� 5   
   -   5         ��Name$ tbName��5      $
��Left=�5      $��
350,36,0,0q�5       �� TextWrapping$
 Wrap=�5      $	��Top=�5      $	��206��5      $��25��5      ��5      �� *Name+5      �� 5   
   -   5         ��Name$ 	btnCommit��5!      $��Commit��5      
���   �
�������$
��Left=�5#      $��
48,413,0,0q�5$      $	��Top=�5%      $��30��5&      $��80��5'      �� 5)   
   -   5        $ 	btnRemove��5,      $��Remove��5)      
���  ��
�������$
��Left=�5.      $��453,413,0,0q�5/      $	��Top=�50      $��30��51      $	��103��52      �� 54   
   -   5        $ btnBack��56      
������ 
������ $
��Left=�58      $��	20,29,0,0q�59      $	��Top=�5:      $��35��5;      $��55��5<      .��5=      �� $��/Assets/back.png��6   5>      �� 5?   
   -   5         ��Name$ lvAllPeople��5?      $	��150��5@      $	��300��5A      $��88,75,362,75q�5B       �� View 5D      �� 5E      .P�5F      ��  �� Width$	 150��6%   $��
All people��5G   %   5H      5J      �� 5K   
   -   5        $ lvPeopleInGroup��5K      $	��150��5L      $	��300��5M      $��350,75,100,75q�5N       5P      �� 5Q      .P�5R      �� $	 150��6%   $��People in group��5S   %   5T      5V      5W      5X      