using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    public static unsafe partial class Social
    {
        [DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialSubscribeToSocialRelationshipChange([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("uint64_t")] ulong xboxUserId, [NativeTypeName("XblRealTimeActivitySubscriptionHandle *")] IntPtr* subscriptionHandle);

        [DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialUnsubscribeFromSocialRelationshipChange([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("XblRealTimeActivitySubscriptionHandle")] IntPtr subscriptionHandle);
    }
}
