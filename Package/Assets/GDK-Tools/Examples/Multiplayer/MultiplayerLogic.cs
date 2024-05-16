using Microsoft.Xbox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_GAMECORE
using Unity.GameCore;
#endif
#if MICROSOFT_GAME_CORE
using XGamingRuntime;
#endif  

public class MultiplayerLogic : MonoBehaviour
{
    public Text output;

    // Use this for initialization
    void Start()
    {
    }

    public void SendMultiplayerGameInvite()
    {
#if MICROSOFT_GAME_CORE || UNITY_GAMECORE
        Gdk.Helpers.SendMultiplayerGameInvite();
#endif
    }
}
