using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef bool CALLBACK XPackageFeatureEnumerationCallback(_In_ void* context, _In_ const XPackageFeature* feature);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal unsafe delegate NativeBool XPackageFeatureEnumerationCallback(
        IntPtr context,
        XPackageFeature* feature);

    //typedef bool CALLBACK XPackageEnumerationCallback(_In_ void* context, _In_ const XPackageDetails* details);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal unsafe delegate NativeBool XPackageEnumerationCallback(
        IntPtr context,
        XPackageDetails* details);

    //typedef void CALLBACK XPackageInstalledCallback(_In_ void* context, _In_ const XPackageDetails* details);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal unsafe delegate void XPackageInstalledCallback(
        IntPtr context,
        XPackageDetails* details);

    //typedef void CALLBACK XPackageInstallationProgressCallback(_In_ void* context, _In_ XPackageInstallationMonitorHandle monitor);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate void XPackageInstallationProgressCallback(
        IntPtr context,
        XPackageInstallationMonitorHandle monitor);

    //typedef bool CALLBACK XPackageChunkAvailabilityCallback(_In_ void* context, _In_ const XPackageChunkSelector* selector, _In_ XPackageChunkAvailability availability);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal unsafe delegate NativeBool XPackageChunkAvailabilityCallback(
        IntPtr context,
        XPackageChunkSelector* selector,
        XPackageChunkAvailability availability);


    partial class XGRInterop
    {
        internal const Int32 LOCALE_NAME_MAX_LENGTH = 85;

        //STDAPI_(void) XPackageCloseMountHandle(
        //    _In_ XPackageMountHandle mount
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XPackageCloseMountHandle(
            XPackageMountHandle mount);

        //STDAPI XPackageEnumerateFeatures(
        //    _In_z_ const char* packageIdentifier,
        //    _In_opt_ void* context,
        //    _In_ XPackageFeatureEnumerationCallback* callback
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageEnumerateFeatures(
            Byte[] packageIdentifier,
            IntPtr context,
            XPackageFeatureEnumerationCallback callback);

        //STDAPI XPackageEstimateDownloadSize(
        //    _In_z_ const char* packageIdentifier,
        //    _In_ uint32_t selectorCount,
        //    _In_reads_(selectorCount) XPackageChunkSelector* selectors,
        //    _Out_ uint64_t* downloadSize,
        //    _Out_opt_ bool* shouldPresentUserConfirmation
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageEstimateDownloadSize(
            Byte[] packageIdentifier,
            UInt32 selectorCount,
            [In] XPackageChunkSelector[] selectors,
            out UInt64 downloadSize,
            out NativeBool shouldPresentUserConfirmation);
        
        //STDAPI XPackageEnumeratePackages(
        //    _In_ XPackageKind kind,
        //    _In_ XPackageEnumerationScope scope,
        //    _In_opt_ void* context,
        //    _In_ XPackageEnumerationCallback* callback
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageEnumeratePackages(
            XPackageKind kind,
            XPackageEnumerationScope scope,
            IntPtr context,
            XPackageEnumerationCallback callback);

        //STDAPI XPackageRegisterPackageInstalled(
        //    _In_ XTaskQueueHandle queue,
        //    _In_opt_ void* context,
        //    _In_ XPackageInstalledCallback* callback,
        //    _Out_ XTaskQueueRegistrationToken* token
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageRegisterPackageInstalled(
            XTaskQueueHandle queue,
            IntPtr context,
            XPackageInstalledCallback callback,
            out XTaskQueueRegistrationToken token);

        //STDAPI XPackageGetWriteStats(
        //    _Out_ XPackageWriteStats* writeStats
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageGetWriteStats(
            out XPackageWriteStats writeStats);
        
        //STDAPI XPackageUninstallUWPInstance(
        //    _In_z_ const char* packageName
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageUninstallUWPInstance(
            Byte[] packageName);
    
        //STDAPI XPackageRegisterInstallationProgressChanged(
        //    _In_ XPackageInstallationMonitorHandle installationMonitor,
        //    _In_opt_ void* context,
        //    _In_ XPackageInstallationProgressCallback* callback,
        //    _Out_ XTaskQueueRegistrationToken* token
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageRegisterInstallationProgressChanged(
            XPackageInstallationMonitorHandle installationMonitor,
            IntPtr context,
            XPackageInstallationProgressCallback callback,
            out XTaskQueueRegistrationToken token);

        //STDAPI XPackageMount(
        //    _In_z_ const char* packageIdentifier,
        //    _Out_ XPackageMountHandle* mount
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageMount(
            Byte[] packageIdentifier,
            out XPackageMountHandle mount);

        //STDAPI XPackageGetCurrentProcessPackageIdentifier(
        //    _In_ size_t bufferSize,
        //    _Out_writes_(bufferSize) char* buffer
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageGetCurrentProcessPackageIdentifier(
            SizeT bufferSize,
            Byte[] buffer);

        //STDAPI XPackageGetMountPath(
        //    _In_ XPackageMountHandle mount,
        //    _In_ size_t pathSize,
        //    _Out_writes_(pathSize) char* path
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageGetMountPath(
            XPackageMountHandle mount,
            SizeT pathSize,
            Byte[] path);

        //STDAPI_(bool) XPackageIsPackagedProcess() noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XPackageIsPackagedProcess();

        //STDAPI_(bool) XPackageUnregisterPackageInstalled(
        //    _In_ XTaskQueueRegistrationToken token,
        //    _In_ bool wait
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XPackageUnregisterPackageInstalled(
            XTaskQueueRegistrationToken token,
            NativeBool wait);
        
        //STDAPI XPackageCreateInstallationMonitor(
        //    _In_z_ const char* packageIdentifier,
        //    _In_ uint32_t selectorCount,
        //    _In_reads_opt_(selectorCount) XPackageChunkSelector* selectors,
        //    _In_ uint32_t minimumUpdateIntervalMs, // 0 == no update
        //    _In_opt_ XTaskQueueHandle queue,
        //    _Out_ XPackageInstallationMonitorHandle* installationMonitor
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageCreateInstallationMonitor(
            Byte[] packageIdentifier,
            UInt32 selectorCount,
            [In] XPackageChunkSelector[] selectors,
            UInt32 minimumUpdateIntervalMs,
            XTaskQueueHandle queue,
            out XPackageInstallationMonitorHandle installationMonitor);

        //STDAPI_(void) XPackageCloseInstallationMonitorHandle(
        //    _In_ XPackageInstallationMonitorHandle installationMonitor
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XPackageCloseInstallationMonitorHandle(
            XPackageInstallationMonitorHandle installationMonitor);

        //STDAPI_(bool) XPackageUnregisterInstallationProgressChanged(
        //    _In_ XPackageInstallationMonitorHandle installationMonitor,
        //    _In_ XTaskQueueRegistrationToken token,
        //    _In_ bool wait
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XPackageUnregisterInstallationProgressChanged(
            XPackageInstallationMonitorHandle installationMonitor,
            XTaskQueueRegistrationToken token,
            NativeBool wait);

        //STDAPI XPackageGetMountPathSize(
        //    _In_ XPackageMountHandle mount,
        //    _Out_ size_t* pathSize
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageGetMountPathSize(
            XPackageMountHandle mount,
            out SizeT pathSize);

        //STDAPI XPackageGetUserLocale(
        //    _In_ size_t localeSize,
        //    _Out_writes_(localeSize) char* locale
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XPackageGetUserLocale(
            SizeT localeSize,
            Byte[] locale);

        //STDAPI_(void) XPackageGetInstallationProgress(
        //    _In_ XPackageInstallationMonitorHandle installationMonitor,
        //    _Out_ XPackageInstallationProgress* progress
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XPackageGetInstallationProgress(
            XPackageInstallationMonitorHandle installationMonitor,
            out XPackageInstallationProgress progress);

        //STDAPI_(bool) XPackageUpdateInstallationMonitor(
        //    _In_ XPackageInstallationMonitorHandle installationMonitor
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XPackageUpdateInstallationMonitor(
            XPackageInstallationMonitorHandle installationMonitor);

        // TODO should include these?
        //STDAPI XPackageFindChunkAvailability(
        //    _In_z_ const char* packageIdentifier,
        //    _In_ uint32_t selectorCount,
        //    _In_reads_opt_(selectorCount) XPackageChunkSelector* selectors,
        //    _Out_ XPackageChunkAvailability* availability
        //    ) noexcept;
        //[DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        //internal static extern Int32 XPackageFindChunkAvailability(
        //    Byte[] packageIdentifier,
        //    UInt32 selectorCount,
        //    [In] XPackageChunkSelector[] selectors,
        //    out XPackageChunkAvailability availability);

        //STDAPI XPackageEnumerateChunkAvailability(
        //    _In_z_ const char* packageIdentifier,
        //    _In_ XPackageChunkSelectorType type,
        //    _In_ void* context,
        //    _In_ XPackageChunkAvailabilityCallback* callback
        //    ) noexcept;
        //[DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        //internal static extern Int32 XPackageEnumerateChunkAvailability(
        //    Byte[] packageIdentifier,
        //    XPackageChunkSelectorType type,
        //    IntPtr context,
        //    XPackageChunkAvailabilityCallback callback);

        //STDAPI XPackageChangeChunkInstallOrder(
        //    _In_z_ const char* packageIdentifier,
        //    _In_ uint32_t selectorCount,
        //    _In_reads_(selectorCount) XPackageChunkSelector* selectors
        //    ) noexcept;
        //[DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        //internal static extern Int32 XPackageChangeChunkInstallOrder(
        //    Byte[] packageIdentifier,
        //    UInt32 selectorCount,
        //    [In] XPackageChunkSelector[] selectors);

        //STDAPI XPackageInstallChunks(
        //    _In_z_ const char* packageIdentifier,
        //    _In_ uint32_t selectorCount,
        //    _In_reads_(selectorCount) XPackageChunkSelector* selectors,
        //    _In_ uint32_t minimumUpdateIntervalMs,
        //    _In_ bool suppressUserConfirmation,
        //    _In_opt_ XTaskQueueHandle queue,
        //    _Out_ XPackageInstallationMonitorHandle* installationMonitor
        //    ) noexcept;
        //[DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        //internal static extern Int32 XPackageInstallChunks(
        //    Byte[] packageIdentifier,
        //    UInt32 selectorCount,
        //    [In] XPackageChunkSelector[] selectors,
        //    UInt32 minimumUpdateIntervalMs,
        //    NativeBool suppressUserConfirmation,
        //    XTaskQueueHandle queue,
        //    out XPackageInstallationMonitorHandle installationMonitor);

        //STDAPI XPackageInstallChunksAsync(
        //    _In_z_ const char* packageIdentifier,
        //    _In_ uint32_t selectorCount,
        //    _In_reads_(selectorCount) XPackageChunkSelector* selectors,
        //    _In_ uint32_t minimumUpdateIntervalMs,
        //    _In_ bool suppressUserConfirmation,
        //    _Inout_ XAsyncBlock* asyncBlock
        //    ) noexcept;
        //[DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        //internal static extern Int32 XPackageInstallChunksAsync(
        //    Byte[] packageIdentifier,
        //    UInt32 selectorCount,
        //    [In] XPackageChunkSelector[] selectors,
        //    UInt32 minimumUpdateIntervalMs,
        //    NativeBool suppressUserConfirmation,
        //    XAsyncBlockPtr asyncBlock);

        //STDAPI XPackageInstallChunksResult(
        //    _Inout_ XAsyncBlock* asyncBlock,
        //    _Out_ XPackageInstallationMonitorHandle* installationMonitor
        //    ) noexcept;
        //[DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        //internal static extern Int32 XPackageInstallChunksResult(
        //    XAsyncBlockPtr asyncBlock,
        //    out XPackageInstallationMonitorHandle installationMonitor);

        //STDAPI XPackageUninstallChunks(
        //    _In_z_ const char* packageIdentifier,
        //    _In_ uint32_t selectorCount,
        //    _In_reads_(selectorCount) XPackageChunkSelector* selectors
        //    ) noexcept;
        //[DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        //internal static extern Int32 XPackageUninstallChunks(
        //    Byte[] packageIdentifier,
        //    UInt32 selectorCount,
        //    [In] XPackageChunkSelector[] selectors);
    }
}