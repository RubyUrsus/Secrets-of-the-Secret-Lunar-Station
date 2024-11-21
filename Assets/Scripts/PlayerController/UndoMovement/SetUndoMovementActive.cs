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

    [SerializeField]
    GameObject undoTutorialText;

    private void Start()
    {
       
        GameObject go = Camera.main.transform.root.gameObject;
        undoMovement = go.GetComponent<UndoMovement>();
        inventory = go.GetComponent<Inventory>();
        
    }


    public void Interact()
    {
        SoundManager.Instance.PlayEquipPickupSound();
        inventory.SetUndoBool();
        undoMovement.OnUndoPickUp();
        gameObject.SetActive(false);
        undoTutorialText.SetActive(true);

    }
}
