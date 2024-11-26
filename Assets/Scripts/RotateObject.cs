using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f; // Pyörimisnopeus asteina sekunnissa

    void Update()
    {
        // Pyöritetään objektia y-akselin ympäri
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
