using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // HBRODIE: TODO: Update to agreed on format for marshalling strings.

    //struct XGameSaveContainerInfo
    //{
    //    _Field_z_ const char* name;           // unique container name
    //    _Field_z_ const char* displayName;    // display name
    //    uint32_t blobCount;      // number of blobs in the container
    //    uint64_t totalSize;      // size of all the blobs in the container
    //    time_t lastModifiedTime; // last time this container was updated
    //    bool needsSync;          // sync status, if not synced any operation on this container may result in a network call (if using SyncOnDemand) 
    //};

    [StructLayout(LayoutKind.Sequential)]
    internal struct XGameSaveContainerInfo
    {
        internal UTF8StringPtr name;
        internal UTF8StringPtr displayName;
        internal UInt32 blobCount;
        internal UInt64 totalSize;
        internal TimeT lastModifiedTime;
        [MarshalAs(UnmanagedType.U1)]
        internal bool NeedsSync;
    }
}