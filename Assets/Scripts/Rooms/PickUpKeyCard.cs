using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKeyCard : MonoBehaviour, IInteractable
{
    [SerializeField]
    string setUIText;
    public string UIText => setUIText;
    Inventory inventory;

    public void Interact()
    {
        inventory.SetKeyBool();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
}
