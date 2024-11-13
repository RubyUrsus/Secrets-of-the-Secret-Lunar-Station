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

    private void Start()
    {
        HideUIText();
    }

    void Update()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hitInfo, maxInteractDistance))
        {
            IInteractable interactable = hitInfo.collider.gameObject.GetComponent<IInteractable>();

            if ((interactable != null) && hitInfo.distance < 3)
            {
                UIText.value = interactable.UIText;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (interactable != null)
                    {
                        interactable.Interact();
                    }
                }
            }
            else HideUIText();
        }
        else HideUIText();
    }

    private void HideUIText()
    {
        UIText.value = "";
    }
}
