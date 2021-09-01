using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public static XTaskQueue defaultQueue = null;
        static bool isInitialized = false;

        public static Int32 XGameRuntimeInitialize()
        {
            Int32 hr = XGRInterop.XGameRuntimeInitialize();
            if (HR.SUCCEEDED(hr))
            {
                XTaskQueueHandle handle;
                hr = XGRInterop.XTaskQueueCreate(XTaskQueueDispatchMode.ThreadPool, XTaskQueueDispatchMode.Manual, out handle);
                defaultQueue = new XTaskQueue { handle = handle };
            }

            if (HR.SUCCEEDED(hr))
            {
                isInitialized = true;
            }

            return hr;
        }

        public static void XGameRuntimeUninitialize()
        {
            if (isInitialized)
            {
                XGRInterop.XTaskQueueCloseHandle(defaultQueue.handle);
                XGRInterop.XGameRuntimeUninitialize();
            }
        }

        public static void XTaskQueueDispatch(UInt32 timeoutMs = 0)
        {
            if (isInitialized)
            {
                XGRInterop.XTaskQueueDispatch(defaultQueue.handle, XTaskQueuePort.Completion, timeoutMs);
            }
        }
    }
}
