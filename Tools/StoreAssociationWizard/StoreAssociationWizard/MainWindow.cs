// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Windows;

namespace Wizard
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var wizard = new WizardDialogBox();
            var showDialog = wizard.ShowDialog();
            if (showDialog != null && !(bool)showDialog)
            {
                MessageBox.Show(wizard.WizardData.ErrorMessage, "Error");
            }
            Close();
        }
    }
}