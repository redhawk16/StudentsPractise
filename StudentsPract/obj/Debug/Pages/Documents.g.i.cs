﻿#pragma checksum "..\..\..\Pages\Documents.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E9440783EA74454A3CB1DC797B5869CE2DC99039F8464FFC7BFE8D600DB43379"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DataGridExtensions;
using DataGridExtensions.Behaviors;
using StudentsPract.Classes;
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
    /// Documents
    /// </summary>
    public partial class Documents : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 18 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Contract_open;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Contract_edit;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Contract_del;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid contracts_list;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ContractsAdd;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid orders_list;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Pages\Documents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OrdersAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/StudentsPract;component/pages/documents.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Documents.xaml"
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
            this.Contract_open = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Pages\Documents.xaml"
            this.Contract_open.Click += new System.Windows.RoutedEventHandler(this.Controls_Buttons);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Contract_edit = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Pages\Documents.xaml"
            this.Contract_edit.Click += new System.Windows.RoutedEventHandler(this.Controls_Buttons);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Contract_del = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Pages\Documents.xaml"
            this.Contract_del.Click += new System.Windows.RoutedEventHandler(this.Controls_Buttons);
            
            #line default
            #line hidden
            return;
            case 4:
            this.contracts_list = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.ContractsAdd = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\Pages\Documents.xaml"
            this.ContractsAdd.Click += new System.Windows.RoutedEventHandler(this.ContractsAdd_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.orders_list = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.OrdersAdd = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\Pages\Documents.xaml"
            this.OrdersAdd.Click += new System.Windows.RoutedEventHandler(this.OrdersAdd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 7:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Documents.Hyperlink.ClickEvent;
            
            #line 86 "..\..\..\Pages\Documents.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.DG_Hyperlink_Click_order);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

