using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XGameSaveContainerInfo
    {
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public UInt32 BlobCount { get; private set; }
        public UInt64 TotalSize { get; private set; }
        public DateTime LastModifiedTime { get; private set; }

        internal XGameSaveContainerInfo(Interop.XGameSaveContainerInfo interopInfo)
        {
            Name = interopInfo.name.GetString();
            DisplayName = interopInfo.displayName.GetString();
            BlobCount = interopInfo.blobCount;
            TotalSize = interopInfo.totalSize;
            LastModifiedTime = interopInfo.lastModifiedTime.DateTime;
        }        
    }
}
