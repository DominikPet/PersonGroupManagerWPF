   M S B A M L   `   `   `  ����H  DPersonManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonManagerPersonManager  5      "    PersonManager.EditPersonPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PersonManager     5        N� Title$  EditPersonPage��5
      .��5      � -   5         �Name$
 grid��5         GradientBackground#��[  5      .+�5   
   �� -   5         ��Name$ pictureBorder��5      $	��200��5      $	��300��5      
�������$��1q�5      $��347,75,53,75q�5      ._�5      �� -   5         ��Name$ picture��5      $��Uniform=�5      ��5      �� *Image+5      5      �� 5   
   
�������$��
First name��5      $
��Left=�5      $��	45,97,0,0q�5      $	��Top=�5      $��26��5      $��65��5      �� 5   
   -   5         ��Name$ tbFirstName��5      $
��Left=�5!      $��131,101,0,0q�5"       �� TextWrapping$
 Wrap=�5#      $	��Top=�5$      $	��148��5%      $��22��5&      ��5       �� *	FirstName+5&      �� 5(   
   
�������$��	Last name��5)      $
��Left=�5*      $��
45,153,0,0q�5+      $	��Top=�5,      $��26��5-      $��65��5.      �� 5/   
   -   5        $ 
tbLastName��5/      $
��Left=�51      $��131,157,0,0q�52      $
 Wrap=�53      $	��Top=�54      $	��148��55      $��22��56      ��50      �� *
LastName+56      �� 58   
   
�������$	��Age��59      $
��Left=�5:      $��
45,216,0,0q�5;      $	��Top=�5<      $��26��5=      $��65��5>      �� 5?   
   -   5        $ tbAge��5?      
 � Tag$	 Int��5A      $
��Left=�5B      $��205,216,0,0q�5C      $
 Wrap=�5D      $	��Top=�5E      $��74��5F      $��22��5G      ��5@      �� *Age+5G      �� 5I   
   
�������$��Email��5J      $
��Left=�5K      $��
45,265,0,0q�5L      $	��Top=�5M      $��26��5N      $��65��5O      �� 5P   
   -   5        $ tbEmail��5P      $ Email��5R      $
��Left=�5S      $��131,269,0,0q�5T      $
 Wrap=�5U      $	��Top=�5V      $	��148��5W      $��22��5X      ��5Q      �� *Email+5X      �� 5Z   
   -   5         ��Name$ 	btnCommit��5]      $��Commit��5Z      
���   �
�������$
��Left=�5_      $��
49,345,0,0q�5`      $	��Top=�5a      $��30��5b      $��80��5c      �� 5d   
   -	   5        $ 	btnUpload��5g      $��Upload��5d      
��� ���
�������$
��Left=�5i      $��181,345,0,0q�5j      $	��Top=�5k      $��30��5l      $��80��5m      �� 5n   
   -
   5        $ btnBack��5p      
������ 
������ $
��Left=�5r      $��	20,29,0,0q�5s      $	��Top=�5t      $��35��5u      $��55��5v      .��5w      �� $��/Assets/back.png��6   5x      5y      5z      