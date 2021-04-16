using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        //STDAPI_(bool) XblSocialManagerPresenceRecordIsUserPlayingTitle(
        //    _In_ const XblSocialManagerPresenceRecord* presenceRecord,
        //    _In_ uint32_t titleId
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool XblSocialManagerPresenceRecordIsUserPlayingTitle(
            [In] ref XblSocialManagerPresenceRecord presenceRecord,
            UInt32 titleId);

        //STDAPI XblSocialManagerUserGroupGetUsers(
        //    _In_ XblSocialManagerUserGroupHandle group,
        //    _Outptr_ const XblSocialManagerUser* const** users,
        //    _Out_ size_t* usersCount
        //    ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerUserGroupGetUsers(
            XblSocialManagerUserGroupHandle group,
            out IntPtr xboxSocialUsers,
            out SizeT usersCount);

        // STDAPI XblSocialManagerUserGroupGetUsersFromXboxUserIds(
        //     _In_ XblSocialManagerUserGroup* group,
        //     _In_ const uint64_t* xboxUserIds,
        //     _In_ uint32_t xboxUserIdsCount,
        //     _Out_writes_to_(xboxUserIdsCount, *xboxSocialUsersCount) XblSocialManagerUser* xboxSocialUsers,
        //     _Out_opt_ uint32_t* xboxSocialUsersCount
        //     ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerUserGroupGetUsersFromXboxUserIds(
            XblSocialManagerUserGroupHandle group,
            UInt64[] xboxUserIds,
            UInt32 xboxUserIdsCount,
            [Out] XblSocialManagerUser[] xboxSocialUsers,
            out UInt32 xboxSocialUsersCount);

        // STDAPI XblSocialManagerUserGroupGetUsersTrackedByGroup(
        //     _In_ XblSocialManagerUserGroupHandle group,
        //     _Outptr_ const uint64_t** trackedUsers,
        //     _Out_ size_t* trackedUsersCount
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerUserGroupGetUsersTrackedByGroup(
            XblSocialManagerUserGroupHandle group,
            out IntPtr trackedUsers,
            out SizeT trackedUsersCount);

        //STDAPI XblSocialManagerAddLocalUser(
        //     _In_ XblUserHandle user,
        //     _In_ XblSocialManagerExtraDetailLevel extraLevelDetail,
        //     _In_opt_ XTaskQueueHandle queue
        //     ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerAddLocalUser(
            XUserHandle user,
            XblSocialManagerExtraDetailLevel extraLevelDetail,
            XTaskQueueHandle queue);

        // STDAPI XblSocialManagerRemoveLocalUser(
        //     _In_ XblUserHandle user
        //     ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerRemoveLocalUser(XUserHandle user);

        //STDAPI XblSocialManagerDoWork(
        //    _Outptr_ const XblSocialManagerEvent** socialEvents,
        //    _Out_ size_t* socialEventsCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerDoWork(
            out IntPtr socialEvents,
            out SizeT socialEventsCount);

        //STDAPI XblSocialManagerCreateSocialUserGroupFromFilters(
        //    _In_ XblUserHandle user,
        //    _In_ XblPresenceFilter presenceFilter,
        //    _In_ XblRelationshipFilter relationshipFilter,
        //    _Outptr_result_maybenull_ XblSocialManagerUserGroupHandle* group
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerCreateSocialUserGroupFromFilters(
            XUserHandle user,
            XblPresenceFilter presenceDetailLevel,
            XblRelationshipFilter filter,
            out XblSocialManagerUserGroupHandle group);

        //STDAPI XblSocialManagerCreateSocialUserGroupFromList(
        //    _In_ XblUserHandle user,
        //    _In_ uint64_t* xboxUserIdList,
        //    _In_ size_t xboxUserIdListCount,
        //    _Outptr_result_maybenull_ XblSocialManagerUserGroupHandle* group
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerCreateSocialUserGroupFromList(
            XUserHandle user,
            UInt64[] xboxUserIdList,
            SizeT xboxUserIdListCount,
            out XblSocialManagerUserGroupHandle group);

        //STDAPI XblSocialManagerDestroySocialUserGroup(
        //    _In_ XblSocialManagerUserGroupHandle group
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerDestroySocialUserGroup(
            XblSocialManagerUserGroupHandle group);

        //STDAPI_(size_t) XblSocialManagerGetLocalUserCount() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern SizeT XblSocialManagerGetLocalUserCount();

        //STDAPI XblSocialManagerGetLocalUsers(
        //    _In_ size_t usersCount,
        //    _Out_writes_(usersCount) XblUserHandle* users
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerGetLocalUsers(
            SizeT usersCount,
            [Out] XUserHandle[] users);

        //STDAPI XblSocialManagerUpdateSocialUserGroup(
        //    _In_ XblSocialManagerUserGroupHandle group,
        //    _In_ uint64_t* users,
        //    _In_ size_t usersCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerUpdateSocialUserGroup(
            XblSocialManagerUserGroupHandle group,
            UInt64[] users,
            SizeT usersCount);

        // STDAPI XblSocialManagerSetRichPresencePollingStatus(
        //     _In_ XblUserHandle user,
        //     _In_ bool shouldEnablePolling
        //     ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerSetRichPresencePollingStatus(
            XUserHandle user,
            [MarshalAs(UnmanagedType.U1)] bool shouldEnablePolling);

        // STDAPI_(void) XblSocialManagerSetBackgroundWorkAsyncQueue(
        //     _In_opt_ XTaskQueueHandle queue
        //     ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XblSocialManagerSetBackgroundWorkAsyncQueue(
            XTaskQueueHandle queue);

        // STDAPI XblSocialManagerUserGroupGetType(
        //     _In_ XblSocialManagerUserGroupHandle group,
        //     _Out_ XblSocialUserGroupType* type
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerUserGroupGetType(
            XblSocialManagerUserGroupHandle group,
            out XblSocialUserGroupType type);

        // STDAPI XblSocialManagerUserGroupGetLocalUser(
        //     _In_ XblSocialManagerUserGroupHandle group,
        //     _Out_ XblUserHandle* localUser
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerUserGroupGetLocalUser(
            XblSocialManagerUserGroupHandle group,
            out XUserHandle localUser);

        // STDAPI XblSocialManagerUserGroupGetFilters(
        //     _In_ XblSocialManagerUserGroupHandle group,
        //     _Out_opt_ XblPresenceFilter* presenceFilter,
        //     _Out_opt_ XblRelationshipFilter* relationshipFilter
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblSocialManagerUserGroupGetFilters(
            XblSocialManagerUserGroupHandle group,
            out XblPresenceFilter presenceFilter,
            out XblRelationshipFilter relationshipFilter);
    }
}
