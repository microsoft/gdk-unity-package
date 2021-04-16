using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    partial class XblInterop
    {
        //STDAPI XblProfileGetUserProfileAsync(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_ uint64_t xboxUserId,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblProfileGetUserProfileAsync(
            XblContextHandle xblContextHandle,
            UInt64 xboxUserId,
            XAsyncBlockPtr async);

        //STDAPI XblProfileGetUserProfileResult(
        //    _In_ XAsyncBlock* async,
        //    _Out_ XblUserProfile* profile
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblProfileGetUserProfileResult(
            XAsyncBlockPtr async,
            out XblUserProfile profile);

        //STDAPI XblProfileGetUserProfilesAsync(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_ uint64_t* xboxUserIds,
        //    _In_ size_t xboxUserIdsCount,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblProfileGetUserProfilesAsync(
            XblContextHandle xblContextHandle,
            UInt64[] xboxUserIds,
            SizeT xboxUserIdsCount,
            XAsyncBlockPtr async);

        //STDAPI XblProfileGetUserProfilesResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* profileCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblProfileGetUserProfilesResultCount(
            XAsyncBlockPtr async,
            out SizeT profileCount);

        //STDAPI XblProfileGetUserProfilesResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t profilesCount,
        //    _Out_writes_(profilesCount) XblUserProfile* profiles
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblProfileGetUserProfilesResult(
            XAsyncBlockPtr async,
            SizeT profilesCount,
            [Out] XblUserProfile[] profiles);

        //STDAPI XblProfileGetUserProfilesForSocialGroupAsync(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_z_ const char* socialGroup,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblProfileGetUserProfilesForSocialGroupAsync(
            XblContextHandle xblContextHandle,
            Byte[] socialGroup,
            XAsyncBlockPtr async);

        //STDAPI XblProfileGetUserProfilesForSocialGroupResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* profileCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblProfileGetUserProfilesForSocialGroupResultCount(
            XAsyncBlockPtr async,
            out SizeT profileCount);

        //STDAPI XblProfileGetUserProfilesForSocialGroupResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t profilesCount,
        //    _Out_writes_(profilesCount) XblUserProfile* profiles
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblProfileGetUserProfilesForSocialGroupResult(
            XAsyncBlockPtr async,
            SizeT profilesCount,
            [Out] XblUserProfile[] profiles);
    }
}
