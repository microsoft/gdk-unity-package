using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    public enum XTaskQueueDispatchMode : UInt32
    {
        Manual = 0,
        ThreadPool,
        SerializedThreadPool,
        Immediate
    }

    public enum XTaskQueuePort : UInt32
    {
        Work = 0,
        Completion
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XTaskQueueHandle
    {
        private readonly IntPtr intPtr;
    }

    //struct XTaskQueueRegistrationToken
    //{
    //    uint64_t token;
    //};
    [StructLayout(LayoutKind.Sequential)]
    public struct XTaskQueueRegistrationToken
    {
        public readonly UInt64 token;
    }

    public class XTaskQueue
    {
        public XTaskQueueHandle handle { get; set; }
    }
}
