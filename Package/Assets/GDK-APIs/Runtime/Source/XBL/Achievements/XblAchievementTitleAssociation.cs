using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblAchievementTitleAssociation
    {
        internal unsafe XblAchievementTitleAssociation(Interop.XblAchievementTitleAssociation interopTitleAssociation)
        {
            this.Name = Converters.PtrToStringUTF8(interopTitleAssociation.name);
            this.TitleId = interopTitleAssociation.titleId;
        }

        public string Name { get; private set; }
        public UInt32 TitleId { get; private set; }
    }
}
