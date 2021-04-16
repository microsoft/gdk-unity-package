using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionChangeEventArgs
    {
        internal XblMultiplayerSessionChangeEventArgs(Interop.XblMultiplayerSessionChangeEventArgs interopStruct)
        {
            this.SessionReference = new XblMultiplayerSessionReference(interopStruct.SessionReference);
            this.Branch = interopStruct.GetBranch();
            this.ChangeNumber = interopStruct.ChangeNumber;
        }

        public XblMultiplayerSessionReference SessionReference { get; private set; }
        public string Branch { get; private set; }
        public ulong ChangeNumber { get; private set; }
    }
}
