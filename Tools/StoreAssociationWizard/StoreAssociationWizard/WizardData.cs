// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml;

namespace Wizard
{
    /// <summary>
    ///     Data that is collected by the wizard
    /// </summary>
    public class WizardData
    {
        public string GameConfigFilePath { get; set; }
        public XmlDocument GameConfig { get; set; }
        public bool IsNewConfig { get; set; }
        public bool IsSignedIn { get; set; }
        public SortedList<string, StoreData> StoreData { get; set; }
        public List<string> SandboxIds { get; set; }
        public string StoreDataKey { get; set; }
        public string ErrorMessage { get; set; }
    }
}