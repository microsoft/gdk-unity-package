// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

#if UNITY_GAMECORE
using Unity.GameCore;
#endif
#if MICROSOFT_GAME_CORE
using XGamingRuntime;
#endif

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace Microsoft.Xbox
{
    public class ErrorEventArgs : System.EventArgs
    {
        public string ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public ErrorEventArgs(string errorCode, string errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }
    }
    public class GameSaveLoadedArgs : System.EventArgs
    {
        public byte[] Data { get; private set; }

        public GameSaveLoadedArgs(byte[] data)
        {
            this.Data = data;
        }
    }

#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
    public delegate void ShowPurchaseUICallback(Int32 hresult, XStoreProduct storeProduct);
    public delegate void GetAssociatedProductsCallback(Int32 hresult, List<XStoreProduct> associatedProducts);
#endif

    public class Gdk : MonoBehaviour
    {
        [Header("You can find the value of the scid in your MicrosoftGame.config")]
        public string scid;
        public Text gamertagLabel;
        public bool signInOnStart = true;

        private static Gdk _xboxHelpers;
        private static bool _initialized;
        private static Dictionary<int, string> _hresultToFriendlyErrorLookup;

#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
        private XStoreContext _storeContext = null;
        private XUserHandle _userHandle;
        private XblContextHandle _xblContextHandle;
        private XGameSaveWrapper _gameSaveHelper;

        private List<XStoreProduct> _associatedProducts;
        GetAssociatedProductsCallback _queryAssociatedProductsCallback;
        private bool _pendingGetAssociatedProductsRequest;

        private const XStoreProductKind _addOnProducts = XStoreProductKind.Durable;
#endif

        private const int _100PercentAchievementProgress = 100;
        private const string _GameSaveContainerName = "x_game_save_default_container";
        private const string _GameSaveBlobName = "x_game_save_default_blob";
        private const int _MaxAssociatedProductsToRetrieve = 25;

        /// <summary>
        /// Static function for getting a reference to an instance of the Helpers class.
        /// This class contains useful methods for integrating your game with Xbox.
        /// </summary>
        /// <returns>The singleton instance of the Helpers class.</returns>
        public static Gdk Helpers
        {
            get
            {
                if (_xboxHelpers == null)
                {
                    Gdk[] xboxHelperInstances = FindObjectsOfType<Gdk>();
                    if (xboxHelperInstances.Length > 0)
                    {
                        _xboxHelpers = xboxHelperInstances[0];
                        _xboxHelpers._Initialize();
                    }
                    else
                    {
                        _LogError("Error: Could not find Xbox prefab. Make sure you have added the Xbox prefab to your scene.");
                    }
                }

                return _xboxHelpers;
            }
        }

        public delegate void OnGameSaveLoadedHandler(object sender, GameSaveLoadedArgs e);
#pragma warning disable 0067 // Called when MICROSOFT_GAME_CORE is defined
        public event OnGameSaveLoadedHandler OnGameSaveLoaded;
#pragma warning restore 0067
                
        public delegate void OnErrorHandler(object sender, ErrorEventArgs e);
        public event OnErrorHandler OnError;

        // Start is called before the first frame update
        void Start()
        {
            _Initialize();
        }

        private void _Initialize()
        {
            if (_initialized)
            {
                return;
            }
            _initialized = true;

            DontDestroyOnLoad(gameObject);

            _hresultToFriendlyErrorLookup = new Dictionary<int, string>();
            InitializeHresultToFriendlyErrorLookup();

#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
            if (!Succeeded(SDK.XGameRuntimeInitialize(), "Initialize gaming runtime"))
            {
                return;
            }

            // Check for store updates
            int hresult = SDK.XStoreCreateContext(out _storeContext);
            if (Succeeded(hresult, "Create store context"))
            {
               SDK.XStoreQueryGameAndDlcPackageUpdatesAsync(_storeContext, HandleQueryForUpdatesComplete);
            }

            _gameSaveHelper = new XGameSaveWrapper();
            if (signInOnStart)
            {
               SignIn();
            }
#endif
        }

        private void InitializeHresultToFriendlyErrorLookup()
        {
            if (_hresultToFriendlyErrorLookup == null)
            {
                return;
            }

            _hresultToFriendlyErrorLookup.Add(-2143330041, "IAP_UNEXPECTED: Does the player you are signed in as have a license for the game? " +
                "You can get one by downloading your game from the store and purchasing it first. If you can't find your game in the store, " +
                "have you published it in Partner Center?");

            _hresultToFriendlyErrorLookup.Add(-1994108656, "E_GAMEUSER_NO_PACKAGE_IDENTITY: Are you trying to call GDK APIs from the Unity editor?" +
                " To call GDK APIs, you must use the GDK > Build and Run menu. You can debug your code by attaching the Unity debugger once your" +
                "game is launched.");

            _hresultToFriendlyErrorLookup.Add(-2015559675, "AM_E_XAST_UNEXPECTED: Have you added the Windows 10 PC platform on the Xbox Settings page " +
                "in Partner Center? Learn more: aka.ms/sandboxtroubleshootingguide");
        }

        public void SignIn()
        {
#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
            SignInImpl();
#endif
        }

        public void Save(byte[] data)
        {
#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
            _gameSaveHelper.Save(
                _GameSaveContainerName,
                _GameSaveBlobName,
                data,
                GameSaveSaveCompleted);
#endif
        }

        public void LoadSaveData()
        {
#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
            _gameSaveHelper.Load(
                _GameSaveContainerName,
                _GameSaveBlobName,
                GameSaveLoadCompleted);
#endif
        }

        public void UnlockAchievement(string achievementId)
        {
#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
            UnlockAchievementImpl(achievementId);
#endif
        }

#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
        private void SignInImpl()
        {
            XUserAddOptions options = XUserAddOptions.AddDefaultUserAllowingUI;
            SDK.XUserAddAsync(options, AddUserComplete);
        }

        private void AddUserComplete(int hresult, XUserHandle userHandle)
        {
            if (!Succeeded(hresult, "Sign in."))
            {
                return;
            }

            _userHandle = userHandle;
            CompletePostSignInInitialization();
        }

        private void CompletePostSignInInitialization()
        {
            string gamertag = string.Empty;
            if (gamertagLabel != null &&
                Succeeded(SDK.XUserGetGamertag(_userHandle, XUserGamertagComponent.UniqueModern, out gamertag), "Get gamertag."))
            {
                gamertagLabel.text = gamertag;
            }
            Succeeded(SDK.XBL.XblInitialize(
                scid
                ), "Initialize Xbox Live");
            Succeeded(SDK.XBL.XblContextCreateHandle(
                    _userHandle, 
                    out _xblContextHandle
                ), "Create Xbox Live context");
            InitializeGameSaves();
        }

        private void InitializeGameSaves()
        {
            _gameSaveHelper.InitializeAsync(_userHandle, scid, XGameSaveInitializeCompleted);
        }

        private void XGameSaveInitializeCompleted(int hresult)
        {
            if (!Succeeded(hresult, "Initialize game save provider"))
            {
                return;
            }
        }

        private void GameSaveSaveCompleted(int hresult)
        {
            Succeeded(hresult, "Game save submit update complete");
        }

        private void GameSaveLoadCompleted(int hresult, byte[] savedData)
        {
            if (!Succeeded(hresult, "Loaded Blob"))
            {
                return;
            }

            if (Helpers.OnGameSaveLoaded != null)
            {
                Helpers.OnGameSaveLoaded(Helpers, new GameSaveLoadedArgs(savedData));
            }
        }

        private void UnlockAchievementImpl(string achievementId)
        {
            ulong xuid;
            if (!Succeeded(SDK.XUserGetId(_userHandle, out xuid), "Get Xbox user ID"))
            {
                return;
            }
            SDK.XBL.XblAchievementsUpdateAchievementAsync(
                    _xblContextHandle,
                    xuid,
                    achievementId,
                    _100PercentAchievementProgress,
                    UnlockAchievementComplete
                );
        }

        private void UnlockAchievementComplete(int hresult)
        {
            Succeeded(hresult, "Unlock achievement");
        }

        private void ProcessAssociatedProductsResults(Int32 hresult, XStoreQueryResult result)
        {
            if (Succeeded(hresult, "GetAssociatedProductsAsync callback"))
            {
                _associatedProducts.AddRange(result.PageItems);
                if (result.HasMorePages)
                {
                    SDK.XStoreQueryAssociatedProductsAsync(
                        _storeContext,
                        _addOnProducts,
                        _MaxAssociatedProductsToRetrieve,
                        ProcessAssociatedProductsResults
                        );
                }
                else
                {
                    if (_queryAssociatedProductsCallback != null)
                    {
                        _queryAssociatedProductsCallback(hresult, _associatedProducts);
                    }
                }
            }
            else
            {
                if (_queryAssociatedProductsCallback != null)
                {
                    _queryAssociatedProductsCallback(hresult, _associatedProducts);
                }
            }
        }

        public void GetAssociatedProductsAsync(GetAssociatedProductsCallback callback)
        {
            if (callback == null)
            {
                _LogError("Callback cannot be null.");
            }

            _associatedProducts = new List<XStoreProduct>();
            _queryAssociatedProductsCallback = callback;
            int hresult = SDK.XStoreCreateContext(out _storeContext);
            SDK.XStoreQueryAssociatedProductsAsync(
                _storeContext,
                _addOnProducts,
                _MaxAssociatedProductsToRetrieve,
                ProcessAssociatedProductsResults
                );
        }

        public void ShowPurchaseUIAsync(XStoreProduct storeProduct, ShowPurchaseUICallback callback)
        {
            SDK.XStoreShowPurchaseUIAsync(
                    _storeContext,
                    storeProduct.StoreId,
                    null,
                    null,
                    (Int32 hresult) =>
            {
                callback(hresult, storeProduct);
            });
        }

        private void HandleQueryForUpdatesComplete(int hresult, XStorePackageUpdate[] packageUpdates)
        {
            List<string> _packageIdsToUpdate = new List<string>();
            if (hresult >= 0)
            {
                if (packageUpdates != null && 
                    packageUpdates.Length > 0)
                {
                    foreach (XStorePackageUpdate packageUpdate in packageUpdates)
                    {
                        _packageIdsToUpdate.Add(packageUpdate.PackageIdentifier);
                    }
                    // What do we do?
                    SDK.XStoreDownloadAndInstallPackageUpdatesAsync(
                        _storeContext,
                        _packageIdsToUpdate.ToArray(),
                        DownloadFinishedCallback);
                }
            }
            else
            {
                // No-op
            }
        }

        private void DownloadFinishedCallback(int hresult)
        {
            Succeeded(hresult, "DownloadAndInstallPackageUpdates callback");
        }
#endif

        // Update is called once per frame
        void Update()
        {
#if (MICROSOFT_GAME_CORE || UNITY_GAMECORE) && !UNITY_EDITOR
            SDK.XTaskQueueDispatch();
#endif
        }

        // Helper methods
        protected static bool Succeeded(int hresult, string operationFriendlyName)
        {
            bool succeeded = false;
            if (HR.SUCCEEDED(hresult))
            {
                succeeded = true;
            }
            else
            {
                string errorCode = hresult.ToString("X8");
                string errorMessage = string.Empty;
                if (_hresultToFriendlyErrorLookup.ContainsKey(hresult))
                {
                    errorMessage = _hresultToFriendlyErrorLookup[hresult];
                }
                else
                {
                    errorMessage = operationFriendlyName + " failed.";
                }
                string formattedErrorString = string.Format("{0} Error code: hr=0x{1}", errorMessage, errorCode);
                _LogError(formattedErrorString);
                if (Helpers.OnError != null)
                {
                    Helpers.OnError(Helpers, new ErrorEventArgs(errorCode, errorMessage));
                }
            }

            return succeeded;
        }

        private static void _LogError(string message)
        {
            Debug.Log(message);
        }
    }
}