﻿#pragma checksum "..\..\..\..\MVVM\View\SettingsView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BBD811703BF082E5B4777E09EDED9CC9F562F2E285E4EB9F3F5CEDE02A831FC4"
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
using xstrat.Ui;


namespace xstrat.MVVM.View {
    
    
    /// <summary>
    /// SettingsView
    /// </summary>
    public partial class SettingsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\MVVM\View\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal xstrat.Ui.ToggleSwitch RememberMeSettings;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\MVVM\View\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox APIText;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\MVVM\View\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DCId;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\MVVM\View\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel WebhookView;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\MVVM\View\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DCWebhook;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\MVVM\View\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SkinSwitcherPathDisplay;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\MVVM\View\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SkinSwitcherPickPathBtn;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\MVVM\View\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/xstrat;component/mvvm/view/settingsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\View\SettingsView.xaml"
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
            this.RememberMeSettings = ((xstrat.Ui.ToggleSwitch)(target));
            return;
            case 2:
            this.APIText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.DCId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.WebhookView = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.DCWebhook = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SkinSwitcherPathDisplay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.SkinSwitcherPickPathBtn = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\MVVM\View\SettingsView.xaml"
            this.SkinSwitcherPickPathBtn.Click += new System.Windows.RoutedEventHandler(this.SkinSwitcherPickPathBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\MVVM\View\SettingsView.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.Save_BtnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

