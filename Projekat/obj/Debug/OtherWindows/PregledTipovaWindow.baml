   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Projekat.OtherWindowsProjekat.OtherWindows  5      9!clr-namespace:Projekat.ValidationProjekat.Validation  5      =#clr-namespace:Projekat.HelpProviderProjekat.HelpProvider  5
      /    )Projekat.OtherWindows.PregledTipovaWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      5local#clr-namespace:Projekat.OtherWindows     5      1val!clr-namespace:Projekat.Validation     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      .help#clr-namespace:Projekat.HelpProvider  5
      -   5          � Title$  Pregled tipova��5      $
��Auto��5      $	��450��5      $	��246��5      $	��450��5      $	��450��5       � SizeToContent$ WidthAndHeight=�5          Projekat.HelpProvider.Help   Filename$ Help/PregledTipova.chm��5       � 	Resources 5       �� 
TargetType   	EmptyText �� Property �� Value �� Triggers �� Binding	 �� Path
 �� Value#  MaterialDesignThemes.Wpf.Chip �� 	Resources3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   ShadowDepth  selectedChipStyle  
dugmeBrush �� Color  dugmeObrisiStil $  MaterialDesignRaisedAccentButton �� BasedOn �� ElementName �� UpdateSourceTrigger  	dugmeStil # MaterialDesignRaisedLightButton ^� 
Conditions �� Binding �� Value  ikonicaDugmeStil / +MaterialDesignFloatingActionMiniLightButton��%�
  &	        '  �    &	 �    &	 x    &	 �    7  7  &	     7  7  &	 �	    7  �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�5      �� 5       � ��$ 8 8 8 8q�5      �� 5       � ��$
 Wrap=�5      �� 5       � ��$ Center=�5      �� 5        � ��$ Center=�5!      �� 5"       � y�$ Hidden=�5#       5$      �� 5%       6   �� $	 Count�
 05&      .a�5'      ��  � y�$ Visible=�5(      5)      5+      �� 5,   
   "  6    5-      ���� 5.      '��       " ��6   .�5/      ��  �@J�Effect 50        51      $ Black��6/   $ 8Q�52   /   $ 7Q�53   /   55      56      57      58      �� 59   
   "  5:       5;      ���� 5<      '��       " ��6   .�5=      ��  �@J�Effect 5>        5?      $ #fc655a��6/   $ 8Q�5@   /   $ 1Q�5A   /   5C      5D      5E      5F      �� 5G   
   $ 	#FFB0BEC5��5H      �� 5I   
   " ��5J      8    5L      �� 5M       6   �� *Text.Length+$ 	oznakaBox��$ PropertyChanged=�
 05N      .a�5O      ��  � {� .  5P      5Q      �� 5R       6   �� *Text.Length+$ imeBox��$ PropertyChanged=�
 05S      .a�5T      ��  � {� .  5U      5V      �� 5W       6   �� *Text.Length+$ opisBox��$ PropertyChanged=�
 05X      .a�5Y      ��  � {� .  5Z      5[      �� 5\      8
   6   �� *
Background+$ ikonicaDugme��$ PropertyChanged=�.a�5^      ��  � {� .  5_      5`      5b      �� 5c   
   " ��5d      8    5f      �� 5g       6   �� *Text.Length+$ 	oznakaBox��$ PropertyChanged=�
 05h      .a�5i      ��  � {� .  5j      5k      �� 5l       6   �� *Text.Length+$ imeBox��$ PropertyChanged=�
 05m      .a�5n      ��  � {� .  5o      5p      �� 5q       6   �� *Text.Length+$ opisBox��$ PropertyChanged=�
 05r      .a�5s      ��  � {� .  5t      5u      �� 5v      8
   6   �� *
Background+$ ikonicaDugme��$ PropertyChanged=�.a�5x      ��  � {� .  5y      5z      �� 5{       6   �� $	 .�$ PropertyChanged=�
 5|      Z� .a�5}      ��  � {� .  5~      5      ^� 5�       5�      �� 5�       6$   �� $	 (Validation.HasError)�$ 	oznakaBox��$ PropertyChanged=� True5�   $   .0�5�      ��  � {� .  5�      5�      5�      �� 5�   
   " ��5�      8    5�      �� 5�       6   �� $	 IzabraniTip�$ PropertyChanged=�
 5�      Z� .a�5�      ��  � {� .  5�      5�      5�      5�      .��5�      �  � ColumnDefinitions 5�   
   �� 5�      $��0.35* �6   �� 5�      $��0.65* �6   .+�5�   
   � $��0��6   .+�5�      �� #��[  6   $U��OTrenutno nije nijedan tip dodat.
Dodajte novi tip koristeći dugme "Dodaj tip".��5�       � DataContext 5�      ��  �� Current �� Source# Z $'	 !MainWindow.GlavniKontejner.Tipovi�5�      �� 5�      $��Disabled=�6   $
��Auto=�5�      .��5�      �� ��6   �� # Z $'	 !MainWindow.GlavniKontejner.Tipovi���5�      �� 5�      .R�5�      � 5�      ��5�      �� 5�      .R�5�        -   5        $��3,3,3,3q�5�   2   ��5�   2   �� *Oznaka+ � ToolTip 5�   "   �� 5�   &   �� 5�   .   $�Ime: ��62    �� 5�   .   �62   �� *Ime+�� 5�   .   �� 5�   .   $�Opis: ��62    �� 5�   .   �62   �� *Opis+5�   '      Icon 5�   "   �� 5�   &   ��6,   �� *	Ikonica+5�      5�      5�      5�      5�      � 5�   
   $��1��6   $
��Auto��5�       � RowDefinitions 5�      �� 5�      $
��Auto �6    �� 5�      $
��Auto �6    �� 5�      $
��Auto �6    �� 5�      $
��Auto �6    �� 5�      $
��Auto �6     5�       	 MaterialDesignCheckBox 
 MaterialDesignComboBox)  #MaterialDesignThemes.Wpf.HintAssist  MaterialDesignTextBox��%8  '��       7 	 '�� V     7 
 '�� �     7  �� 5�      " ��6   8   .�5�      ��  � ��$ 8,8,8,8q�5�      5�      �� 5�      " ��6   8   .�5�      ��  �@ 
IsFloating . 5�      �� 5�       � ��$ 8,8,8,8q�5�      5�      �� 5�      " ��6   8    5�      �� 5�       6&   �� $	 IzabraniTip�$ PropertyChanged=�
 5�   &   Z� .a�5�      ��  �@��
IsReadOnly . 5�   %   5�      �5�      �� 5�       �@ 
IsFloating . 5�   !   �� 5�       � ��$ 8,8,8,8q�5�   !   5�      5�      .+�5�      �� -   5         ��Name$ 	oznakaBox��5�       �� 	MaxLength$ 10��5�      $	��120��5�      $
��Left=�5�      $��0��5�         Hint$ Oznaka��5�      $9 3Jedinstvena ljudski čitljiva oznaka izabranog tipa��5�          Keyword$  oznaka��5�      $��2��5�      .��6*   .��5�      �� $ PropertyChanged=�6   $	 Oznaka�5�      ! �� ValidationRules! 5�      2  ,Projekat.Validation.OznakaTipaValidationRule  5�      ,  &System.Windows.Controls.ValidationRule"   ValidatesOnTargetUpdated" . 67   5�      5�      �� 5�      -   5        $ imeBox��5�      $��1��5�      $	 Ime��5�      $ Ime izabranog tipa��5�      $��2��5�      $	  ime��6*   �� 5�      -   5        $ opisBox��5�      $��2��5�      $
 Opis��5�      # �� TextWrapping$
# Wrap=�5�      $
  opis��5      $ Opis izabranog tipa��5     $��2��5     �� 5     $��3��6   $ �� Orientation$$ 
Horizontal=�5     $
��Left=�5     .+�5     �� $��8 20 8 8q�6   $��Center=�5     	Ikonica5	     �� 5
     -   5        % ��Name$% ikonicaDugme��5
     #��[ 5     $* $Izmena slike izabranog tipa sa diska��5     $��8 20 8 8q�5     #��[ 5     5     5     �� 5     $��4��6   $$ Vertical=�5     $��Right=�5     .+�5     �� -   5        #��[ 5     $$ Čuva izmene na izabranom tipu��5     $	��100��5     $��8 8 8 8q�5     .��5  )   	_SAČUVAJ5     �� 5     -   5        #��[ 5     $	��100��5     $��8 8 8 8q�5     $ Briše izabrani tip��5     .��5   (   
_OBRIŠI5"     5#     5%     '  !MaterialDesignThemes.Wpf.Snackbar  5&  
   $��0��6"   $��2��5'  "   &   MessageQueue& 5(  "   �� *MyCustomMessageQueue+5)     5*     