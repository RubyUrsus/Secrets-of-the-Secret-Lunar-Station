using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<IOnInventoryChange> iOnInventoryChange = new List<IOnInventoryChange>();


    [SerializeField] private bool hasGun;
    public bool HasGun { get { return hasGun; } set { hasGun = value; NotifyObservers(); } }


    [SerializeField] private bool hasHelmet;
    public bool HasHelmet { get { return hasHelmet; } set { hasHelmet = value; NotifyObservers(); } }


    [SerializeField] private bool hasKey;
    public bool HasKey { get { return hasKey; } set { hasKey = value; NotifyObservers(); } }


    [SerializeField] private bool hasUndo;
    public bool HasUndo { get { return hasUndo; } set { hasUndo = value; NotifyObservers(); } }

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
