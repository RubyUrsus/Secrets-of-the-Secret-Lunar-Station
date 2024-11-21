using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveTutorial : MonoBehaviour
{
    [SerializeField]
    GameObject undoTutorial;


    // Update is called once per frame
    void Update()
    {
        if (undoTutorial.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            undoTutorial.SetActive(false);
        }
    }
}
