   M S B A M L   `   `   `  ����H  DProductSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProductSearch.ConvertersProductSearch.Converters  5   	   ?$clr-namespace:ProductSearch.ControlsProductSearch.Controls  5   	   '    !ProductSearch.View.MainWindowView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   =
Converters&clr-namespace:ProductSearch.Converters     5   	   9Controls$clr-namespace:ProductSearch.Controls     5   	     � Title$  Product Search��5   	   $	��395��5   	   $	��410��6   $	��395��6"   $	��410��62   $	��395��6A   $	��410��6Q    � 	Resources 5      0   *ProductSearch.Converters.CurrencyConverter   currencyConverter1   +ProductSearch.Converters.IsVisibleConverter  isVisibleConverter��%:   &	        &	        5	      6#     5
      6$   5      .��5      � .+�5      �� -   5        $��	btnSearch��5      $��Search��5      $��40��5      $	��102��6   $
��Left=�5      $	��Top=�6*   $��	27,80,0,0q�5       �� 	IsDefault . ��5      �� *SearchCommand+��5      ��  �� ElementName$ txtProductName�� �� Path$
 Text�5      �� 5      -   5        $��txtProductName��5      $��23��5      $	��120��6   $
��Left=�5      $	��Top=�6+   $��	27,39,0,0q�5      �� 5      -   5        $��txtPrice��5      $��23��5      $
��Left=�5      $	��Top=�6-    �� TextAlignment$
 Left=�5      $��
27,333,0,0q�5      $	��121��5   w   ��6   �� *ProductPrice+ �� 	Converter# [   �� StringFormat$ 
Price: {0}��6w   �� 5       -   5        $��txtErrorMesage��5       $��23��5!      $	��231��6   
���  ��$
��Left=�5#      $	��Top=�6-   $��
135,92,0,0q�5$      ��6&   �� *ErrorMessage+� 5&      -   5        $��grdImage��5&      $	��151��6   $	��102��6*   $
��Left=�5'      $	��Top=�6(   $��
27,145,0,0q�5(      .+�5*   
   �� -   5        $��
imgProduct��5*      ��5+      �� *ProductImage+y�5,      �� *IsSearching+# [  �� ConverterParameter$
 true��*   $ProductSearch.Controls.WaitIndicator  5.   
   $��21,17,20,76q�6!   y�66   �� *IsSearching+# [ �� 50   
   $��Seaching...��6   $��Center=�51      $��Bottom=�52      $��0,0,0,40q�53      y�54      �� *IsSearching+# [ 56   	   57      58      