   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Projekat.OtherWindowsProjekat.OtherWindows  5      9!clr-namespace:Projekat.ValidationProjekat.Validation  5	      =#clr-namespace:Projekat.HelpProviderProjekat.HelpProvider  5
      *    $Projekat.OtherWindows.DodajTipWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      5local#clr-namespace:Projekat.OtherWindows     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      +val!clr-namespace:Projekat.Validation  5	      .help#clr-namespace:Projekat.HelpProvider  5
        � Title$  	Dodaj tip��5      $
��Auto��5      $	��450��5      $	��246��5      $	��450��5      $	��450��5       � SizeToContent$ WidthAndHeight=�5          Projekat.HelpProvider.Help   Filename$ Help/DodajTip.chm��5       � 	Resources 5         
dugmeBrush �� Color  	dugmeStil �� 
TargetType # MaterialDesignRaisedLightButton �� BasedOn �� Triggers �� Binding	 �� ElementName
 �� UpdateSourceTrigger �� Value �� Property �� Value ^� 
Conditions �� Binding �� Path �� Value��%J  &	        &	 #     7  7   �� 5   
   $ 	#FFB0BEC5��6-   �� 5   
   " ��6"   8    5      �� 5       6   �� *Text.Length+$	 	oznakaBox��$
 PropertyChanged=� 06z   .a�5      ��  � {� .  62   5      �� 5       6   �� *Text.Length+$	 imeBox��$
 PropertyChanged=� 06w   .a�5      ��  � {� .  62   5      �� 5       6   �� *Text.Length+$	 opisBox��$
 PropertyChanged=� 06x   .a�5      ��  � {� .  62   5       �� 5!      8   6   �� *
Background+$	 ikonicaDugme��$
 PropertyChanged=�.a�5"      ��  � {� .  62   5#      ^� 5$       5%      �� 5&       6$   �� $ (Validation.HasError)�$	 	oznakaBox��$
 PropertyChanged=� True6�   .0�5(      ��  � {� .  62   5)      5+      5,      .��5-      � $
��Auto��5.   	    � RowDefinitions 5/   
   �� 50      $
��Auto �51      �� 52      $
��Auto �53      �� 54      $
��Auto �55      �� 56      $
��Auto �57      �� 58      $
��Auto �59       5;   
     MaterialDesignCheckBox  MaterialDesignComboBox)  #MaterialDesignThemes.Wpf.HintAssist  MaterialDesignTextBox��%�  '��       7  '�� Z     7  '�� �     7  �� 5<      " ��5=      8   .�5?      ��  � ��$ 8,8,8,8q�5A      5B      �� 5C      " ��5D      8   .�5F      ��  �@ 
IsFloating . 5H      �� 5I       � ��$ 8,8,8,8q�5K      5L      �� 5M      " ��5N      8   .�5P      ��  �@ 
IsFloating . 5R      �� 5S       � ��$ 8,8,8,8q�5U      5V      5W      .+�5X   
   �� -   5         ��Name$ 	oznakaBox��5X       �� 	MaxLength$ 10��5Y      $	��120��5Z      $
��Left=�5[      $��0��5\         Hint$ Oznaka��5]       � ToolTip$/ )Jedinstvena ljudski čitljiva oznaka tipa��5^      $��2��5_         Keyword$ oznaka��5`      .��6(   .��5a      �� $ Oznaka�5b      $
 PropertyChanged=�5c       �� ValidationRules 5d      0  *Projekat.Validation.NotEmptyValidationRule  5e      ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated . 5f      2  ,Projekat.Validation.OznakaTipaValidationRule  5g       . 5h      5j      5k      �� 5l   
   -   5        $ imeBox��5l      $��1��5m      $	 Ime��5n      $ Ime tipa��5o      $��2��5p      $	 ime��5q      .��6%   .��5r      �� $	 Ime�5s      $
 PropertyChanged=�5t       5u        5v       . 5w      5y      5z      �� 5{   
   -   5        $ opisBox��5{      $��2��5|      $
 Opis��5}       �� TextWrapping$
 Wrap=�5~      $ 	Opis tipa��5      $��2��5�      $
 opis��5�      .��6&   .��5�      �� $
 PropertyChanged=�5�      $
 Opis�5�       5�        5�       . 5�      5�      5�      �� 5�   
   $��3��5�       �� Orientation$ 
Horizontal=�5�      $
��Left=�5�      .+�5�      �� $��8 20 8 8q�5�      $��Center=�5�      	Ikonica5�      �� 5�      -   5         ��Name$ ikonicaDugme��5�       / +MaterialDesignFloatingActionMiniLightButton#��[ 5�      $! Biranje slike tipa sa diska��5�      $��8 20 8 8q�5�      #��[  5�      5�      5�      �� 5�   
   $��4��5�      $ 
Horizontal=�5�      $��Right=�5�      .+�5�      �� -   5        #��[ 5�      $	��100��5�      $. (Kreiranje tipa na osnovu unetih podataka��5�      $��8 8 8 8q�5�      .��64   _DODAJ5�      5�      '  !MaterialDesignThemes.Wpf.Snackbar  5�   
   -   5        $
��snek��5�      $��4��5�      $��2��5�         MessageQueue 5�      �� *MyCustomMessageQueue+5�      5�      