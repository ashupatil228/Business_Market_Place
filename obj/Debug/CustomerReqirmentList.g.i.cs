﻿#pragma checksum "..\..\CustomerReqirmentList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8A8DC8DC8043CCAD6F91EB979365083667940830"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BusinessMarketPlace;
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


namespace BusinessMarketPlace {
    
    
    /// <summary>
    /// CustomerReqirmentList
    /// </summary>
    public partial class CustomerReqirmentList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\CustomerReqirmentList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_Name;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\CustomerReqirmentList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_Email;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\CustomerReqirmentList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_Mobile;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\CustomerReqirmentList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_City;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\CustomerReqirmentList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_ProductType;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\CustomerReqirmentList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_Message;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\CustomerReqirmentList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Submit;
        
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
            System.Uri resourceLocater = new System.Uri("/BusinessMarketPlace;component/customerreqirmentlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CustomerReqirmentList.xaml"
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
            this.Txt_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Txt_Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Txt_Mobile = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Txt_City = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Txt_ProductType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Txt_Message = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Btn_Submit = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\CustomerReqirmentList.xaml"
            this.Btn_Submit.Click += new System.Windows.RoutedEventHandler(this.Btn_Submit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

