   M S B A M L   `   `   `  ����F  BLearningBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LearningBox.PagesLearningBox.Pages  5      )clr-namespace:LearningBoxLearningBox  5          LearningBox.Pages.Read   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:LearningBox.Pages     5      1learningBoxclr-namespace:LearningBox     5      -   5          >�Name$  userControlRead��5      $��RightToLeft=�5   ?   .��5	      � ���	#B2282830$
��Auto��6"   $	��200��6/   $	��300��6?    � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��* �6   .+�5   
      LearningBox.MainMenu  $	��Top=�6   $��0��67   �� 5   
   -   5        $��buttonAnswer��5   \   $��پاسخ��6   $��23��6    $
��Left=�6,   $��111,108,0,0q�6G   $	��Top=�6p   $��63��6�   $��0��6�    �� 	IsDefault . $��1��6�   6�   �� 5   
   -   5        $��buttonCorrect��5   [   $��درست��6   $��23��6    $
��Left=�6,   $��
58,108,0,0q�6G   $	��Top=�6p   $��60��6�   $��1��6�    . $��1��6�   6�   �� 5   
   -   5        $��buttonUncorrect��5   [   $��غلط��6   $��23��6   $
��Left=�6+   $��163,108,0,0q�6F   $	��Top=�6r   $��60��6�   $��2��6�    . $��1��6�   6�   � 5   
   -   5        $��progressBar1��5   5   $��10��6   $��	0,198,0,0q�6"   $	��Top=�6I   $��1��6a    � SmallChange$ 1Q�6n   6~   �� 5   
   -   5         ��Name$ buttonVoice��5   J   $��21��6   $
��Left=�6   $��32,6,0,0q�68   $	��Top=�6_   $��25��6w   $��1��6�   ��5      �� 5       �� ImageSource$1 +/LearningBox;component/Images/ringtones.ico��6   5      �� 5   
   -   5        $ buttonJump100��5   X   $	��100��6   $��23��6   $
��Left=�6+   $��62,6,0,0q�6F   $	��Top=�6o   $��27��6�   $��1��6�   6�   o� 5   
   -   5         o�Name$ menuRead��5   G   $��25��6   $
��Left=�6   $��2,4,0,0q�66   $	��Top=�6Y   $��25��6q   $��1��6|   $��RightToLeft=�6�   .@�5      m� $��_M��6   $��7,2,8,3q�6#    m� Icon 5      �� 5      $,��&/LearningBox;component/Images/link.ico��6   $
��None=�6L   .@�5      m� -	   5        $��جعبه ها��5      6,   m� 5       -
   5         m�Name$ menuItemOnTop��5       $��On Top��62   	 m� IsCheckable	 . 
 m� 	IsChecked
 . 6�   5!      m� 5"      $��Words��6   m� 5#      5$      �� 5%   
   -   5         ��Name$ textBoxQuestion��5%      $��25��6+   $��94,6,5,0q�67   $��1��6I    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   $��LeftToRight=�6�    �� 
IsReadOnly . $��18.667(�6�   $
��Bold"�6�   ���	#FFABADB3���	#FF5A5C636�   �� 5&   
   -   5        $ textBoxAnswer��5&      $��67��6)   $��5,36,5,0q�65   $��1��6G   $ WrapWithOverflow=�6T   $	��Top=�6t    �� AcceptsReturn .  . $��RightToLeft=�6�   $��18.667(�6�   ���	#FFB4A7A76�   �� 5'   
   -   5        $ textBoxDictionary��5'      $��57��6-   $��	5,136,5,0q�69   $��1��6L   $ WrapWithOverflow=�6Y   $��RightToLeft=�6y    .  . $	��Top=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $��Stretch=�6  ���	#FFB4A7A76?  5(      5)      