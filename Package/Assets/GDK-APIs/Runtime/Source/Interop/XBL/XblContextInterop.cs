using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal static partial class XblInterop
    {
        /// <summary>
        /// Creates an XblContextHandle used to access Xbox Live services.
        /// </summary>
        /// <param name="user">
        /// The Xbox Live user associated with this context. 
        /// For XDK this should be an IInspectable* to a Windows::Xbox::System::User.  
        /// 
        /// With C++/CX, you can use this helper function to convert a Windows::Xbox::System::User^ to a IInspectable*
        ///
        /// <code>
        /// IInspectable* AsInspectable(Platform::Object^ object)
        /// {
        ///     return reinterpret_cast<IInspectable*>(object);
        /// }
        /// </code>
        /// </param>
        /// <param name="context">The returned Xbox Live context handle.</param>
        /// <returns>HRESULT return code for this API operation.</returns>
        //STDAPI XblContextCreateHandle(
        //    _In_ XblUserHandle user,
        //    _Out_ XblContextHandle* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblContextCreateHandle(
            XUserHandle user,
            out XblContextHandle context);

        /// <summary>
        /// Closes the XblContextHandle.
        /// When all outstanding handles have been closed, XblContextCloseHandle() will free the memory 
        /// associated with the handle.
        /// </summary>
        /// <param name="xboxLiveContextHandle">The Xbox Live context handle.</param>
        //STDAPI_(void) XblContextCloseHandle(
        //    _In_ XblContextHandle xboxLiveContextHandle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XblContextCloseHandle(XblContextHandle xboxLiveContextHandle);
    }
}
