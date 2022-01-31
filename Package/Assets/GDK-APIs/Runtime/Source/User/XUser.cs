using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XUserAddCompleted(Int32 hresult, XUserHandle userHandle);
    public delegate void XUserGetGamerPictureCompleted(Int32 hresult, Byte[] buffer);
    public delegate void XUserResolvePrivilegeWithUiCompleted(Int32 hresult);
    public delegate void XUserGetTokenAndSignatureUtf16Result(Int32 hresult, XUserGetTokenAndSignatureUtf16Data tokenAndSignature);
    public delegate void XUserResolveIssueWithUiUtf16Result(Int32 hresult);
    public delegate void XUserChangeEventCallback(XUserLocalId userLocalId, XUserChangeEvent eventType);

    public partial class SDK
    {
        #region Callbacks
        [MonoPInvokeCallback]
        private static void UserChangeEventCallback(IntPtr context, XUserLocalId userLocalId, XUserChangeEvent eventType)
        {
            GCHandle cbHandle = GCHandle.FromIntPtr(context);
            var callbacks = cbHandle.Target as UnmanagedCallback<Interop.XUserChangeEventCallback, XUserChangeEventCallback>;
            if (callbacks.userCallback != null)
            {
                callbacks.userCallback.Invoke(userLocalId, eventType);
            }
        }
        #endregion

        public static Int32 XUserDuplicateHandle(XUserHandle handle, out XUserHandle duplicatedHandle)
        {
            if (handle == null)
            {
                duplicatedHandle = default(XUserHandle);
                return HR.E_INVALIDARG;
            }

            Interop.XUserHandle duplicatedInteropHandle;
            Int32 hr = XGRInterop.XUserDuplicateHandle(handle.InteropHandle, out duplicatedInteropHandle);
            return XUserHandle.WrapAndReturnHResult(hr, duplicatedInteropHandle, out duplicatedHandle);
        }

        public static void XUserCloseHandle(XUserHandle user)
        {
            if (user == null)
            {
                return;
            }

            XGRInterop.XUserCloseHandle(user.InteropHandle);
            user.ClearInteropHandle();
        }

        public static Int32 XUserCompare(XUserHandle user1, XUserHandle user2, out Int32 comparisonResult)
        {
            if (user1 == null || user2 == null)
            {
                comparisonResult = 0;
                return HR.E_INVALIDARG;
            }

            comparisonResult = XGRInterop.XUserCompare(user1.InteropHandle, user2.InteropHandle);
            return HR.S_OK;
        }

        public static Int32 XUserGetMaxUsers(out UInt32 maxUsers)
        {
            return XGRInterop.XUserGetMaxUsers(out maxUsers);
        }

        public static void XUserAddAsync(XUserAddOptions options, XUserAddCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Interop.XUserHandle interopUserHandle;
                Int32 hresult = XGRInterop.XUserAddResult(block, out interopUserHandle);

                XUserHandle handle;
                XUserHandle.WrapAndReturnHResult(hresult, interopUserHandle, out handle);
                completionRoutine(hresult, handle);
            });

            Int32 hr = XGRInterop.XUserAddAsync(options, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, default(XUserHandle));
            }
        }

        public static Int32 XUserGetId(XUserHandle user, out UInt64 userId)
        {
            if (user == null)
            {
                userId = default(UInt64);
                return HR.E_INVALIDARG;
            }

            return XGRInterop.XUserGetId(user.InteropHandle, out userId);
        }

        public static Int32 XUserFindUserById(UInt64 userId, out XUserHandle handle)
        {
            Interop.XUserHandle interopHandle;
            Int32 hr = XGRInterop.XUserFindUserById(userId, out interopHandle);
            if (hr == HR.S_OK && interopHandle.Ptr == IntPtr.Zero)
            {
                // MSFT:21489553: Underlying XUserFindUserById API has a bug where invalid ids return S_OK
                // but a null XUserHandle; don't wrap a null interopHandle in the public XUserHandle.
                handle = null;
                return hr;
            }
            return XUserHandle.WrapAndReturnHResult(hr, interopHandle, out handle);
        }

        public static Int32 XUserGetLocalId(XUserHandle user, out XUserLocalId userLocalId)
        {
            if (user == null)
            {
                userLocalId = default(XUserLocalId);
                return HR.E_INVALIDARG;
            }

            return XGRInterop.XUserGetLocalId(user.InteropHandle, out userLocalId);
        }

        public static Int32 XUserFindUserByLocalId(XUserLocalId userLocalId, out XUserHandle handle)
        {
            Interop.XUserHandle interopHandle;
            Int32 hr = XGRInterop.XUserFindUserByLocalId(userLocalId, out interopHandle);
            if (hr == HR.S_OK && interopHandle.Ptr == IntPtr.Zero)
            {
                // MSFT:21489553: Underlying XUserFindUserByLocalId API has a bug where invalid ids return S_OK
                // but a null XUserHandle; don't wrap a null interopHandle in the public XUserHandle.
                handle = null;
                return hr;
            }
            return XUserHandle.WrapAndReturnHResult(hr, interopHandle, out handle);
        }

        public static Int32 XUserGetIsGuest(XUserHandle user, out bool isGuest)
        {
            if (user == null)
            {
                isGuest = default(bool);
                return HR.E_INVALIDARG;
            }

            return XGRInterop.XUserGetIsGuest(user.InteropHandle, out isGuest);
        }
        
        public static Int32 XUserGetState(XUserHandle user, out XUserState state)
        {
            if (user == null)
            {
                state = default(XUserState);
                return HR.E_INVALIDARG;
            }

            return XGRInterop.XUserGetState(user.InteropHandle, out state);
        }

        public static Int32 XUserGetGamertag(XUserHandle user, XUserGamertagComponent gamertagComponent, out string gamertag)
        {
            if (user == null)
            {
                gamertag = default(string);
                return HR.E_INVALIDARG;
            }

            int size = 0;
            switch (gamertagComponent)
            {
                case XUserGamertagComponent.Classic:
                    size = XGRInterop.XUserGamertagComponentClassicMaxBytes;
                    break;
                case XUserGamertagComponent.Modern:
                    size = XGRInterop.XUserGamertagComponentModernMaxBytes;
                    break;
                case XUserGamertagComponent.ModernSuffix:
                    size = XGRInterop.XUserGamertagComponentModernSuffixMaxBytes;
                    break;
                case XUserGamertagComponent.UniqueModern:
                    size = XGRInterop.XUserGamertagComponentUniqueModernMaxBytes;
                    break;
            }

            Byte[] gamertagBuffer = new Byte[size];
            SizeT gamertagUsed;
            Int32 hr = XGRInterop.XUserGetGamertag(user.InteropHandle, gamertagComponent, new SizeT(gamertagBuffer.Length), gamertagBuffer, out gamertagUsed);

            if (HR.SUCCEEDED(hr))
            {
                // ByteArrayToString removes the null terminator
                gamertag = Converters.ByteArrayToString(gamertagBuffer, index: 0, count: gamertagUsed.ToInt32());
            }
            else
            {
                gamertag = null;
            }

            return hr;
        }

        public static void XUserGetGamerPictureAsync(XUserHandle user, XUserGamerPictureSize pictureSize, XUserGetGamerPictureCompleted completionRoutine)
        {
            if (user == null)
            {
                completionRoutine(HR.E_INVALIDARG, default(Byte[]));
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                SizeT bufferSize;
                Int32 hresult = XGRInterop.XUserGetGamerPictureResultSize(block, out bufferSize);
                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, default(Byte[]));
                    return;
                }

                Byte[] buffer = new Byte[bufferSize.ToUInt32()];
                SizeT bufferUsed;
                hresult = XGRInterop.XUserGetGamerPictureResult(block, new SizeT(buffer.Length), buffer, out bufferUsed);
                completionRoutine(hresult, buffer);
            });

            Int32 hr = XGRInterop.XUserGetGamerPictureAsync(user.InteropHandle, pictureSize, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, default(Byte[]));
            }
        }

        public static Int32 XUserGetAgeGroup(XUserHandle user, out XUserAgeGroup ageGroup)
        {
            if (user == null)
            {
                ageGroup = default(XUserAgeGroup);
                return HR.E_INVALIDARG;
            }

            return XGRInterop.XUserGetAgeGroup(user.InteropHandle, out ageGroup);
        }

        public static Int32 XUserCheckPrivilege(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, out bool hasPrivilege, out XUserPrivilegeDenyReason reason)
        {
            if (user == null)
            {
                hasPrivilege = default(bool);
                reason = default(XUserPrivilegeDenyReason);
                return HR.E_INVALIDARG;
            }

            return XGRInterop.XUserCheckPrivilege(user.InteropHandle, options, privilege, out hasPrivilege, out reason);
        }

        public static void XUserResolvePrivilegeWithUiAsync(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, XUserResolvePrivilegeWithUiCompleted completionRoutine)
        {
            if (user == null)
            {
                completionRoutine(HR.E_INVALIDARG);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Int32 hresult = XGRInterop.XUserResolvePrivilegeWithUiResult(block);
                completionRoutine(hresult);
            });

            Int32 hr = XGRInterop.XUserResolvePrivilegeWithUiAsync(user.InteropHandle, options, privilege, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr);
            }
        }

        public static void XUserGetTokenAndSignatureUtf16Async(
            XUserHandle user,
            XUserGetTokenAndSignatureOptions options,
            string method,
            string url,
            XUserGetTokenAndSignatureUtf16HttpHeader[] headers,
            Byte[] body,
            XUserGetTokenAndSignatureUtf16Result completionRoutine)
        {
            if (user == null)
            {
                completionRoutine(HR.E_INVALIDARG, default(XUserGetTokenAndSignatureUtf16Data));
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                SizeT bufferSize;
                Int32 hresult = XGRInterop.XUserGetTokenAndSignatureUtf16ResultSize(block, out bufferSize);
                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, default(XUserGetTokenAndSignatureUtf16Data));
                    return;
                }

                // The API fills a single buffer with multiple objects (XUserGetTokenAndSignatureUtf16Data and two strings), so marshal the buffer manually.
                IntPtr buffer = Marshal.AllocHGlobal(bufferSize.ToInt32());
                IntPtr ptrToBuffer;
                SizeT bufferUsed;
                hresult = XGRInterop.XUserGetTokenAndSignatureUtf16Result(block, bufferSize, buffer, out ptrToBuffer, out bufferUsed);

                XUserGetTokenAndSignatureUtf16Data tokenAndSignatureResult;
                if (HR.SUCCEEDED(hresult))
                {
                    Interop.XUserGetTokenAndSignatureUtf16Data interopResult = (Interop.XUserGetTokenAndSignatureUtf16Data)Marshal.PtrToStructure(ptrToBuffer, typeof(Interop.XUserGetTokenAndSignatureUtf16Data));
                    tokenAndSignatureResult = new XUserGetTokenAndSignatureUtf16Data(interopResult.Token, interopResult.Signature);
                }
                else
                {
                    tokenAndSignatureResult = default(XUserGetTokenAndSignatureUtf16Data);
                }
                Marshal.FreeHGlobal(buffer);
                completionRoutine(hresult, tokenAndSignatureResult);
            });

            // Convert the headers array into the interop headers array.
            Int32 headerCount = headers == null ? 0 : headers.Length;
            Interop.XUserGetTokenAndSignatureUtf16HttpHeader[] interopHeaders = null;
            if (headerCount > 0)
            {
                interopHeaders = new Interop.XUserGetTokenAndSignatureUtf16HttpHeader[headerCount];
                for (Int32 i = 0; i < headerCount; ++i)
                {
                    interopHeaders[i] = new Interop.XUserGetTokenAndSignatureUtf16HttpHeader()
                    {
                        Name = headers[i].Name,
                        Value = headers[i].Value
                    };
                }
            }
            SizeT bodyCount = new SizeT(body == null ? 0 : body.Length);
            Int32 hr = XGRInterop.XUserGetTokenAndSignatureUtf16Async(user.InteropHandle, options, method, url, new SizeT(headerCount), interopHeaders, bodyCount, body, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, default(XUserGetTokenAndSignatureUtf16Data));
            }
        }

        public static void XUserResolveIssueWithUiUtf16Async(XUserHandle user, string url, XUserResolveIssueWithUiUtf16Result completionRoutine)
        {
            if (user == null)
            {
                completionRoutine(HR.E_INVALIDARG);
                return;
            }

            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                Int32 hresult = XGRInterop.XUserResolveIssueWithUiUtf16Result(block);
                completionRoutine(hresult);
            });

            Int32 hr = XGRInterop.XUserResolveIssueWithUiUtf16Async(user.InteropHandle, url, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr);
            }
        }

        public static Int32 XUserRegisterForChangeEvent(XUserChangeEventCallback callback, out XRegistrationToken registrationToken)
        {
            var callbacks = new UnmanagedCallback<Interop.XUserChangeEventCallback, XUserChangeEventCallback>
            {
                directCallback = UserChangeEventCallback,
                userCallback = callback
            };
            GCHandle cbHandle = GCHandle.Alloc(callbacks);

            XTaskQueueRegistrationToken taskQueueRegistrationToken;
            Int32 hr = XGRInterop.XUserRegisterForChangeEvent(
                defaultQueue.handle,
                GCHandle.ToIntPtr(cbHandle),
                callbacks.directCallback,
                out taskQueueRegistrationToken);
            if (HR.SUCCEEDED(hr))
            {
                registrationToken = new XRegistrationToken(cbHandle, taskQueueRegistrationToken);
            }
            else
            {
                registrationToken = default(XRegistrationToken);
                cbHandle.Free();
            }
            return hr;
        }

        public static void XUserUnregisterForChangeEvent(XRegistrationToken registrationToken)
        {
            if (registrationToken == null)
            {
                return;
            }

            // Use wait=true to ensure that it's safe to free the context object.
            XGRInterop.XUserUnregisterForChangeEvent(registrationToken.Token, wait: true);
            registrationToken.CallbackHandle.Free();
        }

        public static Int32 XUserGetSignOutDeferral(out XUserSignOutDeferralHandle deferral)
        {
            Interop.XUserSignOutDeferralHandle interopDeferral;
            Int32 hr = XGRInterop.XUserGetSignOutDeferral(out interopDeferral);
            if (HR.SUCCEEDED(hr))
            {
                deferral = new XUserSignOutDeferralHandle(interopDeferral);
            }
            else
            {
                deferral = default(XUserSignOutDeferralHandle);
            }
            return hr;
        }

        public static Int32 XUserCloseSignOutDeferralHandle(XUserSignOutDeferralHandle deferral)
        {
            if (deferral == null)
            {
                return HR.E_INVALIDARG;
            }

            XGRInterop.XUserCloseSignOutDeferralHandle(deferral.InteropHandle);
            return HR.S_OK;
        }
    }
}
