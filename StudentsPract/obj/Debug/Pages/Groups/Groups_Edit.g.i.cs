﻿#pragma checksum "..\..\..\..\Pages\Groups\Groups_Edit.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3067C7248079156AF7D137AFB17AF4BC0259154137313C615B15113A6D098FB6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using StudentsPract.Pages.Groups;
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


namespace StudentsPract.Pages.Groups {
    
    
    /// <summary>
    /// Groups_Edit
    /// </summary>
    public partial class Groups_Edit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox groupe;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox direction;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox form_study;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox enroll;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox end;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid typePract;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChange;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FormClose;
        
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
            System.Uri resourceLocater = new System.Uri("/StudentsPract;component/pages/groups/groups_edit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
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
            this.groupe = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.direction = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.form_study = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.enroll = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.end = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.typePract = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.btnChange = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
            this.btnChange.Click += new System.Windows.RoutedEventHandler(this.Button_Listener);
            
            #line default
            #line hidden
            return;
            case 8:
            this.FormClose = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\..\Pages\Groups\Groups_Edit.xaml"
            this.FormClose.Click += new System.Windows.RoutedEventHandler(this.Button_Listener);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

