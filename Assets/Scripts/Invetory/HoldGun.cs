using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldGun : MonoBehaviour, IOnInventoryChange
{
    [SerializeField] GameObject gunPositioned;
    private Inventory inventory;
    bool hasGun;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        inventory.AddInventoryListener(this);
    }

    public void OnInventoryChange(Inventory inventory)
    {
        Debug.Log("Kutsu tuli");
        hasGun = inventory.HasGun;
        if (hasGun) gunPositioned.SetActive(true);
        else gunPositioned.SetActive(false);
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
