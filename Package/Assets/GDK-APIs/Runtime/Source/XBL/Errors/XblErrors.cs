using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public static XblErrorCondition XblGetErrorCondition(Int32 hr)
            {
                return XblInterop.XblGetErrorCondition(hr);
            }

            public static XblHresult XblGetHRESULT(Int32 hr)
            {
                XblHresult hresult = XblHresult.HRESULT_NOT_RECOGNIZED;
                try
                {
                    hresult = (XblHresult)Enum.GetValues(typeof(XblHresult)).GetValue(hr);
                }
                catch (IndexOutOfRangeException)
                {
                    hresult = XblHresult.HRESULT_NOT_RECOGNIZED;
                }
                return hresult;
            }
        }
    }
}
