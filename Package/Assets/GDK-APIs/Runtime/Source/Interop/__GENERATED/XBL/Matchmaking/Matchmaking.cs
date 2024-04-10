using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    public static unsafe partial class Matchmaking
    {
        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMatchmakingCreateMatchTicketAsync([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, XblMultiplayerSessionReference ticketSessionReference, [NativeTypeName("const char *")] sbyte* matchmakingServiceConfigurationId, [NativeTypeName("const char *")] sbyte* hopperName, [NativeTypeName("const uint64_t")] ulong ticketTimeout, XblPreserveSessionMode preserveSession, [NativeTypeName("const char *")] sbyte* ticketAttributesJson, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr asyncBlock);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMatchmakingCreateMatchTicketResult([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr asyncBlock, XblCreateMatchTicketResponse* resultPtr);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMatchmakingDeleteMatchTicketAsync([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("const char *")] sbyte* serviceConfigurationId, [NativeTypeName("const char *")] sbyte* hopperName, [NativeTypeName("const char *")] sbyte* ticketId, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr asyncBlock);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMatchmakingGetMatchTicketDetailsAsync([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("const char *")] sbyte* serviceConfigurationId, [NativeTypeName("const char *")] sbyte* hopperName, [NativeTypeName("const char *")] sbyte* ticketId, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr asyncBlock);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMatchmakingGetMatchTicketDetailsResultSize([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr asyncBlock, [NativeTypeName("size_t *")] SizeT* resultSizeInBytes);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMatchmakingGetMatchTicketDetailsResult([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr asyncBlock, [NativeTypeName("size_t")] SizeT bufferSize, [NativeTypeName("void *")] IntPtr buffer, XblMatchTicketDetailsResponse** ptrToBuffer, [NativeTypeName("size_t *")] SizeT* bufferUsed);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMatchmakingGetHopperStatisticsAsync([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("const char *")] sbyte* serviceConfigurationId, [NativeTypeName("const char *")] sbyte* hopperName, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr asyncBlock);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMatchmakingGetHopperStatisticsResultSize([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr asyncBlock, [NativeTypeName("size_t *")] SizeT* resultSizeInBytes);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMatchmakingGetHopperStatisticsResult([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr asyncBlock, [NativeTypeName("size_t")] SizeT bufferSize, [NativeTypeName("void *")] IntPtr buffer, XblHopperStatisticsResponse** ptrToBuffer, [NativeTypeName("size_t *")] SizeT* bufferUsed);
    }
}
