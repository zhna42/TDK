   M S B A M L   `   `   `  ����J  FTrack Data Card, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Track_Data_CardTrack_Data_Card  5      b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 6A   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ComboBox.Static.Background  �� EndPoint �� 
StartPoint � Color � Offset  ComboBox.Static.Border �� Color ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph ! ComboBox.MouseOver.Background  ComboBox.MouseOver.Border *	 &ComboBox.MouseOver.Editable.Background &
 "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Background  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph   ComboBox.Disabled.Background  ComboBox.Disabled.Border ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBox.Static.Glyph  ComboBoxToggleButton �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 J� SnapsToDevicePixels F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� 
TargetName P� Property P� Value  ComboBoxTemplate �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode5   /Microsoft.Windows.Themes.SystemDropShadowChrome   Name    Color �� MaxDropDownHeight �� ElementName ��Name �� ClearTypeHint  ��Name! ��Name" ��Name-  'System.Windows.Input.KeyboardNavigation#   DirectionalNavigation$ d�Name% d� 	IsChecked& ��Name' �� SelectionBoxItemTemplate( �� SelectionBoxItem#) �� SelectionBoxItemStringFormat* �� ContentStringFormat+ J� IsHitTestVisible, P� 
SourceName- ]� 
Conditions. �� Property  TextBox.Static.Background  ComboBoxEditableTextBox   ComboBoxEditableTemplate/ ��Name0 �� 
IsReadOnly ! ComboBoxStyle " FocusVisual1 �� Triggers *# &ComboBoxItem.ItemsviewHover.Background &$ "ComboBoxItem.ItemsviewHover.Border -% )ComboBoxItem.ItemsviewSelected.Background )& %ComboBoxItem.ItemsviewSelected.Border 2' .ComboBoxItem.ItemsviewSelectedHover.Background .( *ComboBoxItem.ItemsviewSelectedHover.Border 4) 0ComboBoxItem.ItemsviewSelectedNoFocus.Background 0* ,ComboBoxItem.ItemsviewSelectedNoFocus.Border &+ "ComboBoxItem.ItemsviewFocus.Border /, +ComboBoxItem.ItemsviewHoverFocus.Background +- 'ComboBoxItem.ItemsviewHoverFocus.Border . ComboBoxItemStyle2 �� Padding / ItemsPanelTemplate13 K� IsItemsHost�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      'localclr-namespace:Track_Data_Card  5      VThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  6A   %z8  &	        &	 �     &	 �     &	 �     &	 �     &	 $    &	 I    &	 l    &	     &		 '    &	
 H    &	 k    &	     &	 &    &	 G    &	 �    &	     &	 #    &	 F    &	 �    &	     &	 $    &	 E    &	 h    &	 �    &	 �    &	 �    &	 �    &	     7   7  7  7  7  7  7  7  7  7  7 	 7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 <    7  &	 �    &	 �    &	      7  7  7  &	! �(    7 " 7   7  7  7   &	# %+    &	$ F+    &	% i+    &	& �+    &	' �+    &	( �+    &	) �+    &	* ,    &	+ 5,    &	, X,    &	- y,    &	. �,    7 " 7 # 7 $ 7 % 7 & 7 ' 7 ( 7 ) 7 * 7 + 7 , 7 - &	/ �5    �� 5      $	  0,1&�6=   $	 0,0&�6L   .��5   
   � $ #2c2c2c��6   $	 0.0Q�6'   � 5   
   $ #2c2c2c��6   $	 1.0Q�6'   5      �� 5	      $ 	#FFACACAC��65   �� 5
      $ #2c2c2c��6B   �� 5      $ 	#FFABADB3��6>   �� 5      $ Transparent��6I   �� 5      $ Transparent��6E   �� 5      $ 	#FF000000��67   �� 5      $	  0,1&�6@   $	 0,0&�6O   .��5   
   � $ #2c2c2c��6   $	 0.0Q�6'   � 5   
   $ #2c2c2c��6   $	 1.0Q�6'   5      �� 5      $ 	#FF7EB4EA��68   �� 5      $ #2c2c2c��6E   �� 5      $ 	#FF7EB4EA��6A   �� 5      $	  0,1&�6P   $	 0,0&�6_   .��5   
   � $ #2c2c2c��6   $	 0.0Q�6'   � 5   
   $ #2c2c2c��6   $	 1.0Q�6'   5      �� 5      $ 	#FF7EB4EA��6H   �� 5      $ #2c2c2c��65   �� 5      $	  0,1&�6>   $	 0,0&�6M   .��5   
   � $ #2c2c2c��6   $	 0.0Q�6'   � 5   
   $ #2c2c2c��6   $	 1.0Q�6'   5      �� 5       $ 	#FF569DE5��66   �� 5!      $ #2c2c2c��6C   �� 5"      $ 	#FF569DE5��6?   �� 5#      $	  0,1&�6N   $	 0,0&�6]   .��5$   
   � $ #2c2c2c��6   $	 0.0Q�6'   � 5%   
   $ #2c2c2c��6   $	 1.0Q�6'   5&      �� 5'      $ 	#FF569DE5��6F   �� 5(      $ 	#FFBFBFBF��66   �� 5)      $ #2c2c2c��6;   �� 5*      $ 	#FFD9D9D9��67   �� 5+      $ #2c2c2c��6D   �� 5,      $ 	#FFBFBFBF��6@   �� 5-      $ Transparent��6K   �� 5.      $ Transparent��6G   �� 5/      $ 	#FF606060��64   �� 50      " d�6)   .�51   
   ��  �@�OverridesDefaultStyle . 62   �� 52   
    � �� .  6&   �� 53   
    � |� .  6&   �� 54   
    �@��	ClickMode$ Press=�6&   �� 55   
    � �� 56      �� 57      " d�6"   .R�58      �� $	 templateRoot��6   
 . 8��  #��z��6�   8�� ._�59      �� $	 splitBorder��6!   #��� r�66   
 . $��0q�6�   $��Right=�6�   $��1q�6�   
������ ._�5:      F� $ arrow��6#   $��Center=�62   $��0q�6M   $��Center=�6X   8�� F����        ���( ��( јaQ     јaQ P����̰( � �    P����        6�   5;      5<       5=      ^� 5>       5?      �� 5@   "    6,   �� *
IsEditable+ �� " �� true6�   �� 5A   "    6,   �� *IsMouseOver+ �� *Self+	 false6r   �� 5B   "    6,   �� *	IsPressed+ �� *Self+	 false6p   �� 5C   "    6,   �� *	IsEnabled+ �� *Self+ true6p   .0�5E      �� $ templateRoot��6;   8   � ��6U   �� 5F      $ templateRoot��6<   8   � ��6V   �� 5G      $ splitBorder��6;   8   � ��6T   �� 5H      $ splitBorder��6<   8   � ��6U   5I      P� 5J       �@J�IsMouseOver . . �5K      �� $ arrow��65   8   � ��6H   5L      ^� 5M       5N      �� 5O   "    6,   �� *IsMouseOver+ �� *Self+ true6r   �� 5P   "    6,   �� *
IsEditable+ �� " ��	 false6�   .0�5R      �� $ templateRoot��6;   8   � ��6U   �� 5S      $ templateRoot��6<   8 	  � ��6V   5T      ^� 5U       5V      �� 5W   "    6,   �� *IsMouseOver+ �� *Self+ true6r   �� 5X   "    6,   �� *
IsEditable+ �� " �� true6�   .0�5Z      �� $ templateRoot��6;   8 
  � ��6U   �� 5[      $ templateRoot��6<   8   � ��6V   �� 5\      $ splitBorder��6;   8   � ��6T   �� 5]      $ splitBorder��6<   8   � ��6U   5^      P� 5_       � �� . . �5`      �� $ arrow��65   8   � ��6H   5a      ^� 5b       5c      �� 5d   "    6,   �� *	IsPressed+ �� *Self+ true6p   �� 5e   "    6,   �� *
