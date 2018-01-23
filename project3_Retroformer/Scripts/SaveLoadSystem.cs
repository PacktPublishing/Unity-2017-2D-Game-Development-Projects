using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoadSystem {

	public static void Save(string slotKey, SavingData data) {
        //Save into PlayerPrefs for each data item within the SavingData structure
        PlayerPrefs.SetInt(slotKey + "_level", data.level);
        PlayerPrefs.SetFloat(slotKey + "_positionX", data.positionX);
        PlayerPrefs.SetFloat(slotKey + "_positionY", data.positionY);
        PlayerPrefs.SetInt(slotKey + "_score", data.score);
        PlayerPrefs.SetFloat(slotKey + "_time", data.timeElapsed);
        PlayerPrefs.SetString(slotKey + "_playerName", data.playerName);

        //Save into permanent memory
        PlayerPrefs.Save();
    }

    public static SavingData Load(string slotKey) {
        //Create a new SavingData structure
        SavingData data = new SavingData();

        //Load from memory each item to fill up the data structure
        data.level = PlayerPrefs.GetInt(slotKey + "_level");
        data.positionX = PlayerPrefs.GetFloat(slotKey + "_positionX");
        data.positionY = PlayerPrefs.GetFloat(slotKey + "_positionY");
        data.score = PlayerPrefs.GetInt(slotKey + "_score");
        data.timeElapsed = PlayerPrefs.GetFloat(slotKey + "_time");
        data.playerName = PlayerPrefs.GetString(slotKey + "_playerName");

        //return the data structure
        return data;
    }

    public static bool HasSlot(string slotKey) {
        //Check whether the slotkey exist
        return PlayerPrefs.HasKey(slotKey + "_level");
    }

    public static void DeleteSlot(string slotKey) {
        //Delete the whole slot, item by item
        PlayerPrefs.DeleteKey(slotKey + "_level");
        PlayerPrefs.DeleteKey(slotKey + "_positionX");
        PlayerPrefs.DeleteKey(slotKey + "_positionY");
        PlayerPrefs.DeleteKey(slotKey + "_score");
        PlayerPrefs.DeleteKey(slotKey + "_time");
        PlayerPrefs.DeleteKey(slotKey + "_playerName");
    }

    public static void DeleteAllSlots() {
        //Delete all the PlayerPrefs
        PlayerPrefs.DeleteAll();
    }
}

public struct SavingData {

    public int level;
    public float positionX, positionY;
    public int score;
    public float timeElapsed;
    public string playerName;

}
