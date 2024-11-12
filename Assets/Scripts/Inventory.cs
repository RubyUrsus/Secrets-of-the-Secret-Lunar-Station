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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
