// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Xbox;

#if UNITY_GAMECORE
using Unity.GameCore;
#endif
#if MICROSOFT_GAME_CORE
using XGamingRuntime;
#endif  

public class StoreSampleLogic : MonoBehaviour {

    public GameObject inGamePurchasableItemPrefab;
    public Transform canvasTransform;

	// Use this for initialization
	void Start () {
    }

    public void ShowDLC()
    {
#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
        // Get the list of In game purchasable items.
        Gdk.Helpers.GetAssociatedProductsAsync(GetAssociatedProductsAsyncCallback);
#endif        
    }

#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
    public void GetAssociatedProductsAsyncCallback(Int32 hresult, List<XStoreProduct> associatedProducts)
    {
        for (int i = 0; i < associatedProducts.Count; i++)
        {
            XStoreProduct product = associatedProducts[i];
            GameObject newInGamePurchasableItemPrefab = Instantiate(inGamePurchasableItemPrefab);
            newInGamePurchasableItemPrefab.transform.parent = canvasTransform;
            newInGamePurchasableItemPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(((i % 3) * 150) - 150, (-150 * Mathf.Floor(i / 3) + 100));
            SampleInGamePurchasableItem sampleInGamePurchasableItemScript = newInGamePurchasableItemPrefab.GetComponent<SampleInGamePurchasableItem>();
            sampleInGamePurchasableItemScript.UpdateUI(product);
        }
    }
#endif
}
