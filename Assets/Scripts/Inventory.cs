using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] private bool hasGun;
    public bool HasGun => hasGun;


    [SerializeField] private bool hasHelmet;
    public bool HasHelmet => hasHelmet;


    [SerializeField] private bool hasKey;
    public bool HasKey => hasKey;


    [SerializeField] private bool hasUndo;
    public bool HasUndo => hasUndo;


    public void SetUndoBool()
    {
        hasUndo = !hasUndo;
    }

    public void SetGunBool()
    {
        hasGun = !hasGun;
    }

    public void SetKeyBool()
    {
        hasKey = !hasKey;
    }

    public void SethelmetBool()
    {
        hasHelmet = !hasHelmet;
    }
}
