   M S B A M L   `   `   `  ����  ModernDBPopulator,    &ModernDBPopulator.Pages.InsertarGrupos   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      .��5	      �    ContentRoot#��[  6   .+�5
   
   �� .��5   
   �� .+�5      �� $	��Top=�6   $��Insertar Grupos��6-     Heading2#��[ 6D   $��0,0,0,8q�6f   �� 5        ButtonBorder#���  6   $��1q�6F   $
��Left=�6Z   $��0,0,0,16q�6u   ._�5      �� $
��Auto=�6#   $
��Auto=�6J   .��5      &   System.Windows.Controls.DataGrid  -   5        $	��DG1��5          AutoGenerateColumns  .  "   VerticalScrollBarVisibility$
 Auto=�6^   $	��200��6�   ��6*   ��    Columns 5      =  7FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ GrupoNombre��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *GrupoNombre+  5      $ GrupoCodigo��6-    6B   �� *GrupoCodigo+  5      $ GrupoSuperiorCodigo��6-    6J   �� *GrupoSuperiorCodigo+5      6   5      �� 5       �� Orientation$ 
Horizontal=�6   $��0,0,0,16q�66   .+�5      �� -   5        $��Insertar��5      60   �� 5      -   5        $��ButtonSalva��5      $��Salvar��60   {�.  6S   �� 5      -   5        $��textbox1��5   0   {�.  6B   5      �� 5      $��Eventos��6   $
��Bold"�6+   $��0,0,0,4q�6=   �� 5      -   5         ��Name$ 
TextEvents��5      $	��650��6/   $	��165��6;   $
��Left=�6H    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�6u   $	 �� HorizontalScrollBarVisibility$
	 Auto=�6�   5      5       5%      5&      