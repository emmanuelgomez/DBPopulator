   M S B A M L   `   `   `  ���� D  @ModernAEL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ModernAEL	ModernAEL  1clr-namespace:ModernAEL.PagesModernAEL.Pages  #    ModernAEL.Pages.Configuracion   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  '	ModernAElclr-namespace:ModernAEL  )pagesclr-namespace:ModernAEL.Pages  .���    ContentRoot#��[  .+��� .���� $	��200��.+��� -     ��Name$
  Form�� �� Orientation$ Vertical=� � DataContext "  ModernAEL.ConfiguracionModel  -   	ModelConf�� � 	Resources  �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� R     7��'�� �     7��'	� �     7	��� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 0,0,0,4q��� " ��8   .���  � ��$	 100����  � ��$ Center=��� " ��8   .���  � ��$	 0,3q��� " 	�8   .���  � ��$	 0,3q�.+��� .+��� $
��Host���� -    ��Name$ TextHost��$	��150������ *Host+	 �� Mode$	 TwoWay=�
 �� ValidatesOnDataErrors
 . �� .+��� $
��Port���� -   $ TextPort��$	��150������ *Port+$	 TwoWay=�
 . �� .+��� $
��User���� -   $ TextUser��$	��150������ *User+$	 TwoWay=�
 . �� .+��� $��Password���� -   $ TextPassword��$	��150������ *
Password+$	 TwoWay=�
 . �� .+��� $��Database���� -   $ TextDatabase��$	��150������ *
Database+$	 TwoWay=�
 . �� .+��� $��Entidad���� -   $ TextEntidad��$	��150������ *	Entidad+$	 TwoWay=�
 . �� .+��� $	��Url���� -	   $	 Url��$	��150������ *Url+$	 TwoWay=�
 . �� -
   $��	Continuar��$��
100,16,0,0q�$
��Left=�$#��mui:LinkCommands.NavigateLink��$ ��/Pages/InsertarGrupos.xaml��