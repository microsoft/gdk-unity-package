using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreVideo
    //{
    //    _Field_z_ const char* uri;
    //    uint32_t height;
    //    uint32_t width;
    //    _Field_z_ const char* caption;
    //    _Field_z_ const char* videoPurposeTag;
    //    XStoreImage previewImage;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreVideo
    {
        internal readonly UTF8StringPtr uri;
        internal readonly UInt32 height;
        internal readonly UInt32 width;
        internal readonly UTF8StringPtr caption;
        internal readonly UTF8StringPtr videoPurposeTag;
        internal readonly XStoreImage previewImage;

        internal XStoreVideo(XGamingRuntime.XStoreVideo publicObject, DisposableCollection disposableCollection)
        {
            this.uri = new UTF8StringPtr(publicObject.Uri, disposableCollection);
            this.height = publicObject.Height;
            this.width = publicObject.Width;
            this.caption = new UTF8StringPtr(publicObject.Caption, disposableCollection);
            this.videoPurposeTag = new UTF8StringPtr(publicObject.VideoPurposeTag, disposableCollection);
            this.previewImage = new XStoreImage(publicObject.PreviewImage, disposableCollection);
        }
    }
}