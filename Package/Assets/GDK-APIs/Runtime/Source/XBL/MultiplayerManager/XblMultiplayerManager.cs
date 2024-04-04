using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public static Int32 XblMultiplayerManagerInitialize(string lobbySessionTemplateName)
            {
                return XblInterop.XblMultiplayerManagerInitialize(
                    Converters.StringToNullTerminatedUTF8ByteArray(lobbySessionTemplateName),
                    defaultQueue.handle);
            }

            public static Int32 XblMultiplayerManagerDoWork(out XblMultiplayerEvent[] events)
            {
                IntPtr eventArray;
                SizeT eventCount;
                int hr = XblInterop.XblMultiplayerManagerDoWork(out eventArray, out eventCount);
                if (HR.FAILED(hr))
                {
                    events = default(XblMultiplayerEvent[]);
                    return hr;
                }

                events = Converters.PtrToClassArray<XblMultiplayerEvent, Interop.XblMultiplayerEvent>(eventArray, eventCount, x =>new XblMultiplayerEvent(x));
                return hr;
            }

            public static XblMultiplayerSessionReference XblMultiplayerSessionReferenceCreate(string scid, string sessionTemplateName, string sessionName)
            {
                var reference = XblInterop.XblMultiplayerSessionReferenceCreate(
                    Converters.StringToNullTerminatedUTF8ByteArray(scid),
                    Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName),
                    Converters.StringToNullTerminatedUTF8ByteArray(sessionName));

                return new XblMultiplayerSessionReference(reference);
            }

            public static Int32 XblMultiplayerManagerJoinLobby(string handleId, XUserHandle user)
            {
                if (user == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblMultiplayerManagerJoinLobby(
                    Converters.StringToNullTerminatedUTF8ByteArray(handleId),
                    user.Handle);
            }

            public static Int32 XblMultiplayerManagerSetQosMeasurements(string measurementsJson)
            {
                return XblInterop.XblMultiplayerManagerSetQosMeasurements(
                    Converters.StringToNullTerminatedUTF8ByteArray(measurementsJson));
            }

            public static Int32 XblMultiplayerManagerSetJoinability(XblMultiplayerJoinability joinability, object context)
            {
                return SessionSetInternalWithMarshalledContext(
                    (ctx) =>XblInterop.XblMultiplayerManagerSetJoinability(joinability, ctx),
                    context);
            }

            public static Int32 XblMultiplayerManagerJoinGameFromLobby(string sessionTemplateName)
            {
                return XblInterop.XblMultiplayerManagerJoinGameFromLobby(
                    Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName));
            }

            public static void XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(bool autoFillMembers)
            {
                XblInterop.XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(new NativeBool(autoFillMembers));
            }

            public static XblMultiplayerJoinability XblMultiplayerManagerJoinability()
            {
                return XblInterop.XblMultiplayerManagerJoinability();
            }

            public static void XblMultiplayerManagerCancelMatch()
            {
                XblInterop.XblMultiplayerManagerCancelMatch();
            }

            public static UInt32 XblMultiplayerManagerEstimatedMatchWaitTime()
            {
                return XblInterop.XblMultiplayerManagerEstimatedMatchWaitTime();
            }

            public static bool XblMultiplayerManagerMemberAreMembersOnSameDevice(
                XblMultiplayerManagerMember first,
                XblMultiplayerManagerMember second)
            {
                using (DisposableCollection disposableCollection = new DisposableCollection())
                {
                    var interopFirst = new Interop.XblMultiplayerManagerMember(first, disposableCollection);
                    var interopSecond = new Interop.XblMultiplayerManagerMember(second, disposableCollection);

                    NativeBool ret = XblInterop.XblMultiplayerManagerMemberAreMembersOnSameDevice(
                            ref interopFirst,
                            ref interopSecond);

                    return ret.Value;
                }
            }

            public static Int32 XblMultiplayerSessionReferenceParseFromUriPath(string path, out XblMultiplayerSessionReference sessionReference)
            {
                Interop.XblMultiplayerSessionReference interopSessionRef;
                int hr = XblInterop.XblMultiplayerSessionReferenceParseFromUriPath(
                    Converters.StringToNullTerminatedUTF8ByteArray(path),
                    out interopSessionRef);

                if (HR.FAILED(hr))
                {
                    sessionReference = default(XblMultiplayerSessionReference);
                    return hr;
                }

                sessionReference = new XblMultiplayerSessionReference(interopSessionRef);
                return hr;
            }

            public static Int32 XblMultiplayerManagerLeaveGame()
            {
                return XblInterop.XblMultiplayerManagerLeaveGame();
            }

            public static XblMultiplayerMatchStatus XblMultiplayerManagerMatchStatus()
            {
                return XblInterop.XblMultiplayerManagerMatchStatus();
            }

            public static bool XblMultiplayerManagerAutoFillMembersDuringMatchmaking()
            {
                NativeBool ret = XblInterop.XblMultiplayerManagerAutoFillMembersDuringMatchmaking();
                return ret.Value;
            }
            public static Int32 XblMultiplayerManagerFindMatch(string hopperName, string attributesJson, UInt32 timeoutInSeconds)
            {
                return XblInterop.XblMultiplayerManagerFindMatch(
                    Converters.StringToNullTerminatedUTF8ByteArray(hopperName),
                    Converters.StringToNullTerminatedUTF8ByteArray(attributesJson),
                    timeoutInSeconds);
            }

            public static bool XblMultiplayerSessionReferenceIsValid(XblMultiplayerSessionReference sessionReference)
            {
                var interopSession = new Interop.XblMultiplayerSessionReference(sessionReference);
                NativeBool result = XblInterop.XblMultiplayerSessionReferenceIsValid(ref interopSession);
                return result.Value;
            }

            public static Int32 XblMultiplayerManagerJoinGame(
                string sessionName,
                string sessionTemplateName,
                UInt64[] xuids)
            {
                return XblInterop.XblMultiplayerManagerJoinGame(
                    Converters.StringToNullTerminatedUTF8ByteArray(sessionName),
                    Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName),
                    xuids,
                    new SizeT(xuids.Length));
            }

            /// <summary>
            /// Deprecated
            /// </summary>
            /// <param name="argsHandle"></param>
            /// <param name="registrationState"></param>
            /// <param name="registrationReason"></param>
            /// <returns></returns>
            public static Int32 XblMultiplayerEventArgsTournamentRegistrationStateChanged(
                XblMultiplayerEventArgsHandle argsHandle,
                out XblTournamentRegistrationState registrationState,
                out XblTournamentRegistrationReason registrationReason)
            {
                if (argsHandle == null)
                {
                    registrationState = default(XblTournamentRegistrationState);
                    registrationReason = default(XblTournamentRegistrationReason);
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblMultiplayerEventArgsTournamentRegistrationStateChanged(
                    argsHandle.InteropHandle,
                    out registrationState,
                    out registrationReason);
            }

            public static Int32 XblMultiplayerEventArgsFindMatchCompleted(
                XblMultiplayerEventArgsHandle argsHandle,
                out XblMultiplayerMatchStatus matchStatus,
                out XblMultiplayerMeasurementFailure initializationFailureCause)
            {
                if (argsHandle == null)
                {
                    matchStatus = default(XblMultiplayerMatchStatus);
                    initializationFailureCause = default(XblMultiplayerMeasurementFailure);
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblMultiplayerEventArgsFindMatchCompleted(
                    argsHandle.InteropHandle,
                    out matchStatus,
                    out initializationFailureCause);
            }

            public static Int32 XblMultiplayerEventArgsPropertiesJson(XblMultiplayerEventArgsHandle argsHandle, out string properties)
            {
                properties = default(string);
                if (argsHandle == null)
                {
                    return HR.E_INVALIDARG;
                }

                UTF8StringPtr propertiesPtr;
                int hr = XblInterop.XblMultiplayerEventArgsPropertiesJson(argsHandle.InteropHandle, out propertiesPtr);
                if (HR.SUCCEEDED(hr))
                {
                    properties = propertiesPtr.GetString();
                }

                return hr;
            }

            public static Int32 XblMultiplayerEventArgsXuid(XblMultiplayerEventArgsHandle argsHandle, out UInt64 xuid)
            {
                xuid = default(UInt64);
                if (argsHandle == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblMultiplayerEventArgsXuid(argsHandle.InteropHandle, out xuid);
            }

            /// <summary>
            /// Deprecated
            /// </summary>
            /// <param name="argsHandle"></param>
            /// <param name="startTime"></param>
            /// <returns></returns>
            public static Int32 XblMultiplayerEventArgsTournamentGameSessionReady(XblMultiplayerEventArgsHandle argsHandle, out DateTime startTime)
            {
                startTime = default(DateTime);
                if (argsHandle == null)
                {
                    return HR.E_INVALIDARG;
                }

                TimeT startTimeT;
                int hr = XblInterop.XblMultiplayerEventArgsTournamentGameSessionReady(argsHandle.InteropHandle, out startTimeT);
                if (HR.SUCCEEDED(hr))
                {
                    startTime = startTimeT.DateTime;
                }

                return hr;
            }

            public static Int32 XblMultiplayerEventArgsMember(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember member)
            {
                member = default(XblMultiplayerManagerMember);
                if (argsHandle == null)
                {
                    return HR.E_INVALIDARG;
                }

                Interop.XblMultiplayerManagerMember interopMember;
                int hr = XblInterop.XblMultiplayerEventArgsMember(argsHandle.InteropHandle, out interopMember);
                if (HR.SUCCEEDED(hr))
                {
                    member = new XblMultiplayerManagerMember(interopMember);
                }

                return hr;
            }

            public static Int32 XblMultiplayerEventArgsMembers(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember[] members)
            {
                members = default(XblMultiplayerManagerMember[]);
                if (argsHandle == null)
                {
                    return HR.E_INVALIDARG;
                }

                SizeT membersCount;
                int hr = XblInterop.XblMultiplayerEventArgsMembersCount(argsHandle.InteropHandle, out membersCount);
                if (HR.FAILED(hr))
                {
                    return hr;
                }

                var interopMembers = new Interop.XblMultiplayerManagerMember[membersCount.ToInt32()];
                hr = XblInterop.XblMultiplayerEventArgsMembers(argsHandle.InteropHandle, membersCount, interopMembers);
                if (HR.SUCCEEDED(hr))
                {
                    members = Array.ConvertAll(interopMembers, x =>new XblMultiplayerManagerMember(x));
                }

                return hr;
            }

            public static Int32 XblMultiplayerEventArgsPerformQoSMeasurements(
                XblMultiplayerEventArgsHandle argsHandle,
                out XblMultiplayerPerformQoSMeasurementsArgs performQoSMeasurementsArgs)
            {
                performQoSMeasurementsArgs = default(XblMultiplayerPerformQoSMeasurementsArgs);
                if (argsHandle == null)
                {
                    return HR.E_INVALIDARG;
                }

                Interop.XblMultiplayerPerformQoSMeasurementsArgs interopType;
                int hr = XblInterop.XblMultiplayerEventArgsPerformQoSMeasurements(
                    argsHandle.InteropHandle,
                    out interopType);
                if (HR.SUCCEEDED(hr))
                {
                    performQoSMeasurementsArgs = new XblMultiplayerPerformQoSMeasurementsArgs(interopType);
                }

                return hr;
            }

            // Helper function that wraps and marshals the optional context pointer
            private static Int32 SessionSetInternalWithMarshalledContext(Func<IntPtr, Int32> setterFunction, object context)
            {
                IntPtr ctx = IntPtr.Zero;
                if (context != null)
                {
                    var ctxHandle = GCHandle.Alloc(context);
                    ctx = GCHandle.ToIntPtr(ctxHandle);
                }

                int hr = setterFunction(ctx);

                if (HR.FAILED(hr) && ctx != IntPtr.Zero)
                {
                    GCHandle.FromIntPtr(ctx).Free();
                }

                return hr;
            }
        }
    }
}