IsEditable+ �� " ��	 false6�   .0�5g      �� $ templateRoot��6;   8   � ��6U   �� 5h      $ templateRoot��6<   8   � ��6V   5i      ^� 5j       5k      �� 5l   "    6,   �� *	IsPressed+ �� *Self+ true6p   �� 5m   "    6,   �� *
IsEditable+ �� " �� true6�   .0�5o      �� $ templateRoot��6;   8   � ��6U   �� 5p      $ templateRoot��6<   8   � ��6V   �� 5q      $ splitBorder��6;   8   � ��6T   �� 5r      $ splitBorder��6<   8   � ��6U   5s      P� 5t       � {� .  . �5u      �� $ arrow��65   8   � ��6H   5v      ^� 5w       5x      �� 5y   "    6,   �� *	IsEnabled+ �� *Self+	 false6p   �� 5z   "    6,   �� *
IsEditable+ �� " ��	 false6�   .0�5|      �� $ templateRoot��6;   8   � ��6U   �� 5}      $ templateRoot��6<   8   � ��6V   5~      ^� 5       5�      �� 5�   "    6,   �� *	IsEnabled+ �� *Self+	 false6p   �� 5�   "    6,   �� *
IsEditable+ �� " �� true6�   .0�5�      �� $ templateRoot��6;   8   � ��6U   �� 5�      $ templateRoot��6<   8   � ��6V   �� 5�      $ splitBorder��6;   8   � ��6T   �� 5�      $ splitBorder��6<   8   � ��6U   5�      5�      5�      5�      �� 5�      " ��6/   .R�5�   
   � $ templateRoot��6   
 .  5�      �� 5�      $��* �6#   �� 5�      #��� r�6#   $��0 �6v   .+�5�      � $ 
