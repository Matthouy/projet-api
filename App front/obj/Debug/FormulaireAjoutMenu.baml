   M S B A M L   `   `   `  ����D  @App front, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:App_front	App_front  5   	   #    App_front.FormulaireAjoutMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:App_front     5   	     � Title$   Formulaire d'ajout de menu��5   	   $	��300��6,   $	��400��69   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Burger :��6   $��Center=�6$   $��0��6?   $��	20,10,0,0q�6L   �� 5   
   -   5         ��Name$ ComboBoxBurger��5      $��1��6+   $��0��6;   $	��150��6H   $��25��6T   $��	10,10,0,5q�6`   $
��Left=�6s   �� 5   
   $��	Boisson :��6   $��Center=�6%   $��1��6@   $��	20,10,0,0q�6M   �� 5   
   -   5        $ ComboBoxBoisson��5      $��1��6,   $��1��6<   $	��150��6I   $��25��6U   $��	10,10,0,5q�6a   $
��Left=�6t   �� 5   
   $��	Dessert :��6   $��Center=�6%   $��2��6@   $��	20,10,0,0q�6M   �� 5    
   -   5        $ ComboBoxDessert��5       $��1��6,   $��2��6<   $	��150��6I   $��25��6U   $��	10,10,0,0q�6a   $
��Left=�6t   �� 5#   
   $��2��6   $��3��6)    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��0,20,0,0q�6l    � 	Resources 5%       �� 
TargetType �� Property �� Value��%X   '��       �� 5&      " ��6   .�5'      ��  � ��$ 10,0,0,0q�6/   5(      5)      .+�5,      �� -   5        $��Valider��5,      $��25��6=   5-      5.      5/      