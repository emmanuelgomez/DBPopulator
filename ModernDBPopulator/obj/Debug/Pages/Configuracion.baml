   M S B A M L   `   `   `  ����L  HModernDBPopulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ModernDBPopulatorModernDBPopulator  5      A%clr-namespace:ModernDBPopulator.PagesModernDBPopulator.Pages  5      +    %ModernDBPopulator.Pages.Configuracion   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      /	ModernAElclr-namespace:ModernDBPopulator  5      1pages%clr-namespace:ModernDBPopulator.Pages  5      .��5      �    ContentRoot#��[  6   .+�5   
   �� .��5      �� $	��200��6   .+�5      �� -   5          ��Name$
  Form��5       �� Orientation$ Vertical=�6+    � DataContext 5      *  $ModernDBPopulator.ConfiguracionModel  5      -   5        	ModelConf��5   7    � 	Resources 5       �� 
TargetType �� Property �� Value �� BasedOn��%�  '��       '�� �     7��'�� �     7��'	� I    7	��� 5      " ��6    .�5      ��  �@��Orientation$ 
Horizontal=�6<   �� 5       � ��$ 0,0,0,4q�67   5      �� 5      " ��6    8   .�5      ��  � ��$	 100��66   �� 5       � ��$ Center=�6B   5      �� 5      " ��6    8   .�5      ��  � ��$	 0,3q�68   5       �� 5!      " 	�6    8   .�5"      ��  � ��$	 0,3q�68   5#      5$      .+�5&      �� .+�5'      �� $
��Host��6    �� 5(      -   5         ��Name$ TextHost��5(   "   $	��150��64   ��6@   �� *Host+	 �� Mode$	 TwoWay=�
 �� ValidatesOnDataErrors
 . 5)      �� 5*      .+�5+      �� $
��Port��6    �� 5,      -   5        $ TextPort��5,   "   $	��150��64   ��6@   �� *Port+$	 TwoWay=�
 . 5-      �� 5.      .+�5/      �� $
��User��6    �� 50      -   5        $ TextUser��50   "   $	��150��64   ��6@   �� *User+$	 TwoWay=�
 . 51      �� 52      .+�53      �� $��Password��6    �� 54      -   5        $ TextPassword��54   "   $	��150��68   ��6D   �� *
Password+$	 TwoWay=�
 . 55      �� 56      .+�57      �� $��Database��6    �� 58      -   5        $ TextDatabase��58   "   $	��150��68   ��6D   �� *
Database+$	 TwoWay=�
 . 59      �� 5:      .+�5;      �� $��Entidad��6    �� 5<      -   5        $ TextEntidad��5<   "   $	��150��67   ��6C   �� *	Entidad+$	 TwoWay=�
 . 5=      �� 5>      .+�5?      �� $	��Url��6    �� 5@      -	   5        $	 Url��5@   "   $	��150��6/   ��6;   �� *Url+$	 TwoWay=�
 . 5A      �� 5D      -
   5        $��	Continuar��5D      $��
100,16,0,0q�61   $
��Left=�6E   $#��mui:LinkCommands.NavigateLink��6u   $ ��/Pages/InsertarGrupos.xaml��5E      5F      5G      5H      5I      5J      