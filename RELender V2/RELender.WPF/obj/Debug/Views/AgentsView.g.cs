﻿#pragma checksum "..\..\..\Views\AgentsView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9A7C0381B608C9814BFE80C78E295D469356CD83A21697BB0D28813A0A9E3999"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RELender.WPF.Views;
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


namespace RELender.WPF.Views {
    
    
    /// <summary>
    /// AgentsView
    /// </summary>
    public partial class AgentsView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Views\AgentsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock statusBar;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\AgentsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addBtn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\AgentsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editBtn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\AgentsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/RELender.WPF;component/views/agentsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AgentsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 8 "..\..\..\Views\AgentsView.xaml"
            ((RELender.WPF.Views.AgentsView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.onLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.statusBar = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.addBtn = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Views\AgentsView.xaml"
            this.addBtn.Click += new System.Windows.RoutedEventHandler(this.addBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.editBtn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Views\AgentsView.xaml"
            this.editBtn.Click += new System.Windows.RoutedEventHandler(this.editBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.deleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Views\AgentsView.xaml"
            this.deleteBtn.Click += new System.Windows.RoutedEventHandler(this.deleteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 29 "..\..\..\Views\AgentsView.xaml"
            ((System.Windows.Controls.DataGrid)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
