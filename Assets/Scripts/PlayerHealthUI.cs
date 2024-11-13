using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    TextMeshProUGUI healthText;
    [SerializeField] GlobalInt playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = playerHealth.value.ToString();
    }
}
