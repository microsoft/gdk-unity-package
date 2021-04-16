using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblPermissionCheckResult
    {
        internal XblPermissionCheckResult(Interop.XblPermissionCheckResult interopStruct)
        {
            this.IsAllowed = interopStruct.isAllowed.Value;
            this.TargetXuid = interopStruct.targetXuid;
            this.TargetUserType = interopStruct.targetUserType;
            this.PermissionRequested = interopStruct.permissionRequested;
            this.Reasons = interopStruct.GetReasons(x =>new XblPermissionDenyReasonDetails(x));
        }

        public bool IsAllowed { get; private set; }
        public UInt64 TargetXuid { get; private set; }
        public XblAnonymousUserType TargetUserType { get; private set; }
        public XblPermission PermissionRequested { get; private set; }
        public XblPermissionDenyReasonDetails[] Reasons { get; private set; }
    }
}