using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    public static unsafe partial class XStore
    {
        [DllImport("XGamingRuntimeThunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        internal static extern int XStoreShowProductPageUIAsync([NativeTypeName("const XStoreContextHandle")] XStoreContextHandle storeContextHandle, [NativeTypeName("const char *")] byte[] storeId, XAsyncBlockPtr async);

        [DllImport("XGamingRuntimeThunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        internal static extern int XStoreShowProductPageUIResult(XAsyncBlockPtr async);

        [DllImport("XGamingRuntimeThunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        internal static extern int XStoreShowAssociatedProductsUIAsync([NativeTypeName("const XStoreContextHandle")] XStoreContextHandle storeContextHandle, [NativeTypeName("const char *")] byte[] storeId, XStoreProductKind productKinds, XAsyncBlockPtr async);

        [DllImport("XGamingRuntimeThunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        internal static extern int XStoreShowAssociatedProductsUIResult(XAsyncBlockPtr async);
    }
}
