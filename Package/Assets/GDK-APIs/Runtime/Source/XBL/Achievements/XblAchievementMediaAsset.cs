using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblAchievementMediaAsset
    {
        internal unsafe XblAchievementMediaAsset(Interop.XblAchievementMediaAsset mediaAsset)
        {
            this.Name = Converters.PtrToStringUTF8(mediaAsset.name);
            this.MediaAssetType = mediaAsset.mediaAssetType;
            this.Url = Converters.PtrToStringUTF8(mediaAsset.url);
        }

        public string Name { get; private set; }
        public XblAchievementMediaAssetType MediaAssetType { get; private set; }
        public string Url { get; private set; }
    }
}
