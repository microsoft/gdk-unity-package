// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.Xbox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockAchievementSampleLogic : MonoBehaviour
{
    public Text output;

    public void UnlockAchievement()
    {
        Gdk.Helpers.UnlockAchievement("1");
        output.text = "Unlocking achievement...";
    }
}
