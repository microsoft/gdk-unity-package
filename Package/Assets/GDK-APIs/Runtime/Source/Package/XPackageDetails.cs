using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XPackageDetails
    {
        internal XPackageDetails(Interop.XPackageDetails interopStruct)
        {
            this.PackageIdentifier = interopStruct.packageIdentifier.GetString();
            this.Version = new XVersion(interopStruct.version);
            this.Kind = interopStruct.kind;
            this.DisplayName = interopStruct.displayName.GetString();
            this.Description = interopStruct.description.GetString();
            this.Publisher = interopStruct.publisher.GetString();
            this.StoreId = interopStruct.storeId.GetString();
            this.Installing = interopStruct.installing.Value;
            this.Index = interopStruct.index;
            this.Count = interopStruct.count;
        }

        public string PackageIdentifier { get; private set; }
        public XVersion Version { get; private set; }
        public XPackageKind Kind { get; private set; }
        public string DisplayName { get; private set; }
        public string Description { get; private set; }
        public string Publisher { get; private set; }
        public string StoreId { get; private set; }
        public bool Installing { get; private set; }
        public UInt32 Index { get; private set; }
        public UInt32 Count { get; private set; }
    }
}