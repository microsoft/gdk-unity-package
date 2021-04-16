// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Navigation;
using System.Xml;
using System.Xml.Serialization;

namespace Wizard
{
    public partial class WizardPage4 : PageFunction<WizardResult>
    {
        private const string ShellVisualsNodePath = "/Game/ShellVisuals";
        private const string DefaultDisplayNameAttr = "DefaultDisplayName";
        private const string ExecutableNodePath = "/Game/ExecutableList/Executable";
        private const string OverrideDisplayNameAttr = "OverrideDisplayName";
        private const string IdentityNodePath = "/Game/Identity";
        private const string NameAttr = "Name";
        private const string StoreIdNodePath = "/Game/StoreId";
        private const string MSAAppIdNodePath = "/Game/MSAAppId";
        private const string TitleIdNodePath = "/Game/TitleId";
        private const string ExtendedAttributeListNodePath = "/Game/ExtendedAttributeList";
        private const string ExtendedAttributeNode = "ExtendedAttribute";
        private const string ScidNodePath = "/Game/ExtendedAttributeList/ExtendedAttribute[@Name='Scid']";
        private const string SandboxIdsNodePath = "/Game/ExtendedAttributeList/ExtendedAttribute[@Name='SandboxIds']";
        private const string ScidName = "Scid";
        private const string SandboxIdsName = "SandboxIds";

        public WizardPage4(WizardData wizardData)
        {
            InitializeComponent();

            // Bind wizard state to UI
            DataContext = wizardData;

            var storeData = wizardData.StoreData[wizardData.StoreDataKey];

            txtPackageDisplayName.Text = storeData.PackageDisplayName;
            txtPackageName.Text = storeData.PackageName;
            txtMsaAppId.Text = storeData.MSAAppId;
            txtStoreId.Text = storeData.StoreId;
            txtTitleId.Text = storeData.TitleId;
            txtScid.Text = storeData.Scid.ToString();
            txtSandboxIds.Text = string.Join(",", wizardData.SandboxIds);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to previous wizard page
            NavigationService?.GoBack();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cancel the wizard and don't return any data
            OnReturn(new ReturnEventArgs<WizardResult>(WizardResult.Canceled));
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as WizardData).IsNewConfig)
            {
                CreateGameConfig();
            }
            else
            {
                UpdateGameConfig();
            }

