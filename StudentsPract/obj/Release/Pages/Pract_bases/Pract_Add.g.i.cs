﻿#pragma checksum "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B125C523948DCA4B202341D314C466FFFD511120C641CBB77B77443F360BC0E2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using StudentsPract.Pages.Pract_bases;
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


namespace StudentsPract.Pages.Pract_bases {
    
    
    /// <summary>
    /// Pract_Add
    /// </summary>
    public partial class Pract_Add : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox address;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox employeer;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phone;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_end;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml"
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
            System.Uri resourceLocater = new System.Uri("/StudentsPract;component/pages/pract_bases/pract_add.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml"
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
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.address = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.employeer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.date_end = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.Button_Listener);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FormClose = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\..\Pages\Pract_bases\Pract_Add.xaml"
            this.FormClose.Click += new System.Windows.RoutedEventHandler(this.Button_Listener);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
