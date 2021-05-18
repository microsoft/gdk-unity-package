// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Xbox;

#if UNITY_GAMECORE
using Unity.GameCore;
#endif
#if MICROSOFT_GAME_CORE
using XGamingRuntime;
#endif

public class SampleInGamePurchasableItem : MonoBehaviour {

	public Text titleUIElement;
	public Text priceUIElement;
    public Text ownedUIElement;

#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
    private XStoreProduct storeProduct;

    public void UpdateUI(XStoreProduct product)
    {
        storeProduct = product;
        titleUIElement.text = storeProduct.Title;
        priceUIElement.text = storeProduct.Price.FormattedPrice;
        ownedUIElement.text = storeProduct.IsInUserCollection ? "Owned" : "Not owned";
    }
#endif

    public void Purchase()
    {
#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
        Gdk.Helpers.ShowPurchaseUIAsync(storeProduct, ShowPurchaseCallback);
#endif
    }

#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
    public void ShowPurchaseCallback(int hresult, XStoreProduct product)
    {
        if (hresult >= 0)
        {
            Debug.Log("Purchased " + product.Title);
        } 
        else
        {
            Debug.Log("Purchased failed. Error: " + hresult);
        }
    }
#endif
}
