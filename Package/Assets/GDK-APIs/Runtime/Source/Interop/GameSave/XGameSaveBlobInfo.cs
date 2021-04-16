using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XGameSaveBlobInfo
    //{
    //    _Field_z_ const char* name;  // unique blob name (unique to container)
    //    uint32_t size;           // size of the saved data
    //};

    [StructLayout(LayoutKind.Sequential)]
    internal struct XGameSaveBlobInfo
    {
        public UTF8StringPtr Name;
        public UInt32 Size;
    }
}
