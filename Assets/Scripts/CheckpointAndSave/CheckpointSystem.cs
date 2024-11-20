using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckpointSystem : MonoBehaviour
{
    Vector3 continuePos;
    public Vector3 ContinuePos => continuePos;
    CharacterController characterController;
    SaveManager saveManager;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        saveManager = GetComponent<SaveManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            Debug.Log("checkpoint");
            continuePos = transform.position;
            saveManager.Save();
        }
    }

    public void MovePlayerToCheckpoint(Vector3 position)
    {
        continuePos = position;
        characterController.enabled = false;
        transform.position = continuePos;
        characterController.enabled = true;
    }
}
