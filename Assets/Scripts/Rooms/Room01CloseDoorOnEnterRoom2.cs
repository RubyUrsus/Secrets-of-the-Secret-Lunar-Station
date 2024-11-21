using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room01CloseDoorOnEnterRoom2 : MonoBehaviour
{
    [SerializeField] Door01Controller doorToClose;
    [SerializeField] bool resetUndo = false;
    [SerializeField] bool killAllPowerUps = false;
    UndoMovement undoMovement;

    private void Start()
    {
        undoMovement = FindAnyObjectByType<UndoMovement>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Camera.main.transform.root.gameObject)
        {
            if (doorToClose.Open)
            {
                doorToClose.Interact();
            }
            
            if (resetUndo)
            {
                undoMovement.ClearStack();
                undoMovement.ClearCharges();
                undoMovement.PushCurrent();
                undoMovement.PushCurrent();
            }

            if (killAllPowerUps)
            {
                GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUp");

                foreach (GameObject powerUp in powerUps)
                {
                    Destroy(powerUp);
                }
            }

        }
        gameObject.SetActive(false);
    }
}
