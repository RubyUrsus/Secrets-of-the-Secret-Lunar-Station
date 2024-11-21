using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private class SaveData
    {
        public Vector3 playerPos;
        public Quaternion playerRotation;
        public float playerHealth;
        public int undoCharges;
        public bool hasGun;
        public bool hasHelmet;
        public bool hasKey;
        public bool hasUndo;
    }

    CheckpointSystem checkpointSystem;
    [SerializeField] GlobalFloat playerHealth;
    Inventory inventory;
    UndoMovement undoMovement;

    private void Start()
    {
        checkpointSystem = GetComponent<CheckpointSystem>();
        inventory = GetComponent<Inventory>();
        undoMovement = GetComponent<UndoMovement>();

        if (playerHealth == null)
        {
            Debug.LogWarning("Drag and drop Scriptable object 'playerHealth' to SaveManager script on the player");
        }

        if (PlayerPrefs.GetInt("LoadGame") != 0) Load();
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
        data.playerPos = checkpointSystem.ContinuePos;
        data.playerRotation = transform.rotation;
        data.playerHealth = playerHealth.currentHealth;
        data.hasGun = inventory.HasGun;
        data.hasHelmet = inventory.HasHelmet;
        data.hasKey = inventory.HasKey;
        data.hasUndo = inventory.HasUndo;
        data.undoCharges = undoMovement.UndoCharges;
        string jsonText = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", jsonText);
    }

    public void Load()
    {
        Debug.Log("Loaded");
        string savedData = File.ReadAllText(Application.persistentDataPath + "/saveData.json");
        SaveData data = new SaveData();
        JsonUtility.FromJsonOverwrite(savedData, data);
        checkpointSystem.MovePlayerToCheckpoint(data.playerPos);
        transform.rotation = data.playerRotation;
        playerHealth.currentHealth = data.playerHealth;
        inventory.HasGun = data.hasGun;
        inventory.HasHelmet = data.hasHelmet;
        inventory.HasKey = data.hasKey;
        inventory.HasUndo = data.hasUndo;
        undoMovement.UndoCharges = data.undoCharges;
    }
}
