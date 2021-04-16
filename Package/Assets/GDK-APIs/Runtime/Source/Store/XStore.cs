using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreContext : EquatableHandle
    {
        internal override IntPtr GetInternalPtr()
        {
            return handle.intPtr;
        }

        internal XStoreContextHandle handle { get; set; }
    }

    public partial class SDK
    {
        public static Int32 XStoreCreateContext(out XStoreContext storeContext)
        {
            return XStoreCreateContext(null, out storeContext);
        }

        public static Int32 XStoreCreateContext(XUserHandle user, out XStoreContext storeContext)
        {
            storeContext = null;
            XStoreContextHandle context;
            Int32 hr = XGRInterop.XStoreCreateContext(user == null ? new Interop.XUserHandle() : user.InteropHandle, out context);
            if (HR.SUCCEEDED(hr))
            {
                storeContext = new XStoreContext { handle = context };
            }

            return hr;
        }

        public static void XStoreCloseContextHandle(XStoreContext context)
        {
            if (context == null)
            {
                return;
            }

            XGRInterop.XStoreCloseContextHandle(context.handle);
        }

        public static bool XStoreIsAvailabilityPurchasable(XStoreAvailability availability)
        {
            using (DisposableCollection disposableCollection = new DisposableCollection())
            {
                return XGRInterop.XStoreIsAvailabilityPurchasable(new Interop.XStoreAvailability(availability, disposableCollection)).Value;
            }
        }
    }
}
