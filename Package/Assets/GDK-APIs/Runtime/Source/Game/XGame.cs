using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    partial class SDK
    {
        public static Int32 XGameGetXboxTitleId(out UInt32 titleId)
        {
            return XGRInterop.XGameGetXboxTitleId(out titleId);
        }

        public static void XLaunchNewGame(string exePath, string args, XUserHandle defaultUser)
        {
            IntPtr userHandle = (defaultUser != null) ? defaultUser.Handle : IntPtr.Zero;

            XGRInterop.XLaunchNewGame(exePath, args, userHandle);
        }

        public static Int32 XLaunchRestartOnCrash(string args, UInt32 reserved)
        {
            return XGRInterop.XLaunchRestartOnCrash(args, reserved);
        }
    }
}
