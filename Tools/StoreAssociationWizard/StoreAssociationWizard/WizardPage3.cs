// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Wizard
{
    public partial class WizardPage3 : PageFunction<WizardResult>
    {
        public WizardPage3(WizardData wizardData)
        {
            InitializeComponent();

            // Bind wizard state to UI
            DataContext = wizardData;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to previous wizard page
            NavigationService?.GoBack();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to next wizard page
            var wizardPage4 = new WizardPage4((WizardData)DataContext);
            wizardPage4.Return += wizardPage_Return;
            NavigationService?.Navigate(wizardPage4);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cancel the wizard and don't return any data
            OnReturn(new ReturnEventArgs<WizardResult>(WizardResult.Canceled));
        }

        public void wizardPage_Return(object sender, ReturnEventArgs<WizardResult> e)
        {
            // If returning, wizard was completed (finished or canceled),
            // so continue returning to calling page
            OnReturn(e);
        }

        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView.SelectedIndex == -1)
            {
                (DataContext as WizardData).StoreDataKey = null;
                nextButton.IsEnabled = false;
            }
            else
            {
                (DataContext as WizardData).StoreDataKey = ((KeyValuePair<string, StoreData>)lstView.SelectedItem).Key;
                nextButton.IsEnabled = true;
            }
        }
    }
}