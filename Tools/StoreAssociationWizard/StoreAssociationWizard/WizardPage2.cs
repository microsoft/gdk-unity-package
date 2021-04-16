// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Xbox.Services.DevTools.Authentication;
using Microsoft.Xbox.Services.DevTools.XblConfig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Wizard
{
    public partial class WizardPage2 : PageFunction<WizardResult>
    {
        public WizardPage2(WizardData wizardData)
        {
            InitializeComponent();

            // Bind wizard state to UI
            DataContext = wizardData;

            nextButton.IsEnabled = wizardData.IsSignedIn;
        }

        protected async override void Start()
        {
            base.Start();

            // Automatically sign in.
            if (!(DataContext as WizardData).IsSignedIn)
            {
                await SignInAsync();
            }
        }

        private async void signInButton_Click(object sender, RoutedEventArgs e)
        {
            await SignInAsync();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to previous wizard page
            NavigationService?.GoBack();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateNext();
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

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void NavigateNext()
        {
            // Go to next wizard page
            var wizardPage3 = new WizardPage3((WizardData)DataContext);
            wizardPage3.Return += wizardPage_Return;
            NavigationService?.Navigate(wizardPage3);
        }

        private async Task SignInAsync()
        {
            Mouse.OverrideCursor = Cursors.Wait;

            var devAccount = await GetDevAccountAsync();
            await InitializeStoreData(devAccount);
            nextButton.IsEnabled = (DataContext as WizardData).IsSignedIn;

            Mouse.OverrideCursor = null;

            // Auto-navigate to next page, if successful.
            if (devAccount != null && (DataContext as WizardData).IsSignedIn)
            {
                NavigateNext();
            }
        }

        private async Task<DevAccount> GetDevAccountAsync()
        {
            try
            {
                var devAccount = await ToolAuthentication.SignInAsync(DevAccountSource.WindowsDevCenter, string.Empty);
                (DataContext as WizardData).IsSignedIn = true;
                return devAccount;
            }
            catch
            {
                return null;
            }
        }

        private async Task InitializeStoreData(DevAccount devAccount)
        {
            if (devAccount == null)
            {
                return;
            }

            var wizardData = DataContext as WizardData;

            var storeDataList = new SortedList<string, StoreData>();
            var accountId = devAccount.AccountId;
            var accountIdAsGuid = Guid.Parse(accountId);

            ConfigResponse<IEnumerable<Product>> getProductsResult = null;
            ConfigResponse<IEnumerable<string>> getSandboxIdsResult = null;
            string errorMessage = "";
            try
            {
                // Load products from MPC
                getProductsResult = await ConfigurationManager.GetProductsAsync(accountIdAsGuid);
            }
            catch (HttpRequestException ex)
            {
                errorMessage += string.Format("Unable to load products from Microsoft Partner Center. Please ensure that you have the necessary permissions to Microsoft Partner Center to load product details. ({0})", ex.Message);
            }

            try
            {
                // Load sandboxes from MPC
                getSandboxIdsResult = await ConfigurationManager.GetSandboxesAsync(accountIdAsGuid);
            }
            catch (HttpRequestException ex)
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    errorMessage += "\n\n";
                }
                errorMessage += string.Format("Unable to load sandbox ids from Microsoft Partner Center. Please ensure that you have the 'Sandboxes' permission in Microsoft Partner Center. ({0})", ex.Message);
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                wizardData.ErrorMessage = errorMessage;
                OnReturn(new ReturnEventArgs<WizardResult>(WizardResult.Error));
                return;
            }

            foreach (Product product in getProductsResult.Result)
            {
                var storeData = new StoreData();

                storeData.PackageDisplayName = product.ProductName;
                var index = product.PfnId.IndexOf('_');
                if (index >= 0)
                {
                    storeData.PackageName = product.PfnId.Substring(0, index);
                }
                else
                {
                    storeData.PackageName = product.PfnId;
                }
                if (product.BoundTitleId != null)
                {
                    ConfigResponse<Product> getPrimaryProductResult = null;
                    // Look up the primary product
                    try
                    {
                        getPrimaryProductResult = await ConfigurationManager.GetProductAsync(product.BoundTitleId);
                        Product primaryBoundProduct = getPrimaryProductResult.Result;
                        storeData.TitleId = primaryBoundProduct.TitleId.ToString("X").ToUpperInvariant();
                        storeData.Scid = primaryBoundProduct.PrimaryServiceConfigId;
                    }
                    catch (HttpRequestException ex)
                    {
                        errorMessage += string.Format("Unable to retrieve bound primary products from Microsoft Partner Center. Please ensure that you have the necessary permissions to Microsoft Partner Center to load product details. ({0})", ex.Message);
                    }
                }
                else
                {
                    storeData.TitleId = product.TitleId.ToString("X").ToUpperInvariant();
                    storeData.Scid = product.PrimaryServiceConfigId;
                }
                storeData.MSAAppId = product.MsaAppId;
                storeData.StoreId = product.AlternateIds.First().Value;

                // TODO: Set the following properties when they become exposed.
                storeData.PublisherId = "";
                storeData.PublisherDisplayName = "";
                storeData.Version = "";

                storeDataList.Add(storeData.StoreDataKey, storeData);
            }

            (DataContext as WizardData).StoreData = storeDataList;
            (DataContext as WizardData).SandboxIds = new List<string>(getSandboxIdsResult.Result);
            (DataContext as WizardData).StoreDataKey = null;
        }
    }
}