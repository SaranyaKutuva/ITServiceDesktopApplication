   M S B A M L   `   `   `  ����F  BBitServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BitServices.ViewBitServices.View  5      )    #BitServices.View.MainWindowPageView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:BitServices.View     5        N� Title$  MainWindowPageView��5	       N� ShowsNavigationUI .   � Cursor$
 None��6<   $��Center=�6J   .��5      (� .��5   
   � 
���   �.+�5      �� $��SIGN UP��6   $	��246��6(   $��582,129,144.667,0q�65   $	��Top=�6P   $
��Bold"�6h   $��Century)�6z    � IsSharedSizeScope . ��. ���	#FF2331C1���	#FFF5E1E1$��16(�6   � BindingGroup 5      &   System.Windows.Data.BindingGroup  5      5      �� 5      $��	User Name��6   $��652,196,353.667,216q�6(   $��16(�6E   ���	#FFF0EDED6S   �� 5      $��Password��6   $
��Left=�6'   $��664,235,0,0q�6B   $	��Top=�6W   $��78��6o    J� RenderTransformOrigin$ 4.278,2.076&�6z   $��16(�6�   ���	#FFF3E4E46�   �� 5      $
��Left=�6V   $��23��6q   $��738,202,0,0q�6}    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�    � DataContext 6   �� *SelectedUser+��6;   �� *
UserName+6�   G� 5      -   5        $��Password��5       G� PasswordChar$ *��6O   $
��Left=�6b   $��23��6}   $��738,239,0,0q�6�   $	��Top=�6�   $	��120��6�    6*   �� *SelectedUser+6�   �� 5      -   5        	 ��Name$	 btnLogin��5   ;   $��Login��6N   $
��Left=�6^   $��698,299,0,0q�6y   $	��Top=�6�   $	��100��6�   $��33��6�   $��
Sitka Text)�6�   $��14(�6�   ���	#FF36486B
���������6   �� *LoginButtonClick+6  �� 5      $��165,119,557.667,71.333q�6   $&�� /BitServices;component/login.jpg��64   �� 5      $��0,0,-0.333,360.333q�6   $5��//BitServices;component/BitLogo_YellowBlue_1.png��60   $
��Fill=�6i    � 5!      -   5        
  �Name$

 Main��5!   *   $	��Top=�6   $��Right=�68   $��-2,-89,0.667,-25q�6T   $ Arrow��6�   $
��1096��6�   5"      5#      5$      