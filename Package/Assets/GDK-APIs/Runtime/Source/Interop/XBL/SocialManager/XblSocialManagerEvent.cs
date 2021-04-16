using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblSocialManagerEvent
    // {
    //     XblUserHandle user;
    //     XblSocialManagerEventType eventType;
    //     HRESULT hr;
    //     XblSocialManagerUserGroupHandle groupAffected;
    //     XblSocialManagerUser* usersAffected[XBL_SOCIAL_MANAGER_MAX_AFFECTED_USERS_PER_EVENT];
    // } XblSocialManagerEvent;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblSocialManagerEvent
    {
        internal readonly XUserHandle user;
        internal readonly XblSocialManagerEventType eventType;
        internal readonly Int32 hr;
        internal readonly XblSocialManagerUserGroupHandle loadedGroup;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_SOCIAL_MANAGER_MAX_AFFECTED_USERS_PER_EVENT)]
        internal readonly IntPtr[] usersAffected;

        internal XblSocialManagerUser[] GetUserArray()
        {
            var ret = new List<XblSocialManagerUser>();
            foreach(var structPtr in usersAffected)
            {
                if (structPtr != IntPtr.Zero)
                {
                    ret.Add((XblSocialManagerUser)Marshal.PtrToStructure(structPtr, typeof(XblSocialManagerUser)));
                }
                else
                {
                    break;
                }
            }

            return ret.ToArray();
        }
    }
}
