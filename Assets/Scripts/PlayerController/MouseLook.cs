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

    public void ApplyRecoil()
    {
        mouseY -= Random.Range(0.4f, 1.5f);
        float mouseX = Random.Range(-1, 1);
        transform.Rotate(0, mouseX, 0);
    }

    //void ApplyRecoil()
    //{
    //    // Randomize a slight upward rotation (recoil) in the camera or weapon
    //    float recoilX = Random.Range(recoilAmount * 0.8f, recoilAmount); // Random upward recoil
    //    float recoilY = Random.Range(-recoilAmount / 4, recoilAmount / 4); // Slight side-to-side recoil

    //    // Apply recoil to the local rotation of the camera or weapon
    //    recoilCamera.localEulerAngles += new Vector3(-recoilX, recoilY, 0f);
    //}
}
