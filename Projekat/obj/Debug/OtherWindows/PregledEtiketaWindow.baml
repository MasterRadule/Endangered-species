   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Projekat.OtherWindowsProjekat.OtherWindows  5      X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5      9!clr-namespace:Projekat.ValidationProjekat.Validation  5
      =#clr-namespace:Projekat.HelpProviderProjekat.HelpProvider  5      0    *Projekat.OtherWindows.PregledEtiketaWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      5local#clr-namespace:Projekat.OtherWindows     5      NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      +val!clr-namespace:Projekat.Validation  5
      .help#clr-namespace:Projekat.HelpProvider  5      -   5          � Title$  Pregled etiketa��5      $
��Auto��5      $	��450��5      $	��222��5      $	��450��5      $	��450��5       � SizeToContent$ WidthAndHeight=�5          Projekat.HelpProvider.Help   Filename$ Help/PregledEtiketa.chm��5       � 	Resources 5       �� 
TargetType   	EmptyText �� Property �� Value �� Triggers �� Binding	 �� Path
 �� Value#  MaterialDesignThemes.Wpf.Chip �� 	Resources3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   ShadowDepth  selectedChipStyle  
dugmeBrush �� Color  dugmeObrisiStil $  MaterialDesignRaisedAccentButton �� BasedOn �� ElementName �� UpdateSourceTrigger  	dugmeStil # MaterialDesignRaisedLightButton ^� 
Conditions �� Binding �� Value  odabirBojeStil#  Xceed.Wpf.Toolkit.ColorPicker��%^	  &	        '  �    &	 �    &	 x    &	 �    7  &	 �    7  &	 T    �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�5      �� 5       � ��$ 8 8 8 8q�5      �� 5       � ��$
 Wrap=�5      �� 5       � ��$ Center=�5       �� 5!       � ��$ Center=�5"      �� 5#       � y�$ Hidden=�5$       5%      �� 5&       6   �� $	 Count�
 05'      .a�5(      ��  � y�$ Visible=�5)      5*      5,      �� 5-   
   "  6    5.      ���� 5/      '��       " ��6   .�50      ��  �@J�Effect 51        52      $ Black��6/   $ 8Q�53   /   $ 7Q�54   /   56      57      58      59      �� 5:   
   "  5;       5<      ���� 5=      '��       " ��6   .�5>      ��  �@J�Effect 5?        5@      $ #fc655a��6/   $ 8Q�5A   /   $ 1Q�5B   /   5D      5E      5F      5G      �� 5H   
   $ 	#FFB0BEC5��5I      �� 5J   
   " ��5K      8    5M      �� 5N       6   �� *Text.Length+$ 	oznakaBox��$ PropertyChanged=�
 05O      .a�5P      ��  � {� .  5Q      5R      �� 5S       6   �� *Text.Length+$ opisBox��$ PropertyChanged=�
 05T      .a�5U      ��  � {� .  5V      5W      �� 5X       6   �� *SelectedColorText.Length+$ 
odabirBoje��$ PropertyChanged=�
 05Y      .a�5Z      ��  � {� .  5[      5\      5^      �� 5_   
   " ��5`      8    5b      �� 5c       6   �� *Text.Length+$ 	oznakaBox��$ PropertyChanged=�
 05d      .a�5e      ��  � {� .  5f      5g      �� 5h       6   �� *Text.Length+$ opisBox��$ PropertyChanged=�
 05i      .a�5j      ��  � {� .  5k      5l      �� 5m       6   �� *SelectedColorText.Length+$ 
odabirBoje��$ PropertyChanged=�
 05n      .a�5o      ��  � {� .  5p      5q      ^� 5r       5s      �� 5t       6$   �� $	 (Validation.HasError)�$ 	oznakaBox��$ PropertyChanged=� True5u   $   .0�5w      ��  � {� .  5x      5y      5{      �� 5|   
   "  5}       5~      �� 5       6   �� *IzabranaEtiketa+$ PropertyChanged=�
 5�      Z� .a�5�      ��  � {� .  5�      5�      5�      5�      .��5�      �  � ColumnDefinitions 5�   
   �� 5�      $��0.35* �6   �� 5�      $��0.65* �6   .+�5�   
   � $��0��6   .+�5�      �� #��[  6   $b��\Trenutno nije nijedna etiketa dodata.
Dodajte novu etiketu koristeći dugme "Dodaj etiketu".��5�       � DataContext 5�      ��  �� Current �� Source# Z $(	 "MainWindow.GlavniKontejner.Etikete�5�      �� 5�      $��Disabled=�6   $
��Auto=�5�      .��5�      �� ��6   �� # Z $(	 "MainWindow.GlavniKontejner.Etikete���5�      �� 5�      .R�5�      � 5�      ��5�      �� 5�      .R�5�        -   5        $��3,3,3,3q�5�   2   ��5�   2   �� *Oznaka+   IconBackground 5�   2   �� *Boja+ � ToolTip 5�   "   �� 5�   &   �� 5�   .   $�Opis: ��62    �� 5�   .   �62   �� *Opis+5�   '      Icon 5�   "   �� 5�   &   ��6,   �� *	Ikonica+5�      5�      5�      5�      5�      � 5�   
   $��1��6   $
��Auto��5�       � RowDefinitions 5�      �� 5�      $
��Auto �6    �� 5�      $
��Auto �6    �� 5�      $
��Auto �6    �� 5�      $
��Auto �6     5�        MaterialDesignCheckBox 	 MaterialDesignComboBox)  #MaterialDesignThemes.Wpf.HintAssist 
 MaterialDesignTextBox��%:  '��       7  '�� V     7 	 '�� �     7 
 �� 5�      " ��6   8   .�5�      ��  � ��$ 8,8,8,8q�5�      5�      �� 5�      " ��6   8   .�5�      ��  �@ 
IsFloating . 5�      �� 5�       � ��$ 8,8,8,8q�5�      5�      �� 5�      " ��6   8    5�      �� 5�       6&   �� *IzabranaEtiketa+$ PropertyChanged=�
 5�   &   Z� .a�5�      ��  �@��
IsReadOnly . 5�   %   5�      �5�      �� 5�       �@ 
IsFloating . 5�   !   �� 5�       � ��$ 8,8,8,8q�5�   !   5�      5�      .+�5�      �� -   5         ��Name$ 	oznakaBox��5�      $) #Jedinstvena oznaka izabrane etikete��5�       �� 	MaxLength$ 20��5�      $	��240��5�      $
��Left=�5�      $��0��5�          Hint$  Oznaka��5�      $��2��5�      !   Keyword$! oznaka��5�      .��6"   .��5�      �� $ PropertyChanged=�6   $	 OznakaEtikete�5�      " �� ValidationRules" 5�      5  /Projekat.Validation.OznakaEtiketeValidationRule  5�      ,  &System.Windows.Controls.ValidationRule#   ValidatesOnTargetUpdated# . 6:   5�      5�      �� 5�      -   5        $ opisBox��5�      $��1��5�      $
  Opis��5�      $ �� TextWrapping$
$ Wrap=�5�      $
! opis��5�      $ Opis izabrane etikete��5�      $��2��5�      �� 5�      $��2��6   % �� Orientation$% 
Horizontal=�5�      $
��Left=�5�      .+�5�      �� $��8 8 8 8q�6   $��Center=�5�      Boja5�        5�      -   5        &  Name$& 
odabirBoje��5�   &   $. (Boja kojom je označena izabrana etiketa��5�   &   $��8 8 8 8q�5�   &   $��Center=�5�   &   #��[ 5�   &   5�      5�      �� 5�      $��3��6   $% Vertical=�5�      $��Right=�5      .+�5     �� -   5        #��[ 5     $' !Čuva izmene na izabranoj etiketi��5     $	��100��5     $��8 8 8 8q�5     .��5  )   	_SAČUVAJ5     �� 5     -   5        #��[ 5     $ Briše izabranu etiketu��5	     $	��100��5
     $��8 8 8 8q�5     .��5  (   
_OBRIŠI5     5     5     '  !MaterialDesignThemes.Wpf.Snackbar  5  
   $��0��6"   $��2��5  "   '   MessageQueue' 5  "   �� *MyCustomMessageQueue+5     5     