using System;

namespace XGamingRuntime
{
    public enum XblSocialManagerEventType : UInt32
    {
        /// <summary>Users added to social graph</summary>
        UsersAddedToSocialGraph,

        /// <summary>Users removed from social graph</summary>
        UsersRemovedFromSocialGraph,

        /// <summary>Users presence record has changed</summary>
        PresenceChanged,

        /// <summary>Users profile information has changed</summary>
        ProfilesChanged,

        /// <summary>Relationship to users has changed</summary>
        SocialRelationshipsChanged,

        /// <summary>Social graph load complete from adding a local user</summary>
        LocalUserAdded,

        /// <summary>Xbox Social User Group load complete (will only trigger for views that take a list of users)</summary>
        SocialUserGroupLoaded,

        /// <summary>Social user group updated</summary>
        SocialUserGroupUpdated,

        /// <summary>Unknown</summary>
        UnknownEvent
    }
}
