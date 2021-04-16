// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard
{
    /// <summary>
    ///     Data that is downloaded from 
    /// </summary>
    public class StoreData
    {
        public string PackageDisplayName { get; set; }
        public string PackageName { get; set; }
        public string PublisherId { get; set; }
        public string PublisherDisplayName { get; set; }
        public string Version { get; set; }
        public string TitleId { get; set; }
        public string MSAAppId { get; set; }
        public string StoreId { get; set; }
        public Guid Scid { get; set; }
        public string StoreDataKey { get { return $"{PackageDisplayName}_{PackageName}"; } }
    }
}
