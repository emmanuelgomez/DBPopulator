   M S B A M L   `   `   `  ����   	ModernAEL$    ModernAEL.Pages.InsertarGrupos   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  .���    ContentRoot#��[  .+��� .���� .+��� $	��Top=�$��Insertar Grupos��  Heading2#��[ $��0,0,0,8q���   ButtonBorder#���  $��1q�$
��Left=�$��0,0,0,16q�._��� $
��Auto=�$
��Auto=�.��&   System.Windows.Controls.DataGrid  -   $	��DG1��    AutoGenerateColumns  .  "   VerticalScrollBarVisibility$
 Auto=�$	��200������    Columns =  7FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ GrupoNombre��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *GrupoNombre+  $ GrupoCodigo�� �� *GrupoCodigo+  $ GrupoSuperiorCodigo�� �� *GrupoSuperiorCodigo+��  �� Orientation$ 
Horizontal=�$��0,0,0,16q�.+��� -   $��Insertar���� -   $��ButtonSalva��$��Salvar��{�.  �� -   $��textbox1��{�.  �� $��Eventos��$
��Bold"�$��0,0,0,4q��� -    ��Name$ 
TextEvents��$	��650��$	��165��$
��Left=� �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�$	 �� HorizontalScrollBarVisibility$
	 Auto=