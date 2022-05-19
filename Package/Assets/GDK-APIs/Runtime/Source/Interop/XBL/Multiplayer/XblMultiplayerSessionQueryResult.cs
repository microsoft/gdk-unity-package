
namespace XGamingRuntime
{
    public class XblMultiplayerSessionQueryResult
    {
        public long StartTime;

        public XblMultiplayerSessionReference SessionReference;

        public XblMultiplayerSessionStatus Status;

        public XblMultiplayerSessionVisibility Visibility;

        public bool IsMyTurn;

        public ulong Xuid;

        public uint AcceptedMemberCount;

        public XblMultiplayerSessionRestriction JoinRestriction;

        internal XblMultiplayerSessionQueryResult(Interop.XblMultiplayerSessionQueryResult other)
        {
            StartTime = other.StartTime;
            SessionReference = new XblMultiplayerSessionReference(other.SessionReference);
            Status = (XblMultiplayerSessionStatus)other.Status;
            Visibility = other.Visibility;
            IsMyTurn = other.IsMyTurn;
            Xuid = other.Xuid;
            AcceptedMemberCount = other.AcceptedMemberCount;
            JoinRestriction = other.JoinRestriction;
        }
    }
}
