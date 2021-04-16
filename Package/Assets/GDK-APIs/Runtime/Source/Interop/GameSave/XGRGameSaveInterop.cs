using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef bool CALLBACK XGameSaveBlobInfoCallback(_In_ const XGameSaveBlobInfo* info, _In_opt_ void* context);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate NativeBool XGameSaveBlobInfoCallback(XGameSaveBlobInfo info, IntPtr context);

    //typedef bool CALLBACK XGameSaveContainerInfoCallback(_In_ const XGameSaveContainerInfo* info, _In_opt_ void* context);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate NativeBool XGameSaveContainerInfoCallback(XGameSaveContainerInfo info, IntPtr context);


    partial class XGRInterop
    {
        // HBRODIE: TODO: add correct parameter tagging
        // Provider

        //STDAPI XGameSaveInitializeProvider(_In_ XUserHandle userContext, _In_opt_z_ const char* configurationId, _In_ bool syncOnDemand, _Outptr_result_nullonfailure_ XGameSaveProviderHandle* provider) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveInitializeProvider(XUserHandle userContext, Byte[] configurationId, [MarshalAs(UnmanagedType.U1)] bool syncOnDemand, out XGameSaveProviderHandle provider);

        //STDAPI XGameSaveInitializeProviderAsync(_In_ XUserHandle userContext, _In_opt_z_ const char* configurationId, _In_ bool syncOnDemand, _In_ XAsyncBlock* async) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveInitializeProviderAsync(XUserHandle userContext, Byte[] configurationId, [MarshalAs(UnmanagedType.U1)] bool syncOnDemand, XAsyncBlockPtr asyncBlock);

        //STDAPI XGameSaveInitializeProviderResult(_In_ XAsyncBlock* async, _Outptr_result_nullonfailure_ XGameSaveProviderHandle* provider) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveInitializeProviderResult(XAsyncBlockPtr asyncBlock, out XGameSaveProviderHandle provider);

        //STDAPI_(void) XGameSaveCloseProvider(_In_ XGameSaveProviderHandle provider) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XGameSaveCloseProvider(XGameSaveProviderHandle provider);

        // Quota checks

        //STDAPI XGameSaveGetRemainingQuota(_In_ XGameSaveProviderHandle provider, _Out_ int64_t* remainingQuota) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveGetRemainingQuota(XGameSaveProviderHandle provider, out Int64 remainingQuota);

        //STDAPI XGameSaveGetRemainingQuotaAsync(_In_ XGameSaveProviderHandle provider, _In_ XAsyncBlock* async) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveGetRemainingQuotaAsync(XGameSaveProviderHandle provider, XAsyncBlockPtr asyncBlock);

        //STDAPI XGameSaveGetRemainingQuotaResult(_In_ XAsyncBlock* async, _Out_ int64_t* remainingQuota) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveGetRemainingQuotaResult(XAsyncBlockPtr asyncBlock, out Int64 remainingQuota);

        // Container Management / Information

        //STDAPI XGameSaveDeleteContainer(_In_ XGameSaveProviderHandle provider, _In_z_ const char* containerName) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveDeleteContainer(XGameSaveProviderHandle provider, Byte[] containerName);

        //STDAPI XGameSaveDeleteContainerAsync(_In_ XGameSaveProviderHandle provider, _In_z_ const char* containerName, _In_ XAsyncBlock* async) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveDeleteContainerAsync(XGameSaveProviderHandle provider, Byte[] containerName, XAsyncBlockPtr asyncBlock);

        //STDAPI XGameSaveDeleteContainerResult(_In_ XAsyncBlock* async) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveDeleteContainerResult(XAsyncBlockPtr asyncBlock);

        //STDAPI XGameSaveCreateContainer(_In_ XGameSaveProviderHandle provider, _In_z_ const char* containerName, _Outptr_result_nullonfailure_ XGameSaveContainerHandle* containerContext) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveCreateContainer(XGameSaveProviderHandle provider, Byte[] containerName, out XGameSaveContainerHandle containerContext);

        //STDAPI_(void) XGameSaveCloseContainer(_In_ XGameSaveContainerHandle context) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XGameSaveCloseContainer(XGameSaveContainerHandle containerContext);

        //STDAPI XGameSaveGetContainerInfo(_In_ XGameSaveProviderHandle provider, _In_z_ const char* containerName, _In_opt_ void* context, _In_ XGameSaveContainerInfoCallback* callback) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveGetContainerInfo(XGameSaveProviderHandle provider, Byte[] containerName, IntPtr context, XGameSaveContainerInfoCallback callback);

        //STDAPI XGameSaveEnumerateContainerInfo(_In_ XGameSaveProviderHandle provider, _In_opt_ void* context, _In_ XGameSaveContainerInfoCallback* callback) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveEnumerateContainerInfo(XGameSaveProviderHandle provider, IntPtr context, XGameSaveContainerInfoCallback callback);

        //STDAPI XGameSaveEnumerateContainerInfoByName(_In_ XGameSaveProviderHandle provider, _In_opt_z_ const char* containerNamePrefix, _In_opt_ void* context, _In_ XGameSaveContainerInfoCallback* callback) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveEnumerateContainerInfoByName(XGameSaveProviderHandle provider, Byte[] containerNamePrefix, IntPtr context, XGameSaveContainerInfoCallback callback);


        // Available Blob Information
        //STDAPI XGameSaveEnumerateBlobInfo(_In_ XGameSaveContainerHandle container, _In_opt_ void* context, _In_ XGameSaveBlobInfoCallback* callback) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveEnumerateBlobInfo(XGameSaveContainerHandle container, IntPtr context, XGameSaveBlobInfoCallback callback);

        //STDAPI XGameSaveEnumerateBlobInfoByName(_In_ XGameSaveContainerHandle container, _In_opt_z_ const char* blobNamePrefix, _In_opt_ void* context, _In_ XGameSaveBlobInfoCallback* callback) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveEnumerateBlobInfoByName(XGameSaveContainerHandle container, Byte[] blobNamePrefix, IntPtr context, XGameSaveBlobInfoCallback callback);

        // Read Blob Data
        //STDAPI XGameSaveReadBlobData(_In_ XGameSaveContainerHandle container, _In_opt_z_count_(* countOfBlobs) const char** blobNames, _Inout_ uint32_t* countOfBlobs, _In_ size_t blobsSize, _Out_writes_bytes_(blobsSize) XGameaveBlob* blobData) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveReadBlobData(XGameSaveContainerHandle container, IntPtr blobNames, ref UInt32 countOfBlobs, SizeT blobsSize, IntPtr allocatedBlobPtr);

        //STDAPI XGameSaveReadBlobDataAsync(_In_ XGameSaveContainerHandle container, _In_opt_z_count_(countOfBlobs) const char** blobNames, _In_ uint32_t countOfBlobs, _In_ XAsyncBlock* async) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveReadBlobDataAsync(XGameSaveContainerHandle container, IntPtr blobNames, UInt32 countOfBlobs, XAsyncBlockPtr asyncBlock);
 
        //STDAPI XGameSaveReadBlobDataResult(_In_ XAsyncBlock* async, _In_ size_t blobsSize, _Out_writes_bytes_(blobsSize) XGameSaveBlob* blobData, _Out_ uint32_t* countOfBlobs) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveReadBlobDataResult(XAsyncBlockPtr asyncBlock, SizeT blobsSize, IntPtr allocatedBlobPtr, out UInt32 countOfBlobs);

        // Update / Write Blob Data

        //STDAPI XGameSaveCreateUpdate(_In_ XGameSaveContainerHandle container, _In_z_ const char* containerDisplayName, _Outptr_result_nullonfailure_ XGameSaveUpdateHandle* updateContext) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveCreateUpdate(XGameSaveContainerHandle container, Byte[] containerDisplayName, ref XGameSaveUpdateHandle updateContext);

        //STDAPI_(void) XGameSaveCloseUpdate(_In_ XGameSaveUpdateHandle context) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XGameSaveCloseUpdate(XGameSaveUpdateHandle context);

        //STDAPI XGameSaveSubmitBlobWrite(_In_ XGameSaveUpdateHandle updateContext, _In_z_ const char* blobName, _In_reads_bytes_(byteCount) const uint8_t* data, _In_ size_t byteCount) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveSubmitBlobWrite(XGameSaveUpdateHandle context, Byte[] blobName, Byte[] data, SizeT byteCount);

        //STDAPI XGameSaveSubmitBlobDelete(_In_ XGameSaveUpdateHandle updateContext, _In_z_ const char* blobName) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveSubmitBlobDelete(XGameSaveUpdateHandle updateContext, Byte[] blobName);

        //STDAPI XGameSaveSubmitUpdate(_In_ XGameSaveUpdateHandle updateContext) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveSubmitUpdate(XGameSaveUpdateHandle updateContext);

        //STDAPI XGameSaveSubmitUpdateAsync(_In_ XGameSaveUpdateHandle updateContext, _In_ XAsyncBlock* async) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveSubmitUpdateAsync(XGameSaveUpdateHandle updateContext, XAsyncBlockPtr asyncBlock);

        //STDAPI XGameSaveSubmitUpdateResult(_In_ XAsyncBlock* async) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameSaveSubmitUpdateResult(XAsyncBlockPtr asyncBlock);
    }
}
