﻿#pragma checksum "..\..\..\KitCreateUI.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52F4343CD126BB4975408393548779B03751FDB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KitStemHub.App;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace KitStemHub.App {
    
    
    /// <summary>
    /// KitCreateUI
    /// </summary>
    public partial class KitCreateUI : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\KitCreateUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox kitCategoryCbBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\KitCreateUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox kitNameTxtBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\KitCreateUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox kitBriefTxtBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\KitCreateUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox kitDescriptionTxtBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\KitCreateUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox kitPurchaseCostTxtBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\KitCreateUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox kitPriceTxtBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\KitCreateUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button kitImgBtn;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\KitCreateUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox kitStatusCbBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\KitCreateUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveKitBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KitStemHub.App;V1.0.0.0;component/kitcreateui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\KitCreateUI.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.kitCategoryCbBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.kitNameTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.kitBriefTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.kitDescriptionTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.kitPurchaseCostTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.kitPriceTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.kitImgBtn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\KitCreateUI.xaml"
            this.kitImgBtn.Click += new System.Windows.RoutedEventHandler(this.kitImgBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.kitStatusCbBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.saveKitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\KitCreateUI.xaml"
            this.saveKitBtn.Click += new System.Windows.RoutedEventHandler(this.saveKitBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

