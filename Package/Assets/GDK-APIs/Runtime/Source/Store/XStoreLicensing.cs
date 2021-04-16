using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XStoreAcquireLicenseForPackageCompleted(Int32 hresult, XStoreLicense license);
    public delegate void XStoreCanAcquireLicenseForPackageCompleted(Int32 hresult, XStoreCanAcquireLicenseResult result);
    public delegate void XStoreCanAcquireLicenseForStoreIdCompleted(Int32 hresult, XStoreCanAcquireLicenseResult result);
    public delegate void XStoreQueryAddOnLicensesCompleted(Int32 hresult, XStoreAddonLicense[] licenses);
    public delegate void XStoreQueryGameLicenseCompleted(Int32 hresult, XStoreGameLicense license);
    public delegate void XStoreQueryLicenseTokenCompleted(Int32 hresult, string token);
    public delegate void XStoreAcquireLicenseForDurablesAsync(Int32 hresult, XStoreLicense license);

    public delegate void XStoreGameLicenseChangedCallback();
    public delegate void XStorePackageLicenseLostCallback();

    partial class SDK
    {
        #region Callbacks
        [MonoPInvokeCallback]
        private static void LicenseChangedCallback(IntPtr context)
        {
            GCHandle cbHandle = GCHandle.FromIntPtr(context);
            var callbacks = cbHandle.Target as UnmanagedCallback<Interop.XStoreGameLicenseChangedCallback, XStoreGameLicenseChangedCallback>;
            if (callbacks.userCallback != null)
            {
                callbacks.userCallback.Invoke();
            }
        }

        [MonoPInvokeCallback]
        private static void LicenseLostCallback(IntPtr context)
        {
            GCHandle cbHandle = GCHandle.FromIntPtr(context);
            var callbacks = cbHandle.Target as UnmanagedCallback<Interop.XStorePackageLicenseLostCallback, XStorePackageLicenseLostCallback>;
            if (callbacks.userCallback != null)
            {
                callbacks.userCallback.Invoke();
            }
        }

        #endregion

        public static void XStoreAcquireLicenseForPackageAsync(XStoreContext context, string packageIdentifier, XStoreAcquireLicenseForPackageCompleted completionRoutine)
        {
            if (context == null)
            {
                completionRoutine(HR.E_INVALIDARG, null);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                XStoreLicenseHandle handle;
                Int32 hresult = XGRInterop.XStoreAcquireLicenseForPackageResult(block, out handle);
                completionRoutine(hresult, new XStoreLicense(handle));
            });

            Int32 hr = XGRInterop.XStoreAcquireLicenseForPackageAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, null);
            }
        }

        public static void XStoreCanAcquireLicenseForPackageAsync(XStoreContext context, string packageIdentifier, XStoreCanAcquireLicenseForPackageCompleted completionRoutine)
        {
            if (context == null)
            {
                completionRoutine(HR.E_INVALIDARG, null);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Interop.XStoreCanAcquireLicenseResult result;
                Int32 hresult = XGRInterop.XStoreCanAcquireLicenseForPackageResult(block, out result);
                completionRoutine(hresult, new XStoreCanAcquireLicenseResult(result));
            });

            Int32 hr = XGRInterop.XStoreCanAcquireLicenseForPackageAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), asyncBlock);
            
            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, null);
            }
        }

        public static void XStoreCanAcquireLicenseForStoreIdAsync(XStoreContext context, string storeProductId, XStoreCanAcquireLicenseForStoreIdCompleted completionRoutine)
        {
            if (context == null)
            {
                completionRoutine(HR.E_INVALIDARG, null);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Interop.XStoreCanAcquireLicenseResult result;
                Int32 hresult = XGRInterop.XStoreCanAcquireLicenseForStoreIdResult(block, out result);
                completionRoutine(hresult, new XStoreCanAcquireLicenseResult(result));
            });

            Int32 hr = XGRInterop.XStoreCanAcquireLicenseForStoreIdAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(storeProductId), asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, null);
            }
        }

        public static void XStoreCloseLicenseHandle(XStoreLicense license)
        {
            if (license == null)
            {
                return;
            }

            XGRInterop.XStoreCloseLicenseHandle(license.Handle);
            license.Handle = new XStoreLicenseHandle();
        }

        public static bool XStoreIsLicenseValid(XStoreLicense license)
        {
            if (license == null)
            {
                return false;
            }

            return XGRInterop.XStoreIsLicenseValid(license.Handle).Value;
        }

        public static void XStoreQueryAddOnLicensesAsync(XStoreContext context, XStoreQueryAddOnLicensesCompleted completionRoutine)
        {
            if (context == null)
            {
                completionRoutine(HR.E_INVALIDARG, null);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                UInt32 count;
                Int32 hresult = XGRInterop.XStoreQueryAddOnLicensesResultCount(block, out count);

                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, null);
                    return;
                }

                Interop.XStoreAddonLicense[] licenses = new Interop.XStoreAddonLicense[count];
                hresult = XGRInterop.XStoreQueryAddOnLicensesResult(block, count, licenses);
                XStoreAddonLicense[] result = null;
                

                if (HR.SUCCEEDED(hresult))
                {
                    result = Array.ConvertAll(licenses, x =>new XStoreAddonLicense(x));
                }

                completionRoutine(hresult, result);
            });

            Int32 hr = XGRInterop.XStoreQueryAddOnLicensesAsync(context.handle, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, null);
            }
        }

        public static void XStoreQueryGameLicenseAsync(XStoreContext context, XStoreQueryGameLicenseCompleted completionRoutine)
        {
            if (context == null)
            {
                completionRoutine(HR.E_INVALIDARG, null);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Interop.XStoreGameLicense license;
                Int32 hresult = XGRInterop.XStoreQueryGameLicenseResult(block, out license);
                completionRoutine(hresult, new XStoreGameLicense(license));
            });

            Int32 hr = XGRInterop.XStoreQueryGameLicenseAsync(context.handle, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, null);
            }
        }
        
        public static void XStoreQueryLicenseTokenAsync(XStoreContext context, string[] productIds, string customDeveloperString, XStoreQueryLicenseTokenCompleted completionRoutine)
        {
            if (context == null)
            {
                completionRoutine(HR.E_INVALIDARG, null);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                SizeT size;
                Int32 hresult = XGRInterop.XStoreQueryLicenseTokenResultSize(block, out size);

                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, null);
                }

                Byte[] tempResult = new Byte[size.ToUInt32()];
                hresult = XGRInterop.XStoreQueryLicenseTokenResult(block, size, tempResult);
                string token = Converters.ByteArrayToString(tempResult);
                completionRoutine(hresult, token);
            });

            using (DisposableCollection collection = new DisposableCollection())
            {
                var productIdsUtf8 = Array.ConvertAll(productIds, x =>new UTF8StringPtr(x, collection));
                Int32 hr = XGRInterop.XStoreQueryLicenseTokenAsync(context.handle, productIdsUtf8, new SizeT(productIdsUtf8.Length), Converters.StringToNullTerminatedUTF8ByteArray(customDeveloperString), asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr, null);
                }
            }
        }

        public static Int32 XStoreRegisterGameLicenseChanged(XStoreContext context, XStoreGameLicenseChangedCallback callback, out XRegistrationToken token)
        {
            if (context == null)
            {
                token = null;
                return HR.E_INVALIDARG;
            }

            var callbacks = new UnmanagedCallback<Interop.XStoreGameLicenseChangedCallback, XStoreGameLicenseChangedCallback>
            {
                directCallback = LicenseChangedCallback,
                userCallback = callback
            };
            GCHandle cbHandle = GCHandle.Alloc(callbacks);

            XTaskQueueRegistrationToken taskQueueToken;
            Int32 hr = XGRInterop.XStoreRegisterGameLicenseChanged(
                context.handle,
                defaultQueue.handle,
                GCHandle.ToIntPtr(cbHandle),
                callbacks.directCallback,
                out taskQueueToken);

            if (HR.SUCCEEDED(hr))
            {
                token = new XRegistrationToken(cbHandle, taskQueueToken);
            }
            else
            {
                token = null;
                cbHandle.Free();
            }

            return hr;
        }

        public static Int32 XStoreRegisterPackageLicenseLost(XStoreLicense license, XStorePackageLicenseLostCallback callback, out XRegistrationToken token)
        {
            if (license == null)
            {
                token = null;
                return HR.E_INVALIDARG;
            }

            var callbacks = new UnmanagedCallback<Interop.XStorePackageLicenseLostCallback, XStorePackageLicenseLostCallback>
            {
                directCallback = LicenseLostCallback,
                userCallback = callback
            };
            GCHandle cbHandle = GCHandle.Alloc(callbacks);

            XTaskQueueRegistrationToken taskQueueToken;
            Int32 hr = XGRInterop.XStoreRegisterPackageLicenseLost(
                license.Handle,
                defaultQueue.handle,
                GCHandle.ToIntPtr(cbHandle),
                callbacks.directCallback,
                out taskQueueToken);

            if (HR.SUCCEEDED(hr))
            {
                token = new XRegistrationToken(cbHandle, taskQueueToken);
            }
            else
            {
                token = null;
                cbHandle.Free();
            }

            return hr;
        }

        public static void XStoreUnregisterGameLicenseChanged(XStoreContext context, XRegistrationToken token)
        {
            if (context == null || token == null)
            {
                return;
            }

            XGRInterop.XStoreUnregisterGameLicenseChanged(context.handle, token.Token, new NativeBool(true));
            token.CallbackHandle.Free();
        }

        public static void XStoreUnregisterPackageLicenseLost(XStoreLicense license, XRegistrationToken token)
        {
            if (license == null || token == null)
            {
                return;
            }

            XGRInterop.XStoreUnregisterPackageLicenseLost(license.Handle, token.Token, new NativeBool(true));
            token.CallbackHandle.Free();
        }

        public static void XStoreAcquireLicenseForDurablesAsync(XStoreContext context, string storeId, XStoreAcquireLicenseForDurablesAsync completionRoutine)
        {
            if (context == null)
            {
                completionRoutine(HR.E_INVALIDARG, null);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                XStoreLicenseHandle handle;
                Int32 hresult = XGRInterop.XStoreAcquireLicenseForDurablesResult(block, out handle);
                completionRoutine(hresult, new XStoreLicense(handle));
            });

            Int32 hr = XGRInterop.XStoreAcquireLicenseForDurablesAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(storeId), asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, null);
            }
        }
    }
}
