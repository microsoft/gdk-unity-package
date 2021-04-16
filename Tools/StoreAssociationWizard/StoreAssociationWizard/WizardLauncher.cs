// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Windows.Navigation;
using System.Xml;

namespace Wizard
{
    public class WizardLauncher : PageFunction<WizardResult>
    {
        private readonly WizardData _wizardData = new WizardData();
        public event WizardReturnEventHandler WizardReturn;

        protected override void Start()
        {
            base.Start();

            // So we remember the WizardCompleted event registration
            KeepAlive = true;

            if (Environment.GetCommandLineArgs().Length != 2)
            {
                _wizardData.ErrorMessage = "Usage:  StoreAssociationWizard.exe <config file path>";
                WizardReturn?.Invoke(this, new WizardReturnEventArgs(WizardResult.Error, _wizardData));
            }

            try
            {
                _wizardData.GameConfigFilePath = Path.GetFullPath(Environment.GetCommandLineArgs()[1]);
            }
            catch
            {
                _wizardData.ErrorMessage = $"Problem with path '{Environment.GetCommandLineArgs()[1]}'";
                WizardReturn?.Invoke(this, new WizardReturnEventArgs(WizardResult.Error, _wizardData));
            }

            if (!File.Exists(_wizardData.GameConfigFilePath))
            {
                _wizardData.IsNewConfig = true;
            }
            else
            {
                try
                {
                    _wizardData.GameConfig = new XmlDocument();
                    _wizardData.GameConfig.Load(_wizardData.GameConfigFilePath);
                }
                catch (XmlException)
                {
                    _wizardData.ErrorMessage = $"Invalid XML in '{Environment.GetCommandLineArgs()[1]}'";
                    WizardReturn?.Invoke(this, new WizardReturnEventArgs(WizardResult.Error, _wizardData));
                }
                catch (IOException)
                {
                    _wizardData.ErrorMessage = $"Unable to open '{Environment.GetCommandLineArgs()[1]}'";
                    WizardReturn?.Invoke(this, new WizardReturnEventArgs(WizardResult.Error, _wizardData));
                }
            }

            // Launch the wizard
            var wizardPage1 = new WizardPage1(_wizardData);
            wizardPage1.Return += wizardPage_Return;
            NavigationService?.Navigate(wizardPage1);
        }

        public void wizardPage_Return(object sender, ReturnEventArgs<WizardResult> e)
        {
            // Notify client that wizard has completed
            // NOTE: We need this custom event because the Return event cannot be
            // registered by window code - if WizardDialogBox registers an event handler with
            // the WizardLauncher's Return event, the event is not raised.
            WizardReturn?.Invoke(this, new WizardReturnEventArgs(e.Result, _wizardData));
            OnReturn(null);
        }
    }
}