using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblUserProfile
    {
        internal XblUserProfile(Interop.XblUserProfile interopStruct)
        {
            this.XboxUserId = interopStruct.xboxUserId;
            this.AppDisplayName = Converters.ByteArrayToString(interopStruct.appDisplayName);
            this.AppDisplayPictureResizeUri = Converters.ByteArrayToString(interopStruct.appDisplayPictureResizeUri);
            this.GameDisplayName = Converters.ByteArrayToString(interopStruct.gameDisplayName);
            this.GameDisplayPictureResizeUri = Converters.ByteArrayToString(interopStruct.gameDisplayPictureResizeUri);
            this.Gamerscore = Converters.ByteArrayToString(interopStruct.gamerscore);
            this.Gamertag = Converters.ByteArrayToString(interopStruct.gamertag);
            this.ModernGamertag = Converters.ByteArrayToString(interopStruct.modernGamertag);
            this.ModernGamertagSuffix = Converters.ByteArrayToString(interopStruct.modernGamertagSuffix);
            this.UniqueModernGamertag = Converters.ByteArrayToString(interopStruct.uniqueModernGamertag);
        }

        public UInt64 XboxUserId { get; private set; }
        public string AppDisplayName { get; private set; }
        public string AppDisplayPictureResizeUri { get; private set; }
        public string GameDisplayName { get; private set; }
        public string GameDisplayPictureResizeUri { get; private set; }
        public string Gamerscore { get; private set; }
        public string Gamertag { get; private set; }
        public string ModernGamertag { get; private set; }
        public string ModernGamertagSuffix { get; private set; }
        public string UniqueModernGamertag { get; private set; }
    }
}
