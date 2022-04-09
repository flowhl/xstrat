﻿#pragma checksum "..\..\..\..\MVVM\View\SkinSwitcherView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DD36340022DF4A364083814BF43B169065EE653C882EE138CF3476F4B871721A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using xstrat.MVVM.View;
using xstrat.Theme;


namespace xstrat.MVVM.View {
    
    
    /// <summary>
    /// SkinSwitcherView
    /// </summary>
    public partial class SkinSwitcherView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\MVVM\View\SkinSwitcherView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal xstrat.Theme.ToggleSwitch TS;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\MVVM\View\SkinSwitcherView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplyBtn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\MVVM\View\SkinSwitcherView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Error;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\MVVM\View\SkinSwitcherView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CurrentToNoSkin;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\MVVM\View\SkinSwitcherView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CurrentToSkin;
        
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
            System.Uri resourceLocater = new System.Uri("/xstrat;component/mvvm/view/skinswitcherview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\View\SkinSwitcherView.xaml"
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
            this.TS = ((xstrat.Theme.ToggleSwitch)(target));
            return;
            case 2:
            this.ApplyBtn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\MVVM\View\SkinSwitcherView.xaml"
            this.ApplyBtn.Click += new System.Windows.RoutedEventHandler(this.ApplyBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Error = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.CurrentToNoSkin = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\MVVM\View\SkinSwitcherView.xaml"
            this.CurrentToNoSkin.Click += new System.Windows.RoutedEventHandler(this.CurrentToNoSkin_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CurrentToSkin = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\MVVM\View\SkinSwitcherView.xaml"
            this.CurrentToSkin.Click += new System.Windows.RoutedEventHandler(this.CurrentToSkin_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

