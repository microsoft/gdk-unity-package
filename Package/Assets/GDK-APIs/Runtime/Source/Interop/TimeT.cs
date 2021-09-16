using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TimeT
    {
        public DateTime DateTime {
            get {
                try
                {
                    // -1 is considered an error value with time_t; we use DateTime.MaxValue.
                    if (this.SecondsSinceUnixEpoch == -1)
                    {
                        return DateTime.MaxValue;
                    }
                    else
                    {
                        return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(SecondsSinceUnixEpoch);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    return DateTime.MaxValue;
                }
            }
        }

        // Note that we're assuming 64-bit time_t.
        // See https://docs.microsoft.com/en-us/cpp/c-runtime-library/reference/time-time32-time64?view=vs-2019
        private readonly Int64 SecondsSinceUnixEpoch;

        public TimeT(DateTime time)
        {
            SecondsSinceUnixEpoch = (Int64)(time - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        public TimeT(long secondSinceUnixEpoch)
        {
            SecondsSinceUnixEpoch = secondSinceUnixEpoch;
        }
    }
}
