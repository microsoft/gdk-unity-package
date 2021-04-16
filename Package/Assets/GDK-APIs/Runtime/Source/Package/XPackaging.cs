using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XPackageInstalledCallback(XPackageDetails details);
    public delegate void XPackageInstallationProgressCallback(XPackageInstallationMonitorHandle installationMonitor);

    partial class SDK
    {
        #region Callbacks
        [MonoPInvokeCallback]
        private unsafe static NativeBool EnumerationCallback(IntPtr context, Interop.XPackageDetails* packageDetails)
        {
            // Context contains the collection we are enumerating
            GCHandle collectionHandle = GCHandle.FromIntPtr(context);
            var collection = collectionHandle.Target as List<XPackageDetails>;
            collection.Add(new XPackageDetails(*packageDetails));

            return new NativeBool(true);
        }

        [MonoPInvokeCallback]
        private unsafe static NativeBool FeatureEnumerationCallback(IntPtr context, Interop.XPackageFeature* feature)
        {
            // Context contains the collection we are enumerating
            GCHandle collectionHandle = GCHandle.FromIntPtr(context);
            var collection = collectionHandle.Target as List<XPackageFeature>;
            collection.Add(new XPackageFeature(*feature));

            return new NativeBool(true);
        }

        [MonoPInvokeCallback]
        private unsafe static void PackageInstalledCallback(IntPtr context, Interop.XPackageDetails* packageDetails)
        {
            GCHandle callbackHandle = GCHandle.FromIntPtr(context);
            var callbacks = callbackHandle.Target as UnmanagedCallback<Interop.XPackageInstalledCallback, XPackageInstalledCallback>;
            if (callbacks.userCallback != null)
            {
                callbacks.userCallback.Invoke(new XPackageDetails(*packageDetails));
            }
        }

        [MonoPInvokeCallback]
        private static void PackageInstallationProgressCallback(IntPtr context, Interop.XPackageInstallationMonitorHandle monitor)
        {
            GCHandle callbackHandle = GCHandle.FromIntPtr(context);
            var callbacks = callbackHandle.Target as UnmanagedCallback<Interop.XPackageInstallationProgressCallback, XPackageInstallationProgressCallback>;
            if (callbacks.userCallback != null)
            {
                callbacks.userCallback.Invoke(new XPackageInstallationMonitorHandle(monitor));
            }
        }
        #endregion

        #region Packages
        public static Int32 XPackageGetCurrentProcessPackageIdentifier(out string identifier)
        {
            identifier = null;
            Byte[] buf = new Byte[XGRInterop.XPACKAGE_IDENTIFIER_MAX_LENGTH];
            Int32 hr = XGRInterop.XPackageGetCurrentProcessPackageIdentifier(new SizeT(buf.Length), buf);
            if (HR.SUCCEEDED(hr))
            {
                identifier = Converters.ByteArrayToString(buf);
            }

            return hr;
        }

        public static bool XPackageIsPackagedProcess()
        {
            return XGRInterop.XPackageIsPackagedProcess().Value;
        }

        public static Int32 XPackageGetUserLocale(out string locale)
        {
            locale = null;
            Byte[] buf = new Byte[XGRInterop.LOCALE_NAME_MAX_LENGTH];
            Int32 hr = XGRInterop.XPackageGetUserLocale(new SizeT(buf.Length), buf);
            if (HR.SUCCEEDED(hr))
            {
                locale = Converters.ByteArrayToString(buf);
            }

            return hr;
        }

        public static Int32 XPackageEnumeratePackages(XPackageKind kind, XPackageEnumerationScope scope, out XPackageDetails[] details)
        {
            unsafe
            {
                List<XPackageDetails> results = new List<XPackageDetails>();
                GCHandle resultsHandle = GCHandle.Alloc(results);

                Int32 hr = XGRInterop.XPackageEnumeratePackages(kind, scope, GCHandle.ToIntPtr(resultsHandle), EnumerationCallback);
                details = results.ToArray();

                resultsHandle.Free();
                return hr;
            }
        }

        public static Int32 XPackageRegisterPackageInstalled(XPackageInstalledCallback callback, out XRegistrationToken token)
        {
            unsafe
            {
                var callbacks = new UnmanagedCallback<Interop.XPackageInstalledCallback, XPackageInstalledCallback>
                {
                    directCallback = PackageInstalledCallback,
                    userCallback = callback
                };

                GCHandle callbackHandle = GCHandle.Alloc(callbacks);

                XTaskQueueRegistrationToken taskQueueToken;
                Int32 hr = XGRInterop.XPackageRegisterPackageInstalled(
                        defaultQueue.handle,
                        GCHandle.ToIntPtr(callbackHandle),
                        callbacks.directCallback,
                        out taskQueueToken);

                if (HR.SUCCEEDED(hr))
                {
                    token = new XRegistrationToken(callbackHandle, taskQueueToken);
                }
                else
                {
                    token = default(XRegistrationToken);
                    callbackHandle.Free();
                }

                return hr;
            }
        }

        public static void XPackageUnregisterPackageInstalled(XRegistrationToken token)
        {
            if (token == null)
            {
                return;
            }

            XGRInterop.XPackageUnregisterPackageInstalled(token.Token,  new NativeBool(true));
            token.CallbackHandle.Free();
        }

        public static Int32 XPackageEnumerateFeatures(string packageIdentifier, out XPackageFeature[] features)
        {
            unsafe
            {
                List<XPackageFeature> results = new List<XPackageFeature>();
                GCHandle resultsHandle = GCHandle.Alloc(results);

                Int32 hr = XGRInterop.XPackageEnumerateFeatures(
                    Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), 
                    GCHandle.ToIntPtr(resultsHandle), 
                    FeatureEnumerationCallback);
                features = results.ToArray();

                resultsHandle.Free();
                return hr;
            }
        }
        #endregion

        #region Mounting
        public static Int32 XPackageMount(string packageIdentifier, out XPackageMountHandle mountHandle)
        {
            mountHandle = null;
            Interop.XPackageMountHandle mh;
            Int32 hr = XGRInterop.XPackageMount(Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), out mh);
            if (HR.SUCCEEDED(hr))
            {
                mountHandle = new XPackageMountHandle(mh);
            }
            return hr;
        }

        public static Int32 XPackageGetMountPath(XPackageMountHandle mountHandle, out string path)
        {
            path = string.Empty;

            if (mountHandle == null)
            {
                return HR.E_INVALIDARG;
            }

            SizeT size;
            Int32 hr = XGRInterop.XPackageGetMountPathSize(mountHandle.Handle, out size);
            if (HR.FAILED(hr))
            {
                return hr;
            }

            Byte[] buf = new Byte[size.ToInt32()];
            hr = XGRInterop.XPackageGetMountPath(mountHandle.Handle, size, buf);
            if (HR.SUCCEEDED(hr))
            {
                path = Converters.ByteArrayToString(buf);
            }

            return hr;
        }

        public static void XPackageCloseMountHandle(XPackageMountHandle mountHandle)
        {
            if (mountHandle == null)
            {
                return;
            }

            XGRInterop.XPackageCloseMountHandle(mountHandle.Handle);
            mountHandle.Handle = new Interop.XPackageMountHandle { handle = IntPtr.Zero };
        }
        #endregion

        #region Install Monitor
        public static Int32 XPackageCreateInstallationMonitor(
            string packageIdentifier,
            UInt32 minimumUpdateIntervalMs,
            out XPackageInstallationMonitorHandle installationMonitor)
        {
            Interop.XPackageInstallationMonitorHandle interopHandle;
            int hr = XGRInterop.XPackageCreateInstallationMonitor(
                Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier),
                0,     // chunk selector is not
                null,  // included in Wave 2
                minimumUpdateIntervalMs,
                defaultQueue.handle,
                out interopHandle);

            return XPackageInstallationMonitorHandle.WrapInteropHandleAndReturnHResult(hr, interopHandle, out installationMonitor);
        }

        public static void XPackageCloseInstallationMonitorHandle(XPackageInstallationMonitorHandle installationMonitor)
        {
            if (installationMonitor == null)
            {
                return;
            }

            XGRInterop.XPackageCloseInstallationMonitorHandle(installationMonitor.InteropHandle);
            installationMonitor.InteropHandle = new Interop.XPackageInstallationMonitorHandle { handle = IntPtr.Zero };
        }

        public static void XPackageGetInstallationProgress(
            XPackageInstallationMonitorHandle installationMonitor,
            out XPackageInstallationProgress installationProgress)
        {
            if (installationMonitor == null)
            {
                installationProgress = default(XPackageInstallationProgress);
                return;
            }

            Interop.XPackageInstallationProgress progress;
            XGRInterop.XPackageGetInstallationProgress(installationMonitor.InteropHandle, out progress);
            installationProgress = new XPackageInstallationProgress(progress);
        }

        public static bool XPackageUpdateInstallationMonitor(XPackageInstallationMonitorHandle installationMonitor)
        {
            if (installationMonitor == null)
            {
                return default(bool);
            }

            return XGRInterop.XPackageUpdateInstallationMonitor(installationMonitor.InteropHandle).Value;
        }

        public static Int32 XPackageRegisterInstallationProgressChanged(
            XPackageInstallationMonitorHandle installationMonitor,
            XPackageInstallationProgressCallback callback,
            out XRegistrationToken token)
        {
            token = default(XRegistrationToken);

            if (installationMonitor == null)
            {
                return HR.E_INVALIDARG;
            }

            var callbacks = new UnmanagedCallback<Interop.XPackageInstallationProgressCallback, XPackageInstallationProgressCallback>
            {
                directCallback = PackageInstallationProgressCallback,
                userCallback = callback
            };

            GCHandle callbackHandle = GCHandle.Alloc(callbacks);

            XTaskQueueRegistrationToken taskQueueToken;
            Int32 hr = XGRInterop.XPackageRegisterInstallationProgressChanged(
                installationMonitor.InteropHandle,
                GCHandle.ToIntPtr(callbackHandle),
                callbacks.directCallback,
                out taskQueueToken);

            if (HR.SUCCEEDED(hr))
            {
                token = new XRegistrationToken(GCHandle.Alloc(callbackHandle), taskQueueToken);
            }
            else
            {
                token = default(XRegistrationToken);
                callbackHandle.Free();
            }

            return hr;
        }

        public static void XPackageUnregisterInstallationProgressChanged(
            XPackageInstallationMonitorHandle installationMonitor,
            XRegistrationToken token)
        {
            if (token == null || installationMonitor == null)
            {
                return;
            }

            XGRInterop.XPackageUnregisterInstallationProgressChanged(
                installationMonitor.InteropHandle,
                token.Token,
                wait: new NativeBool(true)
            );

            token.CallbackHandle.Free();
        }

        public static Int32 XPackageEstimateDownloadSize(
            string packageIdentifier,
            out UInt64 downloadSize,
            out bool shouldPresentUserConfirmation)
        {
            NativeBool shouldPresentUserConfirmationNative;
            Int32 hr = XGRInterop.XPackageEstimateDownloadSize(
                Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier),
                0,     // chunk selector is not
                null,  // included in Wave 2
                out downloadSize,
                out shouldPresentUserConfirmationNative);
            shouldPresentUserConfirmation = shouldPresentUserConfirmationNative.Value;

            return hr;
        }
        #endregion
        
        public static Int32 XPackageGetWriteStats(out XPackageWriteStats writeStats)
        {
            Interop.XPackageWriteStats writeStatsInternal;
            Int32 hr = XGRInterop.XPackageGetWriteStats(out writeStatsInternal);
            writeStats = new XPackageWriteStats(writeStatsInternal);
            return hr;
        }
        
        public static Int32 XPackageUninstallUWPInstance(string packageName)
        {
            return XGRInterop.XPackageUninstallUWPInstance(Converters.StringToNullTerminatedUTF8ByteArray(packageName));
        }
    }
}
