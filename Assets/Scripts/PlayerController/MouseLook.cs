using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    Transform camTransform;
    [SerializeField]
    float mouseSens = 1f;
    float mouseY;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens;
        transform.Rotate(0, mouseX, 0);

        mouseY -= Input.GetAxis("Mouse Y") * mouseSens;
        mouseY = Mathf.Clamp(mouseY, -90, 90);
        camTransform.localRotation = Quaternion.Euler(mouseY, 0, 0);
    }
}
