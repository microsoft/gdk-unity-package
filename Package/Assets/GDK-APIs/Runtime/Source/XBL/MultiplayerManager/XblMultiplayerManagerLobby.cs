using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public static Int32 XblMultiplayerManagerLobbySessionHost(out XblMultiplayerManagerMember hostMember)
            {
                hostMember = default(XblMultiplayerManagerMember);
                Interop.XblMultiplayerManagerMember hostInterop;
                int hr = XblInterop.XblMultiplayerManagerLobbySessionHost(out hostInterop);

                if (HR.SUCCEEDED(hr))
                {
                    hostMember = new XblMultiplayerManagerMember(hostInterop);
                }

                return hr;
            }

            public static Int32 XblMultiplayerManagerLobbySessionInviteUsers(
                XUserHandle user,
                UInt64[] xuids,
                string contextStringId,
                string customActivationContext)
            {
                if (user == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblMultiplayerManagerLobbySessionInviteUsers(
                    user.InteropHandle,
                    xuids,
                    new SizeT(xuids.Length),
                    Converters.StringToNullTerminatedUTF8ByteArray(contextStringId),
                    Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext));
            }

            public static Int32 XblMultiplayerManagerLobbySessionInviteFriends(
                XUserHandle requestingUser,
                string contextStringId,
                string customActivationContext)
            {
                if (requestingUser == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblMultiplayerManagerLobbySessionInviteFriends(
                    requestingUser.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(contextStringId),
                    Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext));
            }

            public static Int32 XblMultiplayerManagerLobbySessionAddLocalUser(XUserHandle user)
            {
                if (user == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblMultiplayerManagerLobbySessionAddLocalUser(user.InteropHandle);
            }
            
            public static Int32 XblMultiplayerManagerLobbySessionMembers(out XblMultiplayerManagerMember[] members)
            {
                members = default(XblMultiplayerManagerMember[]);
                var count = XblInterop.XblMultiplayerManagerLobbySessionMembersCount();
                if (count.IsZero)
                {
                    return HR.S_OK;
                }

                var interopMembers = new Interop.XblMultiplayerManagerMember[count.ToInt32()];
                int hr = XblInterop.XblMultiplayerManagerLobbySessionMembers(count, interopMembers);
                if (HR.SUCCEEDED(hr))
                {
                    members = Array.ConvertAll(interopMembers, (x) =>new XblMultiplayerManagerMember(x));
                }

                return hr;
            }

            public static string XblMultiplayerManagerLobbySessionPropertiesJson()
            {
                return XblInterop.XblMultiplayerManagerLobbySessionPropertiesJson().GetString();
            }

            public static XblMultiplayerSessionConstants XblMultiplayerManagerLobbySessionConstants()
            {
                unsafe
                {
                    var interop = XblInterop.XblMultiplayerManagerLobbySessionConstants();
                    if (interop == null)
                    {
                        return null;
                    }

                    return new XblMultiplayerSessionConstants(*interop);
                }
            }

            public static Int32 XblMultiplayerManagerLobbySessionLocalMembers(out XblMultiplayerManagerMember[] localMembers)
            {
                localMembers = default(XblMultiplayerManagerMember[]);
                var count = XblInterop.XblMultiplayerManagerLobbySessionLocalMembersCount();
                if (count.IsZero)
                {
                    return HR.S_OK;
                }

                var interopMembers = new Interop.XblMultiplayerManagerMember[count.ToInt32()];
                int hr = XblInterop.XblMultiplayerManagerLobbySessionLocalMembers(count, interopMembers);
                if (HR.SUCCEEDED(hr))
                {
                    localMembers = Array.ConvertAll(interopMembers, (x) =>new XblMultiplayerManagerMember(x));
                }

                return hr;
            }

            public static Int32 XblMultiplayerManagerLobbySessionRemoveLocalUser(XUserHandle user)
            {
                if (user == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblMultiplayerManagerLobbySessionRemoveLocalUser(user.InteropHandle);
            }

            public static XblTournamentTeamResult XblMultiplayerManagerLobbySessionLastTournamentTeamResult()
            {
                unsafe
                {
                    var interop = XblInterop.XblMultiplayerManagerLobbySessionLastTournamentTeamResult();

                    if (interop == null)
                    {
                        return null;
                    }

                    return new XblTournamentTeamResult(*interop);
                }
            }

            public static bool XblMultiplayerManagerLobbySessionIsHost(UInt64 xuid)
            {
                return XblInterop.XblMultiplayerManagerLobbySessionIsHost(xuid).Value;
            }

            public static Int32 XblMultiplayerManagerLobbySessionCorrelationId(out XblGuid correlationId)
            {
                correlationId = default(XblGuid);
                Interop.XblGuid interopGuid;
                int hr = XblInterop.XblMultiplayerManagerLobbySessionCorrelationId(out interopGuid);
                if (HR.SUCCEEDED(hr))
                {
                    correlationId = new XblGuid(interopGuid);
                }

                return hr;
            }

            public static Int32 XblMultiplayerManagerLobbySessionSetSynchronizedHost(string deviceToken, object context)
            {
                return SessionSetInternalWithMarshalledContext(
                    (ctx) =>XblInterop.XblMultiplayerManagerLobbySessionSetSynchronizedHost(
                        Converters.StringToNullTerminatedUTF8ByteArray(deviceToken),
                        ctx),
                    context);
            }

            public static Int32 XblMultiplayerManagerLobbySessionSessionReference(out XblMultiplayerSessionReference sessionReference)
            {
                sessionReference = default(XblMultiplayerSessionReference);

                Interop.XblMultiplayerSessionReference interopSessionReference;
                int hr = XblInterop.XblMultiplayerManagerLobbySessionSessionReference(out interopSessionReference);

                if (!HR.FAILED(hr))
                {
                    sessionReference = new XblMultiplayerSessionReference(interopSessionReference);
                }

                return hr;
            }

            public static Int32 XblMultiplayerManagerLobbySessionSetProperties(string name, string valueJson, object context)
            {
                return SessionSetInternalWithMarshalledContext(
                    (ctx) =>XblInterop.XblMultiplayerManagerLobbySessionSetProperties(
                                Converters.StringToNullTerminatedUTF8ByteArray(name),
                                Converters.StringToNullTerminatedUTF8ByteArray(valueJson),
                                ctx),
                    context);
            }

            public static Int32 XblMultiplayerManagerLobbySessionSetLocalMemberProperties(
                XUserHandle user,
                string name,
                string valueJson,
                object context)
            {
                if (user == null)
                {
                    return HR.E_INVALIDARG;
                }

                return SessionSetInternalWithMarshalledContext(
                    (ctx) =>XblInterop.XblMultiplayerManagerLobbySessionSetLocalMemberProperties(
                                user.InteropHandle,
                                Converters.StringToNullTerminatedUTF8ByteArray(name),
                                Converters.StringToNullTerminatedUTF8ByteArray(valueJson),
                                ctx),
                    context);
            }

            public static Int32 XblMultiplayerManagerLobbySessionSetSynchronizedProperties(string name, string valueJson, object context)
            {
                return SessionSetInternalWithMarshalledContext(
                    (ctx) =>XblInterop.XblMultiplayerManagerLobbySessionSetSynchronizedProperties(
                                Converters.StringToNullTerminatedUTF8ByteArray(name),
                                Converters.StringToNullTerminatedUTF8ByteArray(valueJson),
                                ctx),
                    context);
            }

            public static Int32 XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(
                XUserHandle user,
                string connectionAddress,
                object context)
            {
                if (user == null)
                {
                    return HR.E_INVALIDARG;
                }

                return SessionSetInternalWithMarshalledContext(
                    (ctx) =>XblInterop.XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(
                        user.InteropHandle,
                        Converters.StringToNullTerminatedUTF8ByteArray(connectionAddress),
                        ctx),
                    context);
            }

            public static Int32 XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(XUserHandle user, string name, object context)
            {
                if (user == null)
                {
                    return HR.E_INVALIDARG;
                }

                return SessionSetInternalWithMarshalledContext(
                    (ctx) =>XblInterop.XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(
                        user.InteropHandle,
                        Converters.StringToNullTerminatedUTF8ByteArray(name),
                        ctx),
                    context);
            }
        }
    }
}