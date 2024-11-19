using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room01CloseDoorOnEnterRoom2 : MonoBehaviour
{
    [SerializeField] Door01Controller doorToClose;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Camera.main.transform.root.gameObject)
        {
            doorToClose.Interact();

        }
        gameObject.SetActive(false);
    }
}
