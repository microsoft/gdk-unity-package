// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.Xml;

namespace ManifestEditor
{
    public static class XmlDocumentExtensions
    {
        public static string GetNodeValue(this XmlDocument doc, string nodePath)
        {
            var node = doc.SelectSingleNode(nodePath);

            if (node == null)
            {
                return string.Empty;
            }

            return node.InnerText.Trim();
        }

        public static string GetAttributeValue(this XmlDocument doc, string nodePath, string attributeName)
        {
            var node = doc.SelectSingleNode($"{nodePath}[@{attributeName}]");

            if (node == null)
            {
                return string.Empty;
            }

            return node.Attributes.GetNamedItem(attributeName).Value.Trim();
        }

        public static bool IsValidNode(this XmlDocument doc, string nodePath)
        {
            return !string.IsNullOrWhiteSpace(doc.GetNodeValue(nodePath));
        }

        public static bool IsValidAttribute(this XmlDocument doc, string nodePath, string attributeName)
        {
            return !string.IsNullOrWhiteSpace(doc.GetAttributeValue(nodePath, attributeName));
        }

        public static void CreateOrUpdateAttribute(this XmlDocument doc, string nodePath, string attributeName, string attributeValue)
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

        public static void CreateOrUpdateNode(this XmlDocument doc, string nodePath, string nodeValue)
        {
            var node = doc.SelectSingleNode(nodePath);

            if (node == null)
            {
                node = GetOrCreateNodeRecursive(doc, nodePath);
            }

            node.InnerText = nodeValue;
        }

        public static XmlNode GetOrCreateNodeRecursive(this XmlDocument doc, string nodePath)
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
    }
}
