   M S B A M L   `   `   `  ����F  BBitServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BitServices.ViewBitServices.View  5   	   $    BitServices.View.ClientAddress   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BitServices.View     5   	     � Title$  ClientAddress��5   	   $	��544��6   $	��800��6,    � WindowStyle$ ThreeDBorderWindow=�68    � 
ResizeMode$ NoResize=�6Y   .��5	      � 
�������$��-1,-1,1.667,1q�6   .+�5
   
   &   System.Windows.Controls.DataGrid     
IsReadOnly .  �� SelectedIndex$ 0��6%   $ �� IsSynchronizedWithCurrentItem$
 TrueY�67      AutoGenerateColumns .  $
��Left=�6x   $	��375��6�   $��
26,108,0,0q�6�   $	��Top=�6�   $	��338��6�    �� SelectedItem 6�   �� *SelectedClientAdd+��6  �� *ClientAddCollection+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	Client ID��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 68   �� *
ClientID+ �� UpdateSourceTrigger$ PropertyChanged=�  5      $	 Location Name��6%   
 6<   �� *LocationName+$ PropertyChanged=�  5      $	 Street��6%   
 65   �� *Street+$ PropertyChanged=�  5      $	 Suburb��6%   
 65   �� *Suburb+$ PropertyChanged=�  5      $	 State��6%   
 64   �� *State+$ PropertyChanged=�  5      $	 Postcode��6%   
 67   �� *
PostCode+$ PropertyChanged=�5      �� 5   
   $��GroupBox��6   $
��Left=�6%   $	��210��6@   $��380,103,0,0q�6M   $	��Top=�6b   $	��382��6z   .��5      �� $
��Left=�6�   $��25��6�   $��	85,35,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��285��6�    � DataContext 6   �� *SelectedClientAdd+��6A   �� *LocationName+$ PropertyChanged=�6�   5      �� 5   
   $
��Left=�6~   $��25��6�   $��471,126,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��285��6�   {�.   6   �� *SelectedClientAdd+��6=   �� *
ClientID+$ PropertyChanged=�6�   �� 5   
   $
��Left=�6y   $��25��6�   $��471,184,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��285��6�    6   �� *SelectedClientAdd+��6<   �� *Street+$ PropertyChanged=�6�   �� 5   
   $
��Left=�6y   $��25��6�   $��471,215,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��285��6�    6   �� *SelectedClientAdd+��6<   �� *Suburb+$ PropertyChanged=�6�   �� 5   
   $
��Left=�6x   $��25��6�   $��471,245,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��285��6�    6   �� *SelectedClientAdd+��6<   �� *State+$ PropertyChanged=�6�   �� 5   
   $
��Left=�6{   $��25��6�   $��471,275,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��285��6�    6   �� *SelectedClientAdd+��6<   �� *
PostCode+$ PropertyChanged=�6�   �� 5   
   $��*Street��6   $
��Left=�6"   $��425,183,0,0q�6=   $	��Top=�6R   $��46��6j   �� 5   
   $��*Suburb��6   $
��Left=�6"   $��420,214,0,0q�6=   $	��Top=�6R   $��53��6j   �� 5   
   $��*State��6   $
��Left=�6!   $��431,243,0,0q�6<   $	��Top=�6Q   �� 5    
   $��
*Post Code��6   $
��Left=�6%   $��404,272,0,0q�6@   $	��Top=�6U   �� 5!   
   $��	Client ID��6   $
��Left=�6$   $��416,124,0,0q�6?   $	��Top=�6T   $��57��6l   �� 5"   
   $��*Location Name��6   $
��Left=�6)   $��378,153,0,0q�6D   $	��Top=�6Y   $��96��6q   �� 5#   
   $	��Add��6   $
��Left=�69   $��405,342,0,0q�6T   $	��Top=�6i   $��75��6�   $��26��6�   $��
Sitka Text)�6�   $��14(�6�   ���	#FF36486B
���������6   �� *Add+6�   �� 5$   
   $
��Save��6   $
��Left=�6;   $��576,342,0,0q�6V   $	��Top=�6k   $��75��6�   $��26��6�   $��
Sitka Text)�6�   $��14(�6�   ���	#FF36486B
���������6    �� *Save+6�   �� 5%   
   $��Delete��6   $
��Left=�6?   $��491,343,0,0q�6Z   $	��Top=�6o   $��75��6�   $��26��6�   $��
Sitka Text)�6�   $��14(�6�   ���	#FF36486B
���������6"   �� *Delete+6�   �� 5&   
   $��Clear��6   $y�Hidden=�6!   $
��Left=�65   $��609,264,0,0q�6P   $	��Top=�6e   $��75��6}   $��27��6�   $��
Sitka Text)�6�   $��14(�6�   ���	#FF36486B
�������6�   �� 5'   
   $
��Left=�6   $��76��6+   $��3,7,0,0q�67   $	��Top=�6J   $	��786��6b   $5��//BitServices;component/BitLogo_YellowBlue_1.png��6n   $
��Fill=�6�   5)      5*      