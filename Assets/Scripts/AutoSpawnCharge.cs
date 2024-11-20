using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawnCharge : MonoBehaviour
{
    [SerializeField]
    GameObject chargeUndoPrefab;
    [SerializeField]
    Transform chargePos;
    UndoMovement undoMovement;

    private void Start()
    {
        undoMovement = FindObjectOfType<UndoMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (undoMovement.UndoCharges < 1 && GameObject.FindGameObjectWithTag("PowerUp") == null)
        {
            Instantiate(chargeUndoPrefab, chargePos);
        }
    }
}
