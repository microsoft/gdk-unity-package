using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    public static unsafe partial class Social
    {
        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialGetSocialRelationshipsAsync([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("uint64_t")] ulong xboxUserId, XblSocialRelationshipFilter socialRelationshipFilter, [NativeTypeName("size_t")] SizeT startIndex, [NativeTypeName("size_t")] SizeT maxItems, XAsyncBlockPtr async);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialGetSocialRelationshipsResult(XAsyncBlockPtr async, [NativeTypeName("XblSocialRelationshipResultHandle *")] IntPtr* handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialRelationshipResultGetRelationships([NativeTypeName("XblSocialRelationshipResultHandle")] IntPtr resultHandle, [NativeTypeName("const XblSocialRelationship **")] XblSocialRelationship** relationships, [NativeTypeName("size_t *")] SizeT* relationshipsCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialRelationshipResultHasNext([NativeTypeName("XblSocialRelationshipResultHandle")] IntPtr resultHandle, bool* hasNext);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialRelationshipResultGetTotalCount([NativeTypeName("XblSocialRelationshipResultHandle")] IntPtr resultHandle, [NativeTypeName("size_t *")] SizeT* totalCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialRelationshipResultGetNextAsync([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("XblSocialRelationshipResultHandle")] IntPtr resultHandle, [NativeTypeName("size_t")] SizeT maxItems, XAsyncBlockPtr async);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialRelationshipResultGetNextResult(XAsyncBlockPtr async, [NativeTypeName("XblSocialRelationshipResultHandle *")] IntPtr* handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialRelationshipResultDuplicateHandle([NativeTypeName("XblSocialRelationshipResultHandle")] IntPtr handle, [NativeTypeName("XblSocialRelationshipResultHandle *")] IntPtr* duplicatedHandle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblSocialRelationshipResultCloseHandle([NativeTypeName("XblSocialRelationshipResultHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("XblFunctionContext")]
        public static extern int XblSocialAddSocialRelationshipChangedHandler([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("XblSocialRelationshipChangedHandler")] XblSocialRelationshipChangedHandler handler, IntPtr handlerContext);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblSocialRemoveSocialRelationshipChangedHandler([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("XblFunctionContext")] int handlerFunctionContext);
    }
}
