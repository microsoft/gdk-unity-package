using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal enum XTaskQueueDispatchMode : UInt32
    {
        Manual = 0,
        ThreadPool,
        SerializedThreadPool,
        Immediate
    }

    internal enum XTaskQueuePort : UInt32
    {
        Work = 0,
        Completion
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XTaskQueueHandle
    {
        private readonly IntPtr intPtr;
    }

    //struct XTaskQueueRegistrationToken
    //{
    //    uint64_t token;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XTaskQueueRegistrationToken
    {
        public readonly UInt64 token;
    }

    internal class XTaskQueue
    {
        public XTaskQueueHandle handle { get; set; }
    }
}
