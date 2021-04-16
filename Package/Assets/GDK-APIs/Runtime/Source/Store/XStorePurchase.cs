using System;
using System.Text;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    partial class SDK
    {
        public delegate void XStoreShowRedeemTokenUICompleted(Int32 hresult);
        public delegate void XStoreShowRateAndReviewUICompleted(Int32 hresult, bool wasUpdated);
        public delegate void XStoreShowPurchaseUICompleted(Int32 hresult);
        public delegate void XStoreQueryConsumableBalanceRemainingCompleted(Int32 hresult, UInt32 quantity);
        public delegate void XStoreReportConsumableFulfillmentCompleted(Int32 hresult, UInt32 quantity);
        public delegate void XStoreGetUserCollectionsIdCompleted(Int32 hresult, string token);
        public delegate void XStoreGetUserPurchaseIdCompleted(Int32 hresult, string token);

        public static void XStoreShowRedeemTokenUIAsync(XStoreContext context, string token, string[] allowedStoreIds, bool disallowCsvRedeption, XStoreShowRedeemTokenUICompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                Int32 hresult = XGRInterop.XStoreShowRedeemTokenUIResult(block);
                completionRoutine(hresult);
            });

            using (DisposableCollection collection = new DisposableCollection())
            {
                UTF8StringPtr[] allowedStoreIdsInterop = Array.ConvertAll(allowedStoreIds, x => new UTF8StringPtr(x, collection));
                Int32 hr = XGRInterop.XStoreShowRedeemTokenUIAsync(
                    context.handle, 
                    Converters.StringToNullTerminatedUTF8ByteArray(token),
                    allowedStoreIdsInterop, 
                    new SizeT(allowedStoreIdsInterop.Length), 
                    new NativeBool(disallowCsvRedeption), asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr);
                }
            }
        }

        public static void XStoreShowRateAndReviewUIAsync(XStoreContext context, XStoreShowRateAndReviewUICompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                Interop.XStoreRateAndReviewResult result;
                Int32 hresult = XGRInterop.XStoreShowRateAndReviewUIResult(block, out result);
                completionRoutine(hresult, result.wasUpdated.Value);
            });

            Int32 hr = XGRInterop.XStoreShowRateAndReviewUIAsync(context.handle, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, false);
            }
        }

        public static void XStoreShowPurchaseUIAsync(XStoreContext context, string storeId, string name, string extendedJsonData, XStoreShowPurchaseUICompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                Int32 hresult = XGRInterop.XStoreShowPurchaseUIResult(block);
                completionRoutine(hresult);
            });

            Int32 hr = XGRInterop.XStoreShowPurchaseUIAsync(
                context.handle,
                Converters.StringToNullTerminatedUTF8ByteArray(storeId),
                Converters.StringToNullTerminatedUTF8ByteArray(name),
                Converters.StringToNullTerminatedUTF8ByteArray(extendedJsonData),
                asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr);
            }
        }

        public static void XStoreQueryConsumableBalanceRemainingAsync(XStoreContext context, string storeProductId, XStoreQueryConsumableBalanceRemainingCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                Interop.XStoreConsumableResult result;
                Int32 hresult = XGRInterop.XStoreQueryConsumableBalanceRemainingResult(block, out result);
                completionRoutine(hresult, result.quantity);
            });

            Int32 hr = XGRInterop.XStoreQueryConsumableBalanceRemainingAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(storeProductId), asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, 0);
            }
        }

        public static void XStoreReportConsumableFulfillmentAsync(XStoreContext context, string storeProductId, UInt32 quantity, Guid trackingId, XStoreReportConsumableFulfillmentCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                Interop.XStoreConsumableResult result;
                Int32 hresult = XGRInterop.XStoreReportConsumableFulfillmentResult(block, out result);
                completionRoutine(hresult, result.quantity);
            });

            Int32 hr = XGRInterop.XStoreReportConsumableFulfillmentAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(storeProductId), quantity, trackingId, asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, 0);
            }
        }

        public static void XStoreGetUserCollectionsIdAsync(XStoreContext context, string serviceTicket, string publisherUserId, XStoreGetUserCollectionsIdCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                string token = null;
                SizeT size;
                Int32 hresult = XGRInterop.XStoreGetUserCollectionsIdResultSize(block, out size);
                if (hresult == 0)
                {
                    Byte[] temp = new Byte[size.ToUInt32()];
                    hresult = XGRInterop.XStoreGetUserCollectionsIdResult(block, size, temp);
                    token = Converters.ByteArrayToString(temp);
                }
                completionRoutine(hresult, token);
            });

            Int32 hr = XGRInterop.XStoreGetUserCollectionsIdAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceTicket), Converters.StringToNullTerminatedUTF8ByteArray(publisherUserId), asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, null);
            }
        }

        public static void XStoreGetUserPurchaseIdAsync(XStoreContext context, string serviceTicket, string publisherUserId, XStoreGetUserPurchaseIdCompleted completionRoutine)
        {
            XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
            {
                // extract result
                string token = null;
                SizeT size;
                Int32 hresult = XGRInterop.XStoreGetUserPurchaseIdResultSize(block, out size);
                if (hresult == 0)
                {
                    Byte[] temp = new Byte[size.ToUInt32()];
                    hresult = XGRInterop.XStoreGetUserPurchaseIdResult(block, size, temp);
                    token = Converters.ByteArrayToString(temp);
                }
                completionRoutine(hresult, token);
            });

            Int32 hr = XGRInterop.XStoreGetUserPurchaseIdAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceTicket), Converters.StringToNullTerminatedUTF8ByteArray(publisherUserId), asyncBlock);

            if (HR.FAILED(hr))
            {
                AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                completionRoutine(hr, null);
            }
        }
    }
}
