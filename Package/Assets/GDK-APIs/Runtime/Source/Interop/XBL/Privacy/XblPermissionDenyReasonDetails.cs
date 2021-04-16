using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblPermissionDenyReasonDetails
    //{
    //    XblPermissionDenyReason reason;
    //    XblPrivilege restrictedPrivilege;
    //    XblPrivacySetting restrictedPrivacySetting;
    //} XblPermissionDenyReasonDetails;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblPermissionDenyReasonDetails
    {
        internal readonly XblPermissionDenyReason reason;
        internal readonly XblPrivilege restrictedPrivilege;
        internal readonly XblPrivacySetting restrictedPrivacySetting;

        internal XblPermissionDenyReasonDetails(XGamingRuntime.XblPermissionDenyReasonDetails publicObject)
        {
            this.reason = publicObject.Reason;
            this.restrictedPrivilege = publicObject.RestrictedPrivilege;
            this.restrictedPrivacySetting = publicObject.RestrictedPrivacySetting;
        }
    }
}