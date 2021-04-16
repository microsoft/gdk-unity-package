using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStorePackageUpdate
    {
        internal XStorePackageUpdate(Interop.XStorePackageUpdate interopStruct)
        {
            this.PackageIdentifier = interopStruct.GetPackageIdentifier();
            this.IsMandatory = interopStruct.isMandatory.Value;
        }

        public string PackageIdentifier { get; private set; }
        public bool IsMandatory { get; private set; }
    }
}