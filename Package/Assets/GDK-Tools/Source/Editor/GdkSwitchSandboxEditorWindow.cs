// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.GameCore.Utilities;
using UnityEditor;
using UnityEngine;

namespace Microsoft.GameCore.Tools
{
    public class GdkSwitchSandboxEditorWindow : EditorWindow
    {
        private int selectedSandboxIndex;
        private string[] sandboxOptions;
        private string currentSandboxId;
        private List<string> availableSandboxes;
        private bool initialized;
        private string operationsSummary;

        private const string RETAIL_SANDBOX_ID = "RETAIL";

        private void Initialize()
        {
            Vector2 scrollPos = Vector2.zero;
            Vector2 scenesScrollPos = Vector2.zero;

            EditorStyles.textArea.wordWrap = true;

            initialized = true;
        }

        private void OnEnable()
        {
            RefreshSwitchSandboxDropdownOptions();
        }

        void OnGUI()
        {
            if (!initialized)
            {
                Initialize();
            }

            EditorGUI.indentLevel = 1;

            GdkEditorHelpers.SectionSeperator();

            // TODO: Figure out if their stuff has been published to their sandbox, specifically is there enough data so
            // they can successfully sign in. If not, let's provide that.
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("Select your development sandbox from the list below and click the Switch Sandbox button to switch your PC to that sandbox. You can always switch back to normal by selecting RETAIL from the dropdown and clicking the Switch Sandbox button.", EditorStyles.wordWrappedLabel);
            GdkEditorHelpers.SectionSeperator();

            EditorGUILayout.LabelField("Current Sandbox: " + currentSandboxId);
            if (sandboxOptions != null &&
                sandboxOptions.Length > 0)
            {
                this.selectedSandboxIndex = EditorGUILayout.Popup("Sandbox", selectedSandboxIndex, sandboxOptions);
            }

            GUI.enabled = availableSandboxes != null && availableSandboxes.Count > 0;
            if (GUILayout.Button("Switch Sandbox"))
            {
                try
                {
                    string sandboxId = sandboxOptions[selectedSandboxIndex];
                    SetSandbox(sandboxId);
                }
                catch (Exception ex)
                {
                    UnityEngine.Debug.Log(ex.Message);
                }
            }
            GUI.enabled = true;

            // Render error if there are no sandboxes available to switch to.
            if (availableSandboxes == null || availableSandboxes.Count == 0 || (availableSandboxes.Count == 1 && availableSandboxes[0].Equals(RETAIL_SANDBOX_ID)))
            {
                var style = new GUIStyle();
                style.normal.textColor = Color.red;
                style.wordWrap = true;
                EditorGUILayout.LabelField("Error: Could not retrieve sandboxes. Have you run the store association wizard?", style);
                if (GUILayout.Button("Open Store Association Wizard"))
                {
                    GdkPlugin.EditGameConfig();
                }
            }

            GdkEditorHelpers.SectionSeperator();

            EditorGUILayout.LabelField("Launch the Microsoft Store and the Xbox app in the current sandbox mode. Sandbox mode will allow you to see how your title loads in these apps. To return to normal, switch your sandbox to RETAIL and click the Launch Apps button.", EditorStyles.wordWrappedLabel);

            GdkEditorHelpers.SectionSeperator();

            if (GUILayout.Button("Launch Apps"))
            {
                try
                {
                    XblPCSandbox.XblPCSandbox.RestartApps();
                    operationsSummary = "Successfully launched system apps in the current sandbox mode.";
                }
                catch (Exception ex)
                {
                    operationsSummary = "Failed to launch system apps in the current sandbox mode.\n\n" + ex.Message;
                    UnityEngine.Debug.Log(ex.Message);
                }
            }

            GdkEditorHelpers.SectionSeperator();

            EditorGUILayout.LabelField(operationsSummary, EditorStyles.wordWrappedLabel);
        }

        private void RefreshSwitchSandboxDropdownOptions()
        {
            currentSandboxId = XblPCSandbox.XblPCSandbox.GetSandbox();
            availableSandboxes = GetAvailableSandboxes();
            // We remove the sandbox the developer is currently in from the list of sandboxes because it doesn't
            // make sense for the developer to switch to a sandbox they are already in.
            availableSandboxes.Remove(currentSandboxId);
            sandboxOptions = availableSandboxes.ToArray();

            // If the developer is currently in a dev sandbox, then default to RETAIL.
            if (currentSandboxId != RETAIL_SANDBOX_ID)
            {
                selectedSandboxIndex = availableSandboxes.IndexOf(RETAIL_SANDBOX_ID);
            }
            else
            {
                selectedSandboxIndex = 0;
            }
        }

        private bool SetSandbox(string sandboxId)
        {
            string arguments = sandboxId + " /noApps";
            string workingDirectory = System.IO.Path.Combine(GdkUtilities.RootPluginPath, @"GDK-Tools\Source\Tools\SandboxSwitcher\");

            var processStartInfo = new ProcessStartInfo(workingDirectory + "XBLPCSandbox.exe");
            processStartInfo.Arguments = arguments;
            processStartInfo.Verb = "runas";
            processStartInfo.WorkingDirectory = workingDirectory;
            processStartInfo.CreateNoWindow = true;

            try
            {
                var process = Process.Start(processStartInfo);
                process.WaitForExit();
                process.Close();

                currentSandboxId = XblPCSandbox.XblPCSandbox.GetSandbox();
                if (!sandboxId.Equals(currentSandboxId))
                {
                    throw new Exception("Requested sandbox != current sandbox.\nRequested sandbox - " + sandboxId + "\nCurrent sandbox - " + currentSandboxId);
                }
                RefreshSwitchSandboxDropdownOptions();

                operationsSummary = "Successfully set the sandbox to " + currentSandboxId;
            }
            catch (Exception e)
            {
                operationsSummary = "Failed to set the sandbox to " + sandboxId + "\n\n" + e.Message;
                GdkEditorHelpers.LogError(e.Message);
                return false;
            }

            return true;
        }

        private List<string> GetAvailableSandboxes()
        {
            List<string> sandboxes = new List<string>();
            sandboxes.Add(RETAIL_SANDBOX_ID);

            XDocument gameConfigXmlDoc = XDocument.Load(GdkUtilities.GameConfigPath);
            try
            {
                XElement extendedAttributesEl = (from extendedAttributeList in gameConfigXmlDoc.Descendants("ExtendedAttributeList")
                                                 select extendedAttributeList).First();
                XElement extendedAttributeSandboxEl = (from extendedAttribute in extendedAttributesEl.Descendants("ExtendedAttribute")
                                                .Where(x => x.Attribute("Name").Value == "SandboxIds")
                                                       select extendedAttribute).First();
                string sandboxesRawValue = extendedAttributeSandboxEl.Attribute("Value").Value;
                string[] sandboxesAsStringArray = sandboxesRawValue.Split(',');
                sandboxes.AddRange(sandboxesAsStringArray);

                selectedSandboxIndex = sandboxes.IndexOf(currentSandboxId);
            }
            catch (Exception)
            {
                // TODO: Prompt them to run the store association wizard if the element is missing.
                GdkEditorHelpers.LogError("Error: Could not retrieve sandboxes. Have you run the store association wizard?");
            }

            return sandboxes;
        }
    }
}