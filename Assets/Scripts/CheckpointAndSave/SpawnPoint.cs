using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    public void Respawn()
    {
        playerTransform.position = transform.position;
    }
}
