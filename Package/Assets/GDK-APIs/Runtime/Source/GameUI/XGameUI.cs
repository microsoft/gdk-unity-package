using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XGameUiShowAchievementsCompleted(Int32 hresult);
    public delegate void XGameUiShowMessageDialogCompleted(Int32 hresult, XGameUiMessageDialogButton resultButton);
    public delegate void XGameUiShowErrorDialogCompleted(Int32 hresult);
    public delegate void XGameUiShowTextEntryAsyncCompleted(Int32 hresult, string resultText);
    public delegate void XGameUiShowSendGameInviteAsyncCompleted(Int32 hresult);
    public delegate void XGameUiShowWebAuthenticationAsyncCompleted(Int32 hresult, XGameUiWebAuthenticationResultData result);
    public delegate void XGameUiShowPlayerProfileCardAsyncCompleted(Int32 hresult);
    public delegate void XGameUiShowPlayerPickerAsyncCompleted(Int32 hresult, UInt64[] resultPlayers);

    partial class SDK
    {
        public static void XGameUiShowAchievementsAsync(XUserHandle requestingUser, UInt32 titleId, XGameUiShowAchievementsCompleted completionRoutine)
        {
            if (requestingUser == null)
            {
                completionRoutine(HR.E_INVALIDARG);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Int32 result = XGRInterop.XGameUiShowAchievementsResult(block);
                completionRoutine(result);
            });

            int hr = XGRInterop.XGameUiShowAchievementsAsync(asyncBlock, requestingUser.InteropHandle, titleId);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr);
            }
        }

        public static void XGameUiShowMessageDialogAsync(
            string titleText,
            string contentText,
            string firstButtonText,
            string secondButtonText,
            string thirdButtonText,
            XGameUiMessageDialogButton defaultButton,
            XGameUiMessageDialogButton cancelButton,
            XGameUiShowMessageDialogCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                XGameUiMessageDialogButton resultButton;
                Int32 result = XGRInterop.XGameUiShowMessageDialogResult(block, out resultButton);
                completionRoutine(result, resultButton);
            });

            int hr = XGRInterop.XGameUiShowMessageDialogAsync(
                asyncBlock,
                Converters.StringToNullTerminatedUTF8ByteArray(titleText),
                Converters.StringToNullTerminatedUTF8ByteArray(contentText),
                Converters.StringToNullTerminatedUTF8ByteArray(firstButtonText),
                Converters.StringToNullTerminatedUTF8ByteArray(secondButtonText),
                Converters.StringToNullTerminatedUTF8ByteArray(thirdButtonText),
                defaultButton,
                cancelButton);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, default(XGameUiMessageDialogButton));
            }
        }

        public static void XGameUiShowErrorDialogAsync(Int32 errorCode, string context, XGameUiShowErrorDialogCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Int32 result = XGRInterop.XGameUiShowErrorDialogResult(block);
                completionRoutine(result);
            });

            int hr = XGRInterop.XGameUiShowErrorDialogAsync(asyncBlock, errorCode, Converters.StringToNullTerminatedUTF8ByteArray(context));

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr);
            }
        }

        public static void XGameUiShowTextEntryAsync(
            string titleText,
            string descriptionText,
            string defaultText,
            XGameUiTextEntryInputScope inputScope,
            UInt32 maxTextLength,
            XGameUiShowTextEntryAsyncCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                UInt32 resultTextBufferSize = 0;
                UInt32 resultTextBufferUsed = 0;

                Int32 result = XGRInterop.XGameUiShowTextEntryResultSize(
                    block,
                    out resultTextBufferSize);

                if (HR.FAILED(result))
                {
                    completionRoutine(result, default(string));
                }

                var resultTextBuffer = new byte[resultTextBufferSize];

                result = XGRInterop.XGameUiShowTextEntryResult(
                    block,
                    resultTextBufferSize,
                    resultTextBuffer,
                    out resultTextBufferUsed);

                var resultText = System.Text.Encoding.UTF8.GetString(resultTextBuffer);
                completionRoutine(result, resultText);
            });

            Int32 hr = XGRInterop.XGameUiShowTextEntryAsync(
                    asyncBlock,
                    Converters.StringToNullTerminatedUTF8ByteArray(titleText),
                    Converters.StringToNullTerminatedUTF8ByteArray(descriptionText),
                    Converters.StringToNullTerminatedUTF8ByteArray(defaultText),
                    inputScope,
                    maxTextLength);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, default(string));
            }
        }

        public static Int32 XGameUiSetNotificationPositionHint(XGameUiNotificationPositionHint position)
        {
            return XGRInterop.XGameUiSetNotificationPositionHint(position);
        }

        public static void XGameUiShowSendGameInviteAsync(
            XUserHandle requestingUser,
            string sessionConfigurationId,
            string sessionTemplateName,
            string sessionId,
            string invitationText,
            string customActivationContext,
            XGameUiShowSendGameInviteAsyncCompleted completionRoutine)
        {
            if (requestingUser == null)
            {
                completionRoutine(HR.E_INVALIDARG);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Int32 result = XGRInterop.XGameUiShowSendGameInviteResult(block);
                completionRoutine(result);
            });

            Int32 hr = XGRInterop.XGameUiShowSendGameInviteAsync(
                    asyncBlock,
                    requestingUser.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(sessionConfigurationId),
                    Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName),
                    Converters.StringToNullTerminatedUTF8ByteArray(sessionId),
                    Converters.StringToNullTerminatedUTF8ByteArray(invitationText),
                    Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext));

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr);
            }
        }

        public static void XGameUIShowWebAuthenticationAsync(
            XUserHandle requestingUser,
            string requestUri,
            string completionUri,
            XGameUiShowWebAuthenticationAsyncCompleted completionRoutine)
        {
            if (requestingUser == null)
            {
                completionRoutine(HR.E_INVALIDARG, default(XGameUiWebAuthenticationResultData));
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                SizeT resultSizeInBytes;
                Int32 result = XGRInterop.XGameUiShowWebAuthenticationResultSize(block, out resultSizeInBytes);
                if (HR.FAILED(result))
                {
                    completionRoutine(result, default(XGameUiWebAuthenticationResultData));
                }

                using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                {
                    IntPtr ptrToBuffer;
                    SizeT bufferUsed;
                    result = XGRInterop.XGameUiShowWebAuthenticationResult(
                        block,
                        resultSizeInBytes,
                        buffer.IntPtr,
                        out ptrToBuffer,
                        out bufferUsed);

                    if (HR.FAILED(result))
                    {
                        completionRoutine(result, default(XGameUiWebAuthenticationResultData));
                        return;
                    }

                    XGameUiWebAuthenticationResultData data =
                        Converters.PtrToClass<XGameUiWebAuthenticationResultData, Interop.XGameUiWebAuthenticationResultData>(ptrToBuffer, r =>new XGameUiWebAuthenticationResultData(r));

                    completionRoutine(result, data);
                }
            });

            Int32 hr = XGRInterop.XGameUiShowWebAuthenticationAsync(
                    asyncBlock,
                    requestingUser.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(requestUri),
                    Converters.StringToNullTerminatedUTF8ByteArray(completionUri));

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, default(XGameUiWebAuthenticationResultData));
            }
        }

        public static void XGameUiShowPlayerProfileCardAsync(
            XUserHandle requestingUser,
            UInt64 targetPlayer,
            XGameUiShowPlayerProfileCardAsyncCompleted completionRoutine)
        {
            if (requestingUser == null)
            {
                completionRoutine(HR.E_INVALIDARG);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Int32 result = XGRInterop.XGameUiShowPlayerProfileCardResult(block);
                completionRoutine(result);
            });

            Int32 hr = XGRInterop.XGameUiShowPlayerProfileCardAsync(
                    asyncBlock,
                    requestingUser.InteropHandle,
                    targetPlayer);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr);
            }
        }

        public static void XGameUiShowPlayerPickerAsync(
            XUserHandle requestingUser,
            string promptText,
            UInt64[] selectFromPlayers,
            UInt64[] preselectedPlayers,
            UInt32 minSelectionCount,
            UInt32 maxSelectionCount,
            XGameUiShowPlayerPickerAsyncCompleted completionRoutine)
        {
            if (requestingUser == null || selectFromPlayers == null || preselectedPlayers == null)
            {
                completionRoutine(HR.E_INVALIDARG, default(ulong[]));
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                UInt32 resultCount;
                Int32 result = XGRInterop.XGameUiShowPlayerPickerResultCount(
                    block,
                    out resultCount);

                if (HR.FAILED(result))
                {
                    completionRoutine(result, default(ulong[]));
                }

                var resultPlayers = new ulong[resultCount];

                UInt32 resultPlayersUsed;
                result = XGRInterop.XGameUiShowPlayerPickerResult(
                    block,
                    resultCount,
                    resultPlayers,
                    out resultPlayersUsed);

                completionRoutine(result, resultPlayers);
            });

            Int32 hr = XGRInterop.XGameUiShowPlayerPickerAsync(
                    asyncBlock,
                    requestingUser.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(promptText),
                    (uint)selectFromPlayers.Length,
                    selectFromPlayers,
                    (uint)preselectedPlayers.Length,
                    preselectedPlayers,
                    minSelectionCount,
                    maxSelectionCount);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, default(ulong[]));
            }
        }
    }
}
