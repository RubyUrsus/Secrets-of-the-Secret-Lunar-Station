using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour, IOnInventoryChange
{
    [SerializeField] GameObject keyUI;
    [SerializeField] GameObject helmetUI;
    [SerializeField] GameObject undoUI;
    private Inventory inventory;
    bool hasHelmet;
    bool hasUndo;
    bool hasKey;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        inventory.AddInventoryListener(this);
    }

    public void OnInventoryChange(Inventory inventory)
    {
        Debug.Log("Kutsu tuli");
        hasHelmet = inventory.HasHelmet;
        hasUndo = inventory.HasUndo;
        hasKey = inventory.HasKey;

        if (hasKey) keyUI.SetActive(true);
        else keyUI.SetActive(false);

        if (hasHelmet) helmetUI.SetActive(true);
        else helmetUI.SetActive(false);

        if(hasUndo) undoUI.SetActive(true);
        else undoUI.SetActive(false);
    }

    private void OnEnable()
    {
        inventory.AddInventoryListener(this);
    }

    private void OnDisable()
    {
        inventory.RemoveInventoryListener(this);
    }
}
