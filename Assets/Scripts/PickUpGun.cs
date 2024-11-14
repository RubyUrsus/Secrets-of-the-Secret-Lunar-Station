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
    [SerializeField]
    GameObject pickUpGun;
    public string UIText => setUIText;

    private void Start()
    {
        pickUpGun.SetActive(false);
    }

    public void Interact()
    {
        closeDoor1.Interact();
        openDoor1.Interact();
        pickUpGun.SetActive(true);
        Destroy(gameObject);
    }

}
