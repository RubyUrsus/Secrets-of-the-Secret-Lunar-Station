using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKeyCard : MonoBehaviour, IInteractable
{
    [SerializeField]
    string setUIText;
    public string UIText => setUIText;
    Inventory inventory;
    [SerializeField] Door01Controller controlDoor;

    public void Interact()
    {
        inventory.SetKeyBool();
        controlDoor.Interact();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
}
