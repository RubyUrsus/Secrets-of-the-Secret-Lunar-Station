using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUndoMovementActive : MonoBehaviour, IInteractable
{
    UndoMovement undoMovement;
    [SerializeField]
    string setUIText;
    public string UIText => setUIText;

    private void Start()
    {
       
        GameObject go = Camera.main.transform.root.gameObject;
        undoMovement = go.GetComponent<UndoMovement>();
        undoMovement.enabled = false;
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
        undoMovement.enabled = true;
        undoMovement.OnUndoPickUp();
        gameObject.SetActive(false);
    }
}
