﻿#pragma checksum "..\..\..\..\Views\Forms\AddRentingRights.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DFC05A23EFA6FF3B71F6D93DBBD9326735CE733855FDD044552819ECE2BF6188"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RELender.WPF.Views.Forms;
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


namespace RELender.WPF.Views.Forms {
    
    
    /// <summary>
    /// AddRentingRights
    /// </summary>
    public partial class AddRentingRights : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Views\Forms\AddRentingRights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AgencyComboBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\Forms\AddRentingRights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RealEstateComboBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Views\Forms\AddRentingRights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CompensationInput;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\Forms\AddRentingRights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker StartDatePicker;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\Forms\AddRentingRights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker EndDatePicker;
        
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
            System.Uri resourceLocater = new System.Uri("/RELender.WPF;component/views/forms/addrentingrights.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Forms\AddRentingRights.xaml"
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
            this.AgencyComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.RealEstateComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.CompensationInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.StartDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.EndDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            
            #line 43 "..\..\..\..\Views\Forms\AddRentingRights.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnSubmit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
