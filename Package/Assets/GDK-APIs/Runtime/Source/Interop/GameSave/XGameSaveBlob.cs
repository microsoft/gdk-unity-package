using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XGameSaveBlob
    //{
    //    XGameSaveBlobInfo info;  // metadata
    //    uint8_t* data;           // saved data
    //};

    [StructLayout(LayoutKind.Sequential)]
    internal struct XGameSaveBlob
    {
        public XGameSaveBlobInfo info;
        private IntPtr data;

        public void CopyData(Byte[] buffer)
        {
            Marshal.Copy(data, buffer, 0, Convert.ToInt32(info.Size));
        }
    }
}
