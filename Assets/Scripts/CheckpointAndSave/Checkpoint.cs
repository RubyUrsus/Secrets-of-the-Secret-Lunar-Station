using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private bool triggered;

    SaveManager saveManager;

    private void Awake()
    {
        triggered = false;
        saveManager = FindObjectOfType<SaveManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") Trigger(other);
    }

    private void Trigger(Collider collider)
    {
        saveManager.Save();
        triggered = true;
    }
}
