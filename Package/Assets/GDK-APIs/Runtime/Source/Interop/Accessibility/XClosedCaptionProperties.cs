using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XClosedCaptionProperties
    //{
    //    XColor BackgroundColor;
    //    XColor FontColor;
    //    XColor WindowColor;
    //    XClosedCaptionFontEdgeAttribute FontEdgeAttribute;
    //    XClosedCaptionFontStyle FontStyle;
    //    float FontScale;
    //    bool Enabled;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XClosedCaptionProperties
    {
        internal readonly XColor BackgroundColor;
        internal readonly XColor FontColor;
        internal readonly XColor WindowColor;
        internal readonly XClosedCaptionFontEdgeAttribute FontEdgeAttribute;
        internal readonly XClosedCaptionFontStyle FontStyle;
        internal readonly float FontScale;
        internal readonly NativeBool Enabled;
    }
}
