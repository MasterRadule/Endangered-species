
﻿#pragma checksum "..\..\..\OtherWindows\DodajEtiketuWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6833DFAB2450F7E2B0A03A42FFD8CC576EAD25C5"

﻿#pragma checksum "..\..\..\OtherWindows\DodajEtiketuWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C18D38F9A9ED3326A7D0CC79CD42870F"

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
using Projekat.HelpProvider;
using Projekat.OtherWindows;
using Projekat.Validation;
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
using Xceed.Wpf.Toolkit;


namespace Projekat.OtherWindows {
    
    
    /// <summary>
    /// DodajEtiketuWindow
    /// </summary>
    public partial class DodajEtiketuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        

        #line 81 "..\..\..\OtherWindows\DodajEtiketuWindow.xaml"

        #line 77 "..\..\..\OtherWindows\DodajEtiketuWindow.xaml"

        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox oznakaBox;
        
        #line default
        #line hidden
        
        

        #line 100 "..\..\..\OtherWindows\DodajEtiketuWindow.xaml"

        #line 94 "..\..\..\OtherWindows\DodajEtiketuWindow.xaml"

        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox opisBox;
        
        #line default
        #line hidden
        
        

        #line 124 "..\..\..\OtherWindows\DodajEtiketuWindow.xaml"

        #line 119 "..\..\..\OtherWindows\DodajEtiketuWindow.xaml"

        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker odabirBoje;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekat;component/otherwindows/dodajetiketuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\OtherWindows\DodajEtiketuWindow.xaml"
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
            this.oznakaBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.opisBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.odabirBoje = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            return;
            case 4:
            

            #line 138 "..\..\..\OtherWindows\DodajEtiketuWindow.xaml"

            #line 131 "..\..\..\OtherWindows\DodajEtiketuWindow.xaml"

            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Dodaj);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

