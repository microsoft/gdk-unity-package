using System;
using System.Runtime.InteropServices;
using System.Text;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    partial class SDK
    {
        public delegate void XStoreQueryGameAndDlcPackageUpdatesCompleted(Int32 hresult, XStorePackageUpdate[] packageUpdates);
        public delegate void XStoreDownloadAndInstallPackagesCompleted(Int32 hresult, string[] packageIdentifiers);
        public delegate void XStoreDownloadAndInstallPackageUpdatesCompleted(Int32 hresult);
        public delegate void XStoreDownloadPackageUpdatesCompleted(Int32 hresult);

        public static void XStoreQueryGameAndDlcPackageUpdatesAsync(XStoreContext context, XStoreQueryGameAndDlcPackageUpdatesCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                XStorePackageUpdate[] result = null;
                UInt32 count;
                Int32 hresult = XGRInterop.XStoreQueryGameAndDlcPackageUpdatesResultCount(block, out count);
                if (hresult == 0)
                {
                    if (count > 0)
                    {
                        Interop.XStorePackageUpdate[] packageUpdates = new Interop.XStorePackageUpdate[count];
                        hresult = XGRInterop.XStoreQueryGameAndDlcPackageUpdatesResult(block, count, packageUpdates);
                        if (hresult == 0)
                        {
                            result = Array.ConvertAll(packageUpdates, x =>new XStorePackageUpdate(x));
                        }
                    }
                }
                completionRoutine(hresult, result);
            });

            Int32 hr = XGRInterop.XStoreQueryGameAndDlcPackageUpdatesAsync(context.handle, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, null);
            }
        }

        public static void XStoreDownloadAndInstallPackagesAsync(XStoreContext context, string[] storeIds, XStoreDownloadAndInstallPackagesCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                string[] packageIdentifiers = null;
                UInt32 count;
                Int32 hresult = XGRInterop.XStoreDownloadAndInstallPackagesResultCount(block, out count);
                if (hresult == 0)
                {
                    packageIdentifiers = new string[count];

                    if (count > 0)
                    {
                        Byte[] temp = new Byte[count * XGRInterop.XPACKAGE_IDENTIFIER_MAX_LENGTH];
                        hresult = XGRInterop.XStoreDownloadAndInstallPackagesResult(block, count, temp);

                        for (Int32 index = 0; index < count; index++)
                        {
                            packageIdentifiers[index] = Converters.ByteArrayToString(temp, index * XGRInterop.XPACKAGE_IDENTIFIER_MAX_LENGTH, XGRInterop.XPACKAGE_IDENTIFIER_MAX_LENGTH);
                        }
                    }
                }
                completionRoutine(hresult, packageIdentifiers);
            });

            using (DisposableCollection collection = new DisposableCollection())
            {
                var storeIdsUtf8 = Array.ConvertAll(storeIds, x =>new UTF8StringPtr(x, collection));
                Int32 hr = XGRInterop.XStoreDownloadAndInstallPackagesAsync(context.handle, storeIdsUtf8, new SizeT(storeIdsUtf8.Length), asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr, null);
                }
            }
        }

        public static void XStoreDownloadAndInstallPackageUpdatesAsync(XStoreContext context, string[] packageIdentifiers, XStoreDownloadAndInstallPackageUpdatesCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                Int32 hresult = XGRInterop.XStoreDownloadPackageUpdatesResult(block);
                completionRoutine(hresult);
            });

            using (DisposableCollection collection = new DisposableCollection())
            {
                var packageIdentifiersUtf8 = Array.ConvertAll(packageIdentifiers, x =>new UTF8StringPtr(x, collection));
                Int32 hr = XGRInterop.XStoreDownloadAndInstallPackageUpdatesAsync(context.handle, packageIdentifiersUtf8, new SizeT(packageIdentifiersUtf8.Length), asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr);
                }
            }
        }

        public static void XStoreDownloadPackageUpdatesAsync(XStoreContext context, string[] packageIdentifiers, XStoreDownloadPackageUpdatesCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                Int32 hresult = XGRInterop.XStoreDownloadPackageUpdatesResult(block);
                completionRoutine(hresult);
            });

            using (DisposableCollection collection = new DisposableCollection())
            {
                var packageIdentifiersUtf8 = Array.ConvertAll(packageIdentifiers, x =>new UTF8StringPtr(x, collection));
                Int32 hr = XGRInterop.XStoreDownloadPackageUpdatesAsync(context.handle, packageIdentifiersUtf8, new SizeT(packageIdentifiersUtf8.Length), asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr);
                }
            }
        }

        public static Int32 XStoreQueryPackageIdentifier(string storeId, out string packageIdentifier)
        {
            packageIdentifier = null;

            Byte[] data = new Byte[XGRInterop.XPACKAGE_IDENTIFIER_MAX_LENGTH];
            Int32 hr = XGRInterop.XStoreQueryPackageIdentifier(Converters.StringToNullTerminatedUTF8ByteArray(storeId), new SizeT(data.Length), data);

            if (HR.SUCCEEDED(hr))
            {
                packageIdentifier = Converters.ByteArrayToString(data);
            }

            return hr;
        }
    }
}
