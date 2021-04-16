using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionCapabilities
    {
        internal XblMultiplayerSessionCapabilities(Interop.XblMultiplayerSessionCapabilities interopStruct)
        {
            this.Connectivity = interopStruct.Connectivity.Value;
            this.Team = interopStruct.Team.Value;
            this.Arbitration = interopStruct.Arbitration.Value;
            this.SuppressPresenceActivityCheck = interopStruct.SuppressPresenceActivityCheck.Value;
            this.Gameplay = interopStruct.Gameplay.Value;
            this.Large = interopStruct.Large.Value;
            this.ConnectionRequiredForActiveMembers = interopStruct.ConnectionRequiredForActiveMembers.Value;
            this.UserAuthorizationStyle = interopStruct.UserAuthorizationStyle.Value;
            this.Crossplay = interopStruct.Crossplay.Value;
            this.Searchable = interopStruct.Searchable.Value;
            this.HasOwners = interopStruct.HasOwners.Value;
        }

        public bool Connectivity { get; private set; }
        public bool Team { get; private set; }
        public bool Arbitration { get; private set; }
        public bool SuppressPresenceActivityCheck { get; private set; }
        public bool Gameplay { get; private set; }
        public bool Large { get; private set; }
        public bool ConnectionRequiredForActiveMembers { get; private set; }
        public bool UserAuthorizationStyle { get; private set; }
        public bool Crossplay { get; private set; }
        public bool Searchable { get; private set; }
        public bool HasOwners { get; private set; }
    }
}