﻿#pragma checksum "..\..\..\..\Pages\Cathedras\Cathedras_Edit.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D76BB696B2C7DF4B3304F6D708BE3838DA5155D9DE0EEBE9EF9C273EC42F464F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using StudentsPract.Pages.Cathedras;
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


namespace StudentsPract.Pages.Cathedras {
    
    
    /// <summary>
    /// Cathedras_Edit
    /// </summary>
    public partial class Cathedras_Edit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\..\Pages\Cathedras\Cathedras_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox number;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\Cathedras\Cathedras_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Pages\Cathedras\Cathedras_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phone;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Pages\Cathedras\Cathedras_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox decan;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Pages\Cathedras\Cathedras_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChange;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\Cathedras\Cathedras_Edit.xaml"
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
            System.Uri resourceLocater = new System.Uri("/StudentsPract;component/pages/cathedras/cathedras_edit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Cathedras\Cathedras_Edit.xaml"
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
            this.number = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.decan = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.btnChange = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\..\Pages\Cathedras\Cathedras_Edit.xaml"
            this.btnChange.Click += new System.Windows.RoutedEventHandler(this.Button_Listener);
            
            #line default
            #line hidden
            return;
            case 6:
            this.FormClose = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\..\Pages\Cathedras\Cathedras_Edit.xaml"
            this.FormClose.Click += new System.Windows.RoutedEventHandler(this.Button_Listener);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

