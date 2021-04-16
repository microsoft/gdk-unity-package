using System;

namespace XGamingRuntime
{
    public class XblSocialManagerEvent
    {
        internal XblSocialManagerEvent(Interop.XblSocialManagerEvent interopEvent)
        {
            this.User = new XUserHandle(interopEvent.user);
            this.EventType = interopEvent.eventType;
            this.Hr = interopEvent.hr;
            this.LoadedGroup = new XblSocialManagerUserGroupHandle(interopEvent.loadedGroup);


            this.UsersAffected = Array.ConvertAll(
                interopEvent.GetUserArray(),
                u =>new XblSocialManagerUser(u));
        }

        public XUserHandle User { get; private set; }
        public XblSocialManagerEventType EventType { get; private set; }
        public Int32 Hr { get; private set; }
        public XblSocialManagerUserGroupHandle LoadedGroup { get; private set; }
        public XblSocialManagerUser[] UsersAffected { get; private set; }
    }
}
