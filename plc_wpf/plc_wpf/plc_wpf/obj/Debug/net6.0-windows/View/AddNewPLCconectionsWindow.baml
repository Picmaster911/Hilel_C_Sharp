   M S B A M L   `   `   `  ����B  >plc_wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:plc_wpf.Viewplc_wpf.View  5   	   5clr-namespace:plc_wpf.ViewModelplc_wpf.ViewModel  5   	   ,    &plc_wpf.View.AddNewPLCconectionsWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:plc_wpf.View     5   	   .vmclr-namespace:plc_wpf.ViewModel     5   	   -   5        $��	AddNewPLC��5
   	     � Title$  AddNewPLCconectionsWindow��5	   	   $	��300��6+   $	��200��68    � WindowStyle$ 
ToolWindow=�6D    � DataContext 5      3  -plc_wpf.ViewModel.AddNewPLCconectionsWindowVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   $��Center=�5      $��Center=�5      $	��120��5      .+�5      �� $
��Name��6   �� 5      $��25��64   ��6   ��  �� Path$ PlcName�64   �� 5      $��IP��6   �� 5      $��25��66   ��6   �� $ 	IpAddress�66   �� 5      $
��Type��6   �� 5      $��25��6j   ��6   �� $ PlcType� �� SelectedItem 6<   �� $ PlcTypeSelected�6j   �� 5      $
��Slot��6   �� 5      $��25��61   ��6   �� $
 Rack�61   �� 5      $
��Rack��6   �� 5       $��25��61   ��6   �� $
 Slot�61   5!      �� 5"   
   $��1��6   $��Add PLC��6   ��60   �� *AddNewConectionWindowCommand+��5#      �� $" AddNewConectionWindowCommand�5$      5%      