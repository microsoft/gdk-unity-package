// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;

namespace Microsoft.Xbox
{
    internal class HR
    {
        internal static bool SUCCEEDED(Int32 hr)
        {
            return hr >= 0;
        }

        internal static bool FAILED(Int32 hr)
        {
            return hr < 0;
        }

        internal const Int32 E_GS_USER_CANCELED = unchecked((Int32)0x80830004);
    }
}
