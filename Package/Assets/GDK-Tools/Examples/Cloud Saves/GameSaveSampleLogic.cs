// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.Xbox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveSampleLogic : MonoBehaviour
{
    public Text output;

    [Serializable]
    private class PlayerSaveData
    {
        public string name;
        public int level;
    }

    private PlayerSaveData playerSaveData;

    private void Start()
    {
        playerSaveData = new PlayerSaveData();
        playerSaveData.name = "Jane Doe";
        playerSaveData.level = 2;
    }

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (MemoryStream memoryStream = new MemoryStream())
        {
            binaryFormatter.Serialize(memoryStream, playerSaveData);
            Gdk.Helpers.Save(memoryStream.ToArray());
            output.text = "\n Saved game data:" +
                "\n Name: " + playerSaveData.name +
                "\n Level: " + playerSaveData.level;
        }
    }

    public void Load()
    {
        Gdk.Helpers.OnGameSaveLoaded -= OnGameSaveLoaded;
        Gdk.Helpers.OnGameSaveLoaded += OnGameSaveLoaded;
        Gdk.Helpers.LoadSaveData();
    }

    private void OnGameSaveLoaded(object sender, GameSaveLoadedArgs saveData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (MemoryStream memoryStream = new MemoryStream(saveData.Data))
        {
            object playerSaveDataObj = binaryFormatter.Deserialize(memoryStream);
            playerSaveData = playerSaveDataObj as PlayerSaveData;
            output.text = "\n Loaded save game:" +
                "\n Name: " + playerSaveData.name +
                "\n Level: " + playerSaveData.level;
        }
    }
}
