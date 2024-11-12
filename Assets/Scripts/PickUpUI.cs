using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpUI : MonoBehaviour
{
    [SerializeField] GlobalString pickUpUIText;
    [SerializeField] GameObject player;
    TextMeshProUGUI pickUpText;
    InteractSystem interactSystem;

    private void Start()
    {
        interactSystem = player.GetComponent<InteractSystem>();
        pickUpText = GetComponent<TextMeshProUGUI>();
        
    }
    void Update()
    {
        if (interactSystem.HittingInteractable) pickUpText.text = pickUpUIText.value.ToString();
        else pickUpText.text = "";
    }
}
