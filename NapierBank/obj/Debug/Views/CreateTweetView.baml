   M S B A M L   `   `   `  ����E  ANapierBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NapierBank.ViewsNapierBank.Views  5      &     NapierBank.Views.CreateTweetView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:NapierBank.Views     5      
�������.��5
      �   � RowDefinitions  5   
   �� 5      $	��87* �6   �� 5      $
��201* �6   �� 5      $	��34* �6   �� 5      $	��34* �6   .+�5   
   �� $��Center=�61   $��
10,33,10,0q�6N   $	��Top=�6b   $	��280��6z   $��23��6�   {�.  ��6   �� *HeaderTextBox+6�   �� 5   
   $��Center=�61   $��
10,56,10,0q�6N   $	��Top=�6b   $	��280��6z   $��23��6�   $��2��6�    �� 	MaxLength$ 16��6�   ��6   �� *SenderTextBox+.��6�   ��5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   -   �� 6   6sys&clr-namespace:System;assembly=mscorlib     6-    �� 
TargetType" ��6    �� 	Resources 5         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual��%�   &	        !� 5      $
 Left=�6=   $ Center=�6O   $
 None=�6c    5      �� 5   "   $%��-- Insert ID e.g. @JohnSmith --��6(   
�������6R   5      5       �� Triggers 5      P� 5      	 P� Property	 � ��
 �� Empty P� Value# Z
 62   . �5       ��  �� Property � �� �� Value# [  6;   5!      P� 5"      	 � �� 62   Z� . �5#      ��  � ��# [  6;   5$      P� 5%      	 �@J�IsKeyboardFocused . . �5&      ��  � ��
 �����6;   5'      5)      .��5*      5+      �� 5.   
   $��Center=�6/   $	��163��6L   $��
10,10,10,0q�6Y    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��280��6�   $��1��6�   $	 140��6�   $��2��6�   ��6   �� *BodyTextBox+.��6�   ��5/      1&clr-namespace:System;assembly=mscorlibSystem 50   -   �� 6   6sys&clr-namespace:System;assembly=mscorlib     6-   " ��6    51      ��%�   &	        !� 52      $
 Left=�6=   $	 Top=�6O   $
 None=�6`    53      �� 54   "   $��-- Insert Message --��6(   
�������6G   56      57       58      P� 59      	 � ��# Z
 62   . �5:      ��  � ��# [  6;   5;      P� 5<      	 � �� 62   Z� . �5=      ��  � ��# [  6;   5>      P� 5?      	 �@J�IsKeyboardFocused . . �5@      ��  � ��
 �����6;   5A      5C      .��5D      5E      �� 5H   
   $��2��6Z   $��1��6g   $��Center=�6w   $	��280��6�   ��6   �� *SendButtonText+��64   �� *SendButtonCommand+6�   �� 5K   
   $��3��6\   $��0��6i   $��Center=�6y   $	��280��6�   ��6   �� *ClearButtonText+��65   �� *ClearButtonCommand+6�   5M      5N      