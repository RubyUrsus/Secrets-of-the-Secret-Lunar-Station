using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpUI : MonoBehaviour
{
    [SerializeField] GlobalString pickUpUIText;
    TextMeshProUGUI pickUpText;
    InteractSystem interactSystem;

    private void Start()
    {
        pickUpText = GetComponent<TextMeshProUGUI>();
        
    }
    void Update()
    {
        pickUpText.text = pickUpUIText.value.ToString();
        
    }
}
