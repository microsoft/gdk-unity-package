using System;

namespace XGamingRuntime
{
    public class XGameSaveBlob
    {
        public XGameSaveBlobInfo Info;
        public Byte[] Data;

        internal XGameSaveBlob(Interop.XGameSaveBlob interopBlob)
        {
            this.Info = new XGameSaveBlobInfo(interopBlob.info);
            this.Data = new Byte[interopBlob.info.Size];
            interopBlob.CopyData(this.Data);
        }
    }
}