PART_Popup��6    . $��2��6B   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6V   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5�         $ shadow��60   $ Transparent��6@   #��z 6T   ��6�   �� *ActualWidth+$ templateRoot��._�5�      �� $	 dropDownBorder��6   #��� ��65   $��1q�6�   #��� ��6�   ._�5�      �� $ DropDownScrollViewer��6'   .��5�      � $
 grid��6#   $ Enabled=�61   .+�5�   "   �� $  canvas��6)   $
��Left=�69   $��0��6T   $	��Top=�6_   $��0��6w   .+�5�   &   �� $! 
opaqueRect��60   ��6D   �� *
Background+$ dropDownBorder����6|   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5�   #   �� 5�   "   $" ItemsPresenter��61   $# 	Contained=�6I   #
 z
 6~   5�      5�      5�      5�      5�      d� 5�      $$ toggleButton��6   #��z��61   #��z��6]   #��z��6�   $��2��6�   8��  
�������$��	123123123��6s  % 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+6s  �� 5�      $& contentPresenter��6   #��z' 69   #��z��6v   #��z( 6�   #* z) 6�   #��z��6)  + .  #��z��6�  #
 z
 6�  #��z��6�  5�       5�   
   P� 5�      $, 
PART_Popup��6/    �@�HasDropShadow . . �5�      �� $ shadow��6+    � ��$ 0,0,5,5q�6?   �� 5�      $ shadow��6*    �@  Color$ 	#71000000��6>   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6+    � ��$ 95��6G   5�      ]� 5�      - 5�      �� 5�      . �@��
IsGrouping . 66   �� 5�      ". �@%�IsVirtualizingWhenGrouping .  6X   ./�5�      ��  � �� .  6B   5�      P� 5�      $, DropDownScrollViewer��6?    � �� .  . �5�      �� $ 
opaqueRect��6/    6G   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��60    6H   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5�      5�      �� 5�      $
 #fff��68   �� 5�      " ��6,   .�5�   
   ��  �@�OverridesDefaultStyle . 62   �� 5�   
    �@J�	AllowDrop . 6&   �� 5�   
    � ��$ 0��6%   �� 5�   
    � ��$ 0��6&   �� 5�   
    �@�FocusVisualStyle 6-   Z� �� 5�   
    �@��PanningMode$ VerticalFirst=�65   �� 5�   
    �@��IsFlicksEnabled .  63   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $ PART_ContentHost��6#   
������ |�.  $��Hidden=�6h   $��Hidden=�6�   5�      5�      5�      �� 5�      " ��67   .R�5�   
   � $ templateRoot��6   
 .  5�      �� 5�      $��* �6#   �� 5�      #��� r�6#   $��0 �6v   .+�5�      � $ 
PART_Popup��6    . $��2��6B   #��� .�6�   $��Bottom=�6  ��6V   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�         $ shadow��60   $ Transparent��6@   #��z 6T   ��6�   �� *ActualWidth+$ templateRoot��._�5�      �� $	 dropDownBorder��6   #��� ��65   $��1q�6�   #��� ��6�   ._�5�      �� $ DropDownScrollViewer��6'   .��5�      � $
 grid��6#   $ Enabled=�61   .+�5�   "   �� $  canvas��6)   $
��Left=�69   $��0��6T   $	��Top=�6_   $��0��6w   .+�5�   &   �� $! 
opaqueRect��60   ��6D   �� *
Background+$ dropDownBorder����6|   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5�   #   �� 5�   "   $" ItemsPresenter��61   $# 	Contained=�6I   #
 z
 6~   5�      5�      5�      5�      5�      d� 5�      $$ toggleButton��6   #��z��61   #��z��6]   #��z��6�   $��2��6�   8��  % 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+62  �� 5�      $	 border��6   8�� #��z��6]   ._�5�      �� $/ PART_EditableTextBox��6   #��z��68   #��z��6�   8�� #��z��6)  0 6�   �� *
