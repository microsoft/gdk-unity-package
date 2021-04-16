// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.Xml;

namespace ManifestEditor
{
    public class EditorData
    {
        public string GameConfigFilePath { get; set; }
        public XmlDocument GameConfig { get; set; }
        public bool IsNewConfig { get; set; }
        public GameEngine GameEngine { get; set; }
        public string PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string ImageFileName { get; set; }
        public bool IsMultiplayer { get; set; }
        public bool CanSave { get; set; }
        public string DefaultImageFilePath { get; set; }
    }
}
