using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public struct XblMatchTicket
    {
        public string matchTicketId;
        public long estimatedWaitTime;
    }

    public struct XblMatchTicketDetailsResponse
    {
        public XblTicketStatus matchStatus;
        public long estimatedWaitTime;
        public XblPreserveSessionMode preserveSession;
        public XblMultiplayerSessionReference ticketSession;
        public XblMultiplayerSessionReference targetSession;
        public string ticketAttributesJson;
    }

    public struct XblHopperStatisticsResponse
    {
        public string hopperName;
        public long estimatedWaitTime;
        public uint playersWaitingToMatch;
    }

    public delegate void XblMatchmakingCreateTicketCallback(
        int hresult,
        XblMatchTicket matchTicket);

    public delegate void XblMatchmakingDeleteTicketCallback(int hresult);

    public delegate void XblMatchmakingTicketDetailsCallback(
        int hresult,
        XblMatchTicketDetailsResponse details);

    public delegate void XblMatchmakingStatisticsCallback(
        int hresult,
        XblHopperStatisticsResponse statistics);

    public partial class SDK
    {
        public partial class XBL
        {
            public static int XblMatchmakingCreateMatchTicketAsync(
                XblContextHandle xboxLiveContext,
                XblMultiplayerSessionReference sessionReference,
                string serviceConfigurationId,
                string hopperName,
                ulong ticketTimeout,
                XblPreserveSessionMode preserveSessionMode,
                string ticketAttributesJson,
                XblMatchmakingCreateTicketCallback createCompletionCallback)
            {
                int result;

                unsafe
                {
                    XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(
                        SDK.defaultQueue.handle,
                        (XAsyncBlockPtr block) =>
                        {
                            var response = new XblCreateMatchTicketResponse();
                            var hresult = Matchmaking.XblMatchmakingCreateMatchTicketResult(
                                block, 
                                &response);

                            var matchTicket = new XblMatchTicket();

                            if (HR.SUCCEEDED(hresult))
                            {
                                matchTicket.matchTicketId =
                                    Converters.NullTerminatedBytePointerToString(
                                        (byte*)response.matchTicketId);
                                matchTicket.estimatedWaitTime = response.estimatedWaitTime;
                            }

                            if (createCompletionCallback != null)
                            {
                                createCompletionCallback.Invoke(
                                    hresult,
                                    matchTicket);
                            }
                        });

                    var scidLen = Converters.GetSizeRequiredToEncodeStringToUTF8(serviceConfigurationId);
                    var hopperLen = Converters.GetSizeRequiredToEncodeStringToUTF8(hopperName);
                    var attrsLen = Converters.GetSizeRequiredToEncodeStringToUTF8(ticketAttributesJson);

                    sbyte[] scidAsBytes = new sbyte[scidLen];
                    sbyte[] hopperNameAsBytes = new sbyte[hopperLen];
                    sbyte[] ticketAttributes = new sbyte[attrsLen];
                    fixed (sbyte* scidBytePtr = &scidAsBytes[0], hopperNameBytePtr = &hopperNameAsBytes[0], attrsBytePtr = &ticketAttributes[0])
                    {
                        Converters.StringToNullTerminatedUTF8FixedPointer(serviceConfigurationId, (byte*)scidBytePtr, scidLen);
                        Converters.StringToNullTerminatedUTF8FixedPointer(hopperName, (byte*)hopperNameBytePtr, hopperLen);
                        Converters.StringToNullTerminatedUTF8FixedPointer(ticketAttributesJson, (byte*)attrsBytePtr, attrsLen);

                        result = Matchmaking.XblMatchmakingCreateMatchTicketAsync(
                            xboxLiveContext.InteropHandle.handle,
                            new Interop.XblMultiplayerSessionReference(sessionReference),
                            scidBytePtr,
                            hopperNameBytePtr,
                            ticketTimeout,
                            Interop.XblPreserveSessionMode.Never,
                            attrsBytePtr,
                            asyncBlock);

                        if (HR.FAILED(result))
                        {
                            if (createCompletionCallback != null)
                            {
                                createCompletionCallback.Invoke(
                                    result,
                                    new XblMatchTicket());
                            }
                        }
                    }
                }

                return result;
            }

            public static int XblMatchmakingDeleteMatchTicketAsync(
                XblContextHandle xboxLiveContext,
                string serviceConfigurationId,
                string hopperName,
                string matchTicketId,
                XblMatchmakingDeleteTicketCallback deleteCompletionCallback)
            {
                int result;

                unsafe
                {
                    XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(
                        SDK.defaultQueue.handle,
                        (XAsyncBlockPtr block) =>
                        {
                            if (deleteCompletionCallback != null)
                            {
                                deleteCompletionCallback.Invoke(HR.S_OK);
                            }
                        });

                    var scidLen = Converters.GetSizeRequiredToEncodeStringToUTF8(serviceConfigurationId);
                    var hopperLen = Converters.GetSizeRequiredToEncodeStringToUTF8(hopperName);
                    var ticketIdLen = Converters.GetSizeRequiredToEncodeStringToUTF8(matchTicketId);

                    sbyte[] scidAsBytes = new sbyte[scidLen];
                    sbyte[] hopperNameAsBytes = new sbyte[hopperLen];
                    sbyte[] matchId = new sbyte[ticketIdLen];
                    fixed (sbyte* scidBytePtr = &scidAsBytes[0], hopperNameBytePtr = &hopperNameAsBytes[0], matchIdPtr = &matchId[0])
                    {
                        Converters.StringToNullTerminatedUTF8FixedPointer(serviceConfigurationId, (byte*)scidBytePtr, scidLen);
                        Converters.StringToNullTerminatedUTF8FixedPointer(hopperName, (byte*)hopperNameBytePtr, hopperLen);
                        Converters.StringToNullTerminatedUTF8FixedPointer(matchTicketId, (byte*)matchIdPtr, ticketIdLen);

                        result = Matchmaking.XblMatchmakingDeleteMatchTicketAsync(
                            xboxLiveContext.InteropHandle.handle,
                            scidBytePtr,
                            hopperNameBytePtr,
                            matchIdPtr,
                            asyncBlock);

                        if (HR.FAILED(result))
                        {
                            if (deleteCompletionCallback != null)
                            {
                                deleteCompletionCallback.Invoke(result);
                            }
                        }
                    }
                }

                return result;
            }

            public static int XblMatchmakingGetMatchTicketDetailsAsync(
                XblContextHandle xboxLiveContext,
                string serviceConfigurationId,
                string hopperName,
                string matchTicketId,
                XblMatchmakingTicketDetailsCallback completionCallback)
            {
                int result;

                unsafe
                {
                    XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(
                        SDK.defaultQueue.handle,
                        (XAsyncBlockPtr block) =>
                        {
                            var resultSize = new SizeT();
                            var hresult = Matchmaking.XblMatchmakingGetMatchTicketDetailsResultSize(
                                block, &resultSize);

                            var details = new XblMatchTicketDetailsResponse();

                            if (HR.SUCCEEDED(hresult))
                            {
                                var buffer = new byte[resultSize.ToInt32()];
                                var bufferUsed = new SizeT();
                                fixed(byte* bufferPtr = &buffer[0])
                                {
                                    Interop.XblMatchTicketDetailsResponse* ptr =
                                        default(Interop.XblMatchTicketDetailsResponse*);
                                    hresult = Matchmaking.XblMatchmakingGetMatchTicketDetailsResult(
                                        block,
                                        resultSize,
                                        (IntPtr)bufferPtr,
                                        &ptr,
                                        &bufferUsed);

                                    if (HR.SUCCEEDED(hresult))
                                    {
                                        details.matchStatus = ptr->matchStatus;
                                        details.estimatedWaitTime = ptr->estimatedWaitTime;
                                        details.preserveSession = (XblPreserveSessionMode)ptr->preserveSession;
                                        details.ticketSession =
                                            new XblMultiplayerSessionReference(ptr->ticketSession);
                                        details.targetSession =
                                            new XblMultiplayerSessionReference(ptr->targetSession);
                                        details.ticketAttributesJson =
                                            Converters.NullTerminatedBytePointerToString((byte*)ptr->ticketAttributes);
                                    }
                                }
                            }

                            if (completionCallback != null)
                            { 
                                completionCallback.Invoke(hresult, details);
                            }
                        });

                    var scidLen = Converters.GetSizeRequiredToEncodeStringToUTF8(serviceConfigurationId);
                    var hopperLen = Converters.GetSizeRequiredToEncodeStringToUTF8(hopperName);
                    var ticketIdLen = Converters.GetSizeRequiredToEncodeStringToUTF8(matchTicketId);

                    sbyte[] scidAsBytes = new sbyte[scidLen];
                    sbyte[] hopperNameAsBytes = new sbyte[hopperLen];
                    sbyte[] matchId = new sbyte[ticketIdLen];
                    fixed (sbyte* scidBytePtr = &scidAsBytes[0], hopperNameBytePtr = &hopperNameAsBytes[0], matchIdPtr = &matchId[0])
                    {
                        Converters.StringToNullTerminatedUTF8FixedPointer(serviceConfigurationId, (byte*)scidBytePtr, scidLen);
                        Converters.StringToNullTerminatedUTF8FixedPointer(hopperName, (byte*)hopperNameBytePtr, hopperLen);
                        Converters.StringToNullTerminatedUTF8FixedPointer(matchTicketId, (byte*)matchIdPtr, ticketIdLen);

                        result = Matchmaking.XblMatchmakingGetMatchTicketDetailsAsync(
                            xboxLiveContext.InteropHandle.handle,
                            scidBytePtr,
                            hopperNameBytePtr,
                            matchIdPtr,
                            asyncBlock);

                        if (HR.FAILED(result))
                        {
                            if (completionCallback != null)
                            { 
                                completionCallback.Invoke(result, new XblMatchTicketDetailsResponse());
                            }
                        }
                    }
                }

                return result;
            }

            public static int XblMatchmakingGetHopperStatisticsAsync(
                XblContextHandle xboxLiveContext,
                string serviceConfigurationId,
                string hopperName,
                XblMatchmakingStatisticsCallback completionCallback)
            {
                int result;

                unsafe
                {
                    XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(
                        SDK.defaultQueue.handle,
                        (XAsyncBlockPtr block) =>
                        {
                            var resultSize = new SizeT();
                            var hresult = Matchmaking.XblMatchmakingGetHopperStatisticsResultSize(
                                block, &resultSize);

                            var statistics = new XblHopperStatisticsResponse();

                        if (HR.SUCCEEDED(hresult))
                        {
                            var buffer = new byte[resultSize.ToInt32()];
                            var bufferUsed = new SizeT();
                            fixed (byte* bufferPtr = &buffer[0])
                            {
                                    Interop.XblHopperStatisticsResponse* ptr =
                                        default(Interop.XblHopperStatisticsResponse*);
                                    hresult = Matchmaking.XblMatchmakingGetHopperStatisticsResult(
                                        block,
                                        resultSize,
                                        (IntPtr)bufferPtr,
                                        &ptr,
                                        &bufferUsed);

                                    if (HR.SUCCEEDED(hresult))
                                    {
                                        statistics.hopperName =
                                            Converters.NullTerminatedBytePointerToString((byte*)ptr->hopperName);
                                        statistics.estimatedWaitTime = ptr->estimatedWaitTime;
                                        statistics.playersWaitingToMatch = ptr->playersWaitingToMatch;
                                    }
                                }
                            }

                            if (completionCallback != null)
                            { 
                                completionCallback.Invoke(hresult, statistics);
                            }
                        });

                    var scidLen = Converters.GetSizeRequiredToEncodeStringToUTF8(serviceConfigurationId);
                    var hopperLen = Converters.GetSizeRequiredToEncodeStringToUTF8(hopperName);

                    sbyte[] scidAsBytes = new sbyte[scidLen];
                    sbyte[] hopperNameAsBytes = new sbyte[hopperLen];
                    fixed (sbyte* scidBytePtr = &scidAsBytes[0], hopperNameBytePtr = &hopperNameAsBytes[0])
                    {
                        Converters.StringToNullTerminatedUTF8FixedPointer(serviceConfigurationId, (byte*)scidBytePtr, scidLen);
                        Converters.StringToNullTerminatedUTF8FixedPointer(hopperName, (byte*)hopperNameBytePtr, hopperLen);

                        result = Matchmaking.XblMatchmakingGetHopperStatisticsAsync(
                            xboxLiveContext.InteropHandle.handle,
                            scidBytePtr,
                            hopperNameBytePtr,
                            asyncBlock);

                        if (HR.FAILED(result))
                        {
                            if (completionCallback != null)
                            { 
                                completionCallback.Invoke(result, new XblHopperStatisticsResponse());
                            }
                        }
                    }
                }

                return result;
            }
        }
    }
}
