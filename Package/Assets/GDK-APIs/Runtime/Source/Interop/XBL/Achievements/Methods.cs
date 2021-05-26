using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal static unsafe partial class XblInterop
    {
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsResultGetAchievements([NativeTypeName("XblAchievementsResultHandle")] XblAchievementsResult* resultHandle, [NativeTypeName("const XblAchievement **")] XblAchievement** achievements, [NativeTypeName("size_t *")] uint* achievementsCount);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsResultHasNext([NativeTypeName("XblAchievementsResultHandle")] XblAchievementsResult* resultHandle, bool* hasNext);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsResultGetNextAsync([NativeTypeName("XblAchievementsResultHandle")] XblAchievementsResult* resultHandle, [NativeTypeName("uint32_t")] uint maxItems, XAsyncBlock* async);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsResultGetNextResult(XAsyncBlock* async, [NativeTypeName("XblAchievementsResultHandle *")] XblAchievementsResult** result);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsGetAchievementsForTitleIdAsync([NativeTypeName("XblContextHandle")] XblContext* xboxLiveContext, [NativeTypeName("uint64_t")] ulong xboxUserId, [NativeTypeName("uint32_t")] uint titleId, XblAchievementType type, [NativeTypeName("bool")] byte unlockedOnly, XblAchievementOrderBy orderBy, [NativeTypeName("uint32_t")] uint skipItems, [NativeTypeName("uint32_t")] uint maxItems, XAsyncBlock* async);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsGetAchievementsForTitleIdResult(XAsyncBlock* async, [NativeTypeName("XblAchievementsResultHandle *")] XblAchievementsResult** result);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsUpdateAchievementAsync([NativeTypeName("XblContextHandle")] XblContext* xboxLiveContext, [NativeTypeName("uint64_t")] ulong xboxUserId, [NativeTypeName("const char *")] sbyte* achievementId, [NativeTypeName("uint32_t")] uint percentComplete, XAsyncBlock* async);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsUpdateAchievementForTitleIdAsync([NativeTypeName("XblContextHandle")] XblContext* xboxLiveContext, [NativeTypeName("uint64_t")] ulong xboxUserId, [NativeTypeName("const uint32_t")] uint titleId, [NativeTypeName("const char *")] sbyte* serviceConfigurationId, [NativeTypeName("const char *")] sbyte* achievementId, [NativeTypeName("uint32_t")] uint percentComplete, XAsyncBlock* async);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsGetAchievementAsync([NativeTypeName("XblContextHandle")] XblContext* xboxLiveContext, [NativeTypeName("uint64_t")] ulong xboxUserId, [NativeTypeName("const char *")] sbyte* serviceConfigurationId, [NativeTypeName("const char *")] sbyte* achievementId, XAsyncBlock* async);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsGetAchievementResult(XAsyncBlock* async, [NativeTypeName("XblAchievementsResultHandle *")] XblAchievementsResult** result);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsResultDuplicateHandle([NativeTypeName("XblAchievementsResultHandle")] XblAchievementsResult* handle, [NativeTypeName("XblAchievementsResultHandle *")] XblAchievementsResult** duplicatedHandle);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblAchievementsResultCloseHandle([NativeTypeName("XblAchievementsResultHandle")] XblAchievementsResult* handle);

        //[DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //[return: NativeTypeName("XblFunctionContext")]
        //public static extern int XblAchievementUnlockAddNotificationHandler([NativeTypeName("XblContextHandle")] XblContext* xblContextHandle, [NativeTypeName("XblAchievementUnlockHandler *")] delegate* unmanaged[Cdecl]<XblAchievementUnlockEvent*, void*, void>* handler, void* handlerContext);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblAchievementUnlockRemoveNotificationHandler([NativeTypeName("XblContextHandle")] XblContext* xblContextHandle, [NativeTypeName("XblFunctionContext")] int functionContext);

        //[DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //[return: NativeTypeName("XblFunctionContext")]
        //public static extern int XblAchievementsAddAchievementProgressChangeHandler([NativeTypeName("XblContextHandle")] XblContext* xblContextHandle, [NativeTypeName("XblAchievementsProgressChangeHandler")] delegate* unmanaged[Cdecl]<XblAchievementProgressChangeEventArgs*, void*, void> handler, void* handlerContext);

        [DllImport(ThunkDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblAchievementsRemoveAchievementProgressChangeHandler([NativeTypeName("XblContextHandle")] XblContext* xblContextHandle, [NativeTypeName("XblFunctionContext")] int functionContext);
    }
}
