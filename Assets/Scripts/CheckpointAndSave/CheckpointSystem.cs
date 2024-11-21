using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckpointSystem : MonoBehaviour
{
    Vector3 continuePos;
    public Vector3 ContinuePos => continuePos;
    CharacterController characterController;
    SaveManager saveManager;
    [SerializeField] GameObject checkpointText;
    [SerializeField] float timer;
    bool hitCheckpoint;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        saveManager = GetComponent<SaveManager>();
        checkpointText.SetActive(false);
    }

    private void Update()
    {
        if (hitCheckpoint)
        {
            timer += Time.deltaTime;
        }

        if (timer > 2)
        {
            checkpointText.SetActive(false);
            timer = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            Debug.Log("checkpoint");
            continuePos = transform.position;
            saveManager.Save();
            hitCheckpoint = true;
            checkpointText.SetActive(true);
        }

        if (other.tag == "Start")
        {
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
