using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUndoMovementActive : MonoBehaviour, IInteractable
{
    Inventory inventory;
    UndoMovement undoMovement;
    [SerializeField]
    string setUIText;
    public string UIText => setUIText;

    private void Start()
    {
       
        GameObject go = Camera.main.transform.root.gameObject;
        undoMovement = go.GetComponent<UndoMovement>();
        undoMovement.enabled = false;
        inventory = go.GetComponent<Inventory>();
        
    }

    private void Update()
    {
        if (undoMovement.enabled ==  false && Input.GetKeyDown(KeyCode.P))
        {
            Interact();
        }
    }

    public void Interact()
    {
        inventory.SetUndoBool();
        undoMovement.enabled = true;
        undoMovement.OnUndoPickUp();
        gameObject.SetActive(false);
    }
}
