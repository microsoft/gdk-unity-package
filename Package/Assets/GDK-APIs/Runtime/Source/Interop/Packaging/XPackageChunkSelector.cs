using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XPackageChunkSelector
    //{
    //    XPackageChunkSelectorType type;
    //    union
    //    {
    //        _Field_z_ const char* language;
    //        _Field_z_ const char* tag;
    //        _Field_z_ const char* feature;
    //        uint32_t chunkId;
    //    };
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XPackageChunkSelector
    {
        internal XPackageChunkSelectorType type;

        internal UIntPtr unionData;
        
        internal string LanguageOrTagOrFeature()
        {
            unsafe
            {
                IntPtr unionDataPtr = (IntPtr)this.unionData.ToPointer();
                return Converters.PtrToStringUTF8(unionDataPtr);
            }
        }

        internal UInt32 ChunkId()
        {
            return Convert.ToUInt32(unionData.ToUInt64() & UInt32.MaxValue);
        }
    }
}