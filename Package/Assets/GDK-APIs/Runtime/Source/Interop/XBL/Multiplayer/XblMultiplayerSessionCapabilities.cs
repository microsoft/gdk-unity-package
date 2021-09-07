using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionCapabilities
    //{
    //    bool Connectivity;
    //    XBL_DEPRECATED bool Team;
    //    XBL_DEPRECATED bool Arbitration;
    //    bool SuppressPresenceActivityCheck;
    //    bool Gameplay;
    //    bool Large;
    //    bool ConnectionRequiredForActiveMembers;
    //    bool UserAuthorizationStyle;
    //    bool Crossplay;
    //    bool Searchable;
    //    bool HasOwners;
    //} XblMultiplayerSessionCapabilities;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerSessionCapabilities
    {
        internal readonly NativeBool Connectivity;
        internal readonly NativeBool Team;
        internal readonly NativeBool Arbitration;
        internal readonly NativeBool SuppressPresenceActivityCheck;
        internal readonly NativeBool Gameplay;
        internal readonly NativeBool Large;
        internal readonly NativeBool ConnectionRequiredForActiveMembers;
        internal readonly NativeBool UserAuthorizationStyle;
        internal readonly NativeBool Crossplay;
        internal readonly NativeBool Searchable;
        internal readonly NativeBool HasOwners;

        internal XblMultiplayerSessionCapabilities(XGamingRuntime.XblMultiplayerSessionCapabilities publicObject)
        {
            this.Connectivity = new NativeBool(publicObject.Connectivity);
            this.Team = new NativeBool(publicObject.Team);
            this.Arbitration = new NativeBool(publicObject.Arbitration);
            this.SuppressPresenceActivityCheck = new NativeBool(publicObject.SuppressPresenceActivityCheck);
            this.Gameplay = new NativeBool(publicObject.Gameplay);
            this.Large = new NativeBool(publicObject.Large);
            this.ConnectionRequiredForActiveMembers = new NativeBool(publicObject.ConnectionRequiredForActiveMembers);
            this.UserAuthorizationStyle = new NativeBool(publicObject.UserAuthorizationStyle);
            this.Crossplay = new NativeBool(publicObject.Crossplay);
            this.Searchable = new NativeBool(publicObject.Searchable);
            this.HasOwners = new NativeBool(publicObject.HasOwners);
        }
    }
}