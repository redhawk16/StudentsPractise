﻿#pragma checksum "..\..\..\..\Pages\Employees\Employee_Add.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7C7B11439DB190663B9C11EE0DBA14C9D980010BD01D429C7705FE290C25EE71"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using StudentsPract.Classes;
using StudentsPract.Pages.Employees;
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


namespace StudentsPract.Pages.Employees {
    
    
    /// <summary>
    /// Employee_Add
    /// </summary>
    public partial class Employee_Add : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surname;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patronymic;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phone;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox email;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lvl;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
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
            System.Uri resourceLocater = new System.Uri("/StudentsPract;component/pages/employees/employee_add.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
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
            this.surname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.patronymic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.lvl = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.Button_Listener);
            
            #line default
            #line hidden
            return;
            case 9:
            this.FormClose = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\..\Pages\Employees\Employee_Add.xaml"
            this.FormClose.Click += new System.Windows.RoutedEventHandler(this.Button_Listener);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

