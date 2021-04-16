using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public static bool XblSocialManagerPresenceRecordIsUserPlayingTitle(
                XblSocialManagerPresenceRecord presenceRecord,
                UInt32 titleId)
            {
                Interop.XblSocialManagerPresenceRecord interopPresenceRecord = new Interop.XblSocialManagerPresenceRecord(presenceRecord);
                return XblInterop.XblSocialManagerPresenceRecordIsUserPlayingTitle(ref interopPresenceRecord, titleId);
            }

            public static Int32 XblSocialManagerUserGroupGetUsers(
                XblSocialManagerUserGroupHandle group,
                out XblSocialManagerUser[] xboxSocialUsers)
            {
                xboxSocialUsers = default(XblSocialManagerUser[]);
                if (group == null)
                {
                    return HR.E_INVALIDARG;
                }

                IntPtr userArrayPtr;
                SizeT userArrayCount;
                Int32 hresult = XblInterop.XblSocialManagerUserGroupGetUsers(
                    group.InteropHandle,
                    out userArrayPtr,
                    out userArrayCount);

                if (HR.FAILED(hresult))
                {
                    return hresult;
                }

                xboxSocialUsers = Converters.PtrToClassArray<XblSocialManagerUser, IntPtr>(
                    userArrayPtr,
                    userArrayCount,
                    intPtr => Converters.PtrToClass<XblSocialManagerUser, Interop.XblSocialManagerUser>(intPtr, u =>new XblSocialManagerUser(u)));

                return hresult;
            }

            public static Int32 XblSocialManagerUserGroupGetUsersTrackedByGroup(
                XblSocialManagerUserGroupHandle group,
                out UInt64[] trackedUsers)
            {
                trackedUsers = default(UInt64[]);

                if (group == null)
                {
                    return HR.E_INVALIDARG;
                }

                IntPtr trackedUsersPtr;
                SizeT trackedUsersCount;
                Int32 hresult = XblInterop.XblSocialManagerUserGroupGetUsersTrackedByGroup(
                    group.InteropHandle,
                    out trackedUsersPtr,
                    out trackedUsersCount);

                if (!HR.FAILED(hresult))
                {
                    trackedUsers = Converters.PtrToClassArray<UInt64, UInt64>(trackedUsersPtr, trackedUsersCount.ToUInt32(), x =>x);
                }

                return hresult;
            }

            public static Int32 XblSocialManagerAddLocalUser(
                XUserHandle user,
                XblSocialManagerExtraDetailLevel extraLevelDetail)
            {
                if (user == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblSocialManagerAddLocalUser(user.InteropHandle, extraLevelDetail, defaultQueue.handle);
            }

            public static Int32 XblSocialManagerRemoveLocalUser(
                XUserHandle user,
                XblSocialManagerExtraDetailLevel extraLevelDetail)
            {
                if (user == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblSocialManagerRemoveLocalUser(user.InteropHandle);
            }

            public static Int32 XblSocialManagerDoWork(out XblSocialManagerEvent[] socialEvents)
            {
                IntPtr interopSocialEvents;
                SizeT socialEventsCount;
                Int32 hresult = XblInterop.XblSocialManagerDoWork(out interopSocialEvents, out socialEventsCount);
                if (HR.FAILED(hresult))
                {
                    socialEvents = default(XblSocialManagerEvent[]);
                    return hresult;
                }

                if (interopSocialEvents == IntPtr.Zero)
                {
                    socialEvents = null;
                }
                else
                {
                    socialEvents = Converters.PtrToClassArray<XblSocialManagerEvent, Interop.XblSocialManagerEvent>(interopSocialEvents, socialEventsCount, e =>new XblSocialManagerEvent(e));
                }

                return hresult;
            }

            public static Int32 XblSocialManagerCreateSocialUserGroupFromFilters(
                XUserHandle user,
                XblPresenceFilter presenceDetailLevel,
                XblRelationshipFilter filter,
                out XblSocialManagerUserGroupHandle group)
            {
                if (user == null)
                {
                    group = default(XblSocialManagerUserGroupHandle);
                    return HR.E_INVALIDARG;
                }

                Interop.XblSocialManagerUserGroupHandle interopGroupPtr;
                Int32 hresult = XblInterop.XblSocialManagerCreateSocialUserGroupFromFilters(
                    user.InteropHandle,
                    presenceDetailLevel,
                    filter,
                    out interopGroupPtr);

                return XblSocialManagerUserGroupHandle.WrapAndReturnHResult(hresult, interopGroupPtr, out group);
            }

            public static Int32 XblSocialManagerCreateSocialUserGroupFromList(
                XUserHandle user,
                UInt64[] xboxUserIdList,
                out XblSocialManagerUserGroupHandle group)
            {
                if (user == null)
                {
                    group = default(XblSocialManagerUserGroupHandle);
                    return HR.E_INVALIDARG;
                }

                Interop.XblSocialManagerUserGroupHandle interopGroupPtr;
                SizeT xboxUserIdListCount = new SizeT(0);
                if (xboxUserIdList != null && xboxUserIdList.Length > 0)
                {
                    xboxUserIdListCount = new SizeT(xboxUserIdList.Length);
                }

                Int32 hresult = XblInterop.XblSocialManagerCreateSocialUserGroupFromList(
                    user.InteropHandle,
                    xboxUserIdList,
                    xboxUserIdListCount,
                    out interopGroupPtr);

                return XblSocialManagerUserGroupHandle.WrapAndReturnHResult(hresult, interopGroupPtr, out group);
            }

            public static Int32 XblSocialManagerDestroySocialUserGroup(XblSocialManagerUserGroupHandle group)
            {
                if (group == null)
                {
                    return HR.E_INVALIDARG;
                }

                Int32 hresult = XblInterop.XblSocialManagerDestroySocialUserGroup(group.InteropHandle);
                if (HR.FAILED(hresult))
                {
                    return hresult;
                }

                group.ClearInteropHandle();
                return hresult;
            }

            public static Int32 XblSocialManagerGetLocalUsers(out XUserHandle[] users)
            {
                SizeT userCount = XblInterop.XblSocialManagerGetLocalUserCount();

                Interop.XUserHandle[] interopUsers = new Interop.XUserHandle[userCount.ToInt32()];
                int hresult = XblInterop.XblSocialManagerGetLocalUsers(userCount, interopUsers);
                if (HR.FAILED(hresult))
                {
                    users = default(XUserHandle[]);
                    return hresult;
                }

                users = Array.ConvertAll(interopUsers, u =>new XUserHandle(u));
                return hresult;
            }

            public static Int32 XblSocialManagerUpdateSocialUserGroup(XblSocialManagerUserGroupHandle group, UInt64[] users)
            {
                if (group == null)
                {
                    return HR.E_INVALIDARG;
                }

                SizeT usersCount = new SizeT(0);
                if (users != null && users.Length > 0)
                {
                    usersCount = new SizeT(users.Length);
                }
                return XblInterop.XblSocialManagerUpdateSocialUserGroup(group.InteropHandle, users, usersCount);
            }

            public static Int32 XblSocialManagerSetRichPresencePollingStatus(XUserHandle user, bool shouldEnablePolling)
            {
                if (user == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblSocialManagerSetRichPresencePollingStatus(user.InteropHandle, shouldEnablePolling);
            }

            public static Int32 XblSocialManagerUserGroupGetType(XblSocialManagerUserGroupHandle group, out XblSocialUserGroupType type)
            {
                type = default(XblSocialUserGroupType);
                if (group == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblSocialManagerUserGroupGetType(group.InteropHandle, out type);
            }

            public static Int32 XblSocialManagerUserGroupGetLocalUser(XblSocialManagerUserGroupHandle group, out XUserHandle localUser)
            {
                localUser = default(XUserHandle);
                if (group == null)
                {
                    return HR.E_INVALIDARG;
                }

                Interop.XUserHandle interopUser;
                Int32 hr = XblInterop.XblSocialManagerUserGroupGetLocalUser(group.InteropHandle, out interopUser);
                return XUserHandle.WrapAndReturnHResult(hr, interopUser, out localUser);
            }

            public static Int32 XblSocialManagerUserGroupGetFilters(
                XblSocialManagerUserGroupHandle group,
                out XblPresenceFilter presenceFilter,
                out XblRelationshipFilter relationshipFilter)
            {
                presenceFilter = default(XblPresenceFilter);
                relationshipFilter = default(XblRelationshipFilter);

                if (group == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblSocialManagerUserGroupGetFilters(group.InteropHandle, out presenceFilter, out relationshipFilter);
            }
        }
    }
}