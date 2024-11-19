using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private class SaveData
    {
        public Vector3 playerPos;
    }

    Checkpoint checkpoint;

    private void Start()
    {
        checkpoint = GetComponent<Checkpoint>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) Save();
        if (Input.GetKeyDown(KeyCode.P)) Load();
    }

    public void Save()
    {
        Debug.Log("Saved");
        SaveData data = new SaveData();
        data.playerPos = checkpoint.ContinuePos;
        string jsonText = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", jsonText);
    }

    public void Load()
    {
        Debug.Log("Loaded");
        string savedData = File.ReadAllText(Application.persistentDataPath + "/saveData.json");
        SaveData data = new SaveData();
        JsonUtility.FromJsonOverwrite(savedData, data);
        checkpoint.MovePlayerToCheckpoint(data.playerPos);
    }
}
