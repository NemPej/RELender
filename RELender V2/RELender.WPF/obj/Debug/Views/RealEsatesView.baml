   M S B A M L   `   `   `  ����G  CRELender.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RELender.WPF.ViewsRELender.WPF.Views  5   	   '    !RELender.WPF.Views.RealEsatesView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:RELender.WPF.Views     5   	   -   5          � Title$  RealEsatesView��5   	   $	��450��6    $	��800��6-   .��5	      ]� .+�5
      �� $��Bottom=�6   .@�5      �� .��5      �� -   5        $��	statusBar��5      5      5      � 5       � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $��* �6   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ addBtn��5      $	��Add��6   $	��100��6-   $��10q�6:   6F   �� 5      -   5        $ editBtn��5      $
��Edit��6   {�.  $	��100��6@   $��10q�6M   6Y   �� 5      -   5        $ 	deleteBtn��5      $��Delete��6    {�.  $��10q�6C   $	��100��6O   6[   5      &   System.Windows.Controls.DataGrid  5      -   5        $��1��5      $��10q�6      AutoGenerateColumns .     
IsReadOnly . $��2q�5   E   
���������5   '   �� *RealEstates+ �� SelectedItem 6K   �� *SelectedItem+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6   
   Header$
 Id��6$   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5       $	 * 6   $
 Area[sq]��6$    67   �� *Area+  5!      $	 * 6   $
 number of beds��6$    6=   �� *NoBeds+  5"      $	 * 6   $
 
Owner name��6$    69   �� *
Owner.Name+  5#      $	 * 6   $
 Country��6$    66   �� *	Country+  5$      $	 * 6   $

 City��6$    63   �� *City+  5%      $	 * 6   $
 Address��6$    66   �� *	Address+5'      5(      5)      5*      