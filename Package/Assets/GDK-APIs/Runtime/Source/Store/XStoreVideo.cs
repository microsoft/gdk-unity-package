using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreVideo
    {
        internal XStoreVideo(Interop.XStoreVideo interopStruct)
        {
            this.Uri = interopStruct.uri.GetString();
            this.Height = interopStruct.height;
            this.Width = interopStruct.width;
            this.Caption = interopStruct.caption.GetString();
            this.VideoPurposeTag = interopStruct.videoPurposeTag.GetString();
            this.PreviewImage = new XStoreImage(interopStruct.previewImage);
        }

        public string Uri { get; private set; }
        public UInt32 Height { get; private set; }
        public UInt32 Width { get; private set; }
        public string Caption { get; private set; }
        public string VideoPurposeTag { get; private set; }
        public XStoreImage PreviewImage { get; private set; }
    }
}