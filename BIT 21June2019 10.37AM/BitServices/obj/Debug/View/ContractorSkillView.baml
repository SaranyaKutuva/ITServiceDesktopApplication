   M S B A M L   `   `   `  ����F  BBitServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BitServices.ViewBitServices.View  5   	   *    $BitServices.View.ContractorSkillView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BitServices.View     5   	     � Title$  ContractorSkillView��5   	   $	��480��6%   $	��707��62    � WindowStartupLocation$ CenterScreen=�6>   .��5	      � 
�������$
��Left=�6   $	��700��69   $	��445��6E   $	��Top=�6R    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ 	lstSkills��5      $
��Left=�6v   $	��304��6�    �� SelectedIndex$ 0��6�    �� SelectedValuePath$ Skill_Id��6�    �� DisplayMemberPath$ 
Skill_Type��6�   $��
30,122,0,0q�6�   $	��Top=�6  $	��250��6   �� SelectedValue 6%   �� *SelectedSkillType+��6Q   �� *SkillColRows+5      �� 5   
   -   5        $ lstcContractorSkill��5      $ 0��6�   $ Skill_Id��6�   $ 
Skill_Type��6�   $
��Left=�6�   $	��301��6�   $��393,122,0,0q�6  $	��Top=�6   $	��262��68   6/   �� *SelectedContractorSkillType+��6e   �� *ContractorSkillColRows+6D  �� 5   
   -   5         ��Name$ btnAdd��5      $��Add>>��69   $
��Left=�6O   $��294,214,0,0q�6j   $	��Top=�6   $��89��6�   $��30��6�   $��
Sitka Text)�6�   $��14(�6�   ���	#FF36486B
�������{�.  ��6!   �� *Add+6  �� 5   
   -   5        $ 	btnRemove��5      $��	<< Remove��6?   $
��Left=�6Y   $��294,256,0,0q�6t   $	��Top=�6�   $��88��6�   $��30��6�   $��
Sitka Text)�6�   $��14(�6�   ���	#FF36486B
�������{�.  ��6$   �� *Delete+6   �� 5   
   $
��Left=�6   $��66��6+   $��4,15,0,0q�67   $	��Top=�6I   $	��680��6a   $5��//BitServices;component/BitLogo_YellowBlue_1.png��6m   $
��Fill=�6�   �� 5   
   $��Available Skill��6   $
��Left=�6*   $��	36,92,0,0q�6E   $	��Top=�6X   $	��186��6p   $��Sitka Small)�6|   �� 5   
   $��Contractor Skill��6   $
��Left=�6+   $��
396,92,0,0q�6F   $	��Top=�6Z   $	��186��6r   $��Sitka Small)�6~   5      5      