using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeUndo : MonoBehaviour
{
    [SerializeField] private float floatSpeed = 1f; // Leijunnan nopeus
    [SerializeField] private float floatHeight = 0.5f; // Leijunnan korkeus
    [SerializeField] private float rotationSpeed = 50f; // Pyörimisnopeus
    UndoMovement undoMovement;
    private Vector3 startPos;

    void Start()
    {
        // Tallenna lähtöasento
        startPos = transform.position;
        undoMovement = FindObjectOfType<UndoMovement>();
    }

    void Update()
    {
        // Leijunta ylös ja alas sinikäyrällä
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Pyörii itsensä ympäri
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Camera.main.transform.root.gameObject)
        {
            undoMovement.AddUndoCharge();
            Destroy(gameObject);
        }
    }
}
