   M S B A M L   `   `   `  ����K  GApplicationManga, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ApplicationMangaApplicationManga  5   	   G(clr-namespace:ApplicationManga.ConverterApplicationManga.Converter  5	   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
   	       ApplicationManga.Video   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ApplicationManga     5   	   9conv(clr-namespace:ApplicationManga.Converter     5	   	   9System&clr-namespace:System;assembly=mscorlib     5
   	     � Title$  Window1��5   	   $
��1080��6   $
��1920��6'   
������� � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5       �� 
TargetType   defaultBorder �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6$   5      .��5      � ���#002D33 � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      .+�5   
   �� -   5         ��Name$ ButtonVideo��5      ���#002D33$��0��6U   .��5      r� -   5         r�Name$ VideoBA��5   M   	 r� Stretch$
	 Fill=�6�   $��Center=�6�   
 r� Source
 6   �� * MangaSelectionnee.BandeAnnonce+6�   5      �� 5   
   $	��5 0q�6   $��1��6   ._�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      �� 5       $	��10* �6#   .+�5"      �� $��Volume��6   $��40(�6*   $��Center=�68   $��Center=�6U   $��0��6p   �� 5$      -   5         ��Name$ VolumeSlide��5$   �   $��Center=�6    � Maximum$ 1Q�64    � Minimum$ 0Q�6@   $��1��6�    � Value 6L   ��  �� Path$ Volume� �� Mode$ TwoWay=� �� ElementName$ VideoBA��6�   �� 5&      -   5        $ TempsSlider��5&   j   $��Center=�6    �� TickFrequency$ 20Q�64   $��2��6   5'      5(      5)      5*      