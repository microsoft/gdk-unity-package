using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        //STDAPI_(XblMultiplayerSessionReference) XblMultiplayerSessionReferenceCreate(
        //    _In_z_ const char* scid,
        //    _In_z_ const char* sessionTemplateName,
        //    _In_z_ const char* sessionName
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern XblMultiplayerSessionReference XblMultiplayerSessionReferenceCreate(
            Byte[] scid,
            Byte[] sessionTemplateName,
            Byte[] sessionName);

        //STDAPI XblMultiplayerSessionReferenceParseFromUriPath(
        //    _In_ const char* path,
        //    _Out_ XblMultiplayerSessionReference* sessionReference
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerSessionReferenceParseFromUriPath(
            Byte[] path,
            out XblMultiplayerSessionReference sessionReference);

        //STDAPI_(XblMultiplayerSessionHandle) XblMultiplayerSessionCreateHandle(
        //    _In_ uint64_t xuid,
        //    _In_opt_ const XblMultiplayerSessionReference* sessionReference,
        //    _In_opt_ const XblMultiplayerSessionInitArgs* initArgs
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern XblMultiplayerSessionHandle XblMultiplayerSessionCreateHandle(
            UInt64 xboxUserId,
            [In] ref XblMultiplayerSessionReference sessionRef,
            [In] ref XblMultiplayerSessionInitArgs initArgs
            );

        //STDAPI_(void) XblMultiplayerSessionCloseHandle(
        //    _In_ XblMultiplayerSessionHandle handle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XblMultiplayerSessionCloseHandle(
            XblMultiplayerSessionHandle handle
            );

        //STDAPI_(const XblMultiplayerSessionProperties*) XblMultiplayerSessionSessionProperties(
        //    _In_ XblMultiplayerSessionHandle handle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern XblMultiplayerSessionProperties* XblMultiplayerSessionSessionProperties(
            XblMultiplayerSessionHandle handle
            );

        //STDAPI XblMultiplayerSessionMembers(
        //    _In_ XblMultiplayerSessionHandle handle,
        //    _Out_ const XblMultiplayerSessionMember** members,
        //    _Out_ size_t* membersCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern Int32 XblMultiplayerSessionMembers(
            XblMultiplayerSessionHandle handle,
            out IntPtr members,
            out SizeT membersCount
            );

        //STDAPI_(const XblMultiplayerSessionMember*) XblMultiplayerSessionCurrentUser(
        //    _In_ XblMultiplayerSessionHandle handle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern XblMultiplayerSessionMember* XblMultiplayerSessionCurrentUser(
            XblMultiplayerSessionHandle handle
            );


        //STDAPI_(XblWriteSessionStatus) XblMultiplayerSessionWriteStatus(
        //    _In_ XblMultiplayerSessionHandle handle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern XblWriteSessionStatus XblMultiplayerSessionWriteStatus(
            XblMultiplayerSessionHandle handle
            );

        //STDAPI XblMultiplayerSessionJoin(
        //    _In_ XblMultiplayerSessionHandle handle,
        //    _In_opt_z_ const char* memberCustomConstantsJson,
        //    _In_ bool initializeRequested,
        //    _In_ bool joinWithActiveStatus
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSessionJoin(
            XblMultiplayerSessionHandle handle,
            byte[] memberCustomConstantsJson,
            [MarshalAs(UnmanagedType.U1)] bool initializeRequested,
            [MarshalAs(UnmanagedType.U1)] bool joinWithActiveStatus
            );

        //STDAPI_(void) XblMultiplayerSessionSetHostDeviceToken(
        //    _In_ XblMultiplayerSessionHandle handle,
        //    _In_ XblDeviceToken hostDeviceToken
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XblMultiplayerSessionSetHostDeviceToken(
            XblMultiplayerSessionHandle handle,
            XblDeviceToken hostDeviceToken
            );

        //STDAPI_(void) XblMultiplayerSessionSetClosed(
        //    _In_ XblMultiplayerSessionHandle handle,
        //    _In_ bool closed
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XblMultiplayerSessionSetClosed(
            XblMultiplayerSessionHandle handle,
            [MarshalAs(UnmanagedType.U1)] bool closed
            );

        //STDAPI XblMultiplayerSessionSetSessionChangeSubscription(
        //    _In_ XblMultiplayerSessionHandle handle,
        //    _In_ XblMultiplayerSessionChangeTypes changeTypes
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSessionSetSessionChangeSubscription(
            XblMultiplayerSessionHandle handle,
            XblMultiplayerSessionChangeTypes changeTypes
            );

        //STDAPI XblMultiplayerSessionLeave(
        //    _In_ XblMultiplayerSessionHandle handle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSessionLeave(
            XblMultiplayerSessionHandle handle
            );

        //STDAPI XblMultiplayerSessionCurrentUserSetStatus(
        //    _In_ XblMultiplayerSessionHandle handle,
        //    _In_ XblMultiplayerSessionMemberStatus status
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSessionCurrentUserSetStatus(
            XblMultiplayerSessionHandle handle,
            XblMultiplayerSessionMemberStatus status
            );

        //STDAPI XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(
        //    _In_ XblMultiplayerSessionHandle handle,
        //    _In_ const char* value
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(
            XblMultiplayerSessionHandle handle,
            Byte[] value
            );

        //STDAPI XblFormatSecureDeviceAddress(
        //    _In_ const char* deviceId,
        //    _Out_ XblFormattedSecureDeviceAddress* address
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblFormatSecureDeviceAddress(
            Byte[] deviceId,
            out XblFormattedSecureDeviceAddress address
            );

        //STDAPI XblMultiplayerSearchHandleDuplicateHandle(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ XblMultiplayerSearchHandle* duplicatedHandle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleDuplicateHandle(
            [In] XblMultiplayerSearchHandle handle,
            out XblMultiplayerSearchHandle duplicatedHandle
            );

        //STDAPI_(void) XblMultiplayerSearchHandleCloseHandle(
        //    _In_ XblMultiplayerSearchHandle handle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XblMultiplayerSearchHandleCloseHandle([In] XblMultiplayerSearchHandle handle);

        //STDAPI XblMultiplayerSearchHandleGetSessionReference(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ XblMultiplayerSessionReference* sessionRef
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetSessionReference(
            [In] XblMultiplayerSearchHandle handle,
            out XblMultiplayerSessionReference sessionRef
            );

        //STDAPI XblMultiplayerSearchHandleGetId(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ const char** id
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetId(
            [In] XblMultiplayerSearchHandle handle,
            out UTF8StringPtr id
            );

        //STDAPI XblMultiplayerSearchHandleGetSessionOwnerXuids(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ const uint64_t** xuids,
        //    _Out_ size_t* xuidsCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetSessionOwnerXuids(
            [In] XblMultiplayerSearchHandle handle,
            out IntPtr xuids,
            out SizeT xuidsCount
            );

        //STDAPI XblMultiplayerSearchHandleGetTags(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ const XblMultiplayerSessionTag** tags,
        //    _Out_ size_t* tagsCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetTags(
            [In] XblMultiplayerSearchHandle handle,
            out IntPtr tags,
            out SizeT tagsCount
            );

        //STDAPI XblMultiplayerSearchHandleGetStringAttributes(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ const XblMultiplayerSessionStringAttribute** attributes,
        //    _Out_ size_t* attributesCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetStringAttributes(
            [In] XblMultiplayerSearchHandle handle,
            out IntPtr attributes,
            out SizeT attributesCount
            );

        //STDAPI XblMultiplayerSearchHandleGetNumberAttributes(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ const XblMultiplayerSessionNumberAttribute** attributes,
        //    _Out_ size_t* attributesCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetNumberAttributes(
            [In] XblMultiplayerSearchHandle handle,
            out IntPtr attributes,
            out SizeT attributesCount
            );

        //STDAPI XblMultiplayerSearchHandleGetVisibility(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ XblMultiplayerSessionVisibility* visibility
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetVisibility(
            [In] XblMultiplayerSearchHandle handle,
            out XblMultiplayerSessionVisibility visibility
            );

        //STDAPI XblMultiplayerSearchHandleGetJoinRestriction(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ XblMultiplayerSessionRestriction* joinRestriction
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetJoinRestriction(
            [In] XblMultiplayerSearchHandle handle,
            out XblMultiplayerSessionRestriction joinRestriction
            );

        //STDAPI XblMultiplayerSearchHandleGetSessionClosed(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ bool* closed
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetSessionClosed(
            [In] XblMultiplayerSearchHandle handle,
            [MarshalAs(UnmanagedType.U1)] out bool closed
            );

        //STDAPI XblMultiplayerSearchHandleGetMemberCounts(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_opt_ size_t* maxMembers,
        //    _Out_opt_ size_t* currentMembers
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetMemberCounts(
            [In] XblMultiplayerSearchHandle handle,
            out SizeT maxMembers,
            out SizeT currentMembers
            );

        //STDAPI XblMultiplayerSearchHandleGetCreationTime(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ time_t* creationTime
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetCreationTime(
            [In] XblMultiplayerSearchHandle handle,
            out TimeT creationTime
            );

        //STDAPI XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(
        //    _In_ XblMultiplayerSearchHandle handle,
        //    _Out_ const char** customPropertiesJson
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(
            [In] XblMultiplayerSearchHandle handle,
            out UTF8StringPtr customPropertiesJson
            );

        //STDAPI XblMultiplayerWriteSessionAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ XblMultiplayerSessionHandle multiplayerSession,
        //    _In_ XblMultiplayerSessionWriteMode writeMode,
        //    _Inout_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerWriteSessionAsync(
            XblContextHandle xblContext,
            XblMultiplayerSessionHandle handle,
            XblMultiplayerSessionWriteMode writeMode,
            XAsyncBlockPtr async
            );

        //STDAPI XblMultiplayerWriteSessionResult(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ XblMultiplayerSessionHandle* handle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerWriteSessionResult(
            XAsyncBlockPtr async,
            out XblMultiplayerSessionHandle handle
            );

        //STDAPI XblMultiplayerCreateSearchHandleAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ const XblMultiplayerSessionReference* sessionRef,
        //    _In_reads_opt_(tagsCount) const XblMultiplayerSessionTag* tags,
        //    _In_ size_t tagsCount,
        //    _In_reads_opt_(numberAttributesCount) const XblMultiplayerSessionNumberAttribute* numberAttributes,
        //    _In_ size_t numberAttributesCount,
        //    _In_reads_opt_(stringAttributesCount) const XblMultiplayerSessionStringAttribute* stringAttributes,
        //    _In_ size_t stringAttributesCount,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerCreateSearchHandleAsync(
            XblContextHandle xblContext,
            [In] ref XblMultiplayerSessionReference sessionRef,
            [Optional] XblMultiplayerSessionTag[] tags,
            SizeT tagsCount,
            [Optional] XblMultiplayerSessionNumberAttribute[] numberAttributes,
            SizeT numberAttributesCount,
            [Optional] XblMultiplayerSessionStringAttribute[] stringAttributes,
            SizeT stringAttributesCount,
            XAsyncBlockPtr async
            );

        //STDAPI XblMultiplayerCreateSearchHandleResult(
        //    _In_ XAsyncBlock* async,
        //    _Out_opt_ XblMultiplayerSearchHandle* handle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerCreateSearchHandleResult(XAsyncBlockPtr async, out XblMultiplayerSearchHandle handle);

        //STDAPI XblMultiplayerDeleteSearchHandleAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ const char* handleId,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerDeleteSearchHandleAsync(
            XblContextHandle xblContext,
            Byte[] handleId,
            XAsyncBlockPtr async
            );

        //STDAPI XblMultiplayerGetSearchHandlesAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_z_ const char* scid,
        //    _In_z_ const char* sessionTemplateName,
        //    _In_opt_z_ const char* orderByAttribute,
        //    _In_ bool orderAscending,
        //    _In_opt_z_ const char* searchFilter,
        //    _In_opt_z_ const char* socialGroup,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerGetSearchHandlesAsync(
            XblContextHandle xblContext,
            Byte[] scid,
            Byte[] sessionTemplateName,
            [Optional] Byte[] orderByAttribute,
            [MarshalAs(UnmanagedType.U1)] bool orderAscending,
            [Optional] Byte[] searchFilter,
            [Optional] Byte[] socialGroup,
            XAsyncBlockPtr async
            );

        //STDAPI XblMultiplayerGetSearchHandlesResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* searchHandleCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerGetSearchHandlesResultCount(
            XAsyncBlockPtr async,
            out SizeT searchHandleCount
            );

        //STDAPI XblMultiplayerGetSearchHandlesResult(
        //    _In_ XAsyncBlock* async,
        //    _Out_writes_(searchHandlesCount) XblMultiplayerSearchHandle* searchHandles,
        //    _In_ size_t searchHandlesCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerGetSearchHandlesResult(
            XAsyncBlockPtr async,
            [Out] XblMultiplayerSearchHandle[] searchHandles,
            SizeT searchHandleCount
            );

        //STDAPI XblMultiplayerSetSubscriptionsEnabled(
        //    _In_ XblContextHandle xblContext,
        //    _In_ bool subscriptionsEnabled
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerSetSubscriptionsEnabled(
            XblContextHandle xblContext,
            [MarshalAs(UnmanagedType.U1)] bool subscriptionsEnabled
            );

        //STDAPI_(bool) XblMultiplayerSubscriptionsEnabled(
        //    _In_ XblContextHandle xblHandle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool XblMultiplayerSubscriptionsEnabled(
            XblContextHandle xblHandle
            );

        //typedef void CALLBACK XblMultiplayerSessionChangedHandler(
        //    _In_opt_ void* context,
        //    _In_ XblMultiplayerSessionChangeEventArgs args
        //);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate void XblMultiplayerSessionChangedHandler(
            IntPtr context,
            XblMultiplayerSessionChangeEventArgs args
            );

        //STDAPI_(XblFunctionContext) XblMultiplayerAddSessionChangedHandler(
        //    _In_ XblContextHandle xblContext,
        //    _In_ XblMultiplayerSessionChangedHandler* handler,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern XblFunctionContext XblMultiplayerAddSessionChangedHandler(
            XblContextHandle xblContext,
            XblMultiplayerSessionChangedHandler handler,
            IntPtr context
            );

        //STDAPI_(void) XblMultiplayerRemoveSessionChangedHandler(
        //    _In_ XblContextHandle xblContext,
        //    _In_ XblFunctionContext token
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerRemoveSessionChangedHandler(
            XblContextHandle xblContext,
            XblFunctionContext token
            );

        //typedef void CALLBACK XblMultiplayerSessionSubscriptionLostHandler(
        //    _In_opt_ void* context
        //);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate void XblMultiplayerSessionSubscriptionLostHandler(
            IntPtr context
            );

        //STDAPI_(XblFunctionContext) XblMultiplayerAddSubscriptionLostHandler(
        //    _In_ XblContextHandle xblContext,
        //    _In_ XblMultiplayerSessionSubscriptionLostHandler* handler,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern XblFunctionContext XblMultiplayerAddSubscriptionLostHandler(
            XblContextHandle xblContext,
            XblMultiplayerSessionSubscriptionLostHandler handler,
            IntPtr context
            );

        //STDAPI_(void) XblMultiplayerRemoveSubscriptionLostHandler(
        //    _In_ XblContextHandle xblContext,
        //    _In_ XblFunctionContext token
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerRemoveSubscriptionLostHandler(
            XblContextHandle xblContext,
            XblFunctionContext token
            );

        //typedef void CALLBACK XblMultiplayerConnectionIdChangedHandler(
        //    _In_opt_ void* context
        //);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate void XblMultiplayerConnectionIdChangedHandler(
            IntPtr context
            );

        //STDAPI_(XblFunctionContext) XblMultiplayerAddConnectionIdChangedHandler(
        //    _In_ XblContextHandle xblContext,
        //    _In_ XblMultiplayerConnectionIdChangedHandler* handler,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern XblFunctionContext XblMultiplayerAddConnectionIdChangedHandler(
            XblContextHandle xblContext,
            XblMultiplayerConnectionIdChangedHandler handler,
            IntPtr context
            );

        //STDAPI_(void) XblMultiplayerRemoveConnectionIdChangedHandler(
        //    _In_ XblContextHandle xblContext,
        //    _In_ XblFunctionContext token
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerRemoveConnectionIdChangedHandler(
            XblContextHandle xblContext,
            XblFunctionContext token
            );
    }
}
