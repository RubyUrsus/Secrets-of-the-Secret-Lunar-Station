using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f; // Py�rimisnopeus asteina sekunnissa

    void Update()
    {
        // Py�ritet��n objektia y-akselin ymp�ri
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