            // Finish the wizard and return bound data to calling page
            OnReturn(new ReturnEventArgs<WizardResult>(WizardResult.Finished));
        }

        private void CreateGameConfig()
        {
            var gameConfig = new Game();
            var wizardData = DataContext as WizardData;
            var storeData = wizardData.StoreData[wizardData.StoreDataKey];

            gameConfig.configVersion = "0";
            gameConfig.ShellVisuals = new CT_ShellVisuals();
            gameConfig.ShellVisuals.DefaultDisplayName = storeData.PackageDisplayName;
            // TODO: Wait on Zach's verdict for OverrideDisplayName.
            ////gameConfig.ExecutableList.Executable[0].OverrideDisplayName = storeData.PackageDisplayName;
            gameConfig.Identity = new CT_Identity();
            gameConfig.Identity.Name = storeData.PackageName;
            gameConfig.Identity.Publisher = "Default Publisher";
            gameConfig.StoreId = storeData.StoreId;
            gameConfig.MSAAppId = storeData.MSAAppId;
            gameConfig.TitleId = storeData.TitleId;
            gameConfig.ExtendedAttributeList = new CT_ExtendedAttributeList();
            gameConfig.ExtendedAttributeList.ExtendedAttribute = new CT_ExtendedAttributeListExtendedAttribute[0];

            var extendedAttributes = new List<CT_ExtendedAttributeListExtendedAttribute>(gameConfig.ExtendedAttributeList.ExtendedAttribute);
            extendedAttributes.Add(new CT_ExtendedAttributeListExtendedAttribute
            {
                Name = SandboxIdsName,
                Value = string.Join(",", wizardData.SandboxIds)
            });
            extendedAttributes.Add(new CT_ExtendedAttributeListExtendedAttribute
            {
                Name = ScidName,
                Value = string.Join(",", storeData.Scid)
            });

            gameConfig.ExtendedAttributeList.ExtendedAttribute = extendedAttributes.ToArray();

            try
            {
                using (FileStream fs = new FileStream(wizardData.GameConfigFilePath, FileMode.Create, FileAccess.Write))
                {
                    new XmlSerializer(typeof(Game)).Serialize(fs, gameConfig);
                }
            }
            catch
            {
                wizardData.ErrorMessage = "Unable to save config file";
                OnReturn(new ReturnEventArgs<WizardResult>(WizardResult.Error));
            }
        }

        private void UpdateGameConfig()
        {
            var wizardData = DataContext as WizardData;
            var storeData = wizardData.StoreData[wizardData.StoreDataKey];
            var gameConfigFilePath = wizardData.GameConfigFilePath;
            var gameConfig = wizardData.GameConfig;

            CreateOrUpdateAttribute(gameConfig, ShellVisualsNodePath, DefaultDisplayNameAttr, storeData.PackageDisplayName);
            // TODO: Wait on Zach's verdict for OverrideDisplayName.
            //UpdateOverrideDisplayName(gameConfig);
            CreateOrUpdateAttribute(gameConfig, IdentityNodePath, NameAttr, storeData.PackageName);
            CreateOrUpdateNode(gameConfig, StoreIdNodePath, storeData.StoreId);
            CreateOrUpdateNode(gameConfig, MSAAppIdNodePath, storeData.MSAAppId);
            CreateOrUpdateNode(gameConfig, TitleIdNodePath, storeData.TitleId);
            CreateOrUpdateExtendedAttributes(gameConfig, ScidNodePath, ScidName, storeData.Scid.ToString());
            CreateOrUpdateExtendedAttributes(gameConfig, SandboxIdsNodePath, SandboxIdsName, string.Join(",", wizardData.SandboxIds));

            try
            {
                gameConfig.Save(gameConfigFilePath);
            }
            catch
            {
                wizardData.ErrorMessage = "Unable to save config file";
                OnReturn(new ReturnEventArgs<WizardResult>(WizardResult.Error));
            }
        }

        private static void UpdateOverrideDisplayName(XmlDocument gameConfig)
        {
            CreateOrUpdateAttribute(gameConfig, ExecutableNodePath, OverrideDisplayNameAttr, "OverrideDisplayName");
        }

        private static void CreateOrUpdateAttribute(XmlDocument doc, string nodePath, string attributeName, string attributeValue)
        {
            var node = doc.SelectSingleNode(nodePath);

            if (node == null)
            {
                node = GetOrCreateNodeRecursive(doc, nodePath);
            }

            XmlAttribute attribute = (XmlAttribute)node.Attributes.GetNamedItem(attributeName);

            if (attribute == null)
            {
                attribute = node.Attributes.Append(doc.CreateAttribute(attributeName));
            }

            attribute.Value = attributeValue;
        }

        private static void CreateOrUpdateNode(XmlDocument doc, string nodePath, string nodeValue)
        {
            var node = doc.SelectSingleNode(nodePath);

            if (node == null)
            {
                node = GetOrCreateNodeRecursive(doc, nodePath);
            }

            node.InnerText = nodeValue;
        }

        private static XmlNode GetOrCreateNodeRecursive(XmlDocument doc, string nodePath)
        {
            var node = doc.SelectSingleNode(nodePath);

            if (node == null)
            {
                node = doc.CreateNode(XmlNodeType.Element, nodePath.Substring(nodePath.LastIndexOf('/') + 1), string.Empty);

                var parent = doc.SelectSingleNode(nodePath.Substring(0, nodePath.LastIndexOf('/')));

                if (parent == null)
                {
                    parent = GetOrCreateNodeRecursive(doc, nodePath.Substring(0, nodePath.LastIndexOf('/')));
                }

                parent.AppendChild(node);
            }

            return node;
        }

        private static void CreateOrUpdateExtendedAttributes(XmlDocument doc, string nodePath, string nodeName, string extendedAttributeValue)
        {
            var node = doc.SelectSingleNode(nodePath);

            if (node == null)
            {
                var parent = GetOrCreateNodeRecursive(doc, ExtendedAttributeListNodePath);
                node = doc.CreateNode(XmlNodeType.Element, ExtendedAttributeNode, string.Empty);
                node.Attributes.Append(doc.CreateAttribute("Name")).Value = nodeName;
                parent.AppendChild(node);
            }

            XmlAttribute attribute = (XmlAttribute)node.Attributes.GetNamedItem("Value");

            if (attribute == null)
            {
                attribute = node.Attributes.Append(doc.CreateAttribute("Value"));
            }

            attribute.Value = extendedAttributeValue;
        }
    }
}