using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreImage
    {
        internal XStoreImage(Interop.XStoreImage interopStruct)
        {
            this.Uri = interopStruct.uri.GetString();
            this.Height = interopStruct.height;
            this.Width = interopStruct.width;
            this.Caption = interopStruct.caption.GetString();
            this.ImagePurposeTag = interopStruct.imagePurposeTag.GetString();
        }

        public string Uri { get; private set; }
        public UInt32 Height { get; private set; }
        public UInt32 Width { get; private set; }
        public string Caption { get; private set; }
        public string ImagePurposeTag { get; private set; }
    }
}