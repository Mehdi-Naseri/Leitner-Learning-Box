   M S B A M L   `   `   `  ����F  BLearningBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LearningBox.PagesLearningBox.Pages  5      )clr-namespace:LearningBoxLearningBox  5      G(clr-namespace:LearningBox.Data.DbContextLearningBox.Data.DbContext  5          LearningBox.Pages.Cards   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:LearningBox.Pages     5      1learningBoxclr-namespace:LearningBox     5      >	dbContext(clr-namespace:LearningBox.Data.DbContext     5      -   5          >�Name$  userControlCards��5   I   $��RightToLeft=�5
      .��5      � 
�������$��0q�6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   .+�5   
      LearningBox.MainMenu  $	��Top=�6   $��0��67   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridCards��5      $��1��6*   $��	5,198,5,5q�68      AutoGenerateColumns .  $	��100��6g      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ سوال��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *
Question+  5      $ پاسخ��6&    64   �� *Answer+  5      $ 
تاریخ��6&    65   �� *Date+ �� StringFormat$ 
dd/MM/yyyy��  5      $ گروه��6&    64   �� *GroupNumber+5      �� 5   
   -   5         ��Name$ label��5      $��	سوال:��6   $
��Left=�6/   $��2,38,0,0q�6J   $��1��6\   $	��Top=�6i   �� 5   
   -   5        $ label1��5      $��	پاسخ:��6    $
��Left=�60   $��2,69,0,0q�6K   $��1��6]   $	��Top=�6j   �� 5   
   -   5        $ label2��5      $��	گروه:��6    $
��Left=�60   $��	7,139,0,0q�6K   $��1��6^   $	��Top=�6k   �� 5   
   -   5        $ label3��5      $�� ��6    $
��Left=�6+   $��249,138,0,0q�6F   $��1��6[   $	��Top=�6h   �� 5    
   -   5        	 ��Name$	 textBoxQuestion��5       $
��Left=�6+   $��23��6F   $��	47,38,5,0q�6R   $��1��6e   
 �� TextWrapping$

 Wrap=�6r   $	��Top=�6�   $	��313��6�   $��LeftToRight=�6�   ��6�   �� *SelectedItem.Question+ �� ElementName$ dataGridCards�� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ Explicit=��� 5!   
   -   5         ��Name$ comboBoxGroupNumber��5!      $
��Left=�60   $��
47,142,0,0q�6K   $��1��6_   $	��Top=�6l   $��37��6�    �� SelectedIndex 6�   �� *SelectedItem.GroupNumber+$ dataGridCards��$ TwoWay=�$ Explicit=�.@�5"      �� $��0��6    �� 
IsSelected . 6'   �� 5#      $��1��6   �� 5$      $��2��6   �� 5%      $��3��6   �� 5&      $��4��6   �� 5'      $��5��6   �� 5(      $��6��6   5)      �� 5*   
   -	   5        $	 textBoxAnswer��5*      $
��Left=�6)   $��68��6D   $��	47,69,5,0q�6P   $��1��6c   $

 Wrap=�6p   $	��Top=�6�   $	��313��6�    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6�   �� *SelectedItem.Answer+$ dataGridCards��$ TwoWay=�$ Explicit=��� 5+   
   -
   5         ��Name$ ButtonCreateCard��5+      $��
ایجاد��6+   $
��Left=�6;   $��
47,173,0,0q�6V   $��1��6j   $	��Top=�6w   $��75��6�   6�   �� 5,   
   -   5        $ ButtonUpdateCard��5,      $��ویرایش��6+   $
��Left=�6<   $��149,173,0,0q�6W   $��1��6l   $	��Top=�6y   $��75��6�   6�   �� 5-   
   -   5        $ ButtonDeleteCard��5-      $��حذف��6+   $
��Left=�69   $��252,173,0,0q�6T   $��1��6i   $	��Top=�6v   $��75��6�   6�   �� 5.   
   -   5        $ label4��5.      $��شماره کارت:��6    $
��Left=�66   $��-1,7,0,0q�6Q   $��1��6c   $	��Top=�6p   {�.  6�   �� 5/   
   -   5        $	 textBoxCardNumber��5/      $
��Left=�6-   $��23��6H   $��	74,10,0,0q�6T   $��1��6g   $

 Wrap=�6t   $	��Top=�6�   $��55��6�    �� 
IsReadOnly . {�.  ��6�   �� *SelectedItem.Id+$ dataGridCards��6  �� 50   
   -   5        $ label5��50      $��تاریخ:��6    $
��Left=�61   $��163,142,0,0q�6L   $��1��6a   $	��Top=�6n   (  "System.Windows.Controls.DatePicker  51   
   -   5          Name$ 
datePicker��51      $
��Left=�6)   $��200,142,0,0q�6D   $��1��6Y   $	��Top=�6f      FirstDayOfWeek$ Saturday=�6~      SelectedDateFormat$ Short=�6	     SelectedDate 6�   �� *SelectedItem.Date+$ dataGridCards��$ TwoWay=�$ Explicit=� � 	Resources 52      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%g   '        �� 53      "  6   .�54      ��  � ��$ انتخاب تاریخ��6-   55      56      57      58      59      