IsReadOnly+ �� *TemplatedParent+6)  5�      5�       5�   
   P� 5�       � {� .  . �5�      �� $ border��6,    �@J�Opacity$
 0.56Q�6@   5�      P� 5�       �@J�IsKeyboardFocusWithin . . �5�      ��  � ��
 �   �6/   5�      P� 5�      $, 
PART_Popup��6/    �@�HasDropShadow . . �5�      �� $ shadow��6+    � ��$ 0,0,5,5q�6?   �� 5�      $ shadow��6*    �@  Color$ 	#71000000��6>   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6+    � ��$ 95��6G   5�      ]� 5�      - 5�      �� 5�      . �@��
IsGrouping . 66   �� 5�      ". �@%�IsVirtualizingWhenGrouping .  6X   ./�5�      ��  � �� .  6B   5�      P� 5�      $, DropDownScrollViewer��6?    � �� .  . �5�      �� $ 
opaqueRect��6/    6G   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��60    6H   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5�      5�      �� 5�      " ��6"   .�5   
   ��  �@�FocusVisualStyle8   6-   �� 5  
    � ��8  6'   �� 5  
    � ��8  6(   �� 5  
    � ��# � ��6'   �� 5  
    � ��$ 1q�6,   �� 5  
    � ��$
 Auto=�6G   �� 5  
    � ��$
 Auto=�6E   �� 5  
    � ��$ 6,3,5,3q�6$   �� 5  
    � �� . 6:   �� 5	  
    �@��PanningMode$
 Both=�65   �� 5
  
    �@��IsFlicksEnabled .  63   �� 5  
    � ��8  6%   1 5  
   P� 5      �@��
IsEditable . . �5     ��  � �� .  6.   �� 5      � ��$ 2q�6,   �� 5      � ��8  6-   5     5     �� 5     $ #2c2c2c��6E   �� 5     $ 	#A826A0DA��6A   �� 5     $ #2c2c2c��6H   �� 5     $ 	#FF26A0DA��6D   �� 5     $ #2c2c2c��6M   �� 5     $ 	#99006CD9��6I   �� 5     $ #2c2c2c��6O   �� 5     $ 	#FFDADADA��6K   �� 5     $ 	#FF26A0DA��6A   �� 5     $ #2c2c2c��6J   �� 5     $ 	#FF26A0DA��6F   �� 5      " ��6&   .�5!  
   ��  �@J�SnapsToDevicePixels . 60   �� 5"  
    � ��$	 4,1q�6$   �� 5#  
    � �� 67   �� *HorizontalContentAlignment+ �� " ���� 5$  
    � �� 65   �� *VerticalContentAlignment+ �� " ���� 5%  
    � ��
 ���� 6'   �� 5&  
    � ��
 ���� 6(   �� 5'  
    � ��$ 1q�6,   �� 5(  
    �@�FocusVisualStyle8   6-   �� 5)  
    � �� 5*     �� 5+     " ��6"   .R�5,     �� $	 Bd��6   #��z��6)   #��z��6U   #��z��6�   #2 z��6�   
 . ._�5-     �� #��z��6+   #
 z
 6n   #��z��6�   5.      5/     P� 50      � {� .  . �51     �� $ Bd��6G   # � ��6W    � ��52     ]� 53     - 54     �� 55  "   . �@��
IsSelected .  6B   �� 56  "   . �@J�IsMouseOver . 6C   �� 57  "   . �@J�IsKeyboardFocused .  6I   ./�59     �� $ Bd��6;   8   � ��6K   �� 5:     $ Bd��6<   8   � ��6L   5;     ]� 5<     - 5=     �� 5>  "   . �@��
IsSelected . 6B   �� 5?  "   . �@J�IsMouseOver .  6C   �� 5@  "   . �@J�IsKeyboardFocused . 6I   ./�5B     �� $ Bd��6;   8   � ��6K   �� 5C     $ Bd��6<   8   � ��6L   5D     ]� 5E     - 5F     �� 5G  "   . �@��
IsSelected . 6B   �� 5H  "   . �@J�IsMouseOver . 6C   ./�5J     �� $ Bd��6;   8   � ��6K   �� 5K     $ Bd��6<   8   � ��6L   5L     ]� 5M     - 5N     �� 5O  "   . �@��
IsSelected . 6B   �� 5P  "   . �@J�IsMouseOver .  6C   �� 5Q  "   . �@J�IsKeyboardFocused .  6I   ./�5S     �� $ Bd��6;   8   � ��6K   �� 5T     $ Bd��6<   8   � ��6L   5U     ]� 5V     - 5W     �� 5X  "   . �@��
IsSelected .  6B   �� 5Y  "   . �@J�IsMouseOver .  6C   �� 5Z  "   . �@J�IsKeyboardFocused . 6I   ./�5\     �� $ Bd��6<   8 	  � ��6L   5]     ]� 5^     - 5_     �� 5`  "   . �@��
IsSelected .  6B   �� 5a  "   . �@J�IsMouseOver . 6C   �� 5b  "   . �@J�IsKeyboardFocused . 6I   ./�5d     �� $ Bd��6;   8 
  � ��6K   �� 5e     $ Bd��6<   8   � ��6L   5f     5h     5j     5k     �� 5l     .R�5m  
   �� 3 . 6   5n     5p     