   M S B A M L   `   `   `  ����A  =Wpf_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Wpf_UI.ViewWpf_UI.View  5   	   !    Wpf_UI.View.EditeNoteWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Wpf_UI.View     5   	   -   5          �Name$  EditeWindows��5   	    � Title$ EditeNoteWindow��5	   	   $	��350��6!   $	��200��6.    � WindowStartupLocation$ CenterScreen=�6:    � WindowStyle$ 
ToolWindow=�6_   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��26��6   $��Edite select Note��6    $��0��69   $��Center=�6G   6f   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��26��6   $	��Id:��6$   $��1��6/   $��70,0,5,0q�6<   6P   �� 5      $��26��6   $��1��68   $��5,0,10,0q�6E   ��6$   �� *Id+6Z   5      �� 5   
   $��26��6   $
��Name��6    $��2��6,   $��Center=�69   6X   �� 5   
   $��3��6   $��	10,0,10,0q�65   ��6   �� *Name+.��6H    � 	Resources 5       �� 
TargetType �� Property	 �� Value��%^   '��       �� 5      " ��6   .�5       ��  �@��CornerRadius$	 3��65   5!      5"      .��6!   5#      �� 5$   
   $��26��6   $��Value��6    $��4��6-   $��Center=�6:   6Y   �� 5%   
   $��5��6   $��	10,0,10,0q�66   ��6   �� *Value+.��6I    5&      ��%^   '��       �� 5'      " ��6   .�5(      ��  �@��CornerRadius$	 3��65   5)      5*      .��6!   5+      �� 5,   
   $��26��6   $��Prioriry��6    $��6��60   $��Center=�6=   6\   �� 5-   
   $��7��6   $��	10,0,10,0q�69   ��6   �� *
Priority+.��6L    5.      ��%^   '��       �� 5/      " ��6   .�50      ��  �@��CornerRadius$	 3��65   51      52      .��6!   53      �� 54   
   $��9��6   $��Edite��6   $��
10,0,10,10q�6/   ���	#FF26FF6F��55      �� *EditeCommand+��63   �� 
 �� ElementName$
 EditeWindows�� 56      ��%^   '��       �� 57      " ��6   .�58      ��  �@��CornerRadius$	 5��65   59      5:      5;      5=      5>      