﻿#pragma checksum "..\..\..\UserControls\UC_Technical.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BEAB0B640B0E00E645AFFF99872DDE8C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SGBD_Juin.UserControls;
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


namespace SGBD_Juin.UserControls {
    
    
    /// <summary>
    /// UC_Technical
    /// </summary>
    public partial class UC_Technical : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\UserControls\UC_Technical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid_Menu;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UserControls\UC_Technical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_Exit;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\UserControls\UC_Technical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_Restart;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\UC_Technical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_RMASearch;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\UserControls\UC_Technical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_MySettings;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\UserControls\UC_Technical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGV_RMAList;
        
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
            System.Uri resourceLocater = new System.Uri("/SGBD-Juin;component/usercontrols/uc_technical.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\UC_Technical.xaml"
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
            this.Grid_Menu = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.BTN_Exit = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\UserControls\UC_Technical.xaml"
            this.BTN_Exit.Click += new System.Windows.RoutedEventHandler(this.BTN_Exit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BTN_Restart = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\UserControls\UC_Technical.xaml"
            this.BTN_Restart.Click += new System.Windows.RoutedEventHandler(this.BTN_Restart_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BTN_RMASearch = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\UserControls\UC_Technical.xaml"
            this.BTN_RMASearch.Click += new System.Windows.RoutedEventHandler(this.BTN_RMASearch_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BTN_MySettings = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\UserControls\UC_Technical.xaml"
            this.BTN_MySettings.Click += new System.Windows.RoutedEventHandler(this.BTN_MySettings_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DGV_RMAList = ((System.Windows.Controls.DataGrid)(target));
            
            #line 51 "..\..\..\UserControls\UC_Technical.xaml"
            this.DGV_RMAList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DGV_RMAList_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

