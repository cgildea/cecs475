// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MvcSPAWin8Client
{
    public delegate void CancelledLogin(object sender, CancelledLoginEventArgs args);
    public delegate void SubmitLogin(object sender, SubmitLoginEventArgs args);
    public sealed partial class FormLogin : UserControl
    {
        public FormLogin()
        {
            this.InitializeComponent();
            VisualStateManager.GoToState(this, "hidden", false);
        }

        public bool Shown
        {
            get { return (bool)GetValue(ShownProperty); }
            set { SetValue(ShownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Shown.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShownProperty =
            DependencyProperty.Register("Shown", typeof(bool), typeof(FormLogin), new PropertyMetadata(false, ShownChanged));

        private static void ShownChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pe = d as FormLogin;
            if (pe != null)
            {
                if ((bool)e.NewValue) pe.Show(); else pe.Hide();
            }
        }

        public event CancelledLogin Cancelled;
        public event SubmitLogin Login;

        public void InvokeCancelled()
        {
            var cncl = Cancelled;
            if (cncl != null)
            {
                cncl.Invoke(this, new CancelledLoginEventArgs());
            }
        }

        public void InvokeSubmitted()
        {
            var accpt = Login;
            if (accpt != null)
            {
                accpt.Invoke(this, new SubmitLoginEventArgs());
            }
        }

        public void Show()
        {
            VisualStateManager.GoToState(this, "shown", false);
        }

        public void Hide()
        {
            VisualStateManager.GoToState(this, "hidden", false);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Shown = false;
            InvokeCancelled();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            Shown = false;
            InvokeSubmitted();
        }
    }

    public class CancelledLoginEventArgs : EventArgs
    {

    }

    public class SubmitLoginEventArgs : EventArgs
    {

    }
}
