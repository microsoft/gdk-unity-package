using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblTitleManagedStatistic
    //{
    //    _Field_z_ const char* statisticName;
    //    XblTitleManagedStatType statisticType;
    //    double numberValue;
    //    _Field_z_ const char* stringValue;
    //} XblTitleManagedStatistic;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblTitleManagedStatistic
    {
        internal readonly UTF8StringPtr statisticName;
        internal readonly XblTitleManagedStatType statisticType;
        internal readonly double numberValue;
        internal readonly UTF8StringPtr stringValue;

        internal XblTitleManagedStatistic(XGamingRuntime.XblTitleManagedStatistic publicObject, DisposableCollection disposableCollection)
        {
            this.statisticName = new UTF8StringPtr(publicObject.StatisticName, disposableCollection);
            this.statisticType = publicObject.StatisticType;
            this.numberValue = publicObject.NumberValue;
            this.stringValue = new UTF8StringPtr(publicObject.StringValue, disposableCollection);
        }
    }
}