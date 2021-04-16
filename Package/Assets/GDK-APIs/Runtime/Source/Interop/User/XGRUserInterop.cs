using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef void CALLBACK XUserChangeEventCallback(
    //     _In_opt_ void* context,
    //     _In_ XUserLocalId userLocalId,
    //     _In_ XUserChangeEvent event
    //     );
    internal delegate void XUserChangeEventCallback(IntPtr context, XUserLocalId userLocalId, XUserChangeEvent eventType);

    // Interop definitions for functions defined in XUser.h
    partial class XGRInterop
    {
        // STDAPI XUserDuplicateHandle(
        //     _In_ XUserHandle handle,
        //     _Out_ XUserHandle* duplicatedHandle
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserDuplicateHandle(XUserHandle handle, out XUserHandle duplicatedHandle);

        // STDAPI_(void) XUserCloseHandle(
        //     _In_ XUserHandle user
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XUserCloseHandle(XUserHandle user);

        // STDAPI_(int32_t) XUserCompare(
        //     _In_ XUserHandle user1,
        //     _In_ XUserHandle user2
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserCompare(XUserHandle user1, XUserHandle user2);

        // STDAPI XUserGetMaxUsers(
        //     _Out_ uint32_t* maxUsers
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetMaxUsers(out UInt32 maxUsers);

        // STDAPI XUserAddAsync(
        //     _In_ XUserAddOptions options,
        //     _Inout_ XAsyncBlock* async
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserAddAsync(XUserAddOptions addOptions, XAsyncBlockPtr asyncBlock);

        // STDAPI XUserAddResult(
        //     _Inout_ XAsyncBlock* async,
        //     _Out_ XUserHandle* newUser
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserAddResult(XAsyncBlockPtr asyncBlock, out XUserHandle newUser);

        // STDAPI XUserGetId(
        //     _In_ XUserHandle user,
        //     _Out_ uint64_t* userId
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetId(XUserHandle user, out UInt64 userId);

        // STDAPI XUserFindUserById(
        //     _In_ uint64_t userId,
        //     _Out_ XUserHandle* handle
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserFindUserById(UInt64 userId, out XUserHandle handle);

        // STDAPI XUserGetLocalId(
        //     _In_ XUserHandle user,
        //     _Out_ XUserLocalId* userLocalId
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetLocalId(XUserHandle user, out XUserLocalId userId);

        // STDAPI XUserFindUserByLocalId(
        //     _In_ XUserLocalId userLocalId,
        //     _Out_ XUserHandle* handle
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserFindUserByLocalId(XUserLocalId userLocalId, out XUserHandle handle);

        // STDAPI XUserGetIsGuest(
        //     _In_ XUserHandle user,
        //     _Out_ bool* isGuest
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetIsGuest(XUserHandle user, [MarshalAs(UnmanagedType.U1)] out bool isGuest);

        // STDAPI XUserGetState(
        //     _In_ XUserHandle user,
        //     _Out_ XUserState* state
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetState(XUserHandle user, out XUserState state);

        // const size_t XUserGamertagComponentClassicMaxBytes = 16;
        // const size_t XUserGamertagComponentModernMaxBytes = 97;
        // const size_t XUserGamertagComponentModernSuffixMaxBytes = 15;
        // const size_t XUserGamertagComponentUniqueModernMaxBytes = 101;
        public const Int32 XUserGamertagComponentClassicMaxBytes = 16;
        public const Int32 XUserGamertagComponentModernMaxBytes = 97;
        public const Int32 XUserGamertagComponentModernSuffixMaxBytes = 15;
        public const Int32 XUserGamertagComponentUniqueModernMaxBytes = 101;

        // STDAPI XUserGetGamertag(
        //     _In_ XUserHandle user,
        //     _In_ XUserGamertagComponent gamertagComponent,
        //     _In_ size_t gamertagSize,
        //     _Out_writes_bytes_to_(gamertagSize, *gamertagUsed) char* gamertag,
        //     _Out_opt_ size_t* gamertagUsed
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetGamertag(
            XUserHandle user,
            XUserGamertagComponent gamertagComponent,
            SizeT gamertagSize,
            [Out] Byte[] gamertag,
            out SizeT gamertagUsed);

        // STDAPI XUserGetGamerPictureAsync(
        //     _In_ XUserHandle user,
        //     _In_ XUserGamerPictureSize pictureSize,
        //     _Inout_ XAsyncBlock* async
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetGamerPictureAsync(XUserHandle user, XUserGamerPictureSize pictureSize, XAsyncBlockPtr asyncBlock);

        // STDAPI XUserGetGamerPictureResultSize(
        //     _Inout_ XAsyncBlock* async,
        //     _Out_ size_t* bufferSize
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetGamerPictureResultSize(XAsyncBlockPtr asyncBlock, out SizeT bufferSize);

        // STDAPI XUserGetGamerPictureResult(
        //     _Inout_ XAsyncBlock* async,
        //     _In_ size_t bufferSize,
        //     _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //     _Out_opt_ size_t* bufferUsed
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetGamerPictureResult(
            XAsyncBlockPtr asyncBlock,
            SizeT bufferSize,
            [Out] Byte[] buffer,
            out SizeT bufferUsed);

        // STDAPI XUserGetAgeGroup(
        //     _In_ XUserHandle user,
        //     _Out_ XUserAgeGroup* ageGroup
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetAgeGroup(XUserHandle userLocalId, out XUserAgeGroup ageGroup);

        // STDAPI XUserCheckPrivilege(
        //     _In_ XUserHandle user,
        //     _In_ XUserPrivilegeOptions options,
        //     _In_ XUserPrivilege privilege,
        //     _Out_ bool* hasPrivilege,
        //     _Out_opt_ XUserPrivilegeDenyReason* reason
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserCheckPrivilege(
            XUserHandle user,
            XUserPrivilegeOptions options,
            XUserPrivilege privilege,
            [MarshalAs(UnmanagedType.U1)] out bool hasPrivilege,
            out XUserPrivilegeDenyReason reason);

        // STDAPI XUserResolvePrivilegeWithUiAsync(
        //     _In_ XUserHandle user,
        //     _In_ XUserPrivilegeOptions options,
        //     _In_ XUserPrivilege privilege,
        //     _Inout_ XAsyncBlock* async
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserResolvePrivilegeWithUiAsync(
            XUserHandle user,
            XUserPrivilegeOptions options,
            XUserPrivilege privilege,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XUserResolvePrivilegeWithUiResult(
        //     _Inout_ XAsyncBlock* async
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserResolvePrivilegeWithUiResult(XAsyncBlockPtr asyncBlock);

        // STDAPI XUserGetTokenAndSignatureUtf16Async(
        //     _In_ XUserHandle user,
        //     _In_ XUserGetTokenAndSignatureOptions options,
        //     _In_z_ const wchar_t* method,
        //     _In_z_ const wchar_t* url,
        //     _In_ size_t headerCount,
        //     _In_reads_opt_(headerCount) const XUserGetTokenAndSignatureUtf16HttpHeader* headers,
        //     _In_ size_t bodySize,
        //     _In_reads_bytes_opt_(bodySize) const void* bodyBuffer,
        //     _Inout_ XAsyncBlock* async
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetTokenAndSignatureUtf16Async(
            XUserHandle user,
            XUserGetTokenAndSignatureOptions options,
            [MarshalAs(UnmanagedType.LPWStr)] string method,
            [MarshalAs(UnmanagedType.LPWStr)] string url,
            SizeT headerCount,
            [Optional] XUserGetTokenAndSignatureUtf16HttpHeader[] headers,
            SizeT bodySize,
            [Optional] Byte[] body,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XUserGetTokenAndSignatureUtf16ResultSize(
        //     _Inout_ XAsyncBlock* async,
        //     _Out_ size_t* bufferSize
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetTokenAndSignatureUtf16ResultSize(XAsyncBlockPtr asyncBlock, out SizeT bufferSize);

        // STDAPI XUserGetTokenAndSignatureUtf16Result(
        //     _Inout_ XAsyncBlock* async,
        //     _In_ size_t bufferSize,
        //     _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //     _Outptr_ XUserGetTokenAndSignatureUtf16Data** ptrToBuffer,
        //     _Out_opt_ size_t* bufferUsed
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetTokenAndSignatureUtf16Result(
            XAsyncBlockPtr asyncBlock,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr ptrToBuffer,
            out SizeT bufferUsed);

        // STDAPI XUserResolveIssueWithUiUtf16Async(
        //     _In_ XUserHandle user,
        //     _In_opt_z_ const wchar_t* url,
        //     _Inout_ XAsyncBlock* async
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserResolveIssueWithUiUtf16Async(
            XUserHandle user,
            [Optional, MarshalAs(UnmanagedType.LPWStr)] string url,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XUserResolveIssueWithUiUtf16Result(
        //     _Inout_ XAsyncBlock* async
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserResolveIssueWithUiUtf16Result(XAsyncBlockPtr asyncBlock);

        // STDAPI XUserRegisterForChangeEvent(
        //     _In_opt_ XTaskQueueHandle queue,
        //     _In_opt_ void* context,
        //     _In_ XUserChangeEventCallback* callback,
        //     _Out_ XTaskQueueRegistrationToken* token
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserRegisterForChangeEvent(
            XTaskQueueHandle queue,
            IntPtr context,
            XUserChangeEventCallback callback,
            out XTaskQueueRegistrationToken token);

        // STDAPI_(bool) XUserUnregisterForChangeEvent(
        //     _In_ XTaskQueueRegistrationToken token,
        //     _In_ bool wait
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool XUserUnregisterForChangeEvent(XTaskQueueRegistrationToken token, bool wait);

        // STDAPI XUserGetSignOutDeferral(
        //     _Out_ XUserSignOutDeferralHandle* deferral
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XUserGetSignOutDeferral(out XUserSignOutDeferralHandle deferral);

        // STDAPI_(void) XUserCloseSignOutDeferralHandle(
        //     _In_ XUserSignOutDeferralHandle deferral
        //     ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XUserCloseSignOutDeferralHandle(XUserSignOutDeferralHandle deferral);
    }
}
