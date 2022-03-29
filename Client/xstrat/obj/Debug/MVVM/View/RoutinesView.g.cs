﻿#pragma checksum "..\..\..\..\MVVM\View\RoutinesView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8CF7CF8AA509A52DA98C10FCEA693A606AD1194BC7FA8C8B0D495847759C6D60"
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
    /// RoutinesView
    /// </summary>
    public partial class RoutinesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\MVVM\View\RoutinesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border RoutinesOverview;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\MVVM\View\RoutinesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel RoutinesSP;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\MVVM\View\RoutinesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\MVVM\View\RoutinesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border EditRoutine;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\MVVM\View\RoutinesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel sp;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\MVVM\View\RoutinesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ButtonsPanel;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\MVVM\View\RoutinesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\MVVM\View\RoutinesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenOverlayButton;
        
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
            System.Uri resourceLocater = new System.Uri("/xstrat;component/mvvm/view/routinesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\View\RoutinesView.xaml"
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
            this.RoutinesOverview = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.RoutinesSP = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.NewButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\MVVM\View\RoutinesView.xaml"
            this.NewButton.Click += new System.Windows.RoutedEventHandler(this.NewButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditRoutine = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.sp = ((System.Windows.Controls.StackPanel)(target));
            
            #line 38 "..\..\..\..\MVVM\View\RoutinesView.xaml"
            this.sp.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.sp_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\..\MVVM\View\RoutinesView.xaml"
            this.sp.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.sp_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\..\MVVM\View\RoutinesView.xaml"
            this.sp.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.sp_PreviewMouseMove);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\..\MVVM\View\RoutinesView.xaml"
            this.sp.DragEnter += new System.Windows.DragEventHandler(this.sp_DragEnter);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\..\MVVM\View\RoutinesView.xaml"
            this.sp.Drop += new System.Windows.DragEventHandler(this.sp_Drop);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButtonsPanel = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\MVVM\View\RoutinesView.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.OpenOverlayButton = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\MVVM\View\RoutinesView.xaml"
            this.OpenOverlayButton.Click += new System.Windows.RoutedEventHandler(this.OpenOverlayButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

