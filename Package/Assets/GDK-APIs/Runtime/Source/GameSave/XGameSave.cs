using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XGameSaveInitializeProviderCompleted(Int32 hresult, XGameSaveProviderHandle gameSaveProviderHandle);
    public delegate void XGameSaveGetRemainingQuotaCompleted(Int32 hresult, Int64 remainingQuota);
    public delegate void XGameSaveDeleteContainerCompleted(Int32 hresult);
    public delegate void XGameSaveSubmitUpdateCompleted(Int32 hresult);
    public delegate void XGameSaveReadBlobDataCompleted(Int32 hresult, XGameSaveBlob[] blobs);

    public partial class SDK
    {
        #region Callbacks
        [MonoPInvokeCallback]
        private static NativeBool GetContainerInfoCallback(Interop.XGameSaveContainerInfo interopInfo, IntPtr context)
        {
            GCHandle infoHandle = GCHandle.FromIntPtr(context);
            infoHandle.Target = new XGameSaveContainerInfo(interopInfo);
            return new NativeBool(false);
        }

        [MonoPInvokeCallback]
        private static NativeBool EnumerateContainerInfoCallback(Interop.XGameSaveContainerInfo interopInfo, IntPtr context)
        {
            GCHandle infoHandle = GCHandle.FromIntPtr(context);
            var infoList = infoHandle.Target as List<XGameSaveContainerInfo>;
            infoList.Add(new XGameSaveContainerInfo(interopInfo));

            return new NativeBool(true);
        }

        [MonoPInvokeCallback]
        private static NativeBool EnumerateBlobInfoCallback(Interop.XGameSaveBlobInfo interopBlobInfo, IntPtr context)
        {
            GCHandle infoHandle = GCHandle.FromIntPtr(context);
            var infoList = infoHandle.Target as List<XGameSaveBlobInfo>;
            infoList.Add(new XGameSaveBlobInfo(interopBlobInfo));
            return new NativeBool(true);
        }
        #endregion

        #region Provider
        public static Int32 XGameSaveInitializeProvider(XUserHandle userHandle, string configurationId, bool syncOnDemand, out XGameSaveProviderHandle gameSaveProviderHandle)
        {
            // init to null;
            gameSaveProviderHandle = null;

            if (userHandle == null)
            {
                return HR.E_INVALIDARG;
            }

            Interop.XGameSaveProviderHandle interopProviderHandle;
            Int32 hr = XGRInterop.XGameSaveInitializeProvider(userHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(configurationId), syncOnDemand, out interopProviderHandle);
            return XGameSaveProviderHandle.WrapInteropHandleAndReturnHResult(hr, interopProviderHandle, out gameSaveProviderHandle);
        }

        public static void XGameSaveInitializeProviderAsync(XUserHandle userHandle, string configurationId, bool syncOnDemand, XGameSaveInitializeProviderCompleted completionRoutine)
        {
            if (userHandle == null)
            {
                completionRoutine(HR.E_INVALIDARG, default(XGameSaveProviderHandle));
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) =>
            {
                Interop.XGameSaveProviderHandle interopProviderHandle;
                Int32 hresult = XGRInterop.XGameSaveInitializeProviderResult(block, out interopProviderHandle);

                XGameSaveProviderHandle providerHandle;
                XGameSaveProviderHandle.WrapInteropHandleAndReturnHResult(hresult, interopProviderHandle, out providerHandle);
                completionRoutine(hresult, providerHandle);

            });

            Int32 hr = XGRInterop.XGameSaveInitializeProviderAsync(userHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(configurationId), syncOnDemand, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, default(XGameSaveProviderHandle));
            }
        }

        public static void XGameSaveCloseProvider(XGameSaveProviderHandle gameSaveProviderHandle)
        {
            if (gameSaveProviderHandle == null)
            {
                return;
            }

            XGRInterop.XGameSaveCloseProvider(gameSaveProviderHandle.InteropHandle);
        }
        #endregion Provider

        #region RemainingQuota
        public static Int32 XGameSaveGetRemainingQuota(XGameSaveProviderHandle gameSaveProviderHandle, out Int64 remainingQuota)
        {
            if (gameSaveProviderHandle == null)
            {
                remainingQuota = default(Int64);
                return HR.E_INVALIDARG;
            }

            return XGRInterop.XGameSaveGetRemainingQuota(gameSaveProviderHandle.InteropHandle, out remainingQuota);
        }

        public static void XGameSaveGetRemainingQuotaAsync(XGameSaveProviderHandle gameSaveProviderHandle, XGameSaveGetRemainingQuotaCompleted completionRoutine)
        {
            if (gameSaveProviderHandle == null)
            {
                completionRoutine(HR.E_INVALIDARG, default(Int64));
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Int64 remainingQuota;
                Int32 hresult = XGRInterop.XGameSaveGetRemainingQuotaResult(block, out remainingQuota);
                completionRoutine(hresult, remainingQuota);
            });

            Int32 hr = XGRInterop.XGameSaveGetRemainingQuotaAsync(gameSaveProviderHandle.InteropHandle, asyncBlock);

            if (HR.FAILED(hr))
            {
                Int64 remainingQuota = default(Int64);
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, remainingQuota);
            }
        }
        #endregion RemainingQuota

        #region Container Management / Information
        public static Int32 XGameSaveDeleteContainer(XGameSaveProviderHandle gameSaveProviderHandle, string containerName)
        {
            if (gameSaveProviderHandle == null || String.IsNullOrEmpty(containerName))
            {
                return HR.E_INVALIDARG;
            }

            return XGRInterop.XGameSaveDeleteContainer(gameSaveProviderHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(containerName));
        }

        public static void XGameSaveDeleteContainerAsync(XGameSaveProviderHandle gameSaveProviderHandle, string containerName, XGameSaveDeleteContainerCompleted completionRoutine)
        {
            if (gameSaveProviderHandle == null || String.IsNullOrEmpty(containerName))
            {
                completionRoutine(HR.E_INVALIDARG);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Int32 hresult = XGRInterop.XGameSaveDeleteContainerResult(block);
                completionRoutine(hresult);
            });

            Int32 hr = XGRInterop.XGameSaveDeleteContainerAsync(gameSaveProviderHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(containerName), asyncBlock);

            if (HR.FAILED(hr))
            {
                completionRoutine(hr);
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
            }
        }

        public static Int32 XGameSaveCreateContainer(XGameSaveProviderHandle gameSaveProviderHandle, string containerName, out XGameSaveContainerHandle containerContext)
        {
            if (gameSaveProviderHandle == null || String.IsNullOrEmpty(containerName))
            {
                containerContext = default(XGameSaveContainerHandle);
                return HR.E_INVALIDARG;
            }

            Interop.XGameSaveContainerHandle interopContext;
            Int32 hresult = XGRInterop.XGameSaveCreateContainer(gameSaveProviderHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(containerName), out interopContext);
            return XGameSaveContainerHandle.WrapInteropHandleAndReturnHResult(hresult, interopContext, out containerContext);
        }

        public static void XGameSaveCloseContainer(XGameSaveContainerHandle containerHandle)
        {
            if (containerHandle == null)
            {
                return;
            }

            XGRInterop.XGameSaveCloseContainer(containerHandle.InteropHandle);
        }

        public static Int32 XGameSaveGetContainerInfo(
            XGameSaveProviderHandle provider,
            string containerName,
            out XGameSaveContainerInfo containerInfo)
        {
            // init to null
            containerInfo = null;

            if (provider == null || String.IsNullOrEmpty(containerName))
            {
                return HR.E_INVALIDARG;
            }

            GCHandle infoHandle = GCHandle.Alloc(null);

            Byte[] nameAsBytes = Converters.StringToNullTerminatedUTF8ByteArray(containerName);
            Int32 hr = XGRInterop.XGameSaveGetContainerInfo(provider.InteropHandle, nameAsBytes, GCHandle.ToIntPtr(infoHandle), GetContainerInfoCallback);
            containerInfo = infoHandle.Target as XGameSaveContainerInfo;
            infoHandle.Free();
            return hr;
        }

        public static Int32 XGameSaveEnumerateContainerInfo(
            XGameSaveProviderHandle provider,
            out XGameSaveContainerInfo[] containerInfos)
        {
            // init to null
            containerInfos = null;

            if (provider == null )
            {
                return HR.E_INVALIDARG;
            }

            List<XGameSaveContainerInfo> localInfos = new List<XGameSaveContainerInfo>();
            GCHandle infoHandle = GCHandle.Alloc(localInfos);

            Int32 hr = XGRInterop.XGameSaveEnumerateContainerInfo(provider.InteropHandle, GCHandle.ToIntPtr(infoHandle), EnumerateContainerInfoCallback);
            containerInfos = localInfos.ToArray();
            infoHandle.Free();
            return hr;
        }

        public static Int32 XGameSaveEnumerateContainerInfoByName(
            XGameSaveProviderHandle provider,
            string containerNamePrefix,
            out XGameSaveContainerInfo[] containerInfos)
        {
            // init to null
            containerInfos = null;

            if (provider == null || String.IsNullOrEmpty(containerNamePrefix))
            {
                return HR.E_INVALIDARG;
            }
            
            List<XGameSaveContainerInfo> localInfos = new List<XGameSaveContainerInfo>();
            GCHandle infoHandle = GCHandle.Alloc(localInfos);

            Byte[] prefixAsBytes = Converters.StringToNullTerminatedUTF8ByteArray(containerNamePrefix);
            Int32 hr = XGRInterop.XGameSaveEnumerateContainerInfoByName(provider.InteropHandle, prefixAsBytes, GCHandle.ToIntPtr(infoHandle), EnumerateContainerInfoCallback);
            containerInfos = localInfos.ToArray();
            infoHandle.Free();
            return hr;            
        }        
        #endregion Container Management / Information

        #region Blob
        public static Int32 XGameSaveEnumerateBlobInfo(
            XGameSaveContainerHandle container, 
            out XGameSaveBlobInfo[] blobInfos)
        {
            // init to null
            blobInfos = null;

            if (container == null)
            {
                return HR.E_INVALIDARG;
            }

            List<XGameSaveBlobInfo> localInfos = new List<XGameSaveBlobInfo>();
            GCHandle infoHandle = GCHandle.Alloc(localInfos);

            Int32 hr = XGRInterop.XGameSaveEnumerateBlobInfo(container.InteropHandle, GCHandle.ToIntPtr(infoHandle), EnumerateBlobInfoCallback);
            blobInfos = localInfos.ToArray();
            infoHandle.Free();
            return hr;
        }

        public static Int32 XGameSaveEnumerateBlobInfoByName(
            XGameSaveContainerHandle container, 
            string blobNamePrefix,
            out XGameSaveBlobInfo[] blobInfos)
        {
            // init to null
            blobInfos = null;

            if (container == null || string.IsNullOrEmpty(blobNamePrefix))
            {
                return HR.E_INVALIDARG;
            }
            
            List<XGameSaveBlobInfo> localInfos = new List<XGameSaveBlobInfo>();
            GCHandle infoHandle = GCHandle.Alloc(localInfos);

            Byte[] prefixAsBytes = Converters.StringToNullTerminatedUTF8ByteArray(blobNamePrefix);
            Int32 hr = XGRInterop.XGameSaveEnumerateBlobInfoByName(
                container.InteropHandle,
                prefixAsBytes, 
                GCHandle.ToIntPtr(infoHandle),
                EnumerateBlobInfoCallback);
            blobInfos = localInfos.ToArray();
            infoHandle.Free();
            return hr;
        }

        public static Int32 XGameSaveReadBlobData(
            XGameSaveContainerHandle container,
            XGameSaveBlobInfo[] blobInfos,
            out XGameSaveBlob[] blobs)
        {
            // init to null
            blobs = null;

            if (container == null || blobInfos == null)
            {
                return HR.E_INVALIDARG;
            }

            string[] blobNames = blobInfos.Select(x =>x.Name).ToArray();
            UInt32 countOfBlobs = Convert.ToUInt32(blobInfos.Length);

            SizeT sizeOfBlobs = new SizeT(blobInfos.Sum(x =>
                Marshal.SizeOf(typeof(Interop.XGameSaveBlob)) +                 // XGameSaveBlob struct
                Converters.StringToNullTerminatedUTF8ByteArray(x.Name).Length + // XGameSaveBlobInfo name string
                Convert.ToInt32(x.Size)));                                      // XGameSaveBlob data

            using (DisposableBuffer blobsBuffer = new DisposableBuffer(sizeOfBlobs.ToInt32()))
            using (DisposableBuffer blobNamesBuffer = Converters.StringArrayToUTF8StringArray(blobNames))
            {
                Int32 hr = XGRInterop.XGameSaveReadBlobData(
                    container.InteropHandle,
                    blobNamesBuffer.IntPtr,
                    ref countOfBlobs,
                    sizeOfBlobs,
                    blobsBuffer.IntPtr);

                if (HR.SUCCEEDED(hr))
                {
                    blobs = Converters.PtrToClassArray<XGameSaveBlob, Interop.XGameSaveBlob>(blobsBuffer.IntPtr, countOfBlobs, x =>new XGameSaveBlob(x));
                }

                return hr;
            }
        }

        public static void XGameSaveReadBlobDataAsync(
            XGameSaveContainerHandle container,
            string[] blobNames,
            XGameSaveReadBlobDataCompleted completionRoutine)
        {

            if (container == null || blobNames == null)
            {
                completionRoutine(HR.E_INVALIDARG, null);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Int32 hr = XGRInterop.XAsyncGetStatus(block, wait: false);

                if (HR.FAILED(hr))
                {
                    completionRoutine(hr, null);
                    return;
                }

                SizeT blobsSize;
                hr = XGRInterop.XAsyncGetResultSize(block, out blobsSize);

                if (HR.FAILED(hr))
                {
                    completionRoutine(hr, null);
                    return;
                }

                using (DisposableBuffer buffer = new DisposableBuffer(blobsSize.ToInt32()))
                {
                    UInt32 countOfBlobs;
                    hr = XGRInterop.XGameSaveReadBlobDataResult(block, blobsSize, buffer.IntPtr, out countOfBlobs);

                    XGameSaveBlob[] blobs = null;
                    if (HR.SUCCEEDED(hr))
                    {
                        blobs = Converters.PtrToClassArray<XGameSaveBlob, Interop.XGameSaveBlob>(buffer.IntPtr, countOfBlobs, x =>new XGameSaveBlob(x));
                    }

                    completionRoutine(hr, blobs);
                }
            });

            using (DisposableBuffer names = Converters.StringArrayToUTF8StringArray(blobNames))
            {
                Int32 hresult = XGRInterop.XGameSaveReadBlobDataAsync(
                    container.InteropHandle,
                    names.IntPtr,
                    Convert.ToUInt32(blobNames.Length),
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hresult, null);
                    return;
                }
            }
        }
        #endregion Blob

        #region Update APIs
        public static Int32 XGameSaveCreateUpdate(XGameSaveContainerHandle container, string containerDisplayName, out XGameSaveUpdateHandle updateHandle)
        {
            // init to null;
            updateHandle = null;

            if (container == null)
            {
                return HR.E_INVALIDARG;
            }

            Byte[] bytes = Converters.StringToNullTerminatedUTF8ByteArray(containerDisplayName);

            Interop.XGameSaveUpdateHandle interopUpdateHandle = new Interop.XGameSaveUpdateHandle();
            Int32 hr = XGRInterop.XGameSaveCreateUpdate(container.InteropHandle, bytes, ref interopUpdateHandle);
            return XGameSaveUpdateHandle.WrapInteropHandleAndReturnHResult(hr, interopUpdateHandle, out updateHandle);
        }

        public static void XGameSaveCloseUpdateHandle(XGameSaveUpdateHandle updateHandle)
        {
            if (updateHandle == null)
            {
                return;
            }

            XGRInterop.XGameSaveCloseUpdate(updateHandle.InteropHandle);
        }

        public static Int32 XGameSaveSubmitBlobWrite(XGameSaveUpdateHandle updateHandle, string blobName, Byte[] data)
        {
            if (updateHandle == null || string.IsNullOrEmpty(blobName) || data == null)
            {
                return HR.E_INVALIDARG;
            }

            Byte[] bytes = Converters.StringToNullTerminatedUTF8ByteArray(blobName);
            SizeT dataSize = new SizeT(data.Length);
            return XGRInterop.XGameSaveSubmitBlobWrite(updateHandle.InteropHandle, bytes, data, dataSize);
        }

        public static Int32 XGameSaveSubmitBlobDelete(XGameSaveUpdateHandle updateHandle, string blobName)
        {
            if (updateHandle == null || string.IsNullOrEmpty(blobName))
            {
                return HR.E_INVALIDARG;
            }

            Byte[] bytes = Converters.StringToNullTerminatedUTF8ByteArray(blobName);
            return XGRInterop.XGameSaveSubmitBlobDelete(updateHandle.InteropHandle, bytes);
        }

        public static Int32 XGameSaveSubmitUpdate(XGameSaveUpdateHandle updateHandle)
        {
            if (updateHandle == null)
            {
                return HR.E_INVALIDARG;
            }

            return XGRInterop.XGameSaveSubmitUpdate(updateHandle.InteropHandle);
        }

        public static void XGameSaveSubmitUpdateAsync(XGameSaveUpdateHandle updateHandle, XGameSaveSubmitUpdateCompleted completionRoutine)
        {
            if (updateHandle == null || completionRoutine == null)
            {
                completionRoutine(HR.E_INVALIDARG);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Int32 hresult = XGRInterop.XGameSaveSubmitUpdateResult(block);
                completionRoutine(hresult);
            });

            Int32 hr = XGRInterop.XGameSaveSubmitUpdateAsync(updateHandle.InteropHandle, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr);
            }
        }
        #endregion 
    }
}
