using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    /// <summary>
    /// Handle to a local multiplayer session.  
    /// This handle will be used to query and change the local session object.  
    /// Anytime the changes made to the local session object will not be reflected in the multiplayer service
    /// until a subsequent call to <see cref="XblMultiplayerWriteSessionAsync"/>.
    /// </summary>
    /// typedef struct XblMultiplayerSession* XblMultiplayerSessionHandle;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerSessionHandle
    {
        public IntPtr handle;
    }
}
