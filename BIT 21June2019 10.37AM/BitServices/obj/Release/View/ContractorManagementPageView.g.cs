﻿#pragma checksum "..\..\..\View\ContractorManagementPageView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F22E19FF266B146A90702D962509CBC201EDF597"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BitServices.View;
using BitServices.ViewModel;
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


namespace BitServices.View {
    
    
    /// <summary>
    /// ContractorManagementPageView
    /// </summary>
    public partial class ContractorManagementPageView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\View\ContractorManagementPageView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgContractor;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\ContractorManagementPageView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\ContractorManagementPageView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\ContractorManagementPageView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\View\ContractorManagementPageView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ContractorDOB;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\View\ContractorManagementPageView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRoster;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\View\ContractorManagementPageView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewSkills;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\View\ContractorManagementPageView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPreferredSuburb;
        
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
            System.Uri resourceLocater = new System.Uri("/BitServices;component/view/contractormanagementpageview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ContractorManagementPageView.xaml"
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
            this.dgContractor = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\View\ContractorManagementPageView.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\View\ContractorManagementPageView.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ContractorDOB = ((System.Windows.Controls.DatePicker)(target));
            
            #line 58 "..\..\..\View\ContractorManagementPageView.xaml"
            this.ContractorDOB.CalendarOpened += new System.Windows.RoutedEventHandler(this.ContractorDOB_CalendarOpened);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnRoster = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\View\ContractorManagementPageView.xaml"
            this.btnRoster.Click += new System.Windows.RoutedEventHandler(this.btnRoster_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnNewSkills = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\View\ContractorManagementPageView.xaml"
            this.btnNewSkills.Click += new System.Windows.RoutedEventHandler(this.btnNewSkills_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnPreferredSuburb = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\View\ContractorManagementPageView.xaml"
            this.btnPreferredSuburb.Click += new System.Windows.RoutedEventHandler(this.btnPreferredSuburb_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

