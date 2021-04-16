using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    partial class XGRInterop
    {
        //STDAPI XClosedCaptionGetProperties(
        //    _Out_ XClosedCaptionProperties* properties
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XClosedCaptionGetProperties(
            out XClosedCaptionProperties properties);

        //STDAPI XClosedCaptionSetEnabled(
        //    _In_ bool enabled
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XClosedCaptionSetEnabled(
            NativeBool enabled);

        //STDAPI XHighContrastGetMode(
        //    _Out_ XHighContrastMode* mode
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XHighContrastGetMode(
            out XHighContrastMode mode);

        //STDAPI XSpeechToTextSendString(
        //    _In_z_ const char* speakerName,
        //    _In_z_ const char* content,
        //    _In_ XSpeechToTextType type
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XSpeechToTextSendString(
            Byte[] speakerName,
            Byte[] content,
            XSpeechToTextType type);
        
        //STDAPI XSpeechToTextSetPositionHint(
        //    _In_ XSpeechToTextPositionHint position
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XSpeechToTextSetPositionHint(
            XSpeechToTextPositionHint position);

        //STDAPI XSpeechToTextFinalizeHypothesisString(
        //    _In_ uint32_t hypothesisId,
        //    _In_z_ const char* content
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XSpeechToTextFinalizeHypothesisString(
            UInt32 hypothesisId,
            Byte[] content);

        //STDAPI XSpeechToTextUpdateHypothesisString(
        //    _In_ uint32_t hypothesisId,
        //    _In_z_ const char* content
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XSpeechToTextUpdateHypothesisString(
            UInt32 hypothesisId,
            Byte[] content);

        //STDAPI XSpeechToTextBeginHypothesisString(
        //    _In_z_ const char* speakerName,
        //    _In_z_ const char* content,
        //    _In_ XSpeechToTextType type,
        //    _Out_ uint32_t* hypothesisId
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XSpeechToTextBeginHypothesisString(
            Byte[] speakerName,
            Byte[] content,
            XSpeechToTextType type,
            out UInt32 hypothesisId);
        
        //STDAPI XSpeechToTextCancelHypothesisString(
        //    _In_ uint32_t hypothesisId
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XSpeechToTextCancelHypothesisString(
            UInt32 hypothesisId);
    }
}
