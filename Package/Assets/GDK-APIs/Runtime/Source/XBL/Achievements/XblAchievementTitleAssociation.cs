using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime
{
    public class XblAchievementTitleAssociation
    {
        internal XblAchievementTitleAssociation(Interop.XblAchievementTitleAssociation interopTitleAssociation)
        {
            this.Name = interopTitleAssociation.name.GetString();
            this.TitleId = interopTitleAssociation.titleId;
        }

        public string Name { get; private set; }
        public UInt32 TitleId { get; private set; }
    }
}
