﻿#pragma checksum "..\..\..\..\Pages\Directions\Direction_Edit.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F9C2021010617E35CEDBD1F22B4A796B4A5B44852A1A5876079F5BA82F7C5352"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using StudentsPract.Pages.Directions;
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


namespace StudentsPract.Pages.Directions {
    
    
    /// <summary>
    /// Direction_Edit
    /// </summary>
    public partial class Direction_Edit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\..\Pages\Directions\Direction_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\Directions\Direction_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox code;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Pages\Directions\Direction_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox id_cathedra;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Pages\Directions\Direction_Edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChange;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Pages\Directions\Direction_Edit.xaml"
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
            System.Uri resourceLocater = new System.Uri("/StudentsPract;component/pages/directions/direction_edit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Directions\Direction_Edit.xaml"
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
            this.code = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.id_cathedra = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btnChange = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\Pages\Directions\Direction_Edit.xaml"
            this.btnChange.Click += new System.Windows.RoutedEventHandler(this.Button_Listener);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FormClose = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\Pages\Directions\Direction_Edit.xaml"
            this.FormClose.Click += new System.Windows.RoutedEventHandler(this.Button_Listener);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
