﻿#pragma checksum "..\..\Wind1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "473EA4350B207B0A95026F62F11C867FCE0D77F5C517E6982BA556B89014CCB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Laboratorna1;
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


namespace Laboratorna1 {
    
    
    /// <summary>
    /// Wind1
    /// </summary>
    public partial class Wind1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Wind1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToHome;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Wind1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PIP_Text;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Wind1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Book_Text;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Wind1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Del_Book_Text;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Wind1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Spec;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Wind1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Kyrs;
        
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
            System.Uri resourceLocater = new System.Uri("/Laboratorna1;component/wind1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Wind1.xaml"
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
            this.ToHome = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Wind1.xaml"
            this.ToHome.Click += new System.Windows.RoutedEventHandler(this.GoHome_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PIP_Text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Book_Text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Del_Book_Text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 35 "..\..\Wind1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Record_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 36 "..\..\Wind1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Del_Record_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Spec = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.Kyrs = ((System.Windows.Controls.ComboBox)(target));
            
            #line 42 "..\..\Wind1.xaml"
            this.Kyrs.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Kyrs_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 48 "..\..\Wind1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Base_Open_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

