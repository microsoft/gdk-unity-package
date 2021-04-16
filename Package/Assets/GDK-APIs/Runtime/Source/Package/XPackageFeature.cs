using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XPackageFeature
    {
        internal XPackageFeature(Interop.XPackageFeature interopStruct)
        {
            this.Id = interopStruct.id.GetString();
            this.DisplayName = interopStruct.displayName.GetString();
            this.Tags = interopStruct.tags.GetString();
            this.Hidden = interopStruct.hidden.Value;
        }

        public string Id { get; private set; }
        public string DisplayName { get; private set; }
        public string Tags { get; private set; }
        public bool Hidden { get; private set; }
    }
}