   M S B A M L   `   `   `  ����F  BBitServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BitServices.ViewBitServices.View  5      (    "BitServices.View.JobAssignPageView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:BitServices.View     5        N� Title$  JobAssignPageView��5      $	��470��6!   .��5	      (� .��5
   
   � 
�������$
��1126��6"   $	��439��6/   .+�5      �� $��Requested Jobs��6   $
��Left=�6/   $	��407��6J   $��11,9,0,0q�6W   $	��Top=�6i   $	��638��6�   $
��Bold"�6�   ���	#FFCFCF196�   �� 5      $��Available Contractors��6   $
��Left=�66   $	��405��6Q   $��	664,9,0,0q�6^   $	��Top=�6q   $	��355��6�   $
��Bold"�6�   ���	#FFCFCF195      �� 5      $��Assign��6   $
��Left=�6m   $	��Top=�6�   $��72��6�   $��1033,156,0,0q�6�   $��32��6�   $��
Sitka Text)�6�   $��14(�6�   ���	#FF36486B
���������6&   �� *Assign+{�6A   �� *IsContractorSelected+6
  &   System.Windows.Controls.DataGrid  5      -   5           
IsReadOnly .    AutoGenerateColumns .  $
��Left=�5   �   $	��365��6�   $��	24,36,0,0q�6�   $	��Top=�6�   $	��611��6  ��6F   �� *JobCollection+ �� SelectedItem 6l   �� *SelectedJob+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Job Request ID��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *JobRequestID+  5      $ Job Type ID��6)    6>   �� *	JobType+  5      $ Request Date��6)    6?   �� *RequestDate+	 �� StringFormat$	 	d/MM/yyyy��  5      $ Client Location��6)    6B   �� *LocationName+  5      $ Priority��6)    6;   �� *
Priority+  5      $ Status��6)    69   �� *Status+  5      $ Comments��6)    6;   �� *
Comments+5        5       . $
 �� IsSynchronizedWithCurrentItem$

 TrueY�6)    �� SelectedIndex$ 0��6O    .  $
��Left=�6  $	��364��6*  $��
680,36,0,0q�67  $	��Top=�6K  $	��323��6c  ��6a   �� *ContractorJobCollection+ 6�   �� *SelectedContractorJob+$ TwoWay=�$ PropertyChanged=� 5         5!      $ Contractor Id��6)    6@   �� *ContractorID+  5"      $ 
First Name��6)    6=   �� *	FirstName+  5#      $ 	Last Name��6)    6<   �� *
LastName+  5$      $ Status��6)    69   �� *ContractorJobStatus+5'      5)      5*      5+      