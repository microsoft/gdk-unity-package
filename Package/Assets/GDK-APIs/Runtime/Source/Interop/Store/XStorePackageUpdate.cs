using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStorePackageUpdate
    //{
    //    _Field_z_ char packageIdentifier[XPACKAGE_IDENTIFIER_MAX_LENGTH];
    //    bool isMandatory;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStorePackageUpdate
    {
        private unsafe fixed Byte packageIdentifier[33]; // char packageIdentifier[33]
        internal readonly NativeBool isMandatory;

        internal string GetPackageIdentifier() { unsafe { fixed (Byte* ptr = this.packageIdentifier) { return Converters.BytePointerToString(ptr, 33); } } }

        internal XStorePackageUpdate(XGamingRuntime.XStorePackageUpdate publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.packageIdentifier)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.PackageIdentifier, ptr, 33);
                }
            }
            this.isMandatory = new NativeBool(publicObject.IsMandatory);
        }
    }
}