using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room01DoorCloseTrigger : MonoBehaviour
{
    [SerializeField]
    Door01Controller closeDoor1;
    [SerializeField]
    Door01Controller closeDoor2;
    [SerializeField]
    Door01Controller openDoor1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Camera.main.transform.root.gameObject)
        {
            closeDoor1.Interact();
            closeDoor2.Interact();
            openDoor1.Interact();
        }
        gameObject.SetActive(false);
    }
}
