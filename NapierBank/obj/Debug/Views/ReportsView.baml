   M S B A M L   `   `   `  ����E  ANapierBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NapierBank.ViewsNapierBank.Views  5      "    NapierBank.Views.ReportsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:NapierBank.Views     5      
�������.��5
      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��197* �6   �� 5      $	��78* �6   �� 5      $	��50* �6   .+�5   
   �� -   5         ��Name$ MentionsTxtB��5      $��Center=�6I   $	��225��6f   $��	10,10,0,0q�6s    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��98��6�   $��0��6�   $��0��6�   {�.  $��2��6�   ��6(   �� *MentionsTextBox+.��6�   ��5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   -   �� 6   6sys&clr-namespace:System;assembly=mscorlib     6-    �� 
TargetType" ��6    �� 	Resources 5         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch	 !� Visual��%�   &	        !� 5      $
 Left=�6=   $ Center=�6O   $
 None=�6c   	 5      �� 5   "   $�� -- @Mentions --��6(   
�������6C   5      5       
 �� Triggers
 5!      P� 5"       P� Property � �� �� Empty P� Value# Z 62   . �5#      ��  �� Property � �� �� Value# [  6;   5$      P� 5%       � �� 62   Z� . �5&      ��  � ��# [  6;   5'      P� 5(       �@J�IsKeyboardFocused . . �5)      ��  � ��
 �����6;   5*      5,      .��5-      5.      �� 51   
   -   5        $ HashTxtB��51      $��Center=�6D   $	��225��6a   $��0,10,0,0q�6n   $
 Wrap=�6�   $	��Top=�6�   $	��108��6�   $��1��6�   $��0��6�   {�.  $��2��6�   ��6$   �� *HashtagTextBox+.��6�   ��52      1&clr-namespace:System;assembly=mscorlibSystem 53   -   �� 6   6sys&clr-namespace:System;assembly=mscorlib     6-   " ��6    54      ��%�   &	        !� 55      $
 Left=�6=   $ Center=�6O   $
 None=�6c   	 56      �� 57   "   $�� -- Trending #tags --��6(   
�������6H   59      5:      
 5;      P� 5<       � ��# Z 62   . �5=      ��  � ��# [  6;   5>      P� 5?       � �� 62   Z� . �5@      ��  � ��# [  6;   5A      P� 5B       �@J�IsKeyboardFocused . . �5C      ��  � ��
 �����6;   5D      5F      .��5G      5H      �� 5K   
   -   5        $ SirTxtB��5K      $��Center=�6?   $	��225��6\   $��	0,10,11,0q�6i   $
 Wrap=�6|   $	��Top=�6�   $��98��6�   $��2��6�   $��0��6�   {�.  $��2��6�   ��6#   �� *
SIRTextBox+.��6�   ��5L      1&clr-namespace:System;assembly=mscorlibSystem 5M   -   �� 6   6sys&clr-namespace:System;assembly=mscorlib     6-   " ��6    5N      ��%�   &	        !� 5O      $
 Left=�6=   $ Center=�6O   $
 None=�6c   	 5P      �� 5Q   "   $�� -- View SIR List --��6(   
�������6G   5S      5T      
 5U      P� 5V       � ��# Z 62   . �5W      ��  � ��# [  6;   5X      P� 5Y       � �� 62   Z� . �5Z      ��  � ��# [  6;   5[      P� 5\       �@J�IsKeyboardFocused . . �5]      ��  � ��
 �����6;   5^      5`      .��5a      5b      �� 5d   
   -   5         ��Name$
 Btn1��5d      $��View Mentions��6   $��Center=�67   $��Center=�6R   $��10,28,10,26q�6o   $��0��6�   $��1��6�   $��24��6�   $��88��6�   6�   �� 5e   
   -   5        $
 Btn3��5e      $��View SIR��6   $��Center=�62   $��Center=�6M   $��10,28,11,26q�6j   $��2��6   $��1��6�   $��24��6�   $��88��6�   6�   �� 5f   
   -   5        $
 Btn2��5f      $��View Trending��6   $��Center=�67   $��Center=�6R   $��10,28,10,26q�6o   $��1��6�   $��1��6�   $��24��6�   $��88��6�   6�   �� 5h   
   -   5        $ button��5h      $
��Left=�6p   $��	16,24,0,0q�6�   $	��Top=�6�   $��75��6�   $��1��6�   $��2��6�   ��6!   �� *ClearDataButtonText+��6I   �� *ClearButtonCommand+6�   5k      5l      