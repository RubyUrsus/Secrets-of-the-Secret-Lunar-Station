using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUndoMovementActive : MonoBehaviour
{
    UndoMovement undoMovement;
    [SerializeField]
    TextMeshProUGUI undoUI;

    private void Start()
    {
       
        GameObject go = Camera.main.transform.root.gameObject;
        undoMovement = go.GetComponent<UndoMovement>();
        //GameObject go2 = 
        undoMovement.enabled = false;
        undoUI.enabled = false;
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
        undoUI.enabled = true;
        gameObject.SetActive(false);
        undoMovement.ClearCharges();
        undoMovement.AddUndoCharge();
        undoMovement.ClearStack();
        undoMovement.PushZero();
    }
}
