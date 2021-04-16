using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreImage
    //{
    //    _Field_z_ const char* uri;
    //    uint32_t height;
    //    uint32_t width;
    //    _Field_z_ const char* caption;
    //    _Field_z_ const char* imagePurposeTag;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreImage
    {
        internal readonly UTF8StringPtr uri;
        internal readonly UInt32 height;
        internal readonly UInt32 width;
        internal readonly UTF8StringPtr caption;
        internal readonly UTF8StringPtr imagePurposeTag;

        internal XStoreImage(XGamingRuntime.XStoreImage publicObject, DisposableCollection disposableCollection)
        {
            this.uri = new UTF8StringPtr(publicObject.Uri, disposableCollection);
            this.height = publicObject.Height;
            this.width = publicObject.Width;
            this.caption = new UTF8StringPtr(publicObject.Caption, disposableCollection);
            this.imagePurposeTag = new UTF8StringPtr(publicObject.ImagePurposeTag, disposableCollection);
        }
    }
}