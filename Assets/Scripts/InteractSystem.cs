using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] GlobalString UIText;

    [SerializeField] float maxInteractDistance = 5;

    private bool hittingInteractable;
    public bool HittingInteractable => hittingInteractable;


    void Update()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hitInfo, maxInteractDistance))
        {
            IInteractable interactable = hitInfo.collider.gameObject.GetComponent<IInteractable>();

            if ((interactable != null) && hitInfo.distance < 3)
            {
                hittingInteractable = true;

                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (interactable != null)
                    {
                        interactable.Interact();
                    }
                }
            }
            else hittingInteractable = false;
        }
        else hittingInteractable = false;
    }
}
