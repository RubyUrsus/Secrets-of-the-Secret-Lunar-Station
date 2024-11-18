using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<IOnInventoryChange> iOnInventoryChange = new List<IOnInventoryChange>();


    [SerializeField] private bool hasGun;
    public bool HasGun => hasGun;


    [SerializeField] private bool hasHelmet;
    public bool HasHelmet => hasHelmet;


    [SerializeField] private bool hasKey;
    public bool HasKey => hasKey;


    [SerializeField] private bool hasUndo;
    public bool HasUndo => hasUndo;

    private void Start()
    {
        NotifyObservers();
    }

    public void SetUndoBool()
    {
        hasUndo = !hasUndo;
        NotifyObservers();
    }

    public void SetGunBool()
    {
        hasGun = !hasGun;
        NotifyObservers();
    }

    public void SetKeyBool()
    {
        hasKey = !hasKey;
        NotifyObservers();
    }

    public void SethelmetBool()
    {
        hasHelmet = !hasHelmet;
        NotifyObservers();
    }

    public void AddInventoryListener(IOnInventoryChange listener)
    {
        if (iOnInventoryChange.Contains(listener) == false) iOnInventoryChange.Add(listener);
    }

    public void RemoveInventoryListener(IOnInventoryChange listener)
    {
        if (iOnInventoryChange.Contains(listener)) iOnInventoryChange.Remove(listener);
    }

    private void NotifyObservers()
    {
        foreach (var observer in iOnInventoryChange)
        {
            observer.OnInventoryChange(this);
        }
    }

    private void OnValidate()
    {
        NotifyObservers();
    }
}