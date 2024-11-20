using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHelmet : MonoBehaviour, IInteractable
{
    [SerializeField]
    Door01Controller doorController;
    Inventory inventory;
    public string UIText => "Pick up helmet";

    private void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }

    public void Interact()
    {
        doorController.Interact();
        inventory.SethelmetBool();
        Destroy(gameObject);
    }

}
