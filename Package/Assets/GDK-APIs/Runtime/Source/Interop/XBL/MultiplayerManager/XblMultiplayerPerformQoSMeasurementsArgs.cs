using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerPerformQoSMeasurementsArgs
    //{
    //    const XblMultiplayerConnectionAddressDeviceTokenPair* remoteClients;
    //    size_t remoteClientsSize;
    //} XblMultiplayerPerformQoSMeasurementsArgs;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerPerformQoSMeasurementsArgs
    {
        private readonly unsafe XblMultiplayerConnectionAddressDeviceTokenPair* remoteClients;
        internal readonly SizeT remoteClientsSize;

        internal T[] GetRemoteClients<T>(Func<XblMultiplayerConnectionAddressDeviceTokenPair,T> ctor) { unsafe { return Converters.PtrToClassArray<T, XblMultiplayerConnectionAddressDeviceTokenPair>((IntPtr)this.remoteClients, this.remoteClientsSize, ctor); } }

        internal XblMultiplayerPerformQoSMeasurementsArgs(XGamingRuntime.XblMultiplayerPerformQoSMeasurementsArgs publicObject, DisposableCollection disposableCollection)
        {
            unsafe
            {
                this.remoteClients = (XblMultiplayerConnectionAddressDeviceTokenPair*) Converters.ClassArrayToPtr(publicObject.RemoteClients, (x, dc) =>new XblMultiplayerConnectionAddressDeviceTokenPair(x, dc), disposableCollection, out this.remoteClientsSize);
            }
        }
    }
}