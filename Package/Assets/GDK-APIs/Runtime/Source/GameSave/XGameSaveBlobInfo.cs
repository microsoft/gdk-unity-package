using System;

namespace XGamingRuntime
{
    public class XGameSaveBlobInfo
    {
        public string Name { get; private set; }
        public UInt32 Size { get; private set; }

        internal XGameSaveBlobInfo(Interop.XGameSaveBlobInfo interopHandle)
        {
            Name = interopHandle.Name.GetString();
            Size = interopHandle.Size;
        }
    }
}
