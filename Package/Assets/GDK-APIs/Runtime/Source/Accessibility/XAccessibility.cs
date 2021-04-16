using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public static Int32 XClosedCaptionGetProperties(out XClosedCaptionProperties properties)
        {
            Interop.XClosedCaptionProperties interopProperties;
            Int32 hr = XGRInterop.XClosedCaptionGetProperties(out interopProperties);
            properties = new XClosedCaptionProperties(interopProperties);
            return hr;
        }

        public static Int32 XClosedCaptionSetEnabled(bool enabled)
        {
            return XGRInterop.XClosedCaptionSetEnabled(new NativeBool(enabled));
        }

        public static Int32 XHighContrastGetMode(out XHighContrastMode mode)
        {
            return XGRInterop.XHighContrastGetMode(out mode);
        }

        public static Int32 XSpeechToTextSendString(string speakerName, string content, XSpeechToTextType type)
        {
            return XGRInterop.XSpeechToTextSendString(
                Converters.StringToNullTerminatedUTF8ByteArray(speakerName),
                Converters.StringToNullTerminatedUTF8ByteArray(content),
                type);
        }

        public static Int32 XSpeechToTextSetPositionHint(XSpeechToTextPositionHint position)
        {
            return XGRInterop.XSpeechToTextSetPositionHint(position);
        }
        

        public static Int32 XSpeechToTextBeginHypothesisString(string speakerName, string content, XSpeechToTextType type, out UInt32 hypothesisId)
        {
            return XGRInterop.XSpeechToTextBeginHypothesisString(
                Converters.StringToNullTerminatedUTF8ByteArray(speakerName),
                Converters.StringToNullTerminatedUTF8ByteArray(content),
                type,
                out hypothesisId);
        }

        public static Int32 XSpeechToTextUpdateHypothesisString(UInt32 hypothesisId, string content)
        {
            return XGRInterop.XSpeechToTextUpdateHypothesisString(
                hypothesisId,
                Converters.StringToNullTerminatedUTF8ByteArray(content));
        }

        public static Int32 XSpeechToTextFinalizeHypothesisString(UInt32 hypothesisId, string content)
        {
            return XGRInterop.XSpeechToTextFinalizeHypothesisString(
                hypothesisId,
                Converters.StringToNullTerminatedUTF8ByteArray(content));
        }

        public static Int32 XSpeechToTextCancelHypothesisString(UInt32 hypothesisId)
        {
            return XGRInterop.XSpeechToTextCancelHypothesisString(hypothesisId);
        }
    }
}
