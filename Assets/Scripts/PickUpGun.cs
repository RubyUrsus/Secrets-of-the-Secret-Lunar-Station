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
    public string UIText => setUIText;

    public void Interact()
    {
        closeDoor1.Interact();
        openDoor1.Interact();
    }

}
