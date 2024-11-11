using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    [SerializeField]
    Transform camTransform;

    [SerializeField]
    float maxInteractDistance = 5;

    [SerializeField]
    TextMeshProUGUI UIText;

    [SerializeField]
    public int woodCollected = 0;

    [SerializeField]
    TextMeshProUGUI collectedWood;

    [SerializeField]
    LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        // voi myös näin hakea kameran transformin ilman drag and droppia
        //camTransform = Camera.main.transform;
        UIText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hitInfo, maxInteractDistance, layerMask))
        {
            Debug.DrawRay(camTransform.position, camTransform.forward, Color.green);

            IInteractable interactable = hitInfo.collider.gameObject.GetComponent<IInteractable>();
            ICollectable collectable = hitInfo.collider.gameObject.GetComponent<ICollectable>();

            if ((interactable != null || collectable != null) && hitInfo.distance < 3)
            {
                UIText.gameObject.SetActive(true);
                if (interactable != null) UIText.text = interactable.UIText;
                if (collectable != null) UIText.text = collectable.UItext;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (interactable != null)
                    {
                        interactable.Interact(hitInfo.point - transform.position);
                        collectedWood.text = woodCollected.ToString();
                    }
                    if (collectable != null)
                    {
                        collectable.Interact(gameObject);
                        if (hitInfo.collider.gameObject.tag != "ShotgunShells") collectedWood.text = woodCollected.ToString();
                    }
                }
            }
            else UIText.gameObject.SetActive(false);
        }
        else UIText.gameObject.SetActive(false);
    }
}
