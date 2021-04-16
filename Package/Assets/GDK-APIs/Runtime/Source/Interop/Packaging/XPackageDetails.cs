using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XPackageDetails
    //{
    //    _Field_z_ const char* packageIdentifier;
    //    XVersion version;
    //    XPackageKind kind;
    //    _Field_z_ const char* displayName;
    //    _Field_z_ const char* description;
    //    _Field_z_ const char* publisher;
    //    _Field_z_ const char* storeId;
    //    bool installing;
    //    uint32_t index;
    //    uint32_t count;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XPackageDetails
    {
        internal readonly UTF8StringPtr packageIdentifier;
        internal readonly XVersion version;
        internal readonly XPackageKind kind;
        internal readonly UTF8StringPtr displayName;
        internal readonly UTF8StringPtr description;
        internal readonly UTF8StringPtr publisher;
        internal readonly UTF8StringPtr storeId;
        internal readonly NativeBool installing;
        internal readonly UInt32 index;
        internal readonly UInt32 count;

        internal XPackageDetails(XGamingRuntime.XPackageDetails publicObject, DisposableCollection disposableCollection)
        {
            this.packageIdentifier = new UTF8StringPtr(publicObject.PackageIdentifier, disposableCollection);
            this.version = new XVersion(publicObject.Version);
            this.kind = publicObject.Kind;
            this.displayName = new UTF8StringPtr(publicObject.DisplayName, disposableCollection);
            this.description = new UTF8StringPtr(publicObject.Description, disposableCollection);
            this.publisher = new UTF8StringPtr(publicObject.Publisher, disposableCollection);
            this.storeId = new UTF8StringPtr(publicObject.StoreId, disposableCollection);
            this.installing = new NativeBool(publicObject.Installing);
            this.index = publicObject.Index;
            this.count = publicObject.Count;
        }
    }
}