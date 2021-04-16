using System;

namespace XGamingRuntime
{
    public enum XUserPrivilege : UInt32
    {
        CrossPlay = 185, // The user can play with people outside of Xbox Live
        Clubs = 188, // Create/join/participate in Clubs
        Sessions = 189, // Create/join non interactive multiplayer sessions
        Broadcast = 190, // Broadcast live gameplay
        ManageProfilePrivacy = 196, // Change settings to show real name
        GameDvr = 198, // Upload GameDVR
        MultiplayerParties = 203, // Join parties
        CloudManageSession = 207, // Allocate cloud compute resources for their session
        CloudJoinSession = 208, // Join cloud compute sessions
        CloudSavedGames = 209, // Save games on the cloud
        SocialNetworkSharing = 220, // Share progress to social networks
        UserGeneratedContent = 247, // Access user generated content in game
        Communications = 252, // Use real time voice and text communication
        Multiplayer = 254, // Join multiplayer sessions
        AddFriends = 255, // Add friends / people to follow
    }
}
