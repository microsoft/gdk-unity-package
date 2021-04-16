using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XblProfileGetUserProfileCompleted(Int32 hresult, XblUserProfile result);
    public delegate void XblProfileGetUserProfilesCompleted(Int32 hresult, XblUserProfile[] result);
    public delegate void XblProfileGetUserProfilesForSocialGroupCompleted(Int32 hresult, XblUserProfile[] result);

    public partial class SDK
    {
        public partial class XBL
        {
            static public void XblProfileGetUserProfileAsync(
                XblContextHandle xblContextHandle,
                UInt64 xboxUserId,
                XblProfileGetUserProfileCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblUserProfile));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    Interop.XblUserProfile profileResult;
                    Int32 hr = XblInterop.XblProfileGetUserProfileResult(block, out profileResult);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblUserProfile));
                        return;
                    }

                    completionRoutine(hr, new XblUserProfile(profileResult));
                });

                Int32 hresult = XblInterop.XblProfileGetUserProfileAsync(
                    xblContextHandle.InteropHandle,
                    xboxUserId,
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, default(XblUserProfile));
                    return;
                }
            }

            static public void XblProfileGetUserProfilesAsync(
                XblContextHandle xblContextHandle,
                UInt64[] xboxUserIds,
                XblProfileGetUserProfilesCompleted completionRoutine
                )
            {
                if (xblContextHandle == null || xboxUserIds == null || xboxUserIds.Length == 0)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblUserProfile[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT profileCount;
                    Int32 hr = XblInterop.XblProfileGetUserProfilesResultCount(block, out profileCount);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblUserProfile[]));
                        return;
                    }

                    var interopProfiles = new Interop.XblUserProfile[profileCount.ToInt32()];

                    hr = XblInterop.XblProfileGetUserProfilesResult(block, profileCount, interopProfiles);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblUserProfile[]));
                        return;
                    }

                    completionRoutine(hr, Array.ConvertAll(interopProfiles, (x) =>new XblUserProfile(x)));
                });

                Int32 hresult = XblInterop.XblProfileGetUserProfilesAsync(
                    xblContextHandle.InteropHandle,
                    xboxUserIds,
                    new SizeT(xboxUserIds.Length),
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, default(XblUserProfile[]));
                    return;
                }
            }

            static public void XblProfileGetUserProfilesForSocialGroupAsync(
                XblContextHandle xblContextHandle,
                string socialGroup,
                XblProfileGetUserProfilesForSocialGroupCompleted completionRoutine
                )
            {
                if (xblContextHandle == null || socialGroup == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblUserProfile[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT profileCount;
                    Int32 hr = XblInterop.XblProfileGetUserProfilesForSocialGroupResultCount(block, out profileCount);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblUserProfile[]));
                        return;
                    }

                    var interopProfiles = new Interop.XblUserProfile[profileCount.ToInt32()];

                    hr = XblInterop.XblProfileGetUserProfilesForSocialGroupResult(block, profileCount, interopProfiles);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblUserProfile[]));
                        return;
                    }

                    completionRoutine(hr, Array.ConvertAll(interopProfiles, (x) =>new XblUserProfile(x)));
                });

                Int32 hresult = XblInterop.XblProfileGetUserProfilesForSocialGroupAsync(
                    xblContextHandle.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(socialGroup),
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, default(XblUserProfile[]));
                    return;
                }
            }
        }
    }
}
