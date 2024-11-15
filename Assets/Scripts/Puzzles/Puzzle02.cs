using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle02 : MonoBehaviour
{
    [SerializeField] Door01Controller doorController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            doorController.Interact();
            Destroy(gameObject);
        }
    }
}
