using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public static bool XblMultiplayerManagerGameSessionIsHost(UInt64 xuid)
            {
                var result = XblInterop.XblMultiplayerManagerGameSessionIsHost(xuid);
                return result.Value;
            }

            public static Int32 XblMultiplayerManagerGameSessionHost(out XblMultiplayerManagerMember hostMember)
            {
                hostMember = default(XblMultiplayerManagerMember);
                Interop.XblMultiplayerManagerMember interopMember;
                int hr = XblInterop.XblMultiplayerManagerGameSessionHost(out interopMember);
                if (HR.SUCCEEDED(hr))
                {
                    hostMember = new XblMultiplayerManagerMember(interopMember);
                }
                return hr;
            }

            public static XblMultiplayerSessionReference XblMultiplayerManagerGameSessionSessionReference()
            {
                unsafe
                {
                    var interop = XblInterop.XblMultiplayerManagerGameSessionSessionReference();
                    if (interop == null)
                    {
                        return null;
                    }

                    return new XblMultiplayerSessionReference(*interop);
                }
            }
            public static bool XblMultiplayerManagerGameSessionActive()
            {
                var result = XblInterop.XblMultiplayerManagerGameSessionActive();
                return result.Value;
            }

            public static Int32 XblMultiplayerManagerGameSessionSetProperties(string name, string valueJson, object context)
            {
                return SessionSetInternalWithMarshalledContext(
                    (ctx) =>XblInterop.XblMultiplayerManagerGameSessionSetProperties(
                                Converters.StringToNullTerminatedUTF8ByteArray(name),
                                Converters.StringToNullTerminatedUTF8ByteArray(valueJson),
                                ctx),
                    context);
            }

            public static Int32 XblMultiplayerManagerGameSessionSetSynchronizedHost(string deviceToken, object context)
            {
                return SessionSetInternalWithMarshalledContext(
                    (ctx) =>XblInterop.XblMultiplayerManagerGameSessionSetSynchronizedHost(
                                Converters.StringToNullTerminatedUTF8ByteArray(deviceToken),
                                ctx),
                    context);
            }

            public static Int32 XblMultiplayerManagerGameSessionSetSynchronizedProperties(string name, string valueJson, object context)
            {
                return SessionSetInternalWithMarshalledContext(
                    (ctx) =>XblInterop.XblMultiplayerManagerGameSessionSetSynchronizedProperties(
                                Converters.StringToNullTerminatedUTF8ByteArray(name),
                                Converters.StringToNullTerminatedUTF8ByteArray(valueJson),
                                ctx),
                    context);
            }

            public static string XblMultiplayerManagerGameSessionCorrelationId()
            {
                return XblInterop.XblMultiplayerManagerGameSessionCorrelationId().GetString();
            }

            public static XblMultiplayerSessionConstants XblMultiplayerManagerGameSessionConstants()
            {
                unsafe
                {
                    var interop = XblInterop.XblMultiplayerManagerGameSessionConstants();
                    if (interop == null)
                    {
                        return null;
                    }

                    return new XblMultiplayerSessionConstants(*interop);
                }
            }

            public static Int32 XblMultiplayerManagerGameSessionMembers(out XblMultiplayerManagerMember[] members)
            {
                members = default(XblMultiplayerManagerMember[]);
                var count = XblInterop.XblMultiplayerManagerGameSessionMembersCount();
                if (count.IsZero)
                {
                    return HR.S_OK;
                }

                var interopMembers = new Interop.XblMultiplayerManagerMember[count.ToInt32()];
                int hr = XblInterop.XblMultiplayerManagerGameSessionMembers(count, interopMembers);
                if (HR.SUCCEEDED(hr))
                {
                    members = Array.ConvertAll(interopMembers, (x) =>new XblMultiplayerManagerMember(x));
                }

                return hr;
            }

            public static string XblMultiplayerManagerGameSessionPropertiesJson()
            {
                return XblInterop.XblMultiplayerManagerGameSessionPropertiesJson().GetString();
            }
        }
    }
}