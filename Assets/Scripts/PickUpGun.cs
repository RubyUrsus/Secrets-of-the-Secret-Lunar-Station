using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour, IInteractable
{
    [SerializeField]
    Door01Controller closeDoor1;
    [SerializeField]
    Door01Controller openDoor1;
    [SerializeField]
    string setUIText;
    GameObject pickUpGun;
    Inventory inventory;
    public string UIText => setUIText;

    private void Awake()
    {
        pickUpGun = GameObject.FindGameObjectWithTag("Weapon");
        inventory = Camera.main.transform.root.GetComponent<Inventory>();
    }


    public void Interact()
    {
        SoundManager.Instance.PlayEquipPickupSound();
        closeDoor1.Interact();
        openDoor1.Interact();
        inventory.SetGunBool();
        Destroy(gameObject);
    }

}
