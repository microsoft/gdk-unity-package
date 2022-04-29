using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionCapabilities
    {
        public XblMultiplayerSessionCapabilities() { }

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

        public bool Connectivity { get; set; }
        /// <summary>
        /// Deprecated
        /// </summary>
        public bool Team { get; set; }
        /// <summary>
        /// Deprecated
        /// </summary>
        public bool Arbitration { get; set; }
        public bool SuppressPresenceActivityCheck { get; set; }
        public bool Gameplay { get; set; }
        public bool Large { get; set; }
        public bool ConnectionRequiredForActiveMembers { get; set; }
        public bool UserAuthorizationStyle { get; set; }
        public bool Crossplay { get; set; }
        public bool Searchable { get; set; }
        public bool HasOwners { get; set; }
    }
}