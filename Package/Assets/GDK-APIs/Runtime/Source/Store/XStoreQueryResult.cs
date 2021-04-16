using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreQueryResult
    {
        internal XStoreQueryResult(XStoreProductQueryHandle queryHandle, XStoreProduct[] pageItems, bool hasMorePages)
        {
            this.QueryHandle = queryHandle;
            this.PageItems = pageItems;
            this.HasMorePages = hasMorePages;
        }

        internal XStoreProductQueryHandle QueryHandle { get; private set; }

        public bool HasMorePages { get; private set; }

        public XStoreProduct[] PageItems { get; private set; }
    }
}
