using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushStackOnTrigger : MonoBehaviour
{
    UndoMovement undoMovement;

    // Start is called before the first frame update
    void Start()
    {
        undoMovement = FindAnyObjectByType<UndoMovement>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Camera.main.transform.root.gameObject)
        {
            undoMovement.PushCurrent();
        }
    }
}
