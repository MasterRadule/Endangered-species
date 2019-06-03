﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8B03ED8AD4546AF0F01644BC6D1C92FA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Projekat;
using Projekat.HelpProvider;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Projekat {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 173 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pretragaImeOznakaTB;
        
        #line default
        #line hidden
        
        
        #line 255 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox tipBox;
        
        #line default
        #line hidden
        
        
        #line 269 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox statusUgrozenostiBox;
        
        #line default
        #line hidden
        
        
        #line 276 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox turistickiStatusBox;
        
        #line default
        #line hidden
        
        
        #line 299 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox etiketeBox;
        
        #line default
        #line hidden
        
        
        #line 343 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton DaNeCheck;
        
        #line default
        #line hidden
        
        
        #line 347 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox opasnaCheck;
        
        #line default
        #line hidden
        
        
        #line 354 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox iucnCheck;
        
        #line default
        #line hidden
        
        
        #line 362 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox naseljenoCheck;
        
        #line default
        #line hidden
        
        
        #line 381 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox godisnjiPrihodDG;
        
        #line default
        #line hidden
        
        
        #line 404 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox godisnjiPrihodGG;
        
        #line default
        #line hidden
        
        
        #line 433 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datumDG;
        
        #line default
        #line hidden
        
        
        #line 442 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datumGG;
        
        #line default
        #line hidden
        
        
        #line 468 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TurnOffSearchButton;
        
        #line default
        #line hidden
        
        
        #line 628 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MapGrid;
        
        #line default
        #line hidden
        
        
        #line 633 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image mapImage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Projekat;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\MainWindow.xaml"
            ((Projekat.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 116 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 120 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 124 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 128 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 132 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_4);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 139 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_6);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 143 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_5);
            
            #line default
            #line hidden
            return;
            case 9:
            this.pretragaImeOznakaTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tipBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.statusUgrozenostiBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.turistickiStatusBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 13:
            this.etiketeBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 14:
            this.DaNeCheck = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 15:
            this.opasnaCheck = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 16:
            this.iucnCheck = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 17:
            this.naseljenoCheck = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 18:
            this.godisnjiPrihodDG = ((System.Windows.Controls.TextBox)(target));
            
            #line 380 "..\..\MainWindow.xaml"
            this.godisnjiPrihodDG.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 384 "..\..\MainWindow.xaml"
            this.godisnjiPrihodDG.KeyDown += new System.Windows.Input.KeyEventHandler(this.GodisnjiPrihod_KeyDown);
            
            #line default
            #line hidden
            
            #line 385 "..\..\MainWindow.xaml"
            this.godisnjiPrihodDG.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.GodisnjiPrihod_TextChanged);
            
            #line default
            #line hidden
            return;
            case 19:
            this.godisnjiPrihodGG = ((System.Windows.Controls.TextBox)(target));
            
            #line 403 "..\..\MainWindow.xaml"
            this.godisnjiPrihodGG.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 407 "..\..\MainWindow.xaml"
            this.godisnjiPrihodGG.KeyDown += new System.Windows.Input.KeyEventHandler(this.GodisnjiPrihod_KeyDown);
            
            #line default
            #line hidden
            
            #line 408 "..\..\MainWindow.xaml"
            this.godisnjiPrihodGG.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.GodisnjiPrihod_TextChanged);
            
            #line default
            #line hidden
            return;
            case 20:
            this.datumDG = ((System.Windows.Controls.DatePicker)(target));
            
            #line 440 "..\..\MainWindow.xaml"
            this.datumDG.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.DatePicker_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 21:
            this.datumGG = ((System.Windows.Controls.DatePicker)(target));
            
            #line 449 "..\..\MainWindow.xaml"
            this.datumGG.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.DatePicker_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 461 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_7);
            
            #line default
            #line hidden
            return;
            case 23:
            this.TurnOffSearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 473 "..\..\MainWindow.xaml"
            this.TurnOffSearchButton.Click += new System.Windows.RoutedEventHandler(this.TurnOffSearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 500 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked_3);
            
            #line default
            #line hidden
            
            #line 503 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).DragEnter += new System.Windows.DragEventHandler(this.RadioButton_DragEnter);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 509 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            
            #line 512 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).DragEnter += new System.Windows.DragEventHandler(this.RadioButton_DragEnter);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 517 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked_1);
            
            #line default
            #line hidden
            
            #line 520 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).DragEnter += new System.Windows.DragEventHandler(this.RadioButton_DragEnter);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 526 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked_2);
            
            #line default
            #line hidden
            
            #line 529 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).DragEnter += new System.Windows.DragEventHandler(this.RadioButton_DragEnter);
            
            #line default
            #line hidden
            return;
            case 29:
            this.MapGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 630 "..\..\MainWindow.xaml"
            this.MapGrid.DragEnter += new System.Windows.DragEventHandler(this.Grid_DragEnter);
            
            #line default
            #line hidden
            
            #line 631 "..\..\MainWindow.xaml"
            this.MapGrid.Drop += new System.Windows.DragEventHandler(this.Grid_Drop);
            
            #line default
            #line hidden
            return;
            case 30:
            this.mapImage = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 28:
            
            #line 573 "..\..\MainWindow.xaml"
            ((MaterialDesignThemes.Wpf.Chip)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Chip_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 574 "..\..\MainWindow.xaml"
            ((MaterialDesignThemes.Wpf.Chip)(target)).PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Chip_PreviewMouseMove);
            
            #line default
            #line hidden
            
            #line 578 "..\..\MainWindow.xaml"
            ((MaterialDesignThemes.Wpf.Chip)(target)).Click += new System.Windows.RoutedEventHandler(this.Chip_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

