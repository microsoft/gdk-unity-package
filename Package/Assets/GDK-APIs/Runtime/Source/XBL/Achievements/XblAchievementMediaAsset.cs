using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XGamingRuntime
{
    public class XblAchievementMediaAsset
    {
        internal XblAchievementMediaAsset(Interop.XblAchievementMediaAsset mediaAsset)
        {
            this.Name = mediaAsset.name.GetString();
            this.MediaAssetType = mediaAsset.mediaAssetType;
            this.Url = mediaAsset.url.GetString();
        }

        public string Name { get; private set; }
        public XblAchievementMediaAssetType MediaAssetType { get; private set; }
        public string Url { get; private set; }
    }
}
