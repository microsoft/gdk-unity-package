using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    partial class XGRInterop
    {
        //STDAPI XGameUiShowAchievementsAsync(
        //    _In_ XAsyncBlock* async,
        //    _In_ XUserHandle requestingUser,
        //    _In_ uint32_t titleId
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowAchievementsAsync(XAsyncBlockPtr asyncBlock, XUserHandle requestingUser, UInt32 titleId);

        //STDAPI XGameUiShowAchievementsResult(
        //    _In_ XAsyncBlock * async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowAchievementsResult(XAsyncBlockPtr asyncBlock);

        //STDAPI XGameUiShowMessageDialogAsync(
        //    _In_ XAsyncBlock* async,
        //    _In_z_ const char* titleText,
        //    _In_z_ const char* contentText,
        //    _In_opt_z_ const char* firstButtonText,
        //    _In_opt_z_ const char* secondButtonText,
        //    _In_opt_z_ const char* thirdButtonText,
        //    _In_ XGameUiMessageDialogButton defaultButton,
        //    _In_ XGameUiMessageDialogButton cancelButton
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowMessageDialogAsync(
            XAsyncBlockPtr asyncBlock,
            byte[] titleText,
            byte[] contentText,
            byte[] firstButtonText,
            byte[] secondButtonText,
            byte[] thirdButtonText,
            XGameUiMessageDialogButton defaultButton,
            XGameUiMessageDialogButton cancelButton);

        //STDAPI XGameUiShowMessageDialogResult(
        //    _In_ XAsyncBlock* async,
        //    _Out_ XGameUiMessageDialogButton* resultButton
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowMessageDialogResult(
            XAsyncBlockPtr asyncBlock,
            out XGameUiMessageDialogButton resultButton);

        //STDAPI XGameUiShowErrorDialogAsync(
        //    _In_ XAsyncBlock* async,
        //    _In_ HRESULT errorCode,
        //    _In_opt_z_ const char* context
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowErrorDialogAsync(
            XAsyncBlockPtr asyncBlock,
            Int32 errorCode,
            [Optional] byte[] context);

        //STDAPI XGameUiShowErrorDialogResult(
        //    _In_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowErrorDialogResult(XAsyncBlockPtr asyncBlock);

        //STDAPI XGameUiShowSendGameInviteAsync(
        //    _In_ XAsyncBlock* async,
        //    _In_ XUserHandle requestingUser,
        //    _In_z_ const char* sessionConfigurationId,
        //    _In_z_ const char* sessionTemplateName,
        //    _In_z_ const char* sessionId,
        //    _In_opt_z_ const char* invitationText,
        //    _In_opt_z_ const char* customActivationContext
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowSendGameInviteAsync(
            XAsyncBlockPtr asyncBlock,
            XUserHandle requestingUser,
            byte[] sessionConfigurationId,
            byte[] sessionTemplateName,
            byte[] sessionId,
            byte[] invitationText,
            byte[] customActivationContext);

        //STDAPI XGameUiShowSendGameInviteResult(
        //    _In_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowSendGameInviteResult(XAsyncBlockPtr asyncBlock);

        //STDAPI XGameUiShowPlayerProfileCardAsync(
        //    _In_ XAsyncBlock* async,
        //    _In_ XUserHandle requestingUser,
        //    _In_ uint64_t targetPlayer
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowPlayerProfileCardAsync(
            XAsyncBlockPtr asyncBlock,
            XUserHandle requestingUser,
            UInt64 targetPlayer);

        //STDAPI XGameUiShowPlayerProfileCardResult(
        //    _In_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowPlayerProfileCardResult(XAsyncBlockPtr asyncBlock);

        //STDAPI XGameUiShowPlayerPickerAsync(
        //    _In_ XAsyncBlock* async,
        //    _In_ XUserHandle requestingUser,
        //    _In_z_ const char* promptText,
        //    _In_ uint32_t selectFromPlayersCount,
        //    _In_reads_(selectFromPlayersCount) const uint64_t* selectFromPlayers,
        //    _In_ uint32_t preSelectedPlayersCount,
        //    _In_reads_opt_(preSelectedPlayersCount) const uint64_t* preSelectedPlayers,
        //    _In_ uint32_t minSelectionCount,
        //    _In_ uint32_t maxSelectionCount
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowPlayerPickerAsync(
            XAsyncBlockPtr asyncBlock,
            XUserHandle requestingUser,
            byte[] promptText,
            UInt32 selectFromPlayersCount,
            [In] UInt64[] selectFromPlayers,
            UInt32 preSelectedPlayersCount,
            [In] UInt64[] preSelectedPlayers,
            UInt32 minSelectionCount,
            UInt32 maxSelectionCount);

        //STDAPI XGameUiShowPlayerPickerResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ uint32_t* resultPlayersCount
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowPlayerPickerResultCount(
            XAsyncBlockPtr asyncBlock,
            out UInt32 resultPlayersCount);

        //STDAPI XGameUiShowPlayerPickerResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ uint32_t resultPlayersCount,
        //    _Out_writes_to_(resultPlayersCount, * resultPlayersUsed) uint64_t* resultPlayers,
        //    _Out_opt_ uint32_t* resultPlayersUsed
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowPlayerPickerResult(
            XAsyncBlockPtr asyncBlock,
            UInt32 resultPlayersCount,
            [MarshalAs(UnmanagedType.LPArray), In, Out]
            UInt64[] resultPlayers,
            out UInt32 resultPlayersUsed);

        //STDAPI XGameUiSetNotificationPositionHint(
        //    _In_ XGameUiNotificationPositionHint position
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiSetNotificationPositionHint(XGameUiNotificationPositionHint position);

        //STDAPI XGameUiShowTextEntryAsync(
        //    _In_ XAsyncBlock* async,
        //    _In_opt_z_ const char* titleText,
        //    _In_opt_z_ const char* descriptionText,
        //    _In_opt_z_ const char* defaultText,
        //    _In_ XGameUiTextEntryInputScope inputScope,
        //    _In_ uint32_t maxTextLength
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowTextEntryAsync(
            XAsyncBlockPtr asyncBlock,
            byte[] titleText,
            byte[] descriptionText,
            byte[] defaultText,
            XGameUiTextEntryInputScope inputScope,
            UInt32 maxTextLength);

        //STDAPI XGameUiShowTextEntryResultSize(
        //    _In_ XAsyncBlock* async,
        //    _Out_ uint32_t* resultTextBufferSize
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowTextEntryResultSize(
            XAsyncBlockPtr asyncBlock,
            out UInt32 resultTextBufferSize);

        //STDAPI XGameUiShowTextEntryResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ uint32_t resultTextBufferSize,
        //    _Out_writes_to_(resultTextBufferSize, * resultTextBufferUsed) char* resultTextBuffer,
        //    _Out_opt_ uint32_t* resultTextBufferUsed
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowTextEntryResult(
            XAsyncBlockPtr asyncBlock,
            UInt32 resultTextBufferSize,
            [Out] byte[] resultTextBuffer,
            out UInt32 resultTextBufferUsed);

        //STDAPI XGameUiShowWebAuthenticationAsync(
        //    _In_ XAsyncBlock* async,
        //    _In_ XUserHandle requestingUser,
        //    _In_z_ const char* requestUri,
        //    _In_z_ const char* completionUri
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowWebAuthenticationAsync(
            XAsyncBlockPtr asyncBlock,
            XUserHandle requestingUser,
            byte[] requestUri,
            byte[] completionUri);


        //STDAPI XGameUiShowWebAuthenticationResultSize(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ size_t* bufferSize
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowWebAuthenticationResultSize(
            XAsyncBlockPtr asyncBlock,
            out SizeT bufferSize);

        //STDAPI XGameUiShowWebAuthenticationResult(
        //    _Inout_ XAsyncBlock* async,
        //    _In_ size_t bufferSize,
        //    _Out_writes_bytes_to_(bufferSize, * bufferUsed) void* buffer,
        //    _Outptr_ XGameUiWebAuthenticationResultData** ptrToBuffer,
        //    _Out_opt_ size_t* bufferUsed
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameUiShowWebAuthenticationResult(
            XAsyncBlockPtr asyncBlock,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr ptrToBuffer,
            out SizeT bufferUsed);
    }
}
