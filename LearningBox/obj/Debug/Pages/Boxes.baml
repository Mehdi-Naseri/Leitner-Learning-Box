   M S B A M L   `   `   `  ����F  BLearningBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LearningBox.PagesLearningBox.Pages  5      )clr-namespace:LearningBoxLearningBox  5      G(clr-namespace:LearningBox.Data.DbContextLearningBox.Data.DbContext  5          LearningBox.Pages.Boxes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:LearningBox.Pages     5      1learningBoxclr-namespace:LearningBox     5      >	dbContext(clr-namespace:LearningBox.Data.DbContext     5      -   5          >�Name$  UserControlBoxes��5	      $��RightToLeft=�5   X   .��5      � 
�������$	��300��6   $	��250��6-    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
      LearningBox.MainMenu  $	��Top=�6   $��0��67   �� 5   
   $��1��6   
����ح�6   �� 5   
   -   5         ��Name$ labelActiveBox��5      $��جعبه فعال:��6(   $
��Left=�6=   $��10,5,0,0q�6X   $	��Top=�6j   $��1��6�   $��Right=�6�   �� 5   
   -   5         ��Name$ comboBoxActivebox��5      $
��Left=�6.   $��78,9,0,0q�6I   $	��Top=�6[   $��1��6s   $	��119��6�    �� ItemBindingGroup 5      &   System.Windows.Data.BindingGroup  5       � BindingGroup 5        5      5      �� 5    
   -   5         ��Name$ buttonCreateBox��5       $��
ایجاد��6*   $
��Left=�6:   $��	19,63,0,0q�6U   $��2��6h   $	��Top=�6u   $��75��6�   6�   �� 5!   
   -   5        $ buttonUpdateBox��5!      $��ویرایش��6*   $
��Left=�6;   $��
109,63,0,0q�6V   $��2��6j   $	��Top=�6w   $��75��6�   6�   �� 5"   
   -   5        $ buttonDeleteBox��5"      $��حذف��6*   $
��Left=�68   $��
202,63,0,0q�6S   $��2��6g   $	��Top=�6t   $��75��6�   6�   �� 5#   
   -   5         ��Name$ textBoxBoxName��5#      $
��Left=�6*   $��23��6E   $��	78,32,0,0q�6Q   $��2��6d    �� TextWrapping$
 Wrap=�6q   $	��Top=�6�   $	��119��6�   ��6�   �� *SelectedItem.Name+	 �� ElementName$	 dataGridBoxes��
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ Explicit=��� 5$   
   -   5        $ label��5$      $��نام جعبه:��6   $
��Left=�63   $��	19,32,0,0q�6N   $��2��6a   $	��Top=�6n   $��Right=�6�   &   System.Windows.Controls.DataGrid  5%   
   -	   5          Name$ dataGridBoxes��5%      $��5,89,5,5q�6*   $��2��6<   $��Stretch=�6I   $	��100��6n      AutoGenerateColumns .     Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ نام جعبه��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *Name+5)      �� 5*   
   -
   5        $ labelBoxNumber��5*      $��شماره جعبه:��6(   $
��Left=�6>   $��5,4,0,0q�6Y   $��2��6j   $	��Top=�6w   {�.  6�   �� 5+   
   -   5        $ textBoxBoxNumber��5+      $
��Left=�6,   $��23��6G   $��78,4,0,0q�6S   $��2��6e   $
 Wrap=�6r   $	��Top=�6�   $��43��6�    �� 
IsReadOnly . {�.  ��6�   �� *SelectedItem.Id+$	 dataGridBoxes��6	  5,      5-      