﻿#pragma checksum "..\..\..\Pages\Groups.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0A3ED44EFA7E27CD29C64D29A04D2405A520F51C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using StudentsPract.Pages;
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


namespace StudentsPract.Pages {
    
    
    /// <summary>
    /// Groups
    /// </summary>
    public partial class Groups : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Pages\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox group;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox direction;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox form_study;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox enroll_year;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox end_year;
        
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
            System.Uri resourceLocater = new System.Uri("/StudentsPract;component/pages/groups.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Groups.xaml"
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
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 14 "..\..\..\Pages\Groups.xaml"
            this.dataGrid.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.dataGrid_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\Pages\Groups.xaml"
            this.dataGrid.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.dataGrid_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 2:
            this.group = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\Pages\Groups.xaml"
            this.group.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.FilterValue));
            
            #line default
            #line hidden
            return;
            case 3:
            this.direction = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\..\Pages\Groups.xaml"
            this.direction.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterValue);
            
            #line default
            #line hidden
            return;
            case 4:
            this.form_study = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\..\Pages\Groups.xaml"
            this.form_study.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterValue);
            
            #line default
            #line hidden
            return;
            case 5:
            this.enroll_year = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\Pages\Groups.xaml"
            this.enroll_year.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterValue);
            
            #line default
            #line hidden
            return;
            case 6:
            this.end_year = ((System.Windows.Controls.TextBox)(target));
            
            #line 70 "..\..\..\Pages\Groups.xaml"
            this.end_year.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterValue);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

