using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XClosedCaptionProperties
    {
        internal XClosedCaptionProperties(Interop.XClosedCaptionProperties interopStruct)
        {
            this.BackgroundColor = new XColor(interopStruct.BackgroundColor);
            this.FontColor = new XColor(interopStruct.FontColor);
            this.WindowColor = new XColor(interopStruct.WindowColor);
            this.FontEdgeAttribute = interopStruct.FontEdgeAttribute;
            this.FontStyle = interopStruct.FontStyle;
            this.FontScale = interopStruct.FontScale;
            this.Enabled = interopStruct.Enabled.Value;
        }
    
        public XColor BackgroundColor { get; private set; }
        public XColor FontColor { get; private set; }
        public XColor WindowColor { get; private set; }
        public XClosedCaptionFontEdgeAttribute FontEdgeAttribute { get; private set; }
        public XClosedCaptionFontStyle FontStyle { get; private set; }
        public float FontScale { get; private set; }
        public bool Enabled { get; private set; }
    }
}
