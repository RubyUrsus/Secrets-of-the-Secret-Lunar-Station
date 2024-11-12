using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    //[SerializeField] GlobalString UIText;
    [SerializeField] TextMeshProUGUI UIText;

    [SerializeField] float maxInteractDistance = 5;

    private bool hittingInteractable;
    public bool HittingInteractable => hittingInteractable;

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
                ShowUIText();
                UIText.text = interactable.UIText;

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


    private void ShowUIText()
    {
        UIText.gameObject.SetActive(true);
    }

    private void HideUIText()
    {
        UIText.gameObject.SetActive(false);
    }
}
