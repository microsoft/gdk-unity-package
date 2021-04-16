using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XGamingRuntime.Interop
{
    internal static partial class XblInterop
    {

        #region Xbox live size constants from types_c.h
        //#define XBL_COLOR_CHAR_SIZE                     (7 * 3)
        internal const Int32 XBL_COLOR_CHAR_SIZE = (7 * 3);

        //#define XBL_DISPLAY_NAME_CHAR_SIZE              (30 * 3)
        internal const Int32 XBL_DISPLAY_NAME_CHAR_SIZE = (30 * 3);

        //#define XBL_DISPLAY_PIC_URL_RAW_CHAR_SIZE       (225 * 3)
        internal const Int32 XBL_DISPLAY_PIC_URL_RAW_CHAR_SIZE = (225 * 3);

        //#define XBL_GAMERSCORE_CHAR_SIZE                (16 * 3)
        internal const Int32 XBL_GAMERSCORE_CHAR_SIZE = (16 * 3);

        //#define XBL_GAMERTAG_CHAR_SIZE                  (16 * 3)
        internal const Int32 XBL_GAMERTAG_CHAR_SIZE = (16 * 3);

        //#define XBL_MODERN_GAMERTAG_CHAR_SIZE           (((12 + 12) * 4) + 1) // 12 characters + 12 diacritic, 4 bytes each, plus 1 byte null terminator
        internal const Int32 XBL_MODERN_GAMERTAG_CHAR_SIZE = (((12 + 12) * 4) + 1);

        //#define XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE    (14 + 1) // 14 alphanumeric characters + null terminator
        internal const Int32 XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE = (14 + 1);

        //#define XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE    (XBL_MODERN_GAMERTAG_CHAR_SIZE + 1 + 3 ) // modern gamertag + '#' + max suffix size for cases when MGT display length is 12. Null terminator already accoutned for in MGT
        internal const Int32 XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE = (XBL_MODERN_GAMERTAG_CHAR_SIZE + 1 + 3);

        //#define XBL_NUM_PRESENCE_RECORDS 6
        internal const Int32 XBL_NUM_PRESENCE_RECORDS = 6;

        //#define XBL_REAL_NAME_CHAR_SIZE                 (255 * 3)
        internal const Int32 XBL_REAL_NAME_CHAR_SIZE = (255 * 3);

        //#define XBL_RICH_PRESENCE_CHAR_SIZE             (100 * 3)
        internal const Int32 XBL_RICH_PRESENCE_CHAR_SIZE = (100 * 3);

        //#define XBL_XBOX_USER_ID_CHAR_SIZE              (21 * 3)
        internal const Int32 XBL_XBOX_USER_ID_CHAR_SIZE = (21 * 3);

        //#define XBL_GUID_LENGTH                         40
        internal const Int32 XBL_GUID_LENGTH = 40;

        //#define XBL_SCID_LENGTH                         XBL_GUID_LENGTH
        internal const Int32 XBL_SCID_LENGTH = XBL_GUID_LENGTH;

        //#define XBL_SOCIAL_MANAGER_MAX_AFFECTED_USERS_PER_EVENT 10
        internal const Int32 XBL_SOCIAL_MANAGER_MAX_AFFECTED_USERS_PER_EVENT = 10;
        #endregion

        private const string ThunkDllName = "Microsoft_Xbox_Services_141_GDK_C_Thunks";

        //XBL_DLLEXPORT HRESULT XBL_CALLING_CONV XblWrapper_XblInitialize(
        //    _In_z_ const char* scid,
        //    _In_ XTaskQueueHandle internalWorkQueue
        //) noexcept
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblWrapper_XblInitialize(
            Byte[] scid,
            XTaskQueueHandle internalWorkQueue);

        /// <summary>
        /// Immediately reclaims all resources associated with the library.
        /// If you called XblMemSetFunctions(), call this before shutting down your app's memory manager.
        /// It is the responsibility of the game to wait for any outstanding Async calls to complete before calling XblCleanup.
        /// </summary>
        //STDAPI XblCleanupAsync(XAsyncBlock* async) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblCleanupAsync(XAsyncBlockPtr asyncBlock);
    }
}
